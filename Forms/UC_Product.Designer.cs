namespace StoreManagementSystem.Forms;

partial class UC_Product
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvProducts;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
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

        this.txtSearch.Location = new Point(15, 50); this.txtSearch.Size = new Size(250, 23);
        this.btnSearch.Text = "搜索"; this.btnSearch.Location = new Point(275, 48); this.btnSearch.Size = new Size(60, 28);
        this.btnSearch.Click += async (s, e) => await LoadProductsAsync(txtSearch.Text.Trim());

        this.btnAdd.Text = "＋ 添加商品"; this.btnAdd.Location = new Point(360, 48); this.btnAdd.Size = new Size(100, 28);
        this.btnAdd.Click += BtnAdd_Click;
        this.btnEdit.Text = "✏ 编辑"; this.btnEdit.Location = new Point(470, 48); this.btnEdit.Size = new Size(80, 28);
        this.btnEdit.Click += BtnEdit_Click;
        this.btnDelete.Text = "✕ 删除"; this.btnDelete.Location = new Point(560, 48); this.btnDelete.Size = new Size(80, 28);
        this.btnDelete.Click += BtnDelete_Click;

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
}
