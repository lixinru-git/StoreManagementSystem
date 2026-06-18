namespace StoreManagementSystem.Forms;

partial class UC_Stock
{
    private System.ComponentModel.IContainer components = null;

    private TabControl tabControl;
    private DataGridView dgvStockIn;
    private DataGridView dgvStockOut;
    private Button btnStockIn;
    private Button btnStockOut;
    private Label lblTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.tabControl = new TabControl();
        this.dgvStockIn = new DataGridView();
        this.dgvStockOut = new DataGridView();
        this.btnStockIn = new Button();
        this.btnStockOut = new Button();
        this.lblTitle = new Label();
        ((System.ComponentModel.ISupportInitialize)this.dgvStockIn).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvStockOut).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.Text = "库存管理";
        this.lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblTitle.Location = new Point(15, 10);
        this.lblTitle.Size = new Size(200, 30);

        // btnStockIn
        this.btnStockIn.Text = "＋ 入库";
        this.btnStockIn.Location = new Point(15, 50);
        this.btnStockIn.Size = new Size(80, 28);
        this.btnStockIn.Click += this.BtnStockIn_Click;

        // btnStockOut
        this.btnStockOut.Text = "＋ 出库";
        this.btnStockOut.Location = new Point(105, 50);
        this.btnStockOut.Size = new Size(80, 28);
        this.btnStockOut.Click += this.BtnStockOut_Click;

        // tabControl
        this.tabControl.Location = new Point(15, 85);
        this.tabControl.Size = new Size(770, 480);

        // TabPage 入库记录
        TabPage tabIn = new TabPage("入库记录");
        this.dgvStockIn.Dock = DockStyle.Fill;
        this.dgvStockIn.ReadOnly = true;
        this.dgvStockIn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvStockIn.AllowUserToAddRows = false;
        this.dgvStockIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStockIn.Columns.Add("SIName", "商品");
        this.dgvStockIn.Columns.Add("SIQty", "数量");
        this.dgvStockIn.Columns[1].Width = 60;
        this.dgvStockIn.Columns.Add("SICost", "单价");
        this.dgvStockIn.Columns[2].Width = 60;
        this.dgvStockIn.Columns.Add("SISupplier", "供应商");
        this.dgvStockIn.Columns[3].Width = 120;
        this.dgvStockIn.Columns.Add("SIRemark", "备注");
        this.dgvStockIn.Columns.Add("SITime", "时间");
        this.dgvStockIn.Columns[5].Width = 130;
        tabIn.Controls.Add(this.dgvStockIn);

        // TabPage 出库记录
        TabPage tabOut = new TabPage("出库记录");
        this.dgvStockOut.Dock = DockStyle.Fill;
        this.dgvStockOut.ReadOnly = true;
        this.dgvStockOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvStockOut.AllowUserToAddRows = false;
        this.dgvStockOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStockOut.Columns.Add("SOName", "商品");
        this.dgvStockOut.Columns.Add("SOQty", "数量");
        this.dgvStockOut.Columns[1].Width = 60;
        this.dgvStockOut.Columns.Add("SOReason", "原因");
        this.dgvStockOut.Columns[2].Width = 80;
        this.dgvStockOut.Columns.Add("SORemark", "备注");
        this.dgvStockOut.Columns.Add("SOTime", "时间");
        this.dgvStockOut.Columns[4].Width = 130;
        tabOut.Controls.Add(this.dgvStockOut);

        this.tabControl.TabPages.Add(tabIn);
        this.tabControl.TabPages.Add(tabOut);

        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.btnStockIn);
        this.Controls.Add(this.btnStockOut);
        this.Controls.Add(this.tabControl);

        ((System.ComponentModel.ISupportInitialize)this.dgvStockIn).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvStockOut).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
