using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Product : UserControl
{
    private readonly IProductService _productSvc;
    private readonly ICategoryService _categorySvc;

    private DataGridView dgvProducts;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;

    public UC_Product()
    {
        _productSvc = Program.ServiceProvider.GetRequiredService<IProductService>();
        _categorySvc = Program.ServiceProvider.GetRequiredService<ICategoryService>();
        InitializeComponent();
        Load += async (s, e) => await LoadProductsAsync();
    }

    private void InitializeComponent()
    {
        this.dgvProducts = new DataGridView();
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.btnAdd = new Button();
        this.btnEdit = new Button();
        this.btnDelete = new Button();
        ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
        this.SuspendLayout();

        var lblTitle = new Label { Text = "商品管理", Font = new Font("微软雅黑", 14, FontStyle.Bold), Location = new Point(15, 10), Size = new Size(200, 30) };

        // 工具栏
        this.txtSearch.Location = new Point(15, 50); this.txtSearch.Size = new Size(250, 23);
        this.btnSearch.Text = "搜索"; this.btnSearch.Location = new Point(275, 48); this.btnSearch.Size = new Size(60, 28);
        this.btnSearch.Click += async (s, e) => await LoadProductsAsync(txtSearch.Text.Trim());

        this.btnAdd.Text = "＋ 添加商品"; this.btnAdd.Location = new Point(360, 48); this.btnAdd.Size = new Size(100, 28);
        this.btnAdd.Click += BtnAdd_Click;

        this.btnEdit.Text = "✏ 编辑"; this.btnEdit.Location = new Point(470, 48); this.btnEdit.Size = new Size(80, 28);
        this.btnEdit.Click += BtnEdit_Click;

        this.btnDelete.Text = "✕ 删除"; this.btnDelete.Location = new Point(560, 48); this.btnDelete.Size = new Size(80, 28);
        this.btnDelete.Click += BtnDelete_Click;

        // 商品表格
        this.dgvProducts.Location = new Point(15, 85);
        this.dgvProducts.Size = new Size(770, 480);
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.Columns.Add("PId", "ID"); this.dgvProducts.Columns[0].Width = 40;
        this.dgvProducts.Columns.Add("PName", "商品名称");
        this.dgvProducts.Columns.Add("PBarcode", "条码"); this.dgvProducts.Columns[2].Width = 100;
        this.dgvProducts.Columns.Add("PCategory", "分类"); this.dgvProducts.Columns[3].Width = 70;
        this.dgvProducts.Columns.Add("PCost", "进价"); this.dgvProducts.Columns[4].Width = 60;
        this.dgvProducts.Columns.Add("PPrice", "售价"); this.dgvProducts.Columns[5].Width = 60;
        this.dgvProducts.Columns.Add("PStock", "库存"); this.dgvProducts.Columns[6].Width = 50;
        this.dgvProducts.Columns.Add("PThreshold", "预警"); this.dgvProducts.Columns[7].Width = 50;

        this.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnAdd, btnEdit, btnDelete, dgvProducts });

        ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
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

/// <summary>商品编辑对话框</summary>
internal class ProductEditForm : Form
{
    private readonly ICategoryService _categorySvc;
    private readonly Product? _original;

    public Product ProductData { get; private set; } = new();

    private TextBox txtName;
    private TextBox txtBarcode;
    private ComboBox cboCategory;
    private NumericUpDown nudCost;
    private NumericUpDown nudPrice;
    private NumericUpDown nudStock;
    private NumericUpDown nudThreshold;

    public ProductEditForm(ICategoryService categorySvc, Product? existing = null)
    {
        _categorySvc = categorySvc;
        _original = existing;
        InitializeComponent();
        Load += async (s, e) => await LoadCategoriesAsync();
    }

