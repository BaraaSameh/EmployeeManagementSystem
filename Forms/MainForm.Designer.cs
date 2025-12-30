namespace EmployeeManagementSystem.Forms
{
    partial class MainForm
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
            button1 = new Button();
            btnReports = new Button();
            btnLeaves = new Button();
            btnAttendance = new Button();
            btnEmployees = new Button();
            logoutbtn = new Button();
            btnSettings = new Button();
            lblWelcome = new Label();
            lblRole = new Label();
            picUserPhoto = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserPhoto).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnReports);
            panel1.Controls.Add(btnLeaves);
            panel1.Controls.Add(btnAttendance);
            panel1.Controls.Add(btnEmployees);
            panel1.Controls.Add(logoutbtn);
            panel1.Controls.Add(btnSettings);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 452);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(23, 22);
            button1.Name = "button1";
            button1.Size = new Size(155, 43);
            button1.TabIndex = 6;
            button1.Text = "إدارة الإضافي";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(23, 84);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(155, 43);
            btnReports.TabIndex = 5;
            btnReports.Text = "إدارة السلف";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnLeaves
            // 
            btnLeaves.Location = new Point(23, 149);
            btnLeaves.Name = "btnLeaves";
            btnLeaves.Size = new Size(155, 43);
            btnLeaves.TabIndex = 4;
            btnLeaves.Text = "إدارة طلبات الإذن والأجازات";
            btnLeaves.UseVisualStyleBackColor = true;
            btnLeaves.Click += btnLeaves_Click;
            // 
            // btnAttendance
            // 
            btnAttendance.Location = new Point(23, 212);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Size = new Size(155, 43);
            btnAttendance.TabIndex = 3;
            btnAttendance.Text = "إدارة الحضور والإنصراف";
            btnAttendance.UseVisualStyleBackColor = true;
            btnAttendance.Click += btnAttendance_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Location = new Point(23, 270);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(155, 43);
            btnEmployees.TabIndex = 2;
            btnEmployees.Text = "إدارة الموظفين";
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // logoutbtn
            // 
            logoutbtn.Location = new Point(23, 394);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Size = new Size(155, 43);
            logoutbtn.TabIndex = 1;
            logoutbtn.Text = "تسجيل الخروج";
            logoutbtn.UseVisualStyleBackColor = true;
            logoutbtn.Click += logoutbtn_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(23, 332);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(155, 43);
            btnSettings.TabIndex = 0;
            btnSettings.Text = "الإعدادات";
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.FlatStyle = FlatStyle.Flat;
            lblWelcome.Font = new Font("Segoe UI", 20F);
            lblWelcome.ForeColor = Color.CornflowerBlue;
            lblWelcome.Location = new Point(315, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(76, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "مرحبا";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.FlatStyle = FlatStyle.Flat;
            lblRole.Font = new Font("Segoe UI", 20F);
            lblRole.ForeColor = Color.CornflowerBlue;
            lblRole.Location = new Point(319, 91);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(72, 37);
            lblRole.TabIndex = 1;
            lblRole.Text = "الدور";
            lblRole.Click += lblRole_Click;
            // 
            // picUserPhoto
            // 
            picUserPhoto.Location = new Point(288, 193);
            picUserPhoto.Name = "picUserPhoto";
            picUserPhoto.Size = new Size(134, 101);
            picUserPhoto.TabIndex = 2;
            picUserPhoto.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(picUserPhoto);
            Controls.Add(lblRole);
            Controls.Add(lblWelcome);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picUserPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblWelcome;
        private Label lblRole;
        private PictureBox picUserPhoto;
        private Button btnEmployees;
        private Button logoutbtn;
        private Button btnSettings;
        private Button btnReports;
        private Button btnLeaves;
        private Button btnAttendance;
        private Button button1;
    }
}