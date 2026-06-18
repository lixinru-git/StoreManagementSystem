using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace StoreManagementSystem.Forms;

public partial class UC_Report : UserControl
{
    private readonly ISaleService _saleSvc;

    public UC_Report()
    {
        _saleSvc = Program.ServiceProvider.GetRequiredService<ISaleService>();
        InitializeComponent();
        Load += async (s, e) => await LoadReportsAsync();
    }

    private async Task LoadReportsAsync()
    {
        try
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            lblPeriod.Text = $"统计周期: {from:yyyy-MM-dd} ~ {to:yyyy-MM-dd}";

            var totalSales = await _saleSvc.GetSalesAsync(from, to);
            lblTotalSales.Text = $"总销售额: ¥ {totalSales:N2}";

            var orders = await _saleSvc.GetOrdersAsync(from, to);
            lblOrderCount.Text = $"总订单数: {orders.Count}";

            var dailySales = await _saleSvc.GetDailySalesAsync(from, to);
            var seriesSales = new Series("日销售额") { ChartType = SeriesChartType.Line, BorderWidth = 2 };
            foreach (var (date, total) in dailySales)
                seriesSales.Points.AddXY(date.ToString("MM-dd"), (double)total);
            this.chartSales.Series.Clear();
            this.chartSales.Series.Add(seriesSales);
            this.chartSales.ChartAreas["Default"].RecalculateAxesScale();

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
