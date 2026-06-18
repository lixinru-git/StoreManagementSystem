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

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
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
        ((System.ComponentModel.ISupportInitialize)this.dgvMembers).BeginInit();
        this.SuspendLayout();

        var lblTitle = new Label { Text = "会员管理", Font = new Font("微软雅黑", 14, FontStyle.Bold), Location = new Point(15, 10), Size = new Size(200, 30) };

        this.txtSearch.Location = new Point(15, 50); this.txtSearch.Size = new Size(200, 23);
        this.btnSearch.Text = "搜索"; this.btnSearch.Location = new Point(225, 48); this.btnSearch.Size = new Size(60, 28);
        this.btnSearch.Click += async (s, e) => await LoadMembersAsync(txtSearch.Text.Trim());

        this.btnAdd.Text = "＋ 新增会员"; this.btnAdd.Location = new Point(310, 48); this.btnAdd.Size = new Size(100, 28);
        this.btnAdd.Click += BtnAdd_Click;
        this.btnEdit.Text = "✏ 编辑"; this.btnEdit.Location = new Point(420, 48); this.btnEdit.Size = new Size(80, 28);
        this.btnEdit.Click += BtnEdit_Click;
        this.btnDelete.Text = "✕ 删除"; this.btnDelete.Location = new Point(510, 48); this.btnDelete.Size = new Size(80, 28);
        this.btnDelete.Click += BtnDelete_Click;

        this.dgvMembers.Location = new Point(15, 85);
        this.dgvMembers.Size = new Size(770, 480);
        this.dgvMembers.ReadOnly = true;
        this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvMembers.AllowUserToAddRows = false;
        this.dgvMembers.Columns.Add("MId", "ID"); this.dgvMembers.Columns[0].Width = 40;
        this.dgvMembers.Columns.Add("MName", "姓名");
        this.dgvMembers.Columns.Add("MPhone", "手机号"); this.dgvMembers.Columns[2].Width = 100;
        this.dgvMembers.Columns.Add("MLevel", "等级"); this.dgvMembers.Columns[3].Width = 60;
        this.dgvMembers.Columns.Add("MPoints", "积分"); this.dgvMembers.Columns[4].Width = 60;
        this.dgvMembers.Columns.Add("MTotal", "累计消费"); this.dgvMembers.Columns[5].Width = 80;
        this.dgvMembers.Columns.Add("MDate", "注册日期"); this.dgvMembers.Columns[6].Width = 100;

        this.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnAdd, btnEdit, btnDelete, dgvMembers });

        ((System.ComponentModel.ISupportInitialize)this.dgvMembers).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
