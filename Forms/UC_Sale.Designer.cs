namespace StoreManagementSystem.Forms;

partial class UC_Sale
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtSearch;
    private DataGridView dgvProducts;
    private DataGridView dgvCart;
    private DataGridView dgvHistory;
    private ComboBox cboPayment;
    private TextBox txtPhone;
    private Button btnAddCart;
    private Button btnRemoveCart;
    private Button btnCheckout;
    private Button btnSearch;
    private Button btnClearCart;
    private Label lblSubtotal;
    private Label lblDiscount;
    private Label lblTotal;
    private Label lblCustomerInfo;
    private NumericUpDown nudQty;
    private Label lblTitle;
    private GroupBox grpSearch;
    private Label lblQty;
    private Label lblCart;
    private GroupBox grpCheckout;
    private Label lblHistory;
    private Button btnFindMember;
    private Label lblPay;
    private Label lblPhone;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.dgvProducts = new DataGridView();
        this.nudQty = new NumericUpDown();
        this.btnAddCart = new Button();
        this.btnRemoveCart = new Button();
        this.btnClearCart = new Button();
        this.dgvCart = new DataGridView();
        this.lblSubtotal = new Label();
        this.lblDiscount = new Label();
        this.lblTotal = new Label();
        this.cboPayment = new ComboBox();
        this.txtPhone = new TextBox();
        this.lblCustomerInfo = new Label();
        this.btnCheckout = new Button();
        this.dgvHistory = new DataGridView();
        this.lblTitle = new Label();
        this.grpSearch = new GroupBox();
        this.lblQty = new Label();
        this.lblCart = new Label();
        this.grpCheckout = new GroupBox();
        this.lblHistory = new Label();
        this.btnFindMember = new Button();
        this.lblPay = new Label();
        this.lblPhone = new Label();
        ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.nudQty).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvCart).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvHistory).BeginInit();
        this.grpSearch.SuspendLayout();
        this.grpCheckout.SuspendLayout();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.Text = "销售收银";
        this.lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        this.lblTitle.Location = new Point(15, 10);
        this.lblTitle.Size = new Size(200, 30);

        // grpSearch
        this.grpSearch.Text = "商品搜索";
        this.grpSearch.Location = new Point(15, 45);
        this.grpSearch.Size = new Size(480, 55);
        this.txtSearch.Location = new Point(10, 22);
        this.txtSearch.Size = new Size(300, 23);
        this.btnSearch.Text = "搜索";
        this.btnSearch.Location = new Point(320, 20);
        this.btnSearch.Size = new Size(70, 28);
        this.btnSearch.Click += this.BtnSearch_Click;
        this.grpSearch.Controls.Add(this.txtSearch);
        this.grpSearch.Controls.Add(this.btnSearch);

        // dgvProducts
        this.dgvProducts.Location = new Point(15, 105);
        this.dgvProducts.Size = new Size(480, 200);
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.Columns.Add("Id", "ID");
        this.dgvProducts.Columns[0].Width = 40;
        this.dgvProducts.Columns.Add("Name", "商品名称");
        this.dgvProducts.Columns.Add("Price", "售价");
        this.dgvProducts.Columns[2].Width = 60;
        this.dgvProducts.Columns.Add("Stock", "库存");
        this.dgvProducts.Columns[3].Width = 50;

        // lblQty
        this.lblQty.Text = "数量:";
        this.lblQty.Location = new Point(15, 315);
        this.lblQty.Size = new Size(40, 25);

        // nudQty
        this.nudQty.Location = new Point(55, 313);
        this.nudQty.Size = new Size(60, 23);
        this.nudQty.Minimum = 1;
        this.nudQty.Maximum = 999;
        this.nudQty.Value = 1;

        // btnAddCart
        this.btnAddCart.Text = "加入购物车";
        this.btnAddCart.Location = new Point(125, 310);
        this.btnAddCart.Size = new Size(100, 30);
        this.btnAddCart.Click += this.BtnAddCart_Click;

        // btnRemoveCart
        this.btnRemoveCart.Text = "移除选中";
        this.btnRemoveCart.Location = new Point(235, 310);
        this.btnRemoveCart.Size = new Size(80, 30);
        this.btnRemoveCart.Click += this.BtnRemoveCart_Click;

        // btnClearCart
        this.btnClearCart.Text = "清空";
        this.btnClearCart.Location = new Point(325, 310);
        this.btnClearCart.Size = new Size(60, 30);
        this.btnClearCart.Click += this.BtnClearCart_Click;

        // lblCart
        this.lblCart.Text = "购物车";
        this.lblCart.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        this.lblCart.Location = new Point(15, 350);
        this.lblCart.Size = new Size(80, 20);

        // dgvCart
        this.dgvCart.Location = new Point(15, 375);
        this.dgvCart.Size = new Size(480, 150);
        this.dgvCart.ReadOnly = true;
        this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvCart.AllowUserToAddRows = false;
        this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCart.Columns.Add("CartId", "ID");
        this.dgvCart.Columns[0].Width = 30;
        this.dgvCart.Columns.Add("CartName", "商品名称");
        this.dgvCart.Columns.Add("CartPrice", "单价");
        this.dgvCart.Columns[2].Width = 60;
        this.dgvCart.Columns.Add("CartQty", "数量");
        this.dgvCart.Columns[3].Width = 50;
        this.dgvCart.Columns.Add("CartSub", "小计");
        this.dgvCart.Columns[4].Width = 70;

        // grpCheckout
        this.grpCheckout.Text = "结算";
        this.grpCheckout.Location = new Point(510, 45);
        this.grpCheckout.Size = new Size(290, 480);

        this.lblPay.Text = "支付方式:";
        this.lblPay.Location = new Point(10, 25);
        this.lblPay.Size = new Size(70, 25);
        this.cboPayment.Location = new Point(85, 23);
        this.cboPayment.Size = new Size(100, 25);
        this.cboPayment.Items.Add("Cash");
        this.cboPayment.Items.Add("WeChat");
        this.cboPayment.Items.Add("Alipay");
        this.cboPayment.Items.Add("Card");
        this.cboPayment.SelectedIndex = 0;

        this.lblPhone.Text = "会员手机:";
        this.lblPhone.Location = new Point(10, 60);
        this.lblPhone.Size = new Size(70, 25);
        this.txtPhone.Location = new Point(85, 58);
        this.txtPhone.Size = new Size(120, 23);
        this.btnFindMember.Text = "查询";
        this.btnFindMember.Location = new Point(210, 56);
        this.btnFindMember.Size = new Size(50, 28);
        this.btnFindMember.Click += this.BtnFindMember_Click;

        this.lblCustomerInfo.Location = new Point(10, 90);
        this.lblCustomerInfo.Size = new Size(260, 40);
        this.lblCustomerInfo.ForeColor = Color.Gray;

        // 金额汇总
        this.lblSubtotal.Location = new Point(100, 140);
        this.lblSubtotal.Size = new Size(160, 25);
        this.lblSubtotal.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        this.lblSubtotal.Text = "¥ 0.00";
        this.lblDiscount.Location = new Point(100, 170);
        this.lblDiscount.Size = new Size(160, 25);
        this.lblDiscount.ForeColor = Color.Red;
        this.lblDiscount.Text = "- ¥ 0.00";
        this.lblTotal.Location = new Point(80, 210);
        this.lblTotal.Size = new Size(180, 30);
        this.lblTotal.Font = new Font("微软雅黑", 16F, FontStyle.Bold);
        this.lblTotal.ForeColor = Color.Red;
        this.lblTotal.Text = "¥ 0.00";

        this.grpCheckout.Controls.Add(this.lblPay);
        this.grpCheckout.Controls.Add(this.cboPayment);
        this.grpCheckout.Controls.Add(this.lblPhone);
        this.grpCheckout.Controls.Add(this.txtPhone);
        this.grpCheckout.Controls.Add(this.btnFindMember);
        this.grpCheckout.Controls.Add(this.lblCustomerInfo);
        this.grpCheckout.Controls.Add(this.lblSubtotal);
        this.grpCheckout.Controls.Add(this.lblDiscount);
        this.grpCheckout.Controls.Add(this.lblTotal);

        // btnCheckout
        this.btnCheckout.Text = "结算";
        this.btnCheckout.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        this.btnCheckout.Location = new Point(15, 260);
        this.btnCheckout.Size = new Size(250, 45);
        this.btnCheckout.BackColor = Color.FromArgb(70, 130, 180);
        this.btnCheckout.ForeColor = Color.White;
        this.btnCheckout.FlatStyle = FlatStyle.Flat;
        this.btnCheckout.Click += this.BtnCheckout_Click;
        this.grpCheckout.Controls.Add(this.btnCheckout);

        // 小计/折扣/合计标签(静态文本)
        Label lblS = new Label();
        lblS.Text = "小计:";
        lblS.Location = new Point(10, 140);
        lblS.Size = new Size(80, 25);
        this.grpCheckout.Controls.Add(lblS);
        Label lblD = new Label();
        lblD.Text = "会员折扣:";
        lblD.Location = new Point(10, 170);
        lblD.Size = new Size(80, 25);
        this.grpCheckout.Controls.Add(lblD);
        Label lblT = new Label();
        lblT.Text = "合计:";
        lblT.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        lblT.Location = new Point(10, 210);
        lblT.Size = new Size(80, 30);
        this.grpCheckout.Controls.Add(lblT);

        // lblHistory
        this.lblHistory.Text = "最近订单";
        this.lblHistory.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        this.lblHistory.Location = new Point(15, 535);
        this.lblHistory.Size = new Size(80, 20);

        // dgvHistory
        this.dgvHistory.Location = new Point(15, 558);
        this.dgvHistory.Size = new Size(785, 150);
        this.dgvHistory.ReadOnly = true;
        this.dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvHistory.AllowUserToAddRows = false;
        this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvHistory.Columns.Add("HOrderNo", "订单号");
        this.dgvHistory.Columns[0].Width = 160;
        this.dgvHistory.Columns.Add("HTotal", "金额");
        this.dgvHistory.Columns[1].Width = 80;
        this.dgvHistory.Columns.Add("HPayment", "支付方式");
        this.dgvHistory.Columns[2].Width = 80;
        this.dgvHistory.Columns.Add("HCustomer", "会员");
        this.dgvHistory.Columns[3].Width = 80;
        this.dgvHistory.Columns.Add("HTime", "时间");

        // 添加到控件
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.grpSearch);
        this.Controls.Add(this.dgvProducts);
        this.Controls.Add(this.lblQty);
        this.Controls.Add(this.nudQty);
        this.Controls.Add(this.btnAddCart);
        this.Controls.Add(this.btnRemoveCart);
        this.Controls.Add(this.btnClearCart);
        this.Controls.Add(this.lblCart);
        this.Controls.Add(this.dgvCart);
        this.Controls.Add(this.grpCheckout);
        this.Controls.Add(this.lblHistory);
        this.Controls.Add(this.dgvHistory);

        ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.nudQty).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvCart).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dgvHistory).EndInit();
        this.grpSearch.ResumeLayout(false);
        this.grpSearch.PerformLayout();
        this.grpCheckout.ResumeLayout(false);
        this.grpCheckout.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
