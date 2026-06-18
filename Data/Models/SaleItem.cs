using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Models;

/// <summary>
/// 销售订单明细
/// </summary>
public class SaleItem
{
    public int Id { get; set; }

    public int SaleOrderId { get; set; }
    public SaleOrder SaleOrder { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }
}
