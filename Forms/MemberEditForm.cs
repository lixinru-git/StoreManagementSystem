using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Forms;

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

        int y = 15;
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
