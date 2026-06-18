using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Forms;

public partial class UC_Report : UserControl
{
    private readonly ISaleService _saleSvc;

    private DateTimePicker dtpFrom;
    private DateTimePicker dtpTo;
    private Button btnRefresh;
    private Chart chartSales;
    private Chart chartTopProducts;
    private Label lblTotalSales;
    private Label lblOrderCount;
    private Label lblPeriod;

    public UC_Report()
    {
        _saleSvc = Program.ServiceProvider.GetRequiredService<ISaleService>();
        InitializeComponent();
        Load += async (s, e) => await LoadReportsAsync();
    }

    private void InitializeComponent()
    {
        this.chartSales = new Chart();
        this.chartTopProducts = new Chart();
        this.dtpFrom = new DateTimePicker();
        this.dtpTo = new DateTimePicker();
        this.btnRefresh = new Button();
        this.lblTotalSales = new Label();
        this.lblOrderCount = new Label();
        this.lblPeriod = new Label();
        ((System.ComponentModel.ISupportInitialize)this.chartSales).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.chartTopProducts).BeginInit();
        this.SuspendLayout();

        var lblTitle = new Label { Text = "数据统计", Font = new Font("微软雅黑", 14, FontStyle.Bold), Location = new Point(15, 10), Size = new Size(200, 30) };

        // 日期选择
        var lblFrom = new Label { Text = "从:", Location = new Point(15, 50), Size = new Size(25, 25) };
        this.dtpFrom.Location = new Point(42, 48); this.dtpFrom.Size = new Size(130, 23);
        this.dtpFrom.Value = DateTime.Today.AddDays(-30);
        var lblTo = new Label { Text = "到:", Location = new Point(180, 50), Size = new Size(25, 25) };
        this.dtpTo.Location = new Point(205, 48); this.dtpTo.Size = new Size(130, 23);
        this.btnRefresh.Text = "刷新"; this.btnRefresh.Location = new Point(350, 46); this.btnRefresh.Size = new Size(60, 28);
        this.btnRefresh.Click += async (s, e) => await LoadReportsAsync();

        // 统计卡片
        this.lblPeriod.Location = new Point(15, 85); this.lblPeriod.Size = new Size(300, 25); this.lblPeriod.Font = new Font("微软雅黑", 9);
        this.lblTotalSales.Location = new Point(15, 115); this.lblTotalSales.Size = new Size(250, 40);
        this.lblTotalSales.Font = new Font("微软雅黑", 18, FontStyle.Bold); this.lblTotalSales.ForeColor = Color.FromArgb(70, 130, 180);
        this.lblOrderCount.Location = new Point(280, 115); this.lblOrderCount.Size = new Size(250, 40);
        this.lblOrderCount.Font = new Font("微软雅黑", 18, FontStyle.Bold); this.lblOrderCount.ForeColor = Color.Green;

        // 图表1: 每日销售额折线图
        var grpChart1 = new GroupBox { Text = "每日销售额趋势", Location = new Point(15, 165), Size = new Size(500, 280) };
        this.chartSales.Location = new Point(5, 20); this.chartSales.Size = new Size(490, 250);
        this.chartSales.ChartAreas.Add(new ChartArea("Default"));
        this.chartSales.ChartAreas["Default"].AxisX.Title = "日期";
        this.chartSales.ChartAreas["Default"].AxisY.Title = "销售额 (¥)";
        this.chartSales.Legends.Add(new Legend("Legend") { Docking = Docking.Bottom });
        grpChart1.Controls.Add(this.chartSales);

        // 图表2: 热销商品柱状图
        var grpChart2 = new GroupBox { Text = "热销商品 Top 10", Location = new Point(530, 165), Size = new Size(250, 280) };
        this.chartTopProducts.Location = new Point(5, 20); this.chartTopProducts.Size = new Size(240, 250);
        this.chartTopProducts.ChartAreas.Add(new ChartArea("Default2"));
        this.chartTopProducts.ChartAreas["Default2"].AxisX.Title = "商品";
        this.chartTopProducts.ChartAreas["Default2"].AxisY.Title = "销售额 (¥)";
        this.chartTopProducts.Legends.Add(new Legend("Legend2") { Docking = Docking.Bottom });
        grpChart2.Controls.Add(this.chartTopProducts);

        this.Controls.AddRange(new Control[] { lblTitle, lblFrom, dtpFrom, lblTo, dtpTo, btnRefresh,
            lblPeriod, lblTotalSales, lblOrderCount, grpChart1, grpChart2 });

        ((System.ComponentModel.ISupportInitialize)this.chartSales).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.chartTopProducts).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private async Task LoadReportsAsync()
    {
        try
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            lblPeriod.Text = $"统计周期: {from:yyyy-MM-dd} ~ {to:yyyy-MM-dd}";

            var totalSales = await _saleSvc.GetSalesAsync(from, to);
            lblTotalSales.Text = $"¥ {totalSales:N2}";
            lblTotalSales.Text = $"总销售额: ¥ {totalSales:N2}";

            var orders = await _saleSvc.GetOrdersAsync(from, to);
            lblOrderCount.Text = $"总订单数: {orders.Count}";

            // 每日销售额折线图
            var dailySales = await _saleSvc.GetDailySalesAsync(from, to);
            var seriesSales = new Series("日销售额") { ChartType = SeriesChartType.Line, BorderWidth = 2 };
            foreach (var (date, total) in dailySales)
                seriesSales.Points.AddXY(date.ToString("MM-dd"), (double)total);
            this.chartSales.Series.Clear();
            this.chartSales.Series.Add(seriesSales);
            this.chartSales.ChartAreas["Default"].RecalculateAxesScale();

            // 热销商品柱状图
            var topProducts = await _saleSvc.GetTopProductsAsync(from, to);
            var seriesTop = new Series("销售额") { ChartType = SeriesChartType.Column, BorderWidth = 1 };
            foreach (var (name, total, qty) in topProducts)
                seriesTop.Points.AddXY(name.Length > 8 ? name[..8] + "..." : name, (double)total);
            this.chartTopProducts.Series.Clear();
            this.chartTopProducts.Series.Add(seriesTop);
            this.chartTopProducts.ChartAreas["Default2"].RecalculateAxesScale();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"加载统计失败: {ex.Message}");
        }
    }
}
