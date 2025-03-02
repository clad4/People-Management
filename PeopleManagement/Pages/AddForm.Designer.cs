namespace PeopleManagement.Pages
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAdd = new Button();
            btnCancel = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbOther = new TextBox();
            tbAge = new TextBox();
            tbName = new TextBox();
            tbNo = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(btnAdd, 3, 1);
            tableLayoutPanel1.Controls.Add(btnCancel, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 231);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(280, 70);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(157, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(92, 43);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 14F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(31, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(92, 43);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.76190472F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.523809F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.61905F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.523809F));
            tableLayoutPanel2.Controls.Add(tbOther, 3, 4);
            tableLayoutPanel2.Controls.Add(tbAge, 3, 3);
            tableLayoutPanel2.Controls.Add(tbName, 3, 2);
            tableLayoutPanel2.Controls.Add(tbNo, 3, 1);
            tableLayoutPanel2.Controls.Add(label1, 1, 1);
            tableLayoutPanel2.Controls.Add(label3, 1, 2);
            tableLayoutPanel2.Controls.Add(label2, 1, 3);
            tableLayoutPanel2.Controls.Add(label4, 1, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Size = new Size(280, 231);
            tableLayoutPanel2.TabIndex = 20;
            // 
            // tbOther
            // 
            tbOther.Font = new Font("Segoe UI", 16F);
            tbOther.Location = new Point(122, 164);
            tbOther.Name = "tbOther";
            tbOther.Size = new Size(127, 36);
            tbOther.TabIndex = 17;
            // 
            // tbAge
            // 
            tbAge.Font = new Font("Segoe UI", 16F);
            tbAge.Location = new Point(122, 118);
            tbAge.Name = "tbAge";
            tbAge.Size = new Size(127, 36);
            tbAge.TabIndex = 11;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 16F);
            tbName.Location = new Point(122, 72);
            tbName.Name = "tbName";
            tbName.Size = new Size(127, 36);
            tbName.TabIndex = 13;
            // 
            // tbNo
            // 
            tbNo.Font = new Font("Segoe UI", 16F);
            tbNo.Location = new Point(122, 26);
            tbNo.Name = "tbNo";
            tbNo.Size = new Size(127, 36);
            tbNo.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(16, 23);
            label1.Name = "label1";
            label1.Size = new Size(42, 30);
            label1.TabIndex = 8;
            label1.Text = "No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(16, 69);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 12;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(16, 115);
            label2.Name = "label2";
            label2.Size = new Size(52, 30);
            label2.TabIndex = 10;
            label2.Text = "Age";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Location = new Point(16, 161);
            label4.Name = "label4";
            label4.Size = new Size(69, 30);
            label4.TabIndex = 16;
            label4.Text = "Other";
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(280, 301);
            ControlBox = false;
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximumSize = new Size(296, 340);
            MinimumSize = new Size(296, 340);
            Name = "AddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnAdd;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox tbOther;
        private TextBox tbAge;
        private TextBox tbName;
        private TextBox tbNo;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
    }
}