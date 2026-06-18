namespace StoreManagementSystem.Forms;

partial class MemberEditForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtName;
    private TextBox txtPhone;
    private ComboBox cboLevel;
    private Button btnOk;
    private Button btnCancel;
    private Label lblName;
    private Label lblPhone;
    private Label lblLevel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblName = new Label();
        this.txtName = new TextBox();
        this.lblPhone = new Label();
        this.txtPhone = new TextBox();
        this.lblLevel = new Label();
        this.cboLevel = new ComboBox();
        this.btnOk = new Button();
        this.btnCancel = new Button();
        this.SuspendLayout();

        this.Text = "会员编辑";
        this.Size = new Size(320, 250);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // lblName
        this.lblName.Text = "姓名:";
        this.lblName.Location = new Point(15, 15);
        this.lblName.Size = new Size(60, 25);
        this.txtName.Location = new Point(80, 13);
        this.txtName.Size = new Size(200, 23);

        // lblPhone
        this.lblPhone.Text = "手机号:";
        this.lblPhone.Location = new Point(15, 50);
        this.lblPhone.Size = new Size(60, 25);
        this.txtPhone.Location = new Point(80, 48);
        this.txtPhone.Size = new Size(200, 23);

        // lblLevel
        this.lblLevel.Text = "等级:";
        this.lblLevel.Location = new Point(15, 85);
        this.lblLevel.Size = new Size(60, 25);
        this.cboLevel.Location = new Point(80, 83);
        this.cboLevel.Size = new Size(120, 25);
        this.cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboLevel.Items.Add("Regular");
        this.cboLevel.Items.Add("Silver");
        this.cboLevel.Items.Add("Gold");
        this.cboLevel.SelectedIndex = 0;

        // btnOk
        this.btnOk.Text = "确定";
        this.btnOk.Location = new Point(70, 140);
        this.btnOk.Size = new Size(80, 30);
        this.btnOk.DialogResult = DialogResult.OK;
        this.btnOk.Click += this.BtnOk_Click;

        // btnCancel
        this.btnCancel.Text = "取消";
        this.btnCancel.Location = new Point(170, 140);
        this.btnCancel.Size = new Size(80, 30);
        this.btnCancel.DialogResult = DialogResult.Cancel;

        this.Controls.Add(this.lblName);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblPhone);
        this.Controls.Add(this.txtPhone);
        this.Controls.Add(this.lblLevel);
        this.Controls.Add(this.cboLevel);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.btnCancel);

        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
