using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Sale : UserControl
{
    private readonly ISaleService _saleSvc;
    private readonly IProductService _productSvc;
    private readonly ICustomerService _customerSvc;

    // UI 控件
    private TextBox txtSearch;
    private DataGridView dgvProducts;
    private DataGridView dgvCart;
    private DataGridView dgvHistory;
    private ComboBox cboPayment;
    private TextBox txtPhone;
    private Button btnAddCart;
    private Button btnRemoveCart;
    private Button btnCheckout;
    private Button btnSearch;
    private Button btnClearCart;
    private Label lblSubtotal;
    private Label lblDiscount;
    private Label lblTotal;
    private Label lblCustomerInfo;
    private NumericUpDown nudQty;

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

    #region 初始化布局
    private void InitializeComponent()
    {
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.dgvProducts = new DataGridView();
        this.nudQty = new NumericUpDown();
        this.btnAddCart = new Button();
        this.btnRemoveCart = new Button();
        this.btnClearCart = new Button();
        this.dgvCart = new DataGridView();
        this.lblSubtotal = new Label();
        this.lblDiscount = new Label();
        this.lblTotal = new Label();
        this.cboPayment = new ComboBox();
        this.txtPhone = new TextBox();
        this.lblCustomerInfo = new Label();
        this.btnCheckout = new Button();
        this.dgvHistory = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.nudQty).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvCart).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvHistory).BeginInit();
        this.SuspendLayout();

        var lblTitle = new Label { Text = "销售收银", Font = new Font("微软雅黑", 14, FontStyle.Bold), Location = new Point(15, 10), Size = new Size(200, 30) };

        // == 商品搜索区域 ==
        var grpSearch = new GroupBox { Text = "商品搜索", Location = new Point(15, 45), Size = new Size(480, 55) };
        this.txtSearch.Location = new Point(10, 22); this.txtSearch.Size = new Size(300, 23);
        this.btnSearch.Text = "搜索"; this.btnSearch.Location = new Point(320, 20); this.btnSearch.Size = new Size(70, 28);
        this.btnSearch.Click += BtnSearch_Click;
        grpSearch.Controls.AddRange(new Control[] { txtSearch, btnSearch });

        // == 商品列表 ==
        this.dgvProducts.Location = new Point(15, 105);
        this.dgvProducts.Size = new Size(480, 200);
        this.dgvProducts.ReadOnly = true; this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.Columns.Add("Id", "ID"); this.dgvProducts.Columns[0].Width = 40;
        this.dgvProducts.Columns.Add("Name", "商品名称");
        this.dgvProducts.Columns.Add("Price", "售价"); this.dgvProducts.Columns[2].Width = 60;
        this.dgvProducts.Columns.Add("Stock", "库存"); this.dgvProducts.Columns[3].Width = 50;

        // == 数量与添加 ==
        var lblQty = new Label { Text = "数量:", Location = new Point(15, 315), Size = new Size(40, 25) };
        this.nudQty.Location = new Point(55, 313); this.nudQty.Size = new Size(60, 23); this.nudQty.Minimum = 1; this.nudQty.Maximum = 999; this.nudQty.Value = 1;
        this.btnAddCart.Text = "加入购物车"; this.btnAddCart.Location = new Point(125, 310); this.btnAddCart.Size = new Size(100, 30);
        this.btnAddCart.Click += BtnAddCart_Click;
        this.btnRemoveCart.Text = "移除选中"; this.btnRemoveCart.Location = new Point(235, 310); this.btnRemoveCart.Size = new Size(80, 30);
        this.btnRemoveCart.Click += BtnRemoveCart_Click;
        this.btnClearCart.Text = "清空"; this.btnClearCart.Location = new Point(325, 310); this.btnClearCart.Size = new Size(60, 30);
        this.btnClearCart.Click += (s, e) => { _cart.Clear(); RefreshCart(); };

        // == 购物车 ==
        var lblCart = new Label { Text = "购物车", Font = new Font("微软雅黑", 10, FontStyle.Bold), Location = new Point(15, 350), Size = new Size(80, 20) };
        this.dgvCart.Location = new Point(15, 375);
        this.dgvCart.Size = new Size(480, 150);
        this.dgvCart.ReadOnly = true; this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvCart.AllowUserToAddRows = false; this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCart.Columns.Add("CartId", "ID"); this.dgvCart.Columns[0].Width = 30;
        this.dgvCart.Columns.Add("CartName", "商品名称");
        this.dgvCart.Columns.Add("CartPrice", "单价"); this.dgvCart.Columns[2].Width = 60;
        this.dgvCart.Columns.Add("CartQty", "数量"); this.dgvCart.Columns[3].Width = 50;
        this.dgvCart.Columns.Add("CartSub", "小计"); this.dgvCart.Columns[4].Width = 70;

        // == 右侧：结算区域 ==
        var grpCheckout = new GroupBox { Text = "结算", Location = new Point(510, 45), Size = new Size(290, 480) };
        var lblPay = new Label { Text = "支付方式:", Location = new Point(10, 25), Size = new Size(70, 25) };
        this.cboPayment.Location = new Point(85, 23); this.cboPayment.Size = new Size(100, 25);
        this.cboPayment.Items.AddRange(new[] { "Cash", "WeChat", "Alipay", "Card" });
        this.cboPayment.SelectedIndex = 0;

        var lblPhone = new Label { Text = "会员手机:", Location = new Point(10, 60), Size = new Size(70, 25) };
        this.txtPhone.Location = new Point(85, 58); this.txtPhone.Size = new Size(120, 23);
        var btnFindMember = new Button { Text = "查询", Location = new Point(210, 56), Size = new Size(50, 28) };
        btnFindMember.Click += BtnFindMember_Click;
        this.lblCustomerInfo.Location = new Point(10, 90); this.lblCustomerInfo.Size = new Size(260, 40);
        this.lblCustomerInfo.ForeColor = Color.Gray;

        // 金额汇总
        var y = 140;
        var lblS = new Label { Text = "小计:", Location = new Point(10, y), Size = new Size(80, 25) };
        this.lblSubtotal.Location = new Point(100, y); this.lblSubtotal.Size = new Size(160, 25);
        this.lblSubtotal.Font = new Font("微软雅黑", 10, FontStyle.Bold); this.lblSubtotal.Text = "¥ 0.00";
        y += 30;
        var lblD = new Label { Text = "会员折扣:", Location = new Point(10, y), Size = new Size(80, 25) };
        this.lblDiscount.Location = new Point(100, y); this.lblDiscount.Size = new Size(160, 25);
        this.lblDiscount.ForeColor = Color.Red; this.lblDiscount.Text = "- ¥ 0.00";
        y += 35;
        var line = new Label { Text = "────────────────", Location = new Point(10, y), Size = new Size(260, 20), ForeColor = Color.Gray };
        y += 20;
        var lblT = new Label { Text = "合计:", Font = new Font("微软雅黑", 12, FontStyle.Bold), Location = new Point(10, y), Size = new Size(80, 30) };
        this.lblTotal.Location = new Point(80, y); this.lblTotal.Size = new Size(180, 30);
        this.lblTotal.Font = new Font("微软雅黑", 16, FontStyle.Bold); this.lblTotal.ForeColor = Color.Red;
        this.lblTotal.Text = "¥ 0.00";
        y += 50;
        this.btnCheckout.Text = "🧾 结算 (F8)"; this.btnCheckout.Font = new Font("微软雅黑", 12, FontStyle.Bold);
        this.btnCheckout.Location = new Point(15, y); this.btnCheckout.Size = new Size(250, 45);
        this.btnCheckout.BackColor = Color.FromArgb(70, 130, 180); this.btnCheckout.ForeColor = Color.White;
        this.btnCheckout.FlatStyle = FlatStyle.Flat;
        this.btnCheckout.Click += BtnCheckout_Click;

        grpCheckout.Controls.AddRange(new Control[] { lblPay, cboPayment, lblPhone, txtPhone, btnFindMember, lblCustomerInfo,
            lblS, lblSubtotal, lblD, lblDiscount, line, lblT, lblTotal, btnCheckout });

        // == 订单历史 ==
        var lblHistory = new Label { Text = "最近订单", Font = new Font("微软雅黑", 10, FontStyle.Bold), Location = new Point(15, 535), Size = new Size(80, 20) };
        this.dgvHistory.Location = new Point(15, 558);
        this.dgvHistory.Size = new Size(785, 150);
        this.dgvHistory.ReadOnly = true; this.dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvHistory.AllowUserToAddRows = false; this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvHistory.Columns.Add("HOrderNo", "订单号"); this.dgvHistory.Columns[0].Width = 160;
        this.dgvHistory.Columns.Add("HTotal", "金额"); this.dgvHistory.Columns[1].Width = 80;
        this.dgvHistory.Columns.Add("HPayment", "支付方式"); this.dgvHistory.Columns[2].Width = 80;
        this.dgvHistory.Columns.Add("HCustomer", "会员"); this.dgvHistory.Columns[3].Width = 80;
        this.dgvHistory.Columns.Add("HTime", "时间");

        this.Controls.AddRange(new Control[] { lblTitle, grpSearch, dgvProducts, lblQty, nudQty, btnAddCart, btnRemoveCart, btnClearCart,
            lblCart, dgvCart, grpCheckout, lblHistory, dgvHistory });

        ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.nudQty).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvCart).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvHistory).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    #endregion

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
