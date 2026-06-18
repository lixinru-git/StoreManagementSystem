using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public interface IProductService
{
    Task<List<Product>> GetAllAsync(string? search = null);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<List<Product>> GetLowStockAsync();
}
