using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public interface ISaleService
{
    Task<List<SaleOrder>> GetOrdersAsync(DateTime? from = null, DateTime? to = null);
    Task<SaleOrder?> GetOrderByIdAsync(int id);
    /// <summary>创建销售订单(包含库存扣减)</summary>
    Task<SaleOrder> CreateOrderAsync(List<(int productId, int qty)> items, int? customerId, string paymentMethod);
    /// <summary>获取今日销售额</summary>
    Task<decimal> GetTodaySalesAsync();
    Task<decimal> GetSalesAsync(DateTime from, DateTime to);
    Task<List<(string Name, decimal Total, int Qty)>> GetTopProductsAsync(DateTime from, DateTime to, int top = 10);
    Task<List<(DateTime Date, decimal Total)>> GetDailySalesAsync(DateTime from, DateTime to);
}
