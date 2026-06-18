using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Models;

/// <summary>
/// 销售订单
/// </summary>
public class SaleOrder
{
    public int Id { get; set; }

    [MaxLength(30)]
    public string OrderNo { get; set; } = string.Empty;

    public decimal Subtotal { get; set; }

    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    /// <summary>支付方式: Cash/WeChat/Alipay/Card</summary>
    [MaxLength(20)]
    public string PaymentMethod { get; set; } = "Cash";

    /// <summary>获取积分</summary>
    public int PointsEarned { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
