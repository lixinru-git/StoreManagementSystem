using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _db;
    public InventoryService(AppDbContext db) { _db = db; }

    public Task<List<StockIn>> GetStockInsAsync(int? productId = null)
    {
        var q = _db.StockIns.Include(s => s.Product).AsQueryable();
        if (productId.HasValue) q = q.Where(s => s.ProductId == productId);
        return q.OrderByDescending(s => s.CreatedAt).ToListAsync();
    }

    public Task<List<StockOut>> GetStockOutsAsync(int? productId = null)
    {
        var q = _db.StockOuts.Include(s => s.Product).AsQueryable();
        if (productId.HasValue) q = q.Where(s => s.ProductId == productId);
        return q.OrderByDescending(s => s.CreatedAt).ToListAsync();
    }

    public async Task<StockIn> AddStockInAsync(int productId, int qty, decimal unitCost, string? supplier, string? remark)
    {
        using var tx = await _db.Database.BeginTransactionAsync();
        try
        {
            var product = await _db.Products.FindAsync(productId)
                ?? throw new InvalidOperationException("商品不存在");
            product.StockQuantity += qty;

            var stockIn = new StockIn
            {
                ProductId = productId, Quantity = qty,
                UnitCost = unitCost, Supplier = supplier, Remark = remark,
                CreatedAt = DateTime.Now
            };
            _db.StockIns.Add(stockIn);
            await _db.SaveChangesAsync();
            await tx.CommitAsync();
            return stockIn;
        }
        catch { await tx.RollbackAsync(); throw; }
    }

    public async Task<StockOut> AddStockOutAsync(int productId, int qty, string reason, string? remark)
    {
        using var tx = await _db.Database.BeginTransactionAsync();
        try
        {
            var product = await _db.Products.FindAsync(productId)
                ?? throw new InvalidOperationException("商品不存在");
            if (product.StockQuantity < qty)
                throw new InvalidOperationException($"商品 [{product.Name}] 库存不足 (剩余: {product.StockQuantity})");
            product.StockQuantity -= qty;

            var stockOut = new StockOut
            {
                ProductId = productId, Quantity = qty,
                Reason = reason, Remark = remark,
                CreatedAt = DateTime.Now
            };
            _db.StockOuts.Add(stockOut);
            await _db.SaveChangesAsync();
            await tx.CommitAsync();
            return stockOut;
        }
        catch { await tx.RollbackAsync(); throw; }
    }
}
