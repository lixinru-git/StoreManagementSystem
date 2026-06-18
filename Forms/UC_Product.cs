using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Product : UserControl
{
    private readonly IProductService _productSvc;
    private readonly ICategoryService _categorySvc;

    public UC_Product()
    {
        _productSvc = Program.ServiceProvider.GetRequiredService<IProductService>();
        _categorySvc = Program.ServiceProvider.GetRequiredService<ICategoryService>();
        InitializeComponent();
        Load += async (s, e) => await LoadProductsAsync();
    }

    private async void BtnSearch_Click(object? sender, EventArgs e)
    {
        await LoadProductsAsync(txtSearch.Text.Trim());
    }

    private async Task LoadProductsAsync(string? search = null)
    {
        try
        {
            var products = await _productSvc.GetAllAsync(search);
            dgvProducts.Rows.Clear();
            foreach (var p in products)
            {
                var rowIdx = dgvProducts.Rows.Add(p.Id, p.Name, p.Barcode ?? "", p.Category?.Name ?? "", p.CostPrice.ToString("N2"), p.SalePrice.ToString("N2"), p.StockQuantity, p.LowStockThreshold);
                if (p.StockQuantity <= p.LowStockThreshold)
                    dgvProducts.Rows[rowIdx].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }
        catch (Exception ex) { MessageBox.Show($"加载失败: {ex.Message}"); }
    }

    private async void BtnAdd_Click(object? sender, EventArgs e)
    {
        using var form = new ProductEditForm(_categorySvc);
        if (form.ShowDialog() == DialogResult.OK)
        {
            await _productSvc.AddAsync(form.ProductData);
            await LoadProductsAsync();
        }
    }

    private async void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null) return;
        var id = (int)dgvProducts.CurrentRow.Cells[0].Value;
        var product = await _productSvc.GetByIdAsync(id);
        if (product == null) return;

        using var form = new ProductEditForm(_categorySvc, product);
        if (form.ShowDialog() == DialogResult.OK)
        {
            await _productSvc.UpdateAsync(form.ProductData);
            await LoadProductsAsync();
        }
    }

    private async void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null) return;
        var id = (int)dgvProducts.CurrentRow.Cells[0].Value;
        var name = dgvProducts.CurrentRow.Cells[1].Value?.ToString() ?? "";
        if (MessageBox.Show($"确认删除 [{name}]？", "确认", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        try { await _productSvc.DeleteAsync(id); await LoadProductsAsync(); }
        catch (Exception ex) { MessageBox.Show($"删除失败: {ex.Message}"); }
    }
}
