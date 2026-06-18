namespace StoreManagementSystem.Forms;

partial class StockInOutForm
{
    private System.ComponentModel.IContainer components = null;

    private ComboBox cboProduct;
    private NumericUpDown nudQty;
    private NumericUpDown nudCost;
    private TextBox txtSupplier;
    private TextBox txtRemark;
    private Button btnOk;
    private Button btnCancel;
    private Label lblProduct;
    private Label lblQty;
    private Label lblCost;
    private Label lblSupplier;
    private Label lblRemark;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblProduct = new Label();
        this.cboProduct = new ComboBox();
        this.lblQty = new Label();
        this.nudQty = new NumericUpDown();
        this.lblCost = new Label();
        this.nudCost = new NumericUpDown();
        this.lblSupplier = new Label();
        this.txtSupplier = new TextBox();
        this.lblRemark = new Label();
        this.txtRemark = new TextBox();
        this.btnOk = new Button();
        this.btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)this.nudQty).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.nudCost).BeginInit();
        this.SuspendLayout();

        this.Text = "入库/出库";
        this.Size = new Size(350, 320);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // lblProduct
        this.lblProduct.Text = "商品:";
        this.lblProduct.Location = new Point(15, 15);
        this.lblProduct.Size = new Size(60, 25);
        this.cboProduct.Location = new Point(80, 13);
        this.cboProduct.Size = new Size(220, 25);
        this.cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboProduct.DisplayMember = "Name";
        this.cboProduct.ValueMember = "Id";

        // lblQty
        this.lblQty.Text = "数量:";
        this.lblQty.Location = new Point(15, 50);
        this.lblQty.Size = new Size(60, 25);
        this.nudQty.Location = new Point(80, 48);
        this.nudQty.Size = new Size(100, 23);
        this.nudQty.Minimum = 1;
        this.nudQty.Maximum = 99999;

        // lblCost
        this.lblCost.Text = "单价:";
        this.lblCost.Location = new Point(15, 85);
        this.lblCost.Size = new Size(60, 25);
        this.nudCost.Location = new Point(80, 83);
        this.nudCost.Size = new Size(100, 23);
        this.nudCost.DecimalPlaces = 2;
        this.nudCost.Maximum = 99999;

        // lblSupplier
        this.lblSupplier.Text = "供应商:";
        this.lblSupplier.Location = new Point(15, 120);
        this.lblSupplier.Size = new Size(60, 25);
        this.txtSupplier.Location = new Point(80, 118);
        this.txtSupplier.Size = new Size(220, 23);

        // lblRemark
        this.lblRemark.Text = "备注:";
        this.lblRemark.Location = new Point(15, 155);
        this.lblRemark.Size = new Size(60, 25);
        this.txtRemark.Location = new Point(80, 153);
        this.txtRemark.Size = new Size(220, 23);

        // btnOk
        this.btnOk.Text = "确定";
        this.btnOk.Location = new Point(80, 200);
        this.btnOk.Size = new Size(80, 30);
        this.btnOk.DialogResult = DialogResult.OK;
        this.btnOk.Click += this.BtnOk_Click;

        // btnCancel
        this.btnCancel.Text = "取消";
        this.btnCancel.Location = new Point(180, 200);
        this.btnCancel.Size = new Size(80, 30);
        this.btnCancel.DialogResult = DialogResult.Cancel;

        this.Controls.Add(this.lblProduct);
        this.Controls.Add(this.cboProduct);
        this.Controls.Add(this.lblQty);
        this.Controls.Add(this.nudQty);
        this.Controls.Add(this.lblCost);
        this.Controls.Add(this.nudCost);
        this.Controls.Add(this.lblSupplier);
        this.Controls.Add(this.txtSupplier);
        this.Controls.Add(this.lblRemark);
        this.Controls.Add(this.txtRemark);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);

        ((System.ComponentModel.ISupportInitialize)this.nudQty).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.nudCost).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
