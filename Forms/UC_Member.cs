using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Member : UserControl
{
    private readonly ICustomerService _customerSvc;

    private DataGridView dgvMembers;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;

    public UC_Member()
    {
        _customerSvc = Program.ServiceProvider.GetRequiredService<ICustomerService>();
        InitializeComponent();
        Load += async (s, e) => await LoadMembersAsync();
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

        // 统计概览
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

    private async Task LoadMembersAsync(string? search = null)
    {
        try
        {
            var list = await _customerSvc.GetAllAsync(search);
            dgvMembers.Rows.Clear();
            foreach (var c in list)
            {
                var levelColor = c.Level switch
                {
                    "Gold" => Color.Gold,
                    "Silver" => Color.Silver,
                    _ => Color.Transparent
                };
                var idx = dgvMembers.Rows.Add(c.Id, c.Name, c.Phone ?? "-", c.Level, c.Points, c.TotalSpent.ToString("N2"), c.CreatedAt.ToString("yyyy-MM-dd"));
                if (levelColor != Color.Transparent)
                    dgvMembers.Rows[idx].DefaultCellStyle.BackColor = levelColor;
            }
        }
        catch (Exception ex) { MessageBox.Show($"加载失败: {ex.Message}"); }
    }

    private async void BtnAdd_Click(object? sender, EventArgs e)
    {
        using var form = new MemberEditForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            await _customerSvc.AddAsync(form.MemberData);
            await LoadMembersAsync();
        }
    }

    private async void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (dgvMembers.CurrentRow == null) return;
        var id = (int)dgvMembers.CurrentRow.Cells[0].Value;
        var member = await _customerSvc.GetByIdAsync(id);
        if (member == null) return;

        using var form = new MemberEditForm(member);
        if (form.ShowDialog() == DialogResult.OK)
        {
            await _customerSvc.UpdateAsync(form.MemberData);
            await LoadMembersAsync();
        }
    }

    private async void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (dgvMembers.CurrentRow == null) return;
        var id = (int)dgvMembers.CurrentRow.Cells[0].Value;
        if (MessageBox.Show("确认删除该会员？", "确认", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        try { await _customerSvc.DeleteAsync(id); await LoadMembersAsync(); } catch { }
    }
}

internal class MemberEditForm : Form
{
    public Customer MemberData { get; private set; } = new();

    private TextBox txtName;
    private TextBox txtPhone;
    private ComboBox cboLevel;

    public MemberEditForm(Customer? existing = null)
    {
        this.Text = existing != null ? "编辑会员" : "新增会员";
        this.Size = new Size(320, 250);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.MinimizeBox = false;

        var y = 15;
        this.Controls.Add(new Label { Text = "姓名:", Location = new Point(15, y), Size = new Size(60, 25) });
        txtName = new TextBox { Location = new Point(80, y - 2), Size = new Size(200, 23) };
        this.Controls.Add(txtName);
        y += 35;
        this.Controls.Add(new Label { Text = "手机号:", Location = new Point(15, y), Size = new Size(60, 25) });
        txtPhone = new TextBox { Location = new Point(80, y - 2), Size = new Size(200, 23) };
        this.Controls.Add(txtPhone);
        y += 35;
        this.Controls.Add(new Label { Text = "等级:", Location = new Point(15, y), Size = new Size(60, 25) });
        cboLevel = new ComboBox { Location = new Point(80, y - 2), Size = new Size(120, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        cboLevel.Items.AddRange(new[] { "Regular", "Silver", "Gold" });
        cboLevel.SelectedIndex = 0;
        this.Controls.Add(cboLevel);
        y += 45;

        var btnOk = new Button { Text = "确定", Location = new Point(70, y), Size = new Size(80, 30), DialogResult = DialogResult.OK };
        btnOk.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("请输入姓名"); DialogResult = DialogResult.None; return; }
            if (existing != null)
            {
                existing.Name = txtName.Text.Trim();
                existing.Phone = txtPhone.Text.Trim();
                existing.Level = cboLevel.Text;
                MemberData = existing;
            }
            else
            {
                MemberData = new Customer { Name = txtName.Text.Trim(), Phone = txtPhone.Text.Trim(), Level = cboLevel.Text };
            }
        };
        var btnCancel = new Button { Text = "取消", Location = new Point(170, y), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };
        this.Controls.AddRange(new Control[] { btnOk, btnCancel });

        if (existing != null)
        {
            txtName.Text = existing.Name;
            txtPhone.Text = existing.Phone;
            cboLevel.SelectedItem = existing.Level;
        }
    }
}
