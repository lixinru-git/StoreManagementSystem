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
        this.components = new System.ComponentModel.Container();
        this.pnlSidebar = new Panel();
        this.flpMenu = new FlowLayoutPanel();
        this.btnMenuSale = new Button();
        this.btnMenuProduct = new Button();
        this.btnMenuStock = new Button();
        this.btnMenuMember = new Button();
        this.btnMenuReport = new Button();
        this.pnlContent = new Panel();
        this.pnlTopBar = new Panel();
        this.lblTitle = new Label();
        this.lblTodaySales = new Label();
        this.lblStatus = new Label();
        this.pnlSidebar.SuspendLayout();
        this.flpMenu.SuspendLayout();
        this.pnlTopBar.SuspendLayout();
        this.SuspendLayout();

        // pnlSidebar
        this.pnlSidebar.BackColor = Color.FromArgb(45, 45, 48);
        this.pnlSidebar.Controls.Add(this.flpMenu);
        this.pnlSidebar.Dock = DockStyle.Left;
        this.pnlSidebar.Location = new Point(0, 0);
        this.pnlSidebar.Name = "pnlSidebar";
        this.pnlSidebar.Size = new Size(180, 650);
        this.pnlSidebar.TabIndex = 0;

        // flpMenu
        this.flpMenu.AutoScroll = true;
        this.flpMenu.BackColor = Color.FromArgb(45, 45, 48);
        this.flpMenu.Controls.Add(this.btnMenuSale);
        this.flpMenu.Controls.Add(this.btnMenuProduct);
        this.flpMenu.Controls.Add(this.btnMenuStock);
        this.flpMenu.Controls.Add(this.btnMenuMember);
        this.flpMenu.Controls.Add(this.btnMenuReport);
        this.flpMenu.Dock = DockStyle.Fill;
        this.flpMenu.FlowDirection = FlowDirection.TopDown;
        this.flpMenu.Location = new Point(0, 0);
        this.flpMenu.Name = "flpMenu";
        this.flpMenu.Padding = new Padding(5, 10, 5, 10);
        this.flpMenu.Size = new Size(180, 650);
        this.flpMenu.TabIndex = 0;
        this.flpMenu.WrapContents = false;

        // btnMenuSale
        this.btnMenuSale.Text = "🏪 销售收银";
        this.btnMenuSale.Tag = "sale";
        this.btnMenuSale.FlatStyle = FlatStyle.Flat;
        this.btnMenuSale.FlatAppearance.BorderSize = 0;
        this.btnMenuSale.ForeColor = Color.White;
        this.btnMenuSale.BackColor = Color.FromArgb(45, 45, 48);
        this.btnMenuSale.Font = new Font("微软雅黑", 10F);
        this.btnMenuSale.TextAlign = ContentAlignment.MiddleLeft;
        this.btnMenuSale.Padding = new Padding(15, 0, 0, 0);
        this.btnMenuSale.Cursor = Cursors.Hand;
        this.btnMenuSale.Width = 160;
        this.btnMenuSale.Height = 45;
        this.btnMenuSale.Click += this.OnMenuClick;

        // btnMenuProduct
        this.btnMenuProduct.Text = "📦 商品管理";
        this.btnMenuProduct.Tag = "product";
        this.btnMenuProduct.FlatStyle = FlatStyle.Flat;
        this.btnMenuProduct.FlatAppearance.BorderSize = 0;
        this.btnMenuProduct.ForeColor = Color.White;
        this.btnMenuProduct.BackColor = Color.FromArgb(45, 45, 48);
        this.btnMenuProduct.Font = new Font("微软雅黑", 10F);
        this.btnMenuProduct.TextAlign = ContentAlignment.MiddleLeft;
        this.btnMenuProduct.Padding = new Padding(15, 0, 0, 0);
        this.btnMenuProduct.Cursor = Cursors.Hand;
        this.btnMenuProduct.Width = 160;
        this.btnMenuProduct.Height = 45;
        this.btnMenuProduct.Click += this.OnMenuClick;

        // btnMenuStock
        this.btnMenuStock.Text = "📋 库存管理";
        this.btnMenuStock.Tag = "stock";
        this.btnMenuStock.FlatStyle = FlatStyle.Flat;
        this.btnMenuStock.FlatAppearance.BorderSize = 0;
        this.btnMenuStock.ForeColor = Color.White;
        this.btnMenuStock.BackColor = Color.FromArgb(45, 45, 48);
        this.btnMenuStock.Font = new Font("微软雅黑", 10F);
        this.btnMenuStock.TextAlign = ContentAlignment.MiddleLeft;
        this.btnMenuStock.Padding = new Padding(15, 0, 0, 0);
        this.btnMenuStock.Cursor = Cursors.Hand;
        this.btnMenuStock.Width = 160;
        this.btnMenuStock.Height = 45;
        this.btnMenuStock.Click += this.OnMenuClick;

        // btnMenuMember
        this.btnMenuMember.Text = "👥 会员管理";
        this.btnMenuMember.Tag = "member";
        this.btnMenuMember.FlatStyle = FlatStyle.Flat;
        this.btnMenuMember.FlatAppearance.BorderSize = 0;
        this.btnMenuMember.ForeColor = Color.White;
        this.btnMenuMember.BackColor = Color.FromArgb(45, 45, 48);
        this.btnMenuMember.Font = new Font("微软雅黑", 10F);
        this.btnMenuMember.TextAlign = ContentAlignment.MiddleLeft;
        this.btnMenuMember.Padding = new Padding(15, 0, 0, 0);
        this.btnMenuMember.Cursor = Cursors.Hand;
        this.btnMenuMember.Width = 160;
        this.btnMenuMember.Height = 45;
        this.btnMenuMember.Click += this.OnMenuClick;

        // btnMenuReport
        this.btnMenuReport.Text = "📊 数据统计";
        this.btnMenuReport.Tag = "report";
        this.btnMenuReport.FlatStyle = FlatStyle.Flat;
        this.btnMenuReport.FlatAppearance.BorderSize = 0;
        this.btnMenuReport.ForeColor = Color.White;
        this.btnMenuReport.BackColor = Color.FromArgb(45, 45, 48);
        this.btnMenuReport.Font = new Font("微软雅黑", 10F);
        this.btnMenuReport.TextAlign = ContentAlignment.MiddleLeft;
        this.btnMenuReport.Padding = new Padding(15, 0, 0, 0);
        this.btnMenuReport.Cursor = Cursors.Hand;
        this.btnMenuReport.Width = 160;
        this.btnMenuReport.Height = 45;
        this.btnMenuReport.Click += this.OnMenuClick;

        // pnlTopBar
        this.pnlTopBar.BackColor = Color.FromArgb(70, 130, 180);
        this.pnlTopBar.Controls.Add(this.lblTitle);
        this.pnlTopBar.Controls.Add(this.lblTodaySales);
        this.pnlTopBar.Dock = DockStyle.Top;
        this.pnlTopBar.Location = new Point(180, 0);
        this.pnlTopBar.Name = "pnlTopBar";
        this.pnlTopBar.Size = new Size(820, 60);
        this.pnlTopBar.TabIndex = 1;

        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new Font("微软雅黑", 16F, FontStyle.Bold);
        this.lblTitle.ForeColor = Color.White;
        this.lblTitle.Location = new Point(15, 15);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(160, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "门店管理系统";

        // lblTodaySales
        this.lblTodaySales.AutoSize = true;
        this.lblTodaySales.Font = new Font("微软雅黑", 12F);
        this.lblTodaySales.ForeColor = Color.FromArgb(255, 255, 200);
        this.lblTodaySales.Location = new Point(580, 18);
        this.lblTodaySales.Name = "lblTodaySales";
        this.lblTodaySales.Size = new Size(160, 21);
        this.lblTodaySales.TabIndex = 1;
        this.lblTodaySales.Text = "今日销售: ¥ 0.00";

        // pnlContent
        this.pnlContent.BackColor = Color.FromArgb(240, 240, 245);
        this.pnlContent.Dock = DockStyle.Fill;
        this.pnlContent.Location = new Point(180, 60);
        this.pnlContent.Name = "pnlContent";
        this.pnlContent.Size = new Size(820, 560);
        this.pnlContent.TabIndex = 2;

        // lblStatus
        this.lblStatus.BackColor = Color.FromArgb(45, 45, 48);
        this.lblStatus.Dock = DockStyle.Bottom;
        this.lblStatus.Font = new Font("微软雅黑", 9F);
        this.lblStatus.ForeColor = Color.White;
        this.lblStatus.Location = new Point(180, 620);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Padding = new Padding(10, 0, 0, 0);
        this.lblStatus.Size = new Size(820, 30);
        this.lblStatus.TabIndex = 3;
        this.lblStatus.Text = "就绪";

        // MainForm
        this.AutoScaleDimensions = new SizeF(7F, 17F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 650);
        this.Controls.Add(this.pnlContent);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.pnlTopBar);
        this.Controls.Add(this.pnlSidebar);
        this.Font = new Font("微软雅黑", 9F);
        this.MinimumSize = new Size(900, 600);
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "门店管理系统";
        this.flpMenu.ResumeLayout(false);
        this.pnlSidebar.ResumeLayout(false);
        this.pnlTopBar.ResumeLayout(false);
        this.pnlTopBar.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
