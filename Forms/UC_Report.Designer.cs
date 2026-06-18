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
        ChartArea chartArea1 = new ChartArea();
        Legend legend1 = new Legend();
        ChartArea chartArea2 = new ChartArea();
        Legend legend2 = new Legend();
        chartSales = new Chart();
        chartTopProducts = new Chart();
        dtpFrom = new DateTimePicker();
        dtpTo = new DateTimePicker();
        btnRefresh = new Button();
        lblTotalSales = new Label();
        lblOrderCount = new Label();
        lblPeriod = new Label();
        lblTitle = new Label();
        grpChart1 = new GroupBox();
        grpChart2 = new GroupBox();
        lblFrom = new Label();
        lblTo = new Label();
        ((System.ComponentModel.ISupportInitialize)chartSales).BeginInit();
        ((System.ComponentModel.ISupportInitialize)chartTopProducts).BeginInit();
        grpChart1.SuspendLayout();
        grpChart2.SuspendLayout();
        SuspendLayout();
        // 
        // chartSales
        // 
        chartArea1.Name = "Default";
        chartSales.ChartAreas.Add(chartArea1);
        legend1.Name = "Legend";
        chartSales.Legends.Add(legend1);
        chartSales.Location = new Point(0, 29);
        chartSales.Name = "chartSales";
        chartSales.Size = new Size(519, 404);
        chartSales.TabIndex = 0;
        // 
        // chartTopProducts
        // 
        chartArea2.Name = "Default2";
        chartTopProducts.ChartAreas.Add(chartArea2);
        legend2.Name = "Legend2";
        chartTopProducts.Legends.Add(legend2);
        chartTopProducts.Location = new Point(0, 29);
        chartTopProducts.Name = "chartTopProducts";
        chartTopProducts.Size = new Size(356, 404);
        chartTopProducts.TabIndex = 0;
        // 
        // dtpFrom
        // 
        dtpFrom.Location = new Point(55, 110);
        dtpFrom.Name = "dtpFrom";
        dtpFrom.Size = new Size(219, 30);
        dtpFrom.TabIndex = 2;
        dtpFrom.Value = new DateTime(2026, 5, 20, 0, 0, 0, 0);
        // 
        // dtpTo
        // 
        dtpTo.Location = new Point(331, 110);
        dtpTo.Name = "dtpTo";
        dtpTo.Size = new Size(218, 30);
        dtpTo.TabIndex = 4;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(575, 110);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(77, 30);
        btnRefresh.TabIndex = 5;
        btnRefresh.Text = "刷新";
        btnRefresh.Click += BtnRefresh_Click;
        // 
        // lblTotalSales
        // 
        lblTotalSales.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
        lblTotalSales.ForeColor = Color.FromArgb(70, 130, 180);
        lblTotalSales.Location = new Point(15, 115);
        lblTotalSales.Name = "lblTotalSales";
        lblTotalSales.Size = new Size(250, 40);
        lblTotalSales.TabIndex = 7;
        // 
        // lblOrderCount
        // 
        lblOrderCount.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
        lblOrderCount.ForeColor = Color.Green;
        lblOrderCount.Location = new Point(280, 115);
        lblOrderCount.Name = "lblOrderCount";
        lblOrderCount.Size = new Size(250, 40);
        lblOrderCount.TabIndex = 8;
        // 
        // lblPeriod
        // 
        lblPeriod.Font = new Font("微软雅黑", 9F);
        lblPeriod.Location = new Point(15, 85);
        lblPeriod.Name = "lblPeriod";
        lblPeriod.Size = new Size(300, 25);
        lblPeriod.TabIndex = 6;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(15, 44);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(214, 49);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "数据统计";
        // 
        // grpChart1
        // 
        grpChart1.Controls.Add(chartSales);
        grpChart1.Location = new Point(15, 165);
        grpChart1.Name = "grpChart1";
        grpChart1.Size = new Size(519, 433);
        grpChart1.TabIndex = 9;
        grpChart1.TabStop = false;
        grpChart1.Text = "每日销售额趋势";
        // 
        // grpChart2
        // 
        grpChart2.Controls.Add(chartTopProducts);
        grpChart2.Location = new Point(564, 165);
        grpChart2.Name = "grpChart2";
        grpChart2.Size = new Size(356, 433);
        grpChart2.TabIndex = 10;
        grpChart2.TabStop = false;
        grpChart2.Text = "热销商品 Top 10";
        // 
        // lblFrom
        // 
        lblFrom.Location = new Point(15, 110);
        lblFrom.Name = "lblFrom";
        lblFrom.Size = new Size(34, 30);
        lblFrom.TabIndex = 1;
        lblFrom.Text = "从:";
        // 
        // lblTo
        // 
        lblTo.Location = new Point(290, 110);
        lblTo.Name = "lblTo";
        lblTo.Size = new Size(35, 30);
        lblTo.TabIndex = 3;
        lblTo.Text = "到:";
        // 
        // UC_Report
        // 
        Controls.Add(lblTitle);
        Controls.Add(lblFrom);
        Controls.Add(dtpFrom);
        Controls.Add(lblTo);
        Controls.Add(dtpTo);
        Controls.Add(btnRefresh);
        Controls.Add(lblPeriod);
        Controls.Add(lblTotalSales);
        Controls.Add(lblOrderCount);
        Controls.Add(grpChart1);
        Controls.Add(grpChart2);
        Name = "UC_Report";
        Size = new Size(952, 649);
        ((System.ComponentModel.ISupportInitialize)chartSales).EndInit();
        ((System.ComponentModel.ISupportInitialize)chartTopProducts).EndInit();
        grpChart1.ResumeLayout(false);
        grpChart2.ResumeLayout(false);
        ResumeLayout(false);
    }
}
