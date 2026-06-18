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
    private Label lblS;
    private Label lblD;
    private Label lblT;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtSearch = new TextBox();
        btnSearch = new Button();
        dgvProducts = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        nudQty = new NumericUpDown();
        btnAddCart = new Button();
        btnRemoveCart = new Button();
        btnClearCart = new Button();
        dgvCart = new DataGridView();
        dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
        lblSubtotal = new Label();
        lblDiscount = new Label();
        lblTotal = new Label();
        cboPayment = new ComboBox();
        txtPhone = new TextBox();
        lblCustomerInfo = new Label();
        btnCheckout = new Button();
        dgvHistory = new DataGridView();
        dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
        lblTitle = new Label();
        grpSearch = new GroupBox();
        lblQty = new Label();
        lblCart = new Label();
        grpCheckout = new GroupBox();
        lblPay = new Label();
        lblPhone = new Label();
        btnFindMember = new Button();
        lblS = new Label();
        lblD = new Label();
        lblT = new Label();
        lblHistory = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQty).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
        grpSearch.SuspendLayout();
        grpCheckout.SuspendLayout();
        SuspendLayout();
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(6, 26);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(556, 30);
        txtSearch.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(568, 26);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(105, 33);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "搜索";
        btnSearch.Click += BtnSearch_Click;
        // 
        // dgvProducts
        // 
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeight = 34;
        dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
        dgvProducts.Location = new Point(15, 133);
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersWidth = 62;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(692, 200);
        dgvProducts.TabIndex = 2;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "ID";
        dataGridViewTextBoxColumn1.MinimumWidth = 8;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "商品名称";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "售价";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "库存";
        dataGridViewTextBoxColumn4.MinimumWidth = 8;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.ReadOnly = true;
        // 
        // nudQty
        // 
        nudQty.Location = new Point(78, 342);
        nudQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudQty.Name = "nudQty";
        nudQty.Size = new Size(75, 30);
        nudQty.TabIndex = 4;
        nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // btnAddCart
        // 
        btnAddCart.Location = new Point(179, 339);
        btnAddCart.Name = "btnAddCart";
        btnAddCart.Size = new Size(116, 33);
        btnAddCart.TabIndex = 5;
        btnAddCart.Text = "加入购物车";
        btnAddCart.Click += BtnAddCart_Click;
        // 
        // btnRemoveCart
        // 
        btnRemoveCart.Location = new Point(325, 339);
        btnRemoveCart.Name = "btnRemoveCart";
        btnRemoveCart.Size = new Size(102, 33);
        btnRemoveCart.TabIndex = 6;
        btnRemoveCart.Text = "移除选中";
        btnRemoveCart.Click += BtnRemoveCart_Click;
        // 
        // btnClearCart
        // 
        btnClearCart.Location = new Point(463, 339);
        btnClearCart.Name = "btnClearCart";
        btnClearCart.Size = new Size(77, 33);
        btnClearCart.TabIndex = 7;
        btnClearCart.Text = "清空";
        btnClearCart.Click += BtnClearCart_Click;
        // 
        // dgvCart
        // 
        dgvCart.AllowUserToAddRows = false;
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCart.ColumnHeadersHeight = 34;
        dgvCart.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
        dgvCart.Location = new Point(15, 411);
        dgvCart.Name = "dgvCart";
        dgvCart.ReadOnly = true;
        dgvCart.RowHeadersWidth = 62;
        dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCart.Size = new Size(692, 199);
        dgvCart.TabIndex = 9;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "ID";
        dataGridViewTextBoxColumn5.MinimumWidth = 8;
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.HeaderText = "商品名称";
        dataGridViewTextBoxColumn6.MinimumWidth = 8;
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.HeaderText = "单价";
        dataGridViewTextBoxColumn7.MinimumWidth = 8;
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn8
        // 
        dataGridViewTextBoxColumn8.HeaderText = "数量";
        dataGridViewTextBoxColumn8.MinimumWidth = 8;
        dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        dataGridViewTextBoxColumn8.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn9
        // 
        dataGridViewTextBoxColumn9.HeaderText = "小计";
        dataGridViewTextBoxColumn9.MinimumWidth = 8;
        dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        dataGridViewTextBoxColumn9.ReadOnly = true;
        // 
        // lblSubtotal
        // 
        lblSubtotal.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblSubtotal.Location = new Point(133, 280);
        lblSubtotal.Name = "lblSubtotal";
        lblSubtotal.Size = new Size(156, 25);
        lblSubtotal.TabIndex = 6;
        lblSubtotal.Text = "¥ 0.00";
        // 
        // lblDiscount
        // 
        lblDiscount.ForeColor = Color.Red;
        lblDiscount.Location = new Point(133, 340);
        lblDiscount.Name = "lblDiscount";
        lblDiscount.Size = new Size(137, 27);
        lblDiscount.TabIndex = 7;
        lblDiscount.Text = "- ¥ 0.00";
        // 
        // lblTotal
        // 
        lblTotal.Font = new Font("微软雅黑", 16F, FontStyle.Bold);
        lblTotal.ForeColor = Color.Red;
        lblTotal.Location = new Point(133, 392);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(156, 49);
        lblTotal.TabIndex = 8;
        lblTotal.Text = "¥ 0.00";
        // 
        // cboPayment
        // 
        cboPayment.Items.AddRange(new object[] { "Cash", "WeChat", "Alipay", "Card" });
        cboPayment.Location = new Point(119, 40);
        cboPayment.Name = "cboPayment";
        cboPayment.Size = new Size(118, 32);
        cboPayment.TabIndex = 1;
        cboPayment.SelectedIndexChanged += cboPayment_SelectedIndexChanged;
        // 
        // txtPhone
        // 
        txtPhone.Location = new Point(108, 87);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(213, 30);
        txtPhone.TabIndex = 3;
        // 
        // lblCustomerInfo
        // 
        lblCustomerInfo.ForeColor = Color.Gray;
        lblCustomerInfo.Location = new Point(19, 84);
        lblCustomerInfo.Name = "lblCustomerInfo";
        lblCustomerInfo.Size = new Size(260, 40);
        lblCustomerInfo.TabIndex = 5;
        // 
        // btnCheckout
        // 
        btnCheckout.BackColor = Color.FromArgb(70, 130, 180);
        btnCheckout.FlatStyle = FlatStyle.Flat;
        btnCheckout.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        btnCheckout.ForeColor = Color.White;
        btnCheckout.Location = new Point(35, 469);
        btnCheckout.Name = "btnCheckout";
        btnCheckout.Size = new Size(254, 47);
        btnCheckout.TabIndex = 9;
        btnCheckout.Text = "结算";
        btnCheckout.UseVisualStyleBackColor = false;
        btnCheckout.Click += BtnCheckout_Click;
        // 
        // dgvHistory
        // 
        dgvHistory.AllowUserToAddRows = false;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.ColumnHeadersHeight = 34;
        dgvHistory.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14 });
        dgvHistory.Location = new Point(15, 645);
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.RowHeadersWidth = 62;
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHistory.Size = new Size(1067, 176);
        dgvHistory.TabIndex = 12;
        // 
        // dataGridViewTextBoxColumn10
        // 
        dataGridViewTextBoxColumn10.HeaderText = "订单号";
        dataGridViewTextBoxColumn10.MinimumWidth = 8;
        dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        dataGridViewTextBoxColumn10.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn11
        // 
        dataGridViewTextBoxColumn11.HeaderText = "金额";
        dataGridViewTextBoxColumn11.MinimumWidth = 8;
        dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
        dataGridViewTextBoxColumn11.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn12
        // 
        dataGridViewTextBoxColumn12.HeaderText = "支付方式";
        dataGridViewTextBoxColumn12.MinimumWidth = 8;
        dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
        dataGridViewTextBoxColumn12.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn13
        // 
        dataGridViewTextBoxColumn13.HeaderText = "会员";
        dataGridViewTextBoxColumn13.MinimumWidth = 8;
        dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
        dataGridViewTextBoxColumn13.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn14
        // 
        dataGridViewTextBoxColumn14.HeaderText = "时间";
        dataGridViewTextBoxColumn14.MinimumWidth = 8;
        dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
        dataGridViewTextBoxColumn14.ReadOnly = true;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(15, 11);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(212, 51);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "销售收银";
        // 
        // grpSearch
        // 
        grpSearch.Controls.Add(txtSearch);
        grpSearch.Controls.Add(btnSearch);
        grpSearch.Location = new Point(15, 65);
        grpSearch.Name = "grpSearch";
        grpSearch.Size = new Size(692, 62);
        grpSearch.TabIndex = 1;
        grpSearch.TabStop = false;
        grpSearch.Text = "商品搜索";
        // 
        // lblQty
        // 
        lblQty.Location = new Point(15, 342);
        lblQty.Name = "lblQty";
        lblQty.Size = new Size(57, 28);
        lblQty.TabIndex = 3;
        lblQty.Text = "数量:";
        // 
        // lblCart
        // 
        lblCart.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblCart.Location = new Point(15, 378);
        lblCart.Name = "lblCart";
        lblCart.Size = new Size(121, 30);
        lblCart.TabIndex = 8;
        lblCart.Text = "购物车";
        // 
        // grpCheckout
        // 
        grpCheckout.Controls.Add(lblPay);
        grpCheckout.Controls.Add(cboPayment);
        grpCheckout.Controls.Add(lblPhone);
        grpCheckout.Controls.Add(txtPhone);
        grpCheckout.Controls.Add(btnFindMember);
        grpCheckout.Controls.Add(lblCustomerInfo);
        grpCheckout.Controls.Add(lblSubtotal);
        grpCheckout.Controls.Add(lblDiscount);
        grpCheckout.Controls.Add(lblTotal);
        grpCheckout.Controls.Add(btnCheckout);
        grpCheckout.Controls.Add(lblS);
        grpCheckout.Controls.Add(lblD);
        grpCheckout.Controls.Add(lblT);
        grpCheckout.Location = new Point(755, 65);
        grpCheckout.Name = "grpCheckout";
        grpCheckout.Size = new Size(327, 545);
        grpCheckout.TabIndex = 10;
        grpCheckout.TabStop = false;
        grpCheckout.Text = "结算";
        // 
        // lblPay
        // 
        lblPay.Location = new Point(19, 40);
        lblPay.Name = "lblPay";
        lblPay.Size = new Size(94, 30);
        lblPay.TabIndex = 0;
        lblPay.Text = "支付方式:";
        // 
        // lblPhone
        // 
        lblPhone.Location = new Point(19, 90);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(94, 37);
        lblPhone.TabIndex = 2;
        lblPhone.Text = "会员手机:";
        // 
        // btnFindMember
        // 
        btnFindMember.Location = new Point(253, 40);
        btnFindMember.Name = "btnFindMember";
        btnFindMember.Size = new Size(68, 32);
        btnFindMember.TabIndex = 4;
        btnFindMember.Text = "查询";
        btnFindMember.Click += BtnFindMember_Click;
        // 
        // lblS
        // 
        lblS.Location = new Point(19, 280);
        lblS.Name = "lblS";
        lblS.Size = new Size(85, 36);
        lblS.TabIndex = 10;
        lblS.Text = "小计:";
        // 
        // lblD
        // 
        lblD.Location = new Point(19, 340);
        lblD.Name = "lblD";
        lblD.Size = new Size(112, 39);
        lblD.TabIndex = 11;
        lblD.Text = "会员折扣:";
        // 
        // lblT
        // 
        lblT.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
        lblT.Location = new Point(19, 401);
        lblT.Name = "lblT";
        lblT.Size = new Size(85, 38);
        lblT.TabIndex = 12;
        lblT.Text = "合计:";
        // 
        // lblHistory
        // 
        lblHistory.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        lblHistory.Location = new Point(15, 613);
        lblHistory.Name = "lblHistory";
        lblHistory.Size = new Size(122, 29);
        lblHistory.TabIndex = 11;
        lblHistory.Text = "最近订单";
        // 
        // UC_Sale
        // 
        Controls.Add(lblTitle);
        Controls.Add(grpSearch);
        Controls.Add(dgvProducts);
        Controls.Add(lblQty);
        Controls.Add(nudQty);
        Controls.Add(btnAddCart);
        Controls.Add(btnRemoveCart);
        Controls.Add(btnClearCart);
        Controls.Add(lblCart);
        Controls.Add(dgvCart);
        Controls.Add(grpCheckout);
        Controls.Add(lblHistory);
        Controls.Add(dgvHistory);
        Name = "UC_Sale";
        Size = new Size(1122, 844);
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudQty).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
        grpSearch.ResumeLayout(false);
        grpSearch.PerformLayout();
        grpCheckout.ResumeLayout(false);
        grpCheckout.PerformLayout();
        ResumeLayout(false);
    }
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
}
