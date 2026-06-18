using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Stock : UserControl
{
    private readonly IInventoryService _invSvc;
    private readonly IProductService _productSvc;

    private TabControl tabControl;
    private DataGridView dgvStockIn;
    private DataGridView dgvStockOut;
    private Button btnStockIn;
    private Button btnStockOut;

    public UC_Stock()
    {
        _invSvc = Program.ServiceProvider.GetRequiredService<IInventoryService>();
        _productSvc = Program.ServiceProvider.GetRequiredService<IProductService>();
        InitializeComponent();
        Load += async (s, e) => { await LoadStockInAsync(); await LoadStockOutAsync(); };
    }

    private void InitializeComponent()
    {
        this.tabControl = new TabControl();
        this.dgvStockIn = new DataGridView();
        this.dgvStockOut = new DataGridView();
        this.btnStockIn = new Button();
        this.btnStockOut = new Button();
        ((System.ComponentModel.ISupportInitialize)this.dgvStockIn).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvStockOut).BeginInit();
        this.SuspendLayout();

        var lblTitle = new Label { Text = "库存管理", Font = new Font("微软雅黑", 14, FontStyle.Bold), Location = new Point(15, 10), Size = new Size(200, 30) };

        this.btnStockIn.Text = "＋ 入库"; this.btnStockIn.Location = new Point(15, 50); this.btnStockIn.Size = new Size(80, 28);
        this.btnStockIn.Click += BtnStockIn_Click;
        this.btnStockOut.Text = "＋ 出库"; this.btnStockOut.Location = new Point(105, 50); this.btnStockOut.Size = new Size(80, 28);
        this.btnStockOut.Click += BtnStockOut_Click;

        // Tab
        this.tabControl.Location = new Point(15, 85);
        this.tabControl.Size = new Size(770, 480);

        var tabIn = new TabPage("入库记录");
        SetupStockInGrid();
        tabIn.Controls.Add(dgvStockIn);

        var tabOut = new TabPage("出库记录");
        SetupStockOutGrid();
        tabOut.Controls.Add(dgvStockOut);

        this.tabControl.TabPages.Add(tabIn);
        this.tabControl.TabPages.Add(tabOut);

        this.Controls.AddRange(new Control[] { lblTitle, btnStockIn, btnStockOut, tabControl });

        ((System.ComponentModel.ISupportInitialize)this.dgvStockIn).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvStockOut).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void SetupStockInGrid()
    {
        this.dgvStockIn.Dock = DockStyle.Fill;
        this.dgvStockIn.ReadOnly = true; this.dgvStockIn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvStockIn.AllowUserToAddRows = false; this.dgvStockIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStockIn.Columns.Add("SIName", "商品");
        this.dgvStockIn.Columns.Add("SIQty", "数量"); this.dgvStockIn.Columns[1].Width = 60;
        this.dgvStockIn.Columns.Add("SICost", "单价"); this.dgvStockIn.Columns[2].Width = 60;
        this.dgvStockIn.Columns.Add("SISupplier", "供应商"); this.dgvStockIn.Columns[3].Width = 120;
        this.dgvStockIn.Columns.Add("SIRemark", "备注");
        this.dgvStockIn.Columns.Add("SITime", "时间"); this.dgvStockIn.Columns[5].Width = 130;
    }

    private void SetupStockOutGrid()
    {
        this.dgvStockOut.Dock = DockStyle.Fill;
        this.dgvStockOut.ReadOnly = true; this.dgvStockOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvStockOut.AllowUserToAddRows = false; this.dgvStockOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStockOut.Columns.Add("SOName", "商品");
        this.dgvStockOut.Columns.Add("SOQty", "数量"); this.dgvStockOut.Columns[1].Width = 60;
        this.dgvStockOut.Columns.Add("SOReason", "原因"); this.dgvStockOut.Columns[2].Width = 80;
        this.dgvStockOut.Columns.Add("SORemark", "备注");
        this.dgvStockOut.Columns.Add("SOTime", "时间"); this.dgvStockOut.Columns[4].Width = 130;
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

        var y = 15;
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
