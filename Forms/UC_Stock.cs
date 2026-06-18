using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Stock : UserControl
{
    private readonly IInventoryService _invSvc;
    private readonly IProductService _productSvc;

    public UC_Stock()
    {
        _invSvc = Program.ServiceProvider.GetRequiredService<IInventoryService>();
        _productSvc = Program.ServiceProvider.GetRequiredService<IProductService>();
        InitializeComponent();
        Load += async (s, e) => { await LoadStockInAsync(); await LoadStockOutAsync(); };
    }

    private async Task LoadStockInAsync()
    {
        try
        {
            var list = await _invSvc.GetStockInsAsync();
            dgvStockIn.Rows.Clear();
            foreach (var s in list)
                dgvStockIn.Rows.Add(s.Product.Name, s.Quantity, s.UnitCost.ToString("N2"), s.Supplier ?? "-", s.Remark ?? "-", s.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
        }
        catch (Exception ex) { MessageBox.Show($"加载失败: {ex.Message}"); }
    }

    private async Task LoadStockOutAsync()
    {
        try
        {
            var list = await _invSvc.GetStockOutsAsync();
            dgvStockOut.Rows.Clear();
            foreach (var s in list)
                dgvStockOut.Rows.Add(s.Product.Name, s.Quantity, s.Reason, s.Remark ?? "-", s.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
        }
        catch (Exception ex) { MessageBox.Show($"加载失败: {ex.Message}"); }
    }

    private async void BtnStockIn_Click(object? sender, EventArgs e)
    {
        using var form = new StockInOutForm(_productSvc, true);
        if (form.ShowDialog() == DialogResult.OK)
        {
            await _invSvc.AddStockInAsync(form.ProductId, form.Quantity, form.UnitCost, form.Supplier, form.Remark);
            await LoadStockInAsync();
        }
    }

    private async void BtnStockOut_Click(object? sender, EventArgs e)
    {
        using var form = new StockInOutForm(_productSvc, false);
        if (form.ShowDialog() == DialogResult.OK)
        {
            try { await _invSvc.AddStockOutAsync(form.ProductId, form.Quantity, "Damage", form.Remark); await LoadStockOutAsync(); }
            catch (Exception ex) { MessageBox.Show($"出库失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
