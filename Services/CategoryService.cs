using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _db;
    public CategoryService(AppDbContext db) { _db = db; }

    public Task<List<Category>> GetAllAsync() => _db.Categories.OrderBy(c => c.Name).ToListAsync();

    public Task<Category?> GetByIdAsync(int id) => _db.Categories.FindAsync(id).AsTask();

    public async Task<Category> AddAsync(Category category)
    {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return category;
    }

    public async Task UpdateAsync(Category category)
    {
        _db.Categories.Update(category);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _db.Categories.FindAsync(id);
        if (c != null) { _db.Categories.Remove(c); await _db.SaveChangesAsync(); }
    }
}
