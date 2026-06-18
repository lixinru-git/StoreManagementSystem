using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync(string? search = null);
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer?> GetByPhoneAsync(string phone);
    Task<Customer> AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}
