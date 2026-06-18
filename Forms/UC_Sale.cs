using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Sale : UserControl
{
    private readonly ISaleService _saleSvc;
    private readonly IProductService _productSvc;
    private readonly ICustomerService _customerSvc;

    private List<(Product Product, int Qty)> _cart = new();
    private Customer? _selectedCustomer;

    public UC_Sale()
    {
        _saleSvc = Program.ServiceProvider.GetRequiredService<ISaleService>();
        _productSvc = Program.ServiceProvider.GetRequiredService<IProductService>();
        _customerSvc = Program.ServiceProvider.GetRequiredService<ICustomerService>();
        InitializeComponent();
        Load += UC_Sale_Load;
    }

    private async void UC_Sale_Load(object? sender, EventArgs e)
    {
        await LoadProductsAsync();
        await LoadOrderHistoryAsync();
    }

    private async Task LoadProductsAsync(string? search = null)
    {
        try
        {
            var products = await _productSvc.GetAllAsync(search);
            dgvProducts.Rows.Clear();
            foreach (var p in products.Where(p => p.IsActive))
                dgvProducts.Rows.Add(p.Id, p.Name, p.SalePrice, p.StockQuantity);
        }
        catch (Exception ex) { MessageBox.Show($"加载商品失败: {ex.Message}"); }
    }

    private async Task LoadOrderHistoryAsync()
    {
        try
        {
            var orders = await _saleSvc.GetOrdersAsync(DateTime.Today.AddDays(-7));
            dgvHistory.Rows.Clear();
            foreach (var o in orders)
                dgvHistory.Rows.Add(o.OrderNo, o.Total.ToString("N2"), o.PaymentMethod, o.Customer?.Name ?? "-", o.CreatedAt.ToString("MM-dd HH:mm"));
        }
        catch { }
    }

    private async void BtnSearch_Click(object? sender, EventArgs e) => await LoadProductsAsync(txtSearch.Text.Trim());

    private void BtnAddCart_Click(object? sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null) return;
        var productId = (int)dgvProducts.CurrentRow.Cells[0].Value;
        var name = dgvProducts.CurrentRow.Cells[1].Value?.ToString() ?? "";
        var price = (decimal)dgvProducts.CurrentRow.Cells[2].Value;
        var stock = (int)dgvProducts.CurrentRow.Cells[3].Value;
        var qty = (int)nudQty.Value;

        var existing = _cart.FirstOrDefault(c => c.Product.Id == productId);
        if (existing.Product != null)
        {
            if (existing.Qty + qty > stock) { MessageBox.Show($"库存不足，剩余{stock}"); return; }
            _cart.Remove(existing);
            _cart.Add((existing.Product, existing.Qty + qty));
        }
        else
        {
            if (qty > stock) { MessageBox.Show($"库存不足，剩余{stock}"); return; }
            _cart.Add((new Product { Id = productId, Name = name, SalePrice = price }, qty));
        }
        RefreshCart();
    }

    private void BtnRemoveCart_Click(object? sender, EventArgs e)
    {
        if (dgvCart.CurrentRow == null) return;
        var idx = dgvCart.CurrentRow.Index;
        if (idx >= 0 && idx < _cart.Count) { _cart.RemoveAt(idx); RefreshCart(); }
    }

    private void BtnClearCart_Click(object? sender, EventArgs e)
    {
        _cart.Clear();
        RefreshCart();
    }

    private void RefreshCart()
    {
        dgvCart.Rows.Clear();
        decimal subtotal = 0;
        foreach (var (product, qty) in _cart)
        {
            var sub = product.SalePrice * qty;
            dgvCart.Rows.Add(product.Id, product.Name, product.SalePrice.ToString("N2"), qty, sub.ToString("N2"));
            subtotal += sub;
        }

        decimal discount = 0;
        if (_selectedCustomer != null)
        {
            discount = _selectedCustomer.Level switch
            {
                "Gold" => subtotal * 0.15m,
                "Silver" => subtotal * 0.08m,
                _ => 0
            };
        }

        lblSubtotal.Text = $"¥ {subtotal:N2}";
        lblDiscount.Text = $"- ¥ {discount:N2}";
        lblTotal.Text = $"¥ {subtotal - discount:N2}";
    }

    private async void BtnFindMember_Click(object? sender, EventArgs e)
    {
        var phone = txtPhone.Text.Trim();
        if (string.IsNullOrEmpty(phone)) { _selectedCustomer = null; lblCustomerInfo.Text = "散客"; RefreshCart(); return; }
        try
        {
            var c = await _customerSvc.GetByPhoneAsync(phone);
            if (c != null)
            {
                _selectedCustomer = c;
                lblCustomerInfo.Text = $"{c.Name} | {c.Level} | 积分:{c.Points}";
                lblCustomerInfo.ForeColor = Color.Green;
            }
            else
            {
                _selectedCustomer = null;
                lblCustomerInfo.Text = "未找到该会员";
                lblCustomerInfo.ForeColor = Color.Red;
            }
            RefreshCart();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void BtnCheckout_Click(object? sender, EventArgs e)
    {
        if (_cart.Count == 0) { MessageBox.Show("购物车为空"); return; }

        if (MessageBox.Show($"确认结算？合计: {lblTotal.Text}", "确认", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        try
        {
            var items = _cart.Select(c => (c.Product.Id, c.Qty)).ToList();
            var order = await _saleSvc.CreateOrderAsync(items, _selectedCustomer?.Id, cboPayment.Text);

            MessageBox.Show($"结算成功！\n订单号: {order.OrderNo}\n合计: ¥{order.Total:N2}\n获得积分: {order.PointsEarned}", "成功");

            _cart.Clear(); _selectedCustomer = null;
            txtPhone.Clear(); lblCustomerInfo.Text = "散客";
            RefreshCart();
            await LoadProductsAsync();
            await LoadOrderHistoryAsync();
        }
        catch (Exception ex) { MessageBox.Show($"结算失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
