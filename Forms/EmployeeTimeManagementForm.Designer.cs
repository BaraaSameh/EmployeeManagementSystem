namespace EmployeeManagementSystem.Forms
{
    partial class EmployeeTimeManagementForm
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
            cmbEmployees = new ComboBox();
            lblEmployee = new Label();
            dtpDate = new DateTimePicker();
            btnSave = new Button();
            dgvLeaves = new DataGridView();
            lblMonthlyTotal = new Label();
            lblDate = new Label();
            cmbShift = new ComboBox();
            lblShift = new Label();
            lblType = new Label();
            cmbType = new ComboBox();
            lblHours = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblReason = new Label();
            txtReason = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnClear = new Button();
            txtHours = new TextBox();
            deletebtn = new Button();
            button2 = new Button();
            backbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLeaves).BeginInit();
            SuspendLayout();
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(459, 95);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(200, 23);
            cmbEmployees.TabIndex = 0;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Segoe UI", 15F);
            lblEmployee.Location = new Point(665, 90);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(125, 28);
            lblEmployee.TabIndex = 1;
            lblEmployee.Text = "اختار الموظف";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(459, 155);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 507);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "حفظ ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // dgvLeaves
            // 
            dgvLeaves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaves.Location = new Point(4, 380);
            dgvLeaves.Name = "dgvLeaves";
            dgvLeaves.Size = new Size(832, 120);
            dgvLeaves.TabIndex = 10;
            // 
            // lblMonthlyTotal
            // 
            lblMonthlyTotal.AutoSize = true;
            lblMonthlyTotal.Font = new Font("Segoe UI", 15F);
            lblMonthlyTotal.Location = new Point(99, 329);
            lblMonthlyTotal.Name = "lblMonthlyTotal";
            lblMonthlyTotal.Size = new Size(123, 28);
            lblMonthlyTotal.TabIndex = 11;
            lblMonthlyTotal.Text = "عدد الساعات ";
            lblMonthlyTotal.Click += lblMonthlyTotal_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 15F);
            lblDate.Location = new Point(689, 150);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(65, 28);
            lblDate.TabIndex = 12;
            lblDate.Text = "التاريخ";
            // 
            // cmbShift
            // 
            cmbShift.FormattingEnabled = true;
            cmbShift.Location = new Point(459, 206);
            cmbShift.Name = "cmbShift";
            cmbShift.Size = new Size(200, 23);
            cmbShift.TabIndex = 13;
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.Font = new Font("Segoe UI", 15F);
            lblShift.Location = new Point(689, 201);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(76, 28);
            lblShift.TabIndex = 14;
            lblShift.Text = "الشيفت";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 15F);
            lblType.Location = new Point(689, 258);
            lblType.Name = "lblType";
            lblType.Size = new Size(86, 28);
            lblType.TabIndex = 15;
            lblType.Text = "نوع الإذن";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(459, 266);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(200, 23);
            cmbType.TabIndex = 16;
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Font = new Font("Segoe UI", 15F);
            lblHours.Location = new Point(236, 95);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(151, 28);
            lblHours.TabIndex = 17;
            lblHours.Text = "عدد ساعات الإذن";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 15F);
            lblStatus.Location = new Point(236, 150);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 28);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "حالة الإذن";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(53, 155);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(146, 23);
            cmbStatus.TabIndex = 20;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Font = new Font("Segoe UI", 15F);
            lblReason.Location = new Point(236, 206);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(99, 28);
            lblReason.TabIndex = 21;
            lblReason.Text = "سبب الإذن";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(53, 214);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(146, 23);
            txtReason.TabIndex = 22;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.FlatStyle = FlatStyle.Flat;
            lblNotes.Font = new Font("Segoe UI", 15F);
            lblNotes.Location = new Point(234, 258);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(93, 28);
            lblNotes.TabIndex = 23;
            lblNotes.Text = "ملاحظات ";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(12, 269);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(198, 23);
            txtNotes.TabIndex = 24;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(261, 506);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 23);
            btnClear.TabIndex = 25;
            btnClear.Text = "مسح الحقول";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtHours
            // 
            txtHours.Location = new Point(53, 100);
            txtHours.Name = "txtHours";
            txtHours.Size = new Size(146, 23);
            txtHours.TabIndex = 27;
            txtHours.TextChanged += txtHours_TextChanged;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(99, 507);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(75, 23);
            deletebtn.TabIndex = 28;
            deletebtn.Text = "حذف";
            deletebtn.UseVisualStyleBackColor = true;
            deletebtn.Click += deletebtn_Click;
            // 
            // button2
            // 
            button2.Location = new Point(180, 506);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 29;
            button2.Text = "تحديث";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // backbtn
            // 
            backbtn.Location = new Point(754, 519);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(75, 23);
            backbtn.TabIndex = 30;
            backbtn.Text = "إلغاء";
            backbtn.UseVisualStyleBackColor = true;
            backbtn.Click += backbtn_Click;
            // 
            // EmployeeTimeManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 554);
            Controls.Add(backbtn);
            Controls.Add(button2);
            Controls.Add(deletebtn);
            Controls.Add(txtHours);
            Controls.Add(btnClear);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtReason);
            Controls.Add(lblReason);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblHours);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(lblShift);
            Controls.Add(cmbShift);
            Controls.Add(lblDate);
            Controls.Add(lblMonthlyTotal);
            Controls.Add(dgvLeaves);
            Controls.Add(btnSave);
            Controls.Add(dtpDate);
            Controls.Add(lblEmployee);
            Controls.Add(cmbEmployees);
            Name = "EmployeeTimeManagementForm";
            Text = "EmployeeTimeManagementForm";
            Load += EmployeeTimeManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLeaves).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ComboBox cmbEmployees;
        private Label lblEmployee;
        private DateTimePicker dtpDate;
        private Button btnSave;
        private DataGridView dgvLeaves;
        private Label lblMonthlyTotal;
        private Label lblDate;
        private ComboBox cmbShift;
        private Label lblShift;
        private Label lblType;
        private ComboBox cmbType;
        private Label lblHours;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblReason;
        private TextBox txtReason;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnClear;
        private TextBox txtHours;
        private Button deletebtn;
        private Button button2;
        private Button backbtn;
    }
}