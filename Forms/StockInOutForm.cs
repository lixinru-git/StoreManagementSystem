using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class StockInOutForm : Form
{
    public int ProductId { get; private set; }
    public int Quantity => (int)this.nudQty.Value;
    public decimal UnitCost => this.nudCost.Value;
    public string? Supplier => this.txtSupplier.Text.Trim();
    public string? Remark => this.txtRemark.Text.Trim();

    private readonly IProductService _productSvc;
    private readonly bool _isStockIn;

    public StockInOutForm(IProductService productSvc, bool isStockIn)
    {
        _productSvc = productSvc;
        _isStockIn = isStockIn;
        InitializeComponent();

        this.Text = isStockIn ? "入库" : "出库(报损)";

        // 入库显示单价和供应商，出库只显示数量和备注
        this.lblCost.Visible = isStockIn;
        this.nudCost.Visible = isStockIn;
        this.lblSupplier.Visible = isStockIn;
        this.txtSupplier.Visible = isStockIn;
        if (!isStockIn)
        {
            this.lblRemark.Top = 85;
            this.txtRemark.Top = 83;
        }

        this.Load += StockInOutForm_Load;
    }

    private async void StockInOutForm_Load(object? sender, EventArgs e)
    {
        var products = await _productSvc.GetAllAsync();
        this.cboProduct.DisplayMember = "Name";
        this.cboProduct.ValueMember = "Id";
        this.cboProduct.DataSource = products.Where(p => p.IsActive).ToList();
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (this.cboProduct.SelectedValue == null)
        {
            MessageBox.Show("请选择商品");
            this.DialogResult = DialogResult.None;
            return;
        }
        this.ProductId = (int)this.cboProduct.SelectedValue;
    }
}
