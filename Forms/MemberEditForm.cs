using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Forms;

public partial class MemberEditForm : Form
{
    public Customer MemberData { get; private set; } = new();

    private readonly Customer? _original;

    public MemberEditForm(Customer? existing = null)
    {
        _original = existing;
        InitializeComponent();

        this.Text = existing != null ? "编辑会员" : "新增会员";

        if (existing != null)
        {
            this.txtName.Text = existing.Name;
            this.txtPhone.Text = existing.Phone;
            this.cboLevel.SelectedItem = existing.Level;
        }
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(this.txtName.Text))
        {
            MessageBox.Show("请输入姓名");
            this.DialogResult = DialogResult.None;
            return;
        }
        if (_original != null)
        {
            _original.Name = this.txtName.Text.Trim();
            _original.Phone = this.txtPhone.Text.Trim();
            _original.Level = this.cboLevel.Text;
            this.MemberData = _original;
        }
        else
        {
            this.MemberData = new Customer
            {
                Name = this.txtName.Text.Trim(),
                Phone = this.txtPhone.Text.Trim(),
                Level = this.cboLevel.Text
            };
        }
    }
}
