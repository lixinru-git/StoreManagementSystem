using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Models;

/// <summary>
/// 客户/会员
/// </summary>
public class Customer
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Phone { get; set; }

    /// <summary>会员等级: Regular/Silver/Gold</summary>
    [MaxLength(20)]
    public string Level { get; set; } = "Regular";

    public int Points { get; set; }

    public decimal TotalSpent { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;

    // Navigation
    public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
}
