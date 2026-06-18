namespace StoreManagementSystem.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlSidebar;
    private FlowLayoutPanel flpMenu;
    private Panel pnlContent;
    private Panel pnlTopBar;
    private Label lblTitle;
    private Label lblTodaySales;
    private Label lblStatus;
    private Button btnMenuSale;
    private Button btnMenuProduct;
    private Button btnMenuStock;
    private Button btnMenuMember;
    private Button btnMenuReport;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlSidebar = new Panel();
        flpMenu = new FlowLayoutPanel();
        btnMenuSale = new Button();
        btnMenuProduct = new Button();
        btnMenuStock = new Button();
        btnMenuMember = new Button();
        btnMenuReport = new Button();
        pnlContent = new Panel();
        pnlTopBar = new Panel();
        lblTitle = new Label();
        lblTodaySales = new Label();
        lblStatus = new Label();
        pnlSidebar.SuspendLayout();
        flpMenu.SuspendLayout();
        pnlTopBar.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(45, 45, 48);
        pnlSidebar.Controls.Add(flpMenu);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(180, 933);
        pnlSidebar.TabIndex = 0;
        // 
        // flpMenu
        // 
        flpMenu.AutoScroll = true;
        flpMenu.BackColor = Color.FromArgb(45, 45, 48);
        flpMenu.Controls.Add(btnMenuSale);
        flpMenu.Controls.Add(btnMenuProduct);
        flpMenu.Controls.Add(btnMenuStock);
        flpMenu.Controls.Add(btnMenuMember);
        flpMenu.Controls.Add(btnMenuReport);
        flpMenu.Dock = DockStyle.Fill;
        flpMenu.FlowDirection = FlowDirection.TopDown;
        flpMenu.Location = new Point(0, 0);
        flpMenu.Name = "flpMenu";
        flpMenu.Padding = new Padding(5, 10, 5, 10);
        flpMenu.Size = new Size(180, 933);
        flpMenu.TabIndex = 0;
        flpMenu.WrapContents = false;
        // 
        // btnMenuSale
        // 
        btnMenuSale.BackColor = Color.FromArgb(45, 45, 48);
        btnMenuSale.Cursor = Cursors.Hand;
        btnMenuSale.FlatAppearance.BorderSize = 0;
        btnMenuSale.FlatStyle = FlatStyle.Flat;
        btnMenuSale.Font = new Font("微软雅黑", 10F);
        btnMenuSale.ForeColor = Color.White;
        btnMenuSale.Location = new Point(8, 13);
        btnMenuSale.Name = "btnMenuSale";
        btnMenuSale.Padding = new Padding(15, 0, 0, 0);
        btnMenuSale.Size = new Size(160, 45);
        btnMenuSale.TabIndex = 0;
        btnMenuSale.Tag = "sale";
        btnMenuSale.Text = "🏪 销售收银";
        btnMenuSale.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuSale.UseVisualStyleBackColor = false;
        btnMenuSale.Click += OnMenuClick;
        // 
        // btnMenuProduct
        // 
        btnMenuProduct.BackColor = Color.FromArgb(45, 45, 48);
        btnMenuProduct.Cursor = Cursors.Hand;
        btnMenuProduct.FlatAppearance.BorderSize = 0;
        btnMenuProduct.FlatStyle = FlatStyle.Flat;
        btnMenuProduct.Font = new Font("微软雅黑", 10F);
        btnMenuProduct.ForeColor = Color.White;
        btnMenuProduct.Location = new Point(8, 64);
        btnMenuProduct.Name = "btnMenuProduct";
        btnMenuProduct.Padding = new Padding(15, 0, 0, 0);
        btnMenuProduct.Size = new Size(160, 45);
        btnMenuProduct.TabIndex = 1;
        btnMenuProduct.Tag = "product";
        btnMenuProduct.Text = "📦 商品管理";
        btnMenuProduct.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuProduct.UseVisualStyleBackColor = false;
        btnMenuProduct.Click += OnMenuClick;
        // 
        // btnMenuStock
        // 
        btnMenuStock.BackColor = Color.FromArgb(45, 45, 48);
        btnMenuStock.Cursor = Cursors.Hand;
        btnMenuStock.FlatAppearance.BorderSize = 0;
        btnMenuStock.FlatStyle = FlatStyle.Flat;
        btnMenuStock.Font = new Font("微软雅黑", 10F);
        btnMenuStock.ForeColor = Color.White;
        btnMenuStock.Location = new Point(8, 115);
        btnMenuStock.Name = "btnMenuStock";
        btnMenuStock.Padding = new Padding(15, 0, 0, 0);
        btnMenuStock.Size = new Size(160, 45);
        btnMenuStock.TabIndex = 2;
        btnMenuStock.Tag = "stock";
        btnMenuStock.Text = "📋 库存管理";
        btnMenuStock.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuStock.UseVisualStyleBackColor = false;
        btnMenuStock.Click += OnMenuClick;
        // 
        // btnMenuMember
        // 
        btnMenuMember.BackColor = Color.FromArgb(45, 45, 48);
        btnMenuMember.Cursor = Cursors.Hand;
        btnMenuMember.FlatAppearance.BorderSize = 0;
        btnMenuMember.FlatStyle = FlatStyle.Flat;
        btnMenuMember.Font = new Font("微软雅黑", 10F);
        btnMenuMember.ForeColor = Color.White;
        btnMenuMember.Location = new Point(8, 166);
        btnMenuMember.Name = "btnMenuMember";
        btnMenuMember.Padding = new Padding(15, 0, 0, 0);
        btnMenuMember.Size = new Size(160, 45);
        btnMenuMember.TabIndex = 3;
        btnMenuMember.Tag = "member";
        btnMenuMember.Text = "👥 会员管理";
        btnMenuMember.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuMember.UseVisualStyleBackColor = false;
        btnMenuMember.Click += OnMenuClick;
        // 
        // btnMenuReport
        // 
        btnMenuReport.BackColor = Color.FromArgb(45, 45, 48);
        btnMenuReport.Cursor = Cursors.Hand;
        btnMenuReport.FlatAppearance.BorderSize = 0;
        btnMenuReport.FlatStyle = FlatStyle.Flat;
        btnMenuReport.Font = new Font("微软雅黑", 10F);
        btnMenuReport.ForeColor = Color.White;
        btnMenuReport.Location = new Point(8, 217);
        btnMenuReport.Name = "btnMenuReport";
        btnMenuReport.Padding = new Padding(15, 0, 0, 0);
        btnMenuReport.Size = new Size(160, 45);
        btnMenuReport.TabIndex = 4;
        btnMenuReport.Tag = "report";
        btnMenuReport.Text = "📊 数据统计";
        btnMenuReport.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuReport.UseVisualStyleBackColor = false;
        btnMenuReport.Click += OnMenuClick;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = Color.FromArgb(240, 240, 245);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(180, 60);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(1145, 843);
        pnlContent.TabIndex = 2;
        // 
        // pnlTopBar
        // 
        pnlTopBar.BackColor = Color.FromArgb(70, 130, 180);
        pnlTopBar.Controls.Add(lblTitle);
        pnlTopBar.Controls.Add(lblTodaySales);
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Location = new Point(180, 0);
        pnlTopBar.Name = "pnlTopBar";
        pnlTopBar.Size = new Size(1145, 60);
        pnlTopBar.TabIndex = 1;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("微软雅黑", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(15, 15);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(210, 42);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "门店管理系统";
        // 
        // lblTodaySales
        // 
        lblTodaySales.AutoSize = true;
        lblTodaySales.Font = new Font("微软雅黑", 12F);
        lblTodaySales.ForeColor = Color.FromArgb(255, 255, 200);
        lblTodaySales.Location = new Point(891, 18);
        lblTodaySales.Name = "lblTodaySales";
        lblTodaySales.Size = new Size(192, 31);
        lblTodaySales.TabIndex = 1;
        lblTodaySales.Text = "今日销售: ¥ 0.00";
        // 
        // lblStatus
        // 
        lblStatus.BackColor = Color.FromArgb(45, 45, 48);
        lblStatus.Dock = DockStyle.Bottom;
        lblStatus.Font = new Font("微软雅黑", 9F);
        lblStatus.ForeColor = Color.White;
        lblStatus.Location = new Point(180, 903);
        lblStatus.Name = "lblStatus";
        lblStatus.Padding = new Padding(10, 0, 0, 0);
        lblStatus.Size = new Size(1145, 30);
        lblStatus.TabIndex = 3;
        lblStatus.Text = "就绪";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1325, 933);
        Controls.Add(pnlContent);
        Controls.Add(lblStatus);
        Controls.Add(pnlTopBar);
        Controls.Add(pnlSidebar);
        Font = new Font("微软雅黑", 9F);
        MinimumSize = new Size(900, 600);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "门店管理系统";
        pnlSidebar.ResumeLayout(false);
        flpMenu.ResumeLayout(false);
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        ResumeLayout(false);
    }
}
