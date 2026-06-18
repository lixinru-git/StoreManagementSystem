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
        this.dgvMembers = new DataGridView();
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.btnAdd = new Button();
        this.btnEdit = new Button();
        this.btnDelete = new Button();
        this.lblTitle = new Label();
        ((System.ComponentModel.ISupportInitialize)this.dgvMembers).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.Text = "会员管理";
        this.lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblTitle.Location = new Point(15, 10);
        this.lblTitle.Size = new Size(200, 30);

        // txtSearch
        this.txtSearch.Location = new Point(15, 50);
        this.txtSearch.Size = new Size(200, 23);

        // btnSearch
        this.btnSearch.Text = "搜索";
        this.btnSearch.Location = new Point(225, 48);
        this.btnSearch.Size = new Size(60, 28);
        this.btnSearch.Click += this.BtnSearch_Click;

        // btnAdd
        this.btnAdd.Text = "＋ 新增会员";
        this.btnAdd.Location = new Point(310, 48);
        this.btnAdd.Size = new Size(100, 28);
        this.btnAdd.Click += this.BtnAdd_Click;

        // btnEdit
        this.btnEdit.Text = "✏ 编辑";
        this.btnEdit.Location = new Point(420, 48);
        this.btnEdit.Size = new Size(80, 28);
        this.btnEdit.Click += this.BtnEdit_Click;

        // btnDelete
        this.btnDelete.Text = "✕ 删除";
        this.btnDelete.Location = new Point(510, 48);
        this.btnDelete.Size = new Size(80, 28);
        this.btnDelete.Click += this.BtnDelete_Click;

        // dgvMembers
        this.dgvMembers.Location = new Point(15, 85);
        this.dgvMembers.Size = new Size(770, 480);
        this.dgvMembers.ReadOnly = true;
        this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvMembers.AllowUserToAddRows = false;
        this.dgvMembers.Columns.Add("MId", "ID");
        this.dgvMembers.Columns[0].Width = 40;
        this.dgvMembers.Columns.Add("MName", "姓名");
        this.dgvMembers.Columns.Add("MPhone", "手机号");
        this.dgvMembers.Columns[2].Width = 100;
        this.dgvMembers.Columns.Add("MLevel", "等级");
        this.dgvMembers.Columns[3].Width = 60;
        this.dgvMembers.Columns.Add("MPoints", "积分");
        this.dgvMembers.Columns[4].Width = 60;
        this.dgvMembers.Columns.Add("MTotal", "累计消费");
        this.dgvMembers.Columns[5].Width = 80;
        this.dgvMembers.Columns.Add("MDate", "注册日期");
        this.dgvMembers.Columns[6].Width = 100;

        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.dgvMembers);

        ((System.ComponentModel.ISupportInitialize)this.dgvMembers).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
