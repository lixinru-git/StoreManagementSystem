using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Data.Models;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Member : UserControl
{
    private readonly ICustomerService _customerSvc;

    public UC_Member()
    {
        _customerSvc = Program.ServiceProvider.GetRequiredService<ICustomerService>();
        InitializeComponent();
        Load += async (s, e) => await LoadMembersAsync();
    }

    private async void BtnSearch_Click(object? sender, EventArgs e)
    {
        await LoadMembersAsync(txtSearch.Text.Trim());
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
