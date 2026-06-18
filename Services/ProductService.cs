using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _db;
    public ProductService(AppDbContext db) { _db = db; }

    public Task<List<Product>> GetAllAsync(string? search = null)
    {
        var q = _db.Products.Include(p => p.Category).AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            q = q.Where(p => p.Name.Contains(search) || (p.Barcode != null && p.Barcode.Contains(search)));
        return q.OrderBy(p => p.Name).ToListAsync();
    }

    public Task<Product?> GetByIdAsync(int id) =>
        _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product> AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var p = await _db.Products.FindAsync(id);
        if (p != null) { _db.Products.Remove(p); await _db.SaveChangesAsync(); }
    }

    public Task<List<Product>> GetLowStockAsync() =>
        _db.Products.Where(p => p.IsActive && p.StockQuantity <= p.LowStockThreshold).ToListAsync();
}
