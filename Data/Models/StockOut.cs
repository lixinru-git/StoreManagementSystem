using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Models;

/// <summary>
/// 出库记录
/// </summary>
public class StockOut
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    /// <summary>出库原因: Sale(销售)/Damage(报损)/Other</summary>
    [MaxLength(20)]
    public string Reason { get; set; } = "Sale";

    [MaxLength(500)]
    public string? Remark { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
