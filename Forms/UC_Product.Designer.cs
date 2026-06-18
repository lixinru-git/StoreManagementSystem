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
    private Label lblTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvProducts = new DataGridView();
        txtSearch = new TextBox();
        btnSearch = new Button();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        lblTitle = new Label();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        SuspendLayout();
        // 
        // dgvProducts
        // 
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeight = 34;
        dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
        dgvProducts.Location = new Point(32, 115);
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersWidth = 62;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(770, 480);
        dgvProducts.TabIndex = 6;
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(32, 67);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(250, 30);
        txtSearch.TabIndex = 1;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(304, 67);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(70, 40);
        btnSearch.TabIndex = 2;
        btnSearch.Text = "搜索";
        btnSearch.Click += BtnSearch_Click;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(395, 67);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(146, 40);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "＋ 添加商品";
        btnAdd.Click += BtnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(559, 69);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(92, 38);
        btnEdit.TabIndex = 4;
        btnEdit.Text = "✏ 编辑";
        btnEdit.Click += BtnEdit_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(685, 67);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(89, 40);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "✕ 删除";
        btnDelete.Click += BtnDelete_Click;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(32, 10);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(214, 54);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "商品管理";
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "ID";
        dataGridViewTextBoxColumn1.MinimumWidth = 8;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "商品名称";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "条码";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "分类";
        dataGridViewTextBoxColumn4.MinimumWidth = 8;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "进价";
        dataGridViewTextBoxColumn5.MinimumWidth = 8;
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.HeaderText = "售价";
        dataGridViewTextBoxColumn6.MinimumWidth = 8;
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.HeaderText = "库存";
        dataGridViewTextBoxColumn7.MinimumWidth = 8;
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn8
        // 
        dataGridViewTextBoxColumn8.HeaderText = "预警";
        dataGridViewTextBoxColumn8.MinimumWidth = 8;
        dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        dataGridViewTextBoxColumn8.ReadOnly = true;
        // 
        // UC_Product
        // 
        Controls.Add(lblTitle);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnAdd);
        Controls.Add(btnEdit);
        Controls.Add(btnDelete);
        Controls.Add(dgvProducts);
        Name = "UC_Product";
        Size = new Size(835, 616);
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
}
