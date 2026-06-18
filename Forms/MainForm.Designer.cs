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
        pnlSidebar = new Panel();
        flpMenu = new FlowLayoutPanel();
        pnlContent = new Panel();
        pnlTopBar = new Panel();
        lblTitle = new Label();
        lblTodaySales = new Label();
        lblStatus = new Label();
        pnlSidebar.SuspendLayout();
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
        pnlSidebar.Size = new Size(180, 866);
        pnlSidebar.TabIndex = 0;
        // 
        // flpMenu
        // 
        flpMenu.AutoScroll = true;
        flpMenu.BackColor = Color.FromArgb(45, 45, 48);
        flpMenu.Dock = DockStyle.Fill;
        flpMenu.FlowDirection = FlowDirection.TopDown;
        flpMenu.Location = new Point(0, 0);
        flpMenu.Name = "flpMenu";
        flpMenu.Padding = new Padding(5, 10, 5, 10);
        flpMenu.Size = new Size(180, 866);
        flpMenu.TabIndex = 0;
        flpMenu.WrapContents = false;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = Color.FromArgb(240, 240, 245);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(180, 60);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(1180, 776);
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
        pnlTopBar.Size = new Size(1180, 60);
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
        lblTodaySales.Location = new Point(410, 24);
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
        lblStatus.Location = new Point(180, 836);
        lblStatus.Name = "lblStatus";
        lblStatus.Padding = new Padding(10, 0, 0, 0);
        lblStatus.Size = new Size(1180, 30);
        lblStatus.TabIndex = 3;
        lblStatus.Text = "就绪";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1360, 866);
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
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        ResumeLayout(false);
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
