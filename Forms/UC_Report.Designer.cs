using System.Windows.Forms.DataVisualization.Charting;

namespace StoreManagementSystem.Forms;

partial class UC_Report
{
    private System.ComponentModel.IContainer components = null;

    private DateTimePicker dtpFrom;
    private DateTimePicker dtpTo;
    private Button btnRefresh;
    private Label lblTotalSales;
    private Label lblOrderCount;
    private Label lblPeriod;
    private Label lblTitle;
    private GroupBox grpChart1;
    private GroupBox grpChart2;
    private Chart chartSales;
    private Chart chartTopProducts;
    private Label lblFrom;
    private Label lblTo;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
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
        this.lblTitle = new Label();
        this.grpChart1 = new GroupBox();
        this.grpChart2 = new GroupBox();
        this.lblFrom = new Label();
        this.lblTo = new Label();
        ((System.ComponentModel.ISupportInitialize)this.chartSales).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.chartTopProducts).BeginInit();
        this.grpChart1.SuspendLayout();
        this.grpChart2.SuspendLayout();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.Text = "数据统计";
        this.lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblTitle.Location = new Point(10, 5);
        this.lblTitle.Size = new Size(160, 30);

        // lblPeriod
        this.lblPeriod.Font = new Font("微软雅黑", 9F);
        this.lblPeriod.Location = new Point(10, 38);
        this.lblPeriod.Size = new Size(300, 20);

        // lblTotalSales
        this.lblTotalSales.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblTotalSales.ForeColor = Color.FromArgb(70, 130, 180);
        this.lblTotalSales.Location = new Point(10, 60);
        this.lblTotalSales.Size = new Size(200, 28);
        this.lblTotalSales.Text = "总销售额: ¥ 0.00";

        // lblOrderCount
        this.lblOrderCount.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblOrderCount.ForeColor = Color.Green;
        this.lblOrderCount.Location = new Point(230, 60);
        this.lblOrderCount.Size = new Size(200, 28);
        this.lblOrderCount.Text = "总订单数: 0";

        // lblFrom
        this.lblFrom.Text = "从:";
        this.lblFrom.Location = new Point(10, 100);
        this.lblFrom.Size = new Size(25, 25);

        // dtpFrom
        this.dtpFrom.Location = new Point(35, 98);
        this.dtpFrom.Size = new Size(150, 23);
        this.dtpFrom.Value = DateTime.Today.AddDays(-30);

        // lblTo
        this.lblTo.Text = "到:";
        this.lblTo.Location = new Point(195, 100);
        this.lblTo.Size = new Size(25, 25);

        // dtpTo
        this.dtpTo.Location = new Point(220, 98);
        this.dtpTo.Size = new Size(150, 23);

        // btnRefresh
        this.btnRefresh.Text = "刷新";
        this.btnRefresh.Location = new Point(385, 96);
        this.btnRefresh.Size = new Size(60, 28);
        this.btnRefresh.Click += this.BtnRefresh_Click;

        // grpChart1 - 每日销售额趋势
        this.grpChart1.Text = "每日销售额趋势";
        this.grpChart1.Location = new Point(10, 135);
        this.grpChart1.Size = new Size(430, 230);
        this.chartSales.Location = new Point(5, 20);
        this.chartSales.Size = new Size(420, 205);
        this.chartSales.ChartAreas.Add(new ChartArea("Default"));
        this.chartSales.ChartAreas["Default"].AxisX.Title = "日期";
        this.chartSales.ChartAreas["Default"].AxisY.Title = "销售额 (¥)";
        this.chartSales.Legends.Add(new Legend("Legend"));
        this.chartSales.Legends["Legend"].Docking = Docking.Bottom;
        this.grpChart1.Controls.Add(this.chartSales);

        // grpChart2 - 热销商品
        this.grpChart2.Text = "热销商品 Top 10";
        this.grpChart2.Location = new Point(455, 135);
        this.grpChart2.Size = new Size(320, 230);
        this.chartTopProducts.Location = new Point(5, 20);
        this.chartTopProducts.Size = new Size(310, 205);
        this.chartTopProducts.ChartAreas.Add(new ChartArea("Default2"));
        this.chartTopProducts.ChartAreas["Default2"].AxisX.Title = "商品";
        this.chartTopProducts.ChartAreas["Default2"].AxisY.Title = "销售额 (¥)";
        this.chartTopProducts.Legends.Add(new Legend("Legend2"));
        this.chartTopProducts.Legends["Legend2"].Docking = Docking.Bottom;
        this.grpChart2.Controls.Add(this.chartTopProducts);

        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblPeriod);
        this.Controls.Add(this.lblTotalSales);
        this.Controls.Add(this.lblOrderCount);
        this.Controls.Add(this.lblFrom);
        this.Controls.Add(this.dtpFrom);
        this.Controls.Add(this.lblTo);
        this.Controls.Add(this.dtpTo);
        this.Controls.Add(this.btnRefresh);
        this.Controls.Add(this.grpChart1);
        this.Controls.Add(this.grpChart2);

        ((System.ComponentModel.ISupportInitialize)this.chartSales).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.chartTopProducts).EndInit();
        this.grpChart1.ResumeLayout(false);
        this.grpChart2.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
