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
        chartSales.Dock = DockStyle.Fill;
        legend1.Name = "Legend";
        chartSales.Legends.Add(legend1);
        chartSales.Location = new Point(3, 27);
        chartSales.Name = "chartSales";
        chartSales.Size = new Size(569, 508);
        chartSales.TabIndex = 0;
        // 
        // chartTopProducts
        // 
        chartArea2.Name = "Default2";
        chartTopProducts.ChartAreas.Add(chartArea2);
        chartTopProducts.Dock = DockStyle.Fill;
        legend2.Name = "Legend2";
        chartTopProducts.Legends.Add(legend2);
        chartTopProducts.Location = new Point(3, 27);
        chartTopProducts.Name = "chartTopProducts";
        chartTopProducts.Size = new Size(528, 508);
        chartTopProducts.TabIndex = 0;
        // 
        // dtpFrom
        // 
        dtpFrom.Location = new Point(70, 213);
        dtpFrom.Name = "dtpFrom";
        dtpFrom.Size = new Size(245, 31);
        dtpFrom.TabIndex = 5;
        dtpFrom.Value = new DateTime(2026, 5, 20, 0, 0, 0, 0);
        // 
        // dtpTo
        // 
        dtpTo.Location = new Point(397, 214);
        dtpTo.Name = "dtpTo";
        dtpTo.Size = new Size(238, 31);
        dtpTo.TabIndex = 7;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(659, 214);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(111, 31);
        btnRefresh.TabIndex = 8;
        btnRefresh.Text = "刷新";
        btnRefresh.Click += BtnRefresh_Click;
        // 
        // lblTotalSales
        // 
        lblTotalSales.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        lblTotalSales.ForeColor = Color.FromArgb(70, 130, 180);
        lblTotalSales.Location = new Point(13, 128);
        lblTotalSales.Name = "lblTotalSales";
        lblTotalSales.Size = new Size(332, 71);
        lblTotalSales.TabIndex = 2;
        lblTotalSales.Text = "总销售额: ¥ 0.00";
        // 
        // lblOrderCount
        // 
        lblOrderCount.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
        lblOrderCount.ForeColor = Color.Green;
        lblOrderCount.Location = new Point(397, 128);
        lblOrderCount.Name = "lblOrderCount";
        lblOrderCount.Size = new Size(308, 71);
        lblOrderCount.TabIndex = 3;
        lblOrderCount.Text = "总订单数: 0";
        // 
        // lblPeriod
        // 
        lblPeriod.Font = new Font("微软雅黑", 9F);
        lblPeriod.Location = new Point(10, 67);
        lblPeriod.Name = "lblPeriod";
        lblPeriod.Size = new Size(454, 61);
        lblPeriod.TabIndex = 1;
        lblPeriod.Text = "统计周期: 选择日期后点击刷新";
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(10, 8);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(292, 59);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "数据统计";
        // 
        // grpChart1
        // 
        grpChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        grpChart1.Controls.Add(chartSales);
        grpChart1.Location = new Point(10, 259);
        grpChart1.Name = "grpChart1";
        grpChart1.Size = new Size(575, 538);
        grpChart1.TabIndex = 9;
        grpChart1.TabStop = false;
        grpChart1.Text = "每日销售额趋势";
        // 
        // grpChart2
        // 
        grpChart2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpChart2.Controls.Add(chartTopProducts);
        grpChart2.Location = new Point(611, 259);
        grpChart2.Name = "grpChart2";
        grpChart2.Size = new Size(534, 538);
        grpChart2.TabIndex = 10;
        grpChart2.TabStop = false;
        grpChart2.Text = "热销商品 Top 10";
        // 
        // lblFrom
        // 
        lblFrom.Location = new Point(13, 213);
        lblFrom.Name = "lblFrom";
        lblFrom.Size = new Size(49, 32);
        lblFrom.TabIndex = 4;
        lblFrom.Text = "从:";
        // 
        // lblTo
        // 
        lblTo.Location = new Point(336, 214);
        lblTo.Name = "lblTo";
        lblTo.Size = new Size(40, 31);
        lblTo.TabIndex = 6;
        lblTo.Text = "到:";
        // 
        // UC_Report
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblTitle);
        Controls.Add(lblPeriod);
        Controls.Add(lblTotalSales);
        Controls.Add(lblOrderCount);
        Controls.Add(lblFrom);
        Controls.Add(dtpFrom);
        Controls.Add(lblTo);
        Controls.Add(dtpTo);
        Controls.Add(btnRefresh);
        Controls.Add(grpChart1);
        Controls.Add(grpChart2);
        Font = new Font("微软雅黑", 9F);
        Name = "UC_Report";
        Size = new Size(1155, 817);
        ((System.ComponentModel.ISupportInitialize)chartSales).EndInit();
        ((System.ComponentModel.ISupportInitialize)chartTopProducts).EndInit();
        grpChart1.ResumeLayout(false);
        grpChart2.ResumeLayout(false);
        ResumeLayout(false);
    }
}
