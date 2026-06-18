namespace StoreManagementSystem.Forms;

partial class UC_Member
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvMembers;
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
        dgvMembers = new DataGridView();
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
        ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
        SuspendLayout();
        // 
        // dgvMembers
        // 
        dgvMembers.AllowUserToAddRows = false;
        dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMembers.ColumnHeadersHeight = 34;
        dgvMembers.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
        dgvMembers.Location = new Point(27, 119);
        dgvMembers.Name = "dgvMembers";
        dgvMembers.ReadOnly = true;
        dgvMembers.RowHeadersWidth = 62;
        dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMembers.Size = new Size(770, 480);
        dgvMembers.TabIndex = 6;
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(27, 71);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(200, 30);
        txtSearch.TabIndex = 1;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(244, 71);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(78, 30);
        btnSearch.TabIndex = 2;
        btnSearch.Text = "搜索";
        btnSearch.Click += BtnSearch_Click;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(328, 71);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(126, 30);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "＋ 新增会员";
        btnAdd.Click += BtnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(460, 71);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(96, 30);
        btnEdit.TabIndex = 4;
        btnEdit.Text = "✏ 编辑";
        btnEdit.Click += BtnEdit_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(582, 71);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(90, 30);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "✕ 删除";
        btnDelete.Click += BtnDelete_Click;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(27, 23);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(200, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "会员管理";
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
        dataGridViewTextBoxColumn2.HeaderText = "姓名";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "手机号";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "等级";
        dataGridViewTextBoxColumn4.MinimumWidth = 8;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "积分";
        dataGridViewTextBoxColumn5.MinimumWidth = 8;
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.HeaderText = "累计消费";
        dataGridViewTextBoxColumn6.MinimumWidth = 8;
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.HeaderText = "注册日期";
        dataGridViewTextBoxColumn7.MinimumWidth = 8;
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.ReadOnly = true;
        // 
        // UC_Member
        // 
        Controls.Add(lblTitle);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnAdd);
        Controls.Add(btnEdit);
        Controls.Add(btnDelete);
        Controls.Add(dgvMembers);
        Name = "UC_Member";
        Size = new Size(824, 616);
        ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
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
}
