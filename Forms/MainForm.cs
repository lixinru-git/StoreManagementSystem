using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class MainForm : Form
{
    private readonly Dictionary<string, UserControl> _ucCache = new();
    private Button? _activeBtn;

    public MainForm()
    {
        InitializeComponent();
        Load += MainForm_Load;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        lblStatus.Text = $"门店管理系统 | {DateTime.Now:yyyy-MM-dd HH:mm}";

        // 加载今日销售概览
        LoadDashboard();

        // 默认选中第一个菜单
        if (flpMenu.Controls.Count > 0 && flpMenu.Controls[0] is Button btn)
            InvokeMenuClick(btn);
    }

    private void LoadDashboard()
    {
        try
        {
            var saleSvc = Program.ServiceProvider.GetRequiredService<ISaleService>();
            var todaySales = saleSvc.GetTodaySalesAsync().GetAwaiter().GetResult();
            lblTodaySales.Text = $"¥ {todaySales:N2}";

            var invSvc = Program.ServiceProvider.GetRequiredService<IInventoryService>();
            var lowStock = invSvc.GetStockInsAsync().GetAwaiter().GetResult().Count;
        }
        catch { }
    }

    private void InvokeMenuClick(Button btn)
    {
        if (_activeBtn != null)
            _activeBtn.BackColor = Color.FromArgb(45, 45, 48);
        _activeBtn = btn;
        btn.BackColor = Color.FromArgb(70, 130, 180);

        var key = btn.Tag as string ?? "";
        ShowUserControl(key);
    }

    private void ShowUserControl(string key)
    {
        if (!_ucCache.TryGetValue(key, out var uc))
        {
            uc = key switch
            {
                "sale" => new UC_Sale(),
                "product" => new UC_Product(),
                "stock" => new UC_Stock(),
                "member" => new UC_Member(),
                "report" => new UC_Report(),
                _ => null
            };
            if (uc != null) _ucCache[key] = uc;
        }

        pnlContent.Controls.Clear();
        if (uc != null)
        {
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }
    }

    private void OnMenuClick(object? sender, EventArgs e)
    {
        if (sender is Button btn)
            InvokeMenuClick(btn);
    }
}
