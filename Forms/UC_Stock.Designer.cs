namespace StoreManagementSystem.Forms;

partial class UC_Stock
{
    private System.ComponentModel.IContainer components = null;

    private TabControl tabControl;
    private DataGridView dgvStockIn;
    private DataGridView dgvStockOut;
    private Button btnStockIn;
    private Button btnStockOut;
    private Label lblTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tabControl = new TabControl();
        tabIn = new TabPage();
        dgvStockIn = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        tabOut = new TabPage();
        dgvStockOut = new DataGridView();
        dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
        btnStockIn = new Button();
        btnStockOut = new Button();
        lblTitle = new Label();
        tabControl.SuspendLayout();
        tabIn.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStockIn).BeginInit();
        tabOut.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStockOut).BeginInit();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Controls.Add(tabIn);
        tabControl.Controls.Add(tabOut);
        tabControl.Location = new Point(24, 126);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(780, 486);
        tabControl.TabIndex = 3;
        // 
        // tabIn
        // 
        tabIn.Controls.Add(dgvStockIn);
        tabIn.Location = new Point(4, 33);
        tabIn.Name = "tabIn";
        tabIn.Size = new Size(772, 449);
        tabIn.TabIndex = 0;
        tabIn.Text = "入库记录";
        // 
        // dgvStockIn
        // 
        dgvStockIn.AllowUserToAddRows = false;
        dgvStockIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStockIn.ColumnHeadersHeight = 34;
        dgvStockIn.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
        dgvStockIn.Dock = DockStyle.Fill;
        dgvStockIn.Location = new Point(0, 0);
        dgvStockIn.Name = "dgvStockIn";
        dgvStockIn.ReadOnly = true;
        dgvStockIn.RowHeadersWidth = 62;
        dgvStockIn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStockIn.Size = new Size(772, 449);
        dgvStockIn.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "商品";
        dataGridViewTextBoxColumn1.MinimumWidth = 8;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "数量";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "单价";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "供应商";
        dataGridViewTextBoxColumn4.MinimumWidth = 8;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "备注";
        dataGridViewTextBoxColumn5.MinimumWidth = 8;
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.HeaderText = "时间";
        dataGridViewTextBoxColumn6.MinimumWidth = 8;
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.ReadOnly = true;
        // 
        // tabOut
        // 
        tabOut.Controls.Add(dgvStockOut);
        tabOut.Location = new Point(4, 33);
        tabOut.Name = "tabOut";
        tabOut.Size = new Size(772, 449);
        tabOut.TabIndex = 1;
        tabOut.Text = "出库记录";
        // 
        // dgvStockOut
        // 
        dgvStockOut.AllowUserToAddRows = false;
        dgvStockOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStockOut.ColumnHeadersHeight = 34;
        dgvStockOut.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11 });
        dgvStockOut.Dock = DockStyle.Fill;
        dgvStockOut.Location = new Point(0, 0);
        dgvStockOut.Name = "dgvStockOut";
        dgvStockOut.ReadOnly = true;
        dgvStockOut.RowHeadersWidth = 62;
        dgvStockOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStockOut.Size = new Size(772, 449);
        dgvStockOut.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.HeaderText = "商品";
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
        dataGridViewTextBoxColumn9.HeaderText = "原因";
        dataGridViewTextBoxColumn9.MinimumWidth = 8;
        dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        dataGridViewTextBoxColumn9.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn10
        // 
        dataGridViewTextBoxColumn10.HeaderText = "备注";
        dataGridViewTextBoxColumn10.MinimumWidth = 8;
        dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        dataGridViewTextBoxColumn10.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn11
        // 
        dataGridViewTextBoxColumn11.HeaderText = "时间";
        dataGridViewTextBoxColumn11.MinimumWidth = 8;
        dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
        dataGridViewTextBoxColumn11.ReadOnly = true;
        // 
        // btnStockIn
        // 
        btnStockIn.Location = new Point(28, 68);
        btnStockIn.Name = "btnStockIn";
        btnStockIn.Size = new Size(84, 42);
        btnStockIn.TabIndex = 1;
        btnStockIn.Text = "＋ 入库";
        btnStockIn.Click += BtnStockIn_Click;
        // 
        // btnStockOut
        // 
        btnStockOut.Location = new Point(135, 68);
        btnStockOut.Name = "btnStockOut";
        btnStockOut.Size = new Size(80, 42);
        btnStockOut.TabIndex = 2;
        btnStockOut.Text = "＋ 出库";
        btnStockOut.Click += BtnStockOut_Click;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(28, 10);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(211, 55);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "库存管理";
        // 
        // UC_Stock
        // 
        Controls.Add(lblTitle);
        Controls.Add(btnStockIn);
        Controls.Add(btnStockOut);
        Controls.Add(tabControl);
        Name = "UC_Stock";
        Size = new Size(831, 632);
        tabControl.ResumeLayout(false);
        tabIn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvStockIn).EndInit();
        tabOut.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvStockOut).EndInit();
        ResumeLayout(false);
    }
    private TabPage tabIn;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private TabPage tabOut;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
}
