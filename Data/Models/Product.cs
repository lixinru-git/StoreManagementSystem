using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Models;

/// <summary>
/// 商品
/// </summary>
public class Product
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Barcode { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>进货价</summary>
    public decimal CostPrice { get; set; }

    /// <summary>销售价</summary>
    public decimal SalePrice { get; set; }

    /// <summary>当前库存</summary>
    public int StockQuantity { get; set; }

    /// <summary>库存预警阈值</summary>
    public int LowStockThreshold { get; set; } = 10;

    /// <summary>商品图片路径</summary>
    [MaxLength(255)]
    public string? ImagePath { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    public ICollection<StockIn> StockIns { get; set; } = new List<StockIn>();
    public ICollection<StockOut> StockOuts { get; set; } = new List<StockOut>();
}
