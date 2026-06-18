using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

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

        int y = 15;
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
