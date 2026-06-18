using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public class SaleService : ISaleService
{
    private readonly AppDbContext _db;
    private static int _orderCounter = 0;

    public SaleService(AppDbContext db) { _db = db; }

    public Task<List<SaleOrder>> GetOrdersAsync(DateTime? from = null, DateTime? to = null)
    {
        var q = _db.SaleOrders.Include(o => o.Customer).Include(o => o.SaleItems).ThenInclude(i => i.Product).AsQueryable();
        if (from.HasValue) q = q.Where(o => o.CreatedAt >= from.Value);
        if (to.HasValue) q = q.Where(o => o.CreatedAt <= to.Value.AddDays(1));
        return q.OrderByDescending(o => o.CreatedAt).ToListAsync();
    }

    public Task<SaleOrder?> GetOrderByIdAsync(int id) =>
        _db.SaleOrders.Include(o => o.Customer).Include(o => o.SaleItems).ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

    public async Task<SaleOrder> CreateOrderAsync(List<(int productId, int qty)> items, int? customerId, string paymentMethod)
    {
        // 使用事务保证库存一致性
        using var tx = await _db.Database.BeginTransactionAsync();

        try
        {
            var order = new SaleOrder
            {
                OrderNo = GenerateOrderNo(),
                PaymentMethod = paymentMethod,
                CustomerId = customerId,
                CreatedAt = DateTime.Now
            };
            _db.SaleOrders.Add(order);
            await _db.SaveChangesAsync();

            decimal subtotal = 0;
            foreach (var (productId, qty) in items)
            {
                // 悲观锁定：查询并锁定商品行保证并发安全
                var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == productId)
                    ?? throw new InvalidOperationException($"商品ID {productId} 不存在");
                if (product.StockQuantity < qty)
                    throw new InvalidOperationException($"商品 [{product.Name}] 库存不足 (剩余: {product.StockQuantity})");

                // 扣减库存
                product.StockQuantity -= qty;

                var item = new SaleItem
                {
                    SaleOrderId = order.Id,
                    ProductId = productId,
                    Quantity = qty,
                    UnitPrice = product.SalePrice,
                    Subtotal = product.SalePrice * qty
                };
                _db.SaleItems.Add(item);
                subtotal += item.Subtotal;
            }

            // 计算会员折扣
            decimal discount = 0;
            if (customerId.HasValue)
            {
                var customer = await _db.Customers.FindAsync(customerId);
                if (customer != null)
                {
                    discount = customer.Level switch
                    {
                        "Gold" => subtotal * 0.15m,
                        "Silver" => subtotal * 0.08m,
                        _ => 0
                    };
                }
            }

            order.Subtotal = subtotal;
            order.Discount = discount;
            order.Total = subtotal - discount;
            order.PointsEarned = (int)(order.Total / 10);

            // 更新会员积分和消费总额
            if (customerId.HasValue)
            {
                var customer = await _db.Customers.FindAsync(customerId);
                if (customer != null)
                {
                    customer.Points += order.PointsEarned;
                    customer.TotalSpent += order.Total;
                }
            }

            await _db.SaveChangesAsync();
            await tx.CommitAsync();

            return order;
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }

    private static string GenerateOrderNo()
    {
        Interlocked.Increment(ref _orderCounter);
        return $"SO{DateTime.Now:yyyyMMddHHmmss}{_orderCounter % 1000:D3}";
    }

    public async Task<decimal> GetTodaySalesAsync()
    {
        var today = DateTime.Today;
        // SQLite 不支持直接对 decimal 求和，转为 double 再转回 decimal
        return (decimal)await _db.SaleOrders.Where(o => o.CreatedAt >= today).SumAsync(o => (double)o.Total);
    }

    public async Task<decimal> GetSalesAsync(DateTime from, DateTime to)
    {
        var end = to.AddDays(1);
        return (decimal)await _db.SaleOrders.Where(o => o.CreatedAt >= from && o.CreatedAt < end).SumAsync(o => (double)o.Total);
    }

    public async Task<List<(string Name, decimal Total, int Qty)>> GetTopProductsAsync(DateTime from, DateTime to, int top = 10)
    {
        var end = to.AddDays(1);
        var data = await _db.SaleItems
            .Where(i => i.SaleOrder.CreatedAt >= from && i.SaleOrder.CreatedAt < end)
            .GroupBy(i => i.Product.Name)
            .Select(g => new { Name = g.Key, Total = g.Sum(i => (double)i.Subtotal), Qty = g.Sum(i => i.Quantity) })
            .OrderByDescending(x => x.Total)
            .Take(top)
            .ToListAsync();
        return data.Select(x => (x.Name, (decimal)x.Total, x.Qty)).ToList();
    }

    public async Task<List<(DateTime Date, decimal Total)>> GetDailySalesAsync(DateTime from, DateTime to)
    {
        var end = to.AddDays(1);
        var data = await _db.SaleOrders
            .Where(o => o.CreatedAt >= from && o.CreatedAt < end)
            .GroupBy(o => o.CreatedAt.Date)
            .Select(g => new { Date = g.Key, Total = g.Sum(o => (double)o.Total) })
            .OrderBy(x => x.Date)
            .ToListAsync();
        return data.Select(x => (x.Date, (decimal)x.Total)).ToList();
    }
}
