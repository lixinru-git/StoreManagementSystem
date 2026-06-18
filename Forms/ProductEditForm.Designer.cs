namespace StoreManagementSystem.Forms;

partial class ProductEditForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtName;
    private TextBox txtBarcode;
    private ComboBox cboCategory;
    private NumericUpDown nudCost;
    private NumericUpDown nudPrice;
    private NumericUpDown nudStock;
    private NumericUpDown nudThreshold;
    private Button btnOk;
    private Button btnCancel;
    private Label lblName;
    private Label lblBarcode;
    private Label lblCategory;
    private Label lblCost;
    private Label lblPrice;
    private Label lblStock;
    private Label lblThreshold;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblName = new Label();
        this.txtName = new TextBox();
        this.lblBarcode = new Label();
        this.txtBarcode = new TextBox();
        this.lblCategory = new Label();
        this.cboCategory = new ComboBox();
        this.lblCost = new Label();
        this.nudCost = new NumericUpDown();
        this.lblPrice = new Label();
        this.nudPrice = new NumericUpDown();
        this.lblStock = new Label();
        this.nudStock = new NumericUpDown();
        this.lblThreshold = new Label();
        this.nudThreshold = new NumericUpDown();
        this.btnOk = new Button();
        this.btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)this.nudCost).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.nudPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.nudStock).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.nudThreshold).BeginInit();
        this.SuspendLayout();

        this.Text = "商品编辑";
        this.Size = new Size(350, 370);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // lblName
        this.lblName.Text = "商品名称:";
        this.lblName.Location = new Point(15, 15);
        this.lblName.Size = new Size(80, 25);
        this.txtName.Location = new Point(100, 13);
        this.txtName.Size = new Size(200, 23);

        // lblBarcode
        this.lblBarcode.Text = "条码:";
        this.lblBarcode.Location = new Point(15, 50);
        this.lblBarcode.Size = new Size(80, 25);
        this.txtBarcode.Location = new Point(100, 48);
        this.txtBarcode.Size = new Size(200, 23);

        // lblCategory
        this.lblCategory.Text = "分类:";
        this.lblCategory.Location = new Point(15, 85);
        this.lblCategory.Size = new Size(80, 25);
        this.cboCategory.Location = new Point(100, 83);
        this.cboCategory.Size = new Size(200, 25);
        this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

        // lblCost
        this.lblCost.Text = "进价:";
        this.lblCost.Location = new Point(15, 120);
        this.lblCost.Size = new Size(80, 25);
        this.nudCost.Location = new Point(100, 118);
        this.nudCost.Size = new Size(100, 23);
        this.nudCost.DecimalPlaces = 2;
        this.nudCost.Maximum = 99999;

        // lblPrice
        this.lblPrice.Text = "售价:";
        this.lblPrice.Location = new Point(15, 155);
        this.lblPrice.Size = new Size(80, 25);
        this.nudPrice.Location = new Point(100, 153);
        this.nudPrice.Size = new Size(100, 23);
        this.nudPrice.DecimalPlaces = 2;
        this.nudPrice.Maximum = 99999;

        // lblStock
        this.lblStock.Text = "库存:";
        this.lblStock.Location = new Point(15, 190);
        this.lblStock.Size = new Size(80, 25);
        this.nudStock.Location = new Point(100, 188);
        this.nudStock.Size = new Size(100, 23);
        this.nudStock.Maximum = 99999;

        // lblThreshold
        this.lblThreshold.Text = "预警阈值:";
        this.lblThreshold.Location = new Point(15, 225);
        this.lblThreshold.Size = new Size(80, 25);
        this.nudThreshold.Location = new Point(100, 223);
        this.nudThreshold.Size = new Size(100, 23);
        this.nudThreshold.Maximum = 99999;
        this.nudThreshold.Value = 10;

        // btnOk
        this.btnOk.Text = "确定";
        this.btnOk.Location = new Point(70, 270);
        this.btnOk.Size = new Size(80, 30);
        this.btnOk.DialogResult = DialogResult.OK;
        this.btnOk.Click += this.BtnOk_Click;

        // btnCancel
        this.btnCancel.Text = "取消";
        this.btnCancel.Location = new Point(170, 270);
        this.btnCancel.Size = new Size(80, 30);
        this.btnCancel.DialogResult = DialogResult.Cancel;

        this.Controls.Add(this.lblName);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblBarcode);
        this.Controls.Add(this.txtBarcode);
        this.Controls.Add(this.lblCategory);
        this.Controls.Add(this.cboCategory);
        this.Controls.Add(this.lblCost);
        this.Controls.Add(this.nudCost);
        this.Controls.Add(this.lblPrice);
        this.Controls.Add(this.nudPrice);
        this.Controls.Add(this.lblStock);
        this.Controls.Add(this.nudStock);
        this.Controls.Add(this.lblThreshold);
        this.Controls.Add(this.nudThreshold);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);

        ((System.ComponentModel.ISupportInitialize)this.nudCost).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.nudPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.nudStock).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.nudThreshold).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
