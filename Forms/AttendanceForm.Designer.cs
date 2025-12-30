namespace EmployeeManagementSystem.Forms
{
    partial class AttendanceForm
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
            label1 = new Label();
            cmbEmployees = new ComboBox();
            dtpDate = new DateTimePicker();
            label2 = new Label();
            txtCheckIn = new TextBox();
            txtCheckOut = new TextBox();
            btnSaveAttendance = new Button();
            btnClear = new Button();
            button3 = new Button();
            label3 = new Label();
            label4 = new Label();
            dgvAttendance = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(710, 105);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "اختيار الموظف";
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(572, 102);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(121, 23);
            cmbEmployees.TabIndex = 1;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(493, 168);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(736, 174);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "التاريخ";
            // 
            // txtCheckIn
            // 
            txtCheckIn.Location = new Point(553, 242);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.Size = new Size(100, 23);
            txtCheckIn.TabIndex = 4;
            // 
            // txtCheckOut
            // 
            txtCheckOut.Location = new Point(553, 300);
            txtCheckOut.Name = "txtCheckOut";
            txtCheckOut.Size = new Size(100, 23);
            txtCheckOut.TabIndex = 5;
            // 
            // btnSaveAttendance
            // 
            btnSaveAttendance.Location = new Point(12, 415);
            btnSaveAttendance.Name = "btnSaveAttendance";
            btnSaveAttendance.Size = new Size(75, 23);
            btnSaveAttendance.TabIndex = 6;
            btnSaveAttendance.Text = "حفظ";
            btnSaveAttendance.UseVisualStyleBackColor = true;
            btnSaveAttendance.Click += btnSaveAttendance_Click_1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(138, 414);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 23);
            btnClear.TabIndex = 7;
            btnClear.Text = "مسح الحقول";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(699, 415);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "الغاء";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(704, 245);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 9;
            label3.Text = "وقت الدخول ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(710, 303);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 10;
            label4.Text = "وقت الخروج";
            // 
            // dgvAttendance
            // 
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Location = new Point(2, 311);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.Size = new Size(505, 97);
            dgvAttendance.TabIndex = 12;
            // 
            // AttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvAttendance);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(btnClear);
            Controls.Add(btnSaveAttendance);
            Controls.Add(txtCheckOut);
            Controls.Add(txtCheckIn);
            Controls.Add(label2);
            Controls.Add(dtpDate);
            Controls.Add(cmbEmployees);
            Controls.Add(label1);
            Name = "AttendanceForm";
            Text = "AttendanceForm";
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbEmployees;
        private DateTimePicker dtpDate;
        private Label label2;
        private TextBox txtCheckIn;
        private TextBox txtCheckOut;
        private Button btnSaveAttendance;
        private Button btnClear;
        private Button button3;
        private Label label3;
        private Label label4;
        private DataGridView dgvAttendance;
    }
}