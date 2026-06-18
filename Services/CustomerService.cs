using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _db;
    public CustomerService(AppDbContext db) { _db = db; }

    public Task<List<Customer>> GetAllAsync(string? search = null)
    {
        var q = _db.Customers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            q = q.Where(c => c.Name.Contains(search) || (c.Phone != null && c.Phone.Contains(search)));
        return q.OrderByDescending(c => c.TotalSpent).ToListAsync();
    }

    public Task<Customer?> GetByIdAsync(int id) => _db.Customers.FindAsync(id).AsTask();
    public Task<Customer?> GetByPhoneAsync(string phone) =>
        _db.Customers.FirstOrDefaultAsync(c => c.Phone == phone);

    public async Task<Customer> AddAsync(Customer customer)
    {
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateAsync(Customer customer)
    {
        _db.Customers.Update(customer);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _db.Customers.FindAsync(id);
        if (c != null) { _db.Customers.Remove(c); await _db.SaveChangesAsync(); }
    }
}
