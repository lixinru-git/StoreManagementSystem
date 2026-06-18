using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class ProductEditForm : Form
{
    private readonly ICategoryService _categorySvc;
    private readonly Product? _original;

    public Product ProductData { get; private set; } = new();

    public ProductEditForm(ICategoryService categorySvc, Product? existing = null)
    {
        _categorySvc = categorySvc;
        _original = existing;
        InitializeComponent();

        this.Text = existing != null ? "编辑商品" : "添加商品";
        this.Load += ProductEditForm_Load;
    }

    private async void ProductEditForm_Load(object? sender, EventArgs e)
    {
        var cats = await _categorySvc.GetAllAsync();
        this.cboCategory.DisplayMember = "Name";
        this.cboCategory.ValueMember = "Id";
        this.cboCategory.DataSource = cats;

        if (_original != null)
        {
            this.txtName.Text = _original.Name;
            this.txtBarcode.Text = _original.Barcode;
            this.cboCategory.SelectedValue = _original.CategoryId;
            this.nudCost.Value = _original.CostPrice;
            this.nudPrice.Value = _original.SalePrice;
            this.nudStock.Value = _original.StockQuantity;
            this.nudThreshold.Value = _original.LowStockThreshold;
        }
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(this.txtName.Text))
        {
            MessageBox.Show("请输入商品名称");
            this.DialogResult = DialogResult.None;
            return;
        }
        if (_original != null)
        {
            _original.Name = this.txtName.Text.Trim();
            _original.Barcode = this.txtBarcode.Text.Trim();
            _original.CategoryId = (int)this.cboCategory.SelectedValue;
            _original.CostPrice = this.nudCost.Value;
            _original.SalePrice = this.nudPrice.Value;
            _original.StockQuantity = (int)this.nudStock.Value;
            _original.LowStockThreshold = (int)this.nudThreshold.Value;
            this.ProductData = _original;
        }
        else
        {
            this.ProductData = new Product
            {
                Name = this.txtName.Text.Trim(),
                Barcode = this.txtBarcode.Text.Trim(),
                CategoryId = (int)this.cboCategory.SelectedValue,
                CostPrice = this.nudCost.Value,
                SalePrice = this.nudPrice.Value,
                StockQuantity = (int)this.nudStock.Value,
                LowStockThreshold = (int)this.nudThreshold.Value
            };
        }
    }
}