    private async Task LoadCategoriesAsync()
    {
        var cats = await _categorySvc.GetAllAsync();
        cboCategory.DisplayMember = "Name";
        cboCategory.ValueMember = "Id";
        cboCategory.DataSource = cats;

        if (_original != null)
        {
            txtName.Text = _original.Name;
            txtBarcode.Text = _original.Barcode;
            cboCategory.SelectedValue = _original.CategoryId;
            nudCost.Value = _original.CostPrice;
            nudPrice.Value = _original.SalePrice;
            nudStock.Value = _original.StockQuantity;
            nudThreshold.Value = _original.LowStockThreshold;
            this.Text = "编辑商品";
        }
    }

    private void InitializeComponent()
    {
        this.Text = _original != null ? "编辑商品" : "添加商品";
        this.Size = new Size(350, 350);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.MinimizeBox = false;

        var y = 15;
        this.Controls.Add(new Label { Text = "商品名称:", Location = new Point(15, y), Size = new Size(80, 25) });
        txtName = new TextBox { Location = new Point(100, y - 2), Size = new Size(200, 23) };
        this.Controls.Add(txtName);
        y += 35;
        this.Controls.Add(new Label { Text = "条码:", Location = new Point(15, y), Size = new Size(80, 25) });
        txtBarcode = new TextBox { Location = new Point(100, y - 2), Size = new Size(200, 23) };
        this.Controls.Add(txtBarcode);
        y += 35;
        this.Controls.Add(new Label { Text = "分类:", Location = new Point(15, y), Size = new Size(80, 25) });
        cboCategory = new ComboBox { Location = new Point(100, y - 2), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        this.Controls.Add(cboCategory);
        y += 35;
        this.Controls.Add(new Label { Text = "进价:", Location = new Point(15, y), Size = new Size(80, 25) });
        nudCost = new NumericUpDown { Location = new Point(100, y - 2), Size = new Size(100, 23), DecimalPlaces = 2, Maximum = 99999 };
        this.Controls.Add(nudCost);
        y += 35;
        this.Controls.Add(new Label { Text = "售价:", Location = new Point(15, y), Size = new Size(80, 25) });
        nudPrice = new NumericUpDown { Location = new Point(100, y - 2), Size = new Size(100, 23), DecimalPlaces = 2, Maximum = 99999 };
        this.Controls.Add(nudPrice);
        y += 35;
        this.Controls.Add(new Label { Text = "库存:", Location = new Point(15, y), Size = new Size(80, 25) });
        nudStock = new NumericUpDown { Location = new Point(100, y - 2), Size = new Size(100, 23), Maximum = 99999 };
        this.Controls.Add(nudStock);
        y += 35;
        this.Controls.Add(new Label { Text = "预警阈值:", Location = new Point(15, y), Size = new Size(80, 25) });
        nudThreshold = new NumericUpDown { Location = new Point(100, y - 2), Size = new Size(100, 23), Maximum = 99999, Value = 10 };
        this.Controls.Add(nudThreshold);
        y += 45;

        var btnOk = new Button { Text = "确定", Location = new Point(80, y), Size = new Size(80, 30), DialogResult = DialogResult.OK };
        btnOk.Click += (s, e) => SaveData();
        var btnCancel = new Button { Text = "取消", Location = new Point(180, y), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };
        this.Controls.AddRange(new Control[] { btnOk, btnCancel });
    }

    private void SaveData()
    {
        if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("请输入商品名称"); DialogResult = DialogResult.None; return; }
        if (_original != null)
        {
            _original.Name = txtName.Text.Trim();
            _original.Barcode = txtBarcode.Text.Trim();
            _original.CategoryId = (int)cboCategory.SelectedValue;
            _original.CostPrice = nudCost.Value;
            _original.SalePrice = nudPrice.Value;
            _original.StockQuantity = (int)nudStock.Value;
            _original.LowStockThreshold = (int)nudThreshold.Value;
            ProductData = _original;
        }
        else
        {
            ProductData = new Product
            {
                Name = txtName.Text.Trim(),
                Barcode = txtBarcode.Text.Trim(),
                CategoryId = (int)cboCategory.SelectedValue,
                CostPrice = nudCost.Value,
                SalePrice = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                LowStockThreshold = (int)nudThreshold.Value
            };
        }
    }
}
