using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Models;

/// <summary>
/// 商品分类
/// </summary>
public class Category
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
