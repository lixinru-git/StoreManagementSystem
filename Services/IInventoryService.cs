using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public interface IInventoryService
{
    Task<List<StockIn>> GetStockInsAsync(int? productId = null);
    Task<List<StockOut>> GetStockOutsAsync(int? productId = null);
    Task<StockIn> AddStockInAsync(int productId, int qty, decimal unitCost, string? supplier, string? remark);
    Task<StockOut> AddStockOutAsync(int productId, int qty, string reason, string? remark);
}
