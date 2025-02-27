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
            panel1 = new Panel();
            btnCancel = new Button();
            btnAdd = new Button();
            tbName = new TextBox();
            label3 = new Label();
            tbAge = new TextBox();
            label2 = new Label();
            tbNo = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbAge);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbNo);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 301);
            panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 14F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(46, 226);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 39);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(151, 226);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 39);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 16F);
            tbName.Location = new Point(103, 72);
            tbName.Name = "tbName";
            tbName.Size = new Size(151, 36);
            tbName.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(24, 75);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 12;
            label3.Text = "Name";
            // 
            // tbAge
            // 
            tbAge.Font = new Font("Segoe UI", 16F);
            tbAge.Location = new Point(103, 140);
            tbAge.Name = "tbAge";
            tbAge.Size = new Size(151, 36);
            tbAge.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(24, 143);
            label2.Name = "label2";
            label2.Size = new Size(52, 30);
            label2.TabIndex = 10;
            label2.Text = "Age";
            // 
            // tbNo
            // 
            tbNo.Font = new Font("Segoe UI", 16F);
            tbNo.Location = new Point(103, 12);
            tbNo.Name = "tbNo";
            tbNo.Size = new Size(151, 36);
            tbNo.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(24, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 30);
            label1.TabIndex = 8;
            label1.Text = "No";
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(280, 301);
            ControlBox = false;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximumSize = new Size(296, 340);
            MinimumSize = new Size(296, 340);
            Name = "AddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCancel;
        private Button btnAdd;
        private TextBox tbNo;
        private TextBox tbName;
        private TextBox tbAge;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}