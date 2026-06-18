namespace StoreManagementSystem.Forms;

partial class MainForm
{
    private Panel pnlSidebar;
    private FlowLayoutPanel flpMenu;
    private Panel pnlContent;
    private Panel pnlTopBar;
    private Label lblTitle;
    private Label lblTodaySales;
    private Label lblStatus;

    private void InitializeComponent()
    {
        this.pnlSidebar = new Panel();
        this.flpMenu = new FlowLayoutPanel();
        this.pnlContent = new Panel();
        this.pnlTopBar = new Panel();
        this.lblTitle = new Label();
        this.lblTodaySales = new Label();
        this.lblStatus = new Label();
        this.pnlSidebar.SuspendLayout();
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
        this.flpMenu.Dock = DockStyle.Fill;
        this.flpMenu.FlowDirection = FlowDirection.TopDown;
        this.flpMenu.Location = new Point(0, 0);
        this.flpMenu.Name = "flpMenu";
        this.flpMenu.Padding = new Padding(5, 10, 5, 10);
        this.flpMenu.Size = new Size(180, 650);
        this.flpMenu.TabIndex = 0;
        this.flpMenu.WrapContents = false;

        // 添加菜单按钮
        AddMenuButton("🏪 销售收银", "sale");
        AddMenuButton("📦 商品管理", "product");
        AddMenuButton("📋 库存管理", "stock");
        AddMenuButton("👥 会员管理", "member");
        AddMenuButton("📊 数据统计", "report");

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
        this.lblTitle.Font = new Font("微软雅黑", 16, FontStyle.Bold);
        this.lblTitle.ForeColor = Color.White;
        this.lblTitle.Location = new Point(15, 15);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(200, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "门店管理系统";

        // lblTodaySales
        this.lblTodaySales.AutoSize = true;
        this.lblTodaySales.Font = new Font("微软雅黑", 12);
        this.lblTodaySales.ForeColor = Color.FromArgb(255, 255, 200);
        this.lblTodaySales.Location = new Point(650, 18);
        this.lblTodaySales.Name = "lblTodaySales";
        this.lblTodaySales.Size = new Size(150, 21);
        this.lblTodaySales.TabIndex = 1;
        this.lblTodaySales.Text = "今日销售: ¥ 0.00";

        // pnlContent
        this.pnlContent.BackColor = Color.FromArgb(240, 240, 245);
        this.pnlContent.Dock = DockStyle.Fill;
        this.pnlContent.Location = new Point(180, 60);
        this.pnlContent.Name = "pnlContent";
        this.pnlContent.Size = new Size(820, 590);
        this.pnlContent.TabIndex = 2;

        // lblStatus (状态栏)
        this.lblStatus = new Label();
        this.lblStatus.BackColor = Color.FromArgb(45, 45, 48);
        this.lblStatus.Dock = DockStyle.Bottom;
        this.lblStatus.Font = new Font("微软雅黑", 9);
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
        this.pnlSidebar.ResumeLayout(false);
        this.pnlTopBar.ResumeLayout(false);
        this.pnlTopBar.PerformLayout();
        this.ResumeLayout(false);
    }

    private void AddMenuButton(string text, string tag)
    {
        var btn = new Button
        {
            Text = text,
            Tag = tag,
            Width = 160,
            Height = 45,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0 },
            ForeColor = Color.White,
            BackColor = Color.FromArgb(45, 45, 48),
            Font = new Font("微软雅黑", 10),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(15, 0, 0, 0),
            Cursor = Cursors.Hand
        };
        btn.Click += OnMenuClick;
        flpMenu.Controls.Add(btn);
    }
}
