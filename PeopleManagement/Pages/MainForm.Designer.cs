namespace PeopleManagement.Pages;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        label2 = new Label();
        cbSort = new ComboBox();
        panel2 = new Panel();
        btnDelete = new Button();
        btnEdit = new Button();
        btnNew = new Button();
        dgvPers = new DataGridView();
        label1 = new Label();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPers).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.BackColor = Color.Transparent;
        panel1.Controls.Add(label2);
        panel1.Controls.Add(cbSort);
        panel1.Controls.Add(panel2);
        panel1.Controls.Add(dgvPers);
        panel1.Controls.Add(label1);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(644, 389);
        panel1.TabIndex = 0;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14F);
        label2.Location = new Point(297, 13);
        label2.Name = "label2";
        label2.Size = new Size(50, 25);
        label2.TabIndex = 9;
        label2.Text = "Sort:";
        // 
        // cbSort
        // 
        cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        cbSort.Font = new Font("Segoe UI", 11F);
        cbSort.FormattingEnabled = true;
        cbSort.Location = new Point(396, 12);
        cbSort.Name = "cbSort";
        cbSort.Size = new Size(121, 28);
        cbSort.TabIndex = 8;
        // 
        // panel2
        // 
        panel2.BackColor = Color.Transparent;
        panel2.Controls.Add(btnDelete);
        panel2.Controls.Add(btnEdit);
        panel2.Controls.Add(btnNew);
        panel2.Dock = DockStyle.Right;
        panel2.Location = new Point(523, 0);
        panel2.Name = "panel2";
        panel2.Size = new Size(121, 389);
        panel2.TabIndex = 7;
        // 
        // btnDelete
        // 
        btnDelete.BackColor = Color.Red;
        btnDelete.FlatStyle = FlatStyle.Popup;
        btnDelete.Font = new Font("Segoe UI", 14F);
        btnDelete.ForeColor = Color.White;
        btnDelete.Location = new Point(11, 140);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(95, 39);
        btnDelete.TabIndex = 12;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = false;
        // 
        // btnEdit
        // 
        btnEdit.BackColor = Color.Coral;
        btnEdit.FlatStyle = FlatStyle.Popup;
        btnEdit.Font = new Font("Segoe UI", 14F);
        btnEdit.ForeColor = Color.White;
        btnEdit.Location = new Point(11, 95);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(95, 39);
        btnEdit.TabIndex = 11;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = false;
        // 
        // btnNew
        // 
        btnNew.BackColor = Color.DodgerBlue;
        btnNew.FlatStyle = FlatStyle.Popup;
        btnNew.Font = new Font("Segoe UI", 14F);
        btnNew.ForeColor = Color.White;
        btnNew.Location = new Point(11, 50);
        btnNew.Name = "btnNew";
        btnNew.Size = new Size(95, 39);
        btnNew.TabIndex = 10;
        btnNew.Text = "New";
        btnNew.UseVisualStyleBackColor = false;
        // 
        // dgvPers
        // 
        dgvPers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvPers.BackgroundColor = Color.Snow;
        dgvPers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPers.Location = new Point(12, 50);
        dgvPers.Name = "dgvPers";
        dgvPers.Size = new Size(505, 327);
        dgvPers.TabIndex = 6;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 16F);
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(214, 30);
        label1.TabIndex = 5;
        label1.Text = "People Management";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        ClientSize = new Size(644, 389);
        Controls.Add(panel1);
        MaximumSize = new Size(660, 428);
        MinimumSize = new Size(660, 428);
        Name = "MainForm";
        Text = "People Management";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPers).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Panel panel2;
    private Button btnDelete;
    private Button btnEdit;
    private Button btnNew;
    private DataGridView dgvPers;
    private Label label1;
    private ComboBox cbSort;
    private Label label2;
}
