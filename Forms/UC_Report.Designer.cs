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

        //
        // UC_Report
        //
        this.AutoScaleMode = AutoScaleMode.Font;
        this.Font = new Font("微软雅黑", 9F);
        this.Name = "UC_Report";
        this.Size = new Size(780, 500);

        // lblTitle
        this.lblTitle.Text = "数据统计";
        this.lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblTitle.Location = new Point(10, 8);
        this.lblTitle.Size = new Size(120, 26);
        this.lblTitle.Name = "lblTitle";

        // lblPeriod
        this.lblPeriod.Font = new Font("微软雅黑", 9F);
        this.lblPeriod.Location = new Point(10, 36);
        this.lblPeriod.Size = new Size(350, 20);
        this.lblPeriod.Text = "统计周期: 选择日期后点击刷新";
        this.lblPeriod.Name = "lblPeriod";

        // lblTotalSales
        this.lblTotalSales.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        this.lblTotalSales.ForeColor = Color.FromArgb(70, 130, 180);
        this.lblTotalSales.Location = new Point(10, 58);
        this.lblTotalSales.Size = new Size(180, 25);
        this.lblTotalSales.Text = "总销售额: ¥ 0.00";
        this.lblTotalSales.Name = "lblTotalSales";

        // lblOrderCount
        this.lblOrderCount.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        this.lblOrderCount.ForeColor = Color.Green;
        this.lblOrderCount.Location = new Point(210, 58);
        this.lblOrderCount.Size = new Size(180, 25);
        this.lblOrderCount.Text = "总订单数: 0";
        this.lblOrderCount.Name = "lblOrderCount";

        // lblFrom
        this.lblFrom.Text = "从:";
        this.lblFrom.Location = new Point(10, 90);
        this.lblFrom.Size = new Size(25, 25);
        this.lblFrom.Name = "lblFrom";

        // dtpFrom
        this.dtpFrom.Location = new Point(35, 88);
        this.dtpFrom.Size = new Size(140, 23);
        this.dtpFrom.Value = DateTime.Today.AddDays(-30);
        this.dtpFrom.Name = "dtpFrom";

        // lblTo
        this.lblTo.Text = "到:";
        this.lblTo.Location = new Point(185, 90);
        this.lblTo.Size = new Size(25, 25);
        this.lblTo.Name = "lblTo";

        // dtpTo
        this.dtpTo.Location = new Point(210, 88);
        this.dtpTo.Size = new Size(140, 23);
        this.dtpTo.Name = "dtpTo";

        // btnRefresh
        this.btnRefresh.Text = "刷新";
        this.btnRefresh.Location = new Point(365, 86);
        this.btnRefresh.Size = new Size(60, 28);
        this.btnRefresh.Click += this.BtnRefresh_Click;
        this.btnRefresh.Name = "btnRefresh";

        // grpChart1 - 每日销售额趋势
        this.grpChart1.Text = "每日销售额趋势";
        this.grpChart1.Location = new Point(10, 120);
        this.grpChart1.Name = "grpChart1";
        this.grpChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        this.grpChart1.Size = new Size(375, 360);
        this.chartSales.Dock = DockStyle.Fill;
        this.chartSales.ChartAreas.Add(new ChartArea("Default"));
        this.chartSales.ChartAreas["Default"].AxisX.Title = "日期";
        this.chartSales.ChartAreas["Default"].AxisY.Title = "销售额 (¥)";
        this.chartSales.Legends.Add(new Legend("Legend"));
        this.chartSales.Legends["Legend"].Docking = Docking.Bottom;
        this.chartSales.Name = "chartSales";
        this.grpChart1.Controls.Add(this.chartSales);

        // grpChart2 - 热销商品 Top 10
        this.grpChart2.Text = "热销商品 Top 10";
        this.grpChart2.Location = new Point(395, 120);
        this.grpChart2.Name = "grpChart2";
        this.grpChart2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.grpChart2.Size = new Size(375, 360);
        this.chartTopProducts.Dock = DockStyle.Fill;
        this.chartTopProducts.ChartAreas.Add(new ChartArea("Default2"));
        this.chartTopProducts.ChartAreas["Default2"].AxisX.Title = "商品";
        this.chartTopProducts.ChartAreas["Default2"].AxisY.Title = "销售额 (¥)";
        this.chartTopProducts.Legends.Add(new Legend("Legend2"));
        this.chartTopProducts.Legends["Legend2"].Docking = Docking.Bottom;
        this.chartTopProducts.Name = "chartTopProducts";
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
    }
}
