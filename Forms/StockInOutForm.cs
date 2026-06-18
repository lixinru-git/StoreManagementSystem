using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

internal class StockInOutForm : Form
{
    public int ProductId { get; private set; }
    public int Quantity => (int)nudQty.Value;
    public decimal UnitCost => nudCost?.Value ?? 0;
    public string? Supplier => txtSupplier?.Text.Trim();
    public string? Remark => txtRemark?.Text.Trim();

    private ComboBox cboProduct;
    private NumericUpDown nudQty;
    private NumericUpDown? nudCost;
    private TextBox? txtSupplier;
    private TextBox txtRemark;
    private readonly bool _isStockIn;

    public StockInOutForm(IProductService productSvc, bool isStockIn)
    {
        _isStockIn = isStockIn;
        this.Text = isStockIn ? "入库" : "出库(报损)";
        this.Size = new Size(350, isStockIn ? 300 : 240);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.MinimizeBox = false;

        int y = 15;
        this.Controls.Add(new Label { Text = "商品:", Location = new Point(15, y), Size = new Size(60, 25) });
        cboProduct = new ComboBox { Location = new Point(80, y - 2), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        cboProduct.DisplayMember = "Name"; cboProduct.ValueMember = "Id";
        this.Controls.Add(cboProduct);
        y += 35;
        this.Controls.Add(new Label { Text = "数量:", Location = new Point(15, y), Size = new Size(60, 25) });
        nudQty = new NumericUpDown { Location = new Point(80, y - 2), Size = new Size(100, 23), Minimum = 1, Maximum = 99999 };
        this.Controls.Add(nudQty);

        if (isStockIn)
        {
            y += 35;
            this.Controls.Add(new Label { Text = "单价:", Location = new Point(15, y), Size = new Size(60, 25) });
            nudCost = new NumericUpDown { Location = new Point(80, y - 2), Size = new Size(100, 23), DecimalPlaces = 2, Maximum = 99999 };
            this.Controls.Add(nudCost);
            y += 35;
            this.Controls.Add(new Label { Text = "供应商:", Location = new Point(15, y), Size = new Size(60, 25) });
            txtSupplier = new TextBox { Location = new Point(80, y - 2), Size = new Size(220, 23) };
            this.Controls.Add(txtSupplier);
        }
        y += 35;
        this.Controls.Add(new Label { Text = "备注:", Location = new Point(15, y), Size = new Size(60, 25) });
        txtRemark = new TextBox { Location = new Point(80, y - 2), Size = new Size(220, 23) };
        this.Controls.Add(txtRemark);
        y += 45;

        var btnOk = new Button { Text = "确定", Location = new Point(80, y), Size = new Size(80, 30), DialogResult = DialogResult.OK };
        btnOk.Click += (s, e) => { if (cboProduct.SelectedValue == null) { MessageBox.Show("请选择商品"); DialogResult = DialogResult.None; } else ProductId = (int)cboProduct.SelectedValue; };
        var btnCancel = new Button { Text = "取消", Location = new Point(180, y), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };
        this.Controls.AddRange(new Control[] { btnOk, btnCancel });

        this.Load += async (s, e) => {
            var products = await productSvc.GetAllAsync();
            cboProduct.DataSource = products.Where(p => p.IsActive).ToList();
        };
    }
}
