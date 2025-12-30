namespace EmployeeManagementSystem.Forms
{
    partial class OvertimeForm
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
            label2 = new Label();
            cmbEmployees = new ComboBox();
            dtpOvertimeDate = new DateTimePicker();
            label3 = new Label();
            txtHours = new TextBox();
            label4 = new Label();
            cmbStatus = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            txtNotes = new TextBox();
            dgvOvertime = new DataGridView();
            btnSave = new Button();
            cancelbtn = new Button();
            lblMonthlyHours = new Label();
            Deletebtn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOvertime).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F);
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(736, 89);
            label1.TabIndex = 0;
            label1.Text = "تسجيل الساعات الإضافية ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(665, 140);
            label2.Name = "label2";
            label2.Size = new Size(113, 37);
            label2.TabIndex = 1;
            label2.Text = "الموظف";
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(459, 154);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(200, 23);
            cmbEmployees.TabIndex = 2;
            cmbEmployees.SelectedIndexChanged += cmbEmployees_SelectedIndexChanged;
            // 
            // dtpOvertimeDate
            // 
            dtpOvertimeDate.Location = new Point(459, 210);
            dtpOvertimeDate.Name = "dtpOvertimeDate";
            dtpOvertimeDate.Size = new Size(200, 23);
            dtpOvertimeDate.TabIndex = 3;
            dtpOvertimeDate.ValueChanged += dtpOvertimeDate_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(681, 196);
            label3.Name = "label3";
            label3.Size = new Size(87, 37);
            label3.TabIndex = 4;
            label3.Text = "التاريخ";
            // 
            // txtHours
            // 
            txtHours.Location = new Point(326, 263);
            txtHours.Name = "txtHours";
            txtHours.Size = new Size(200, 23);
            txtHours.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(532, 249);
            label4.Name = "label4";
            label4.Size = new Size(263, 37);
            label4.TabIndex = 6;
            label4.Text = "عدد الساعات الإضافية";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(42, 153);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(286, 140);
            label5.Name = "label5";
            label5.Size = new Size(79, 37);
            label5.TabIndex = 8;
            label5.Text = "الحالة";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F);
            label6.Location = new Point(276, 210);
            label6.Name = "label6";
            label6.Size = new Size(120, 37);
            label6.TabIndex = 9;
            label6.Text = "ملاحظات";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(42, 225);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(200, 23);
            txtNotes.TabIndex = 10;
            // 
            // dgvOvertime
            // 
            dgvOvertime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOvertime.Location = new Point(0, 305);
            dgvOvertime.Name = "dgvOvertime";
            dgvOvertime.Size = new Size(804, 94);
            dgvOvertime.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cancelbtn
            // 
            cancelbtn.Location = new Point(703, 415);
            cancelbtn.Name = "cancelbtn";
            cancelbtn.Size = new Size(75, 23);
            cancelbtn.TabIndex = 13;
            cancelbtn.Text = "الغاء";
            cancelbtn.UseVisualStyleBackColor = true;
            cancelbtn.Click += cancelbtn_Click;
            // 
            // lblMonthlyHours
            // 
            lblMonthlyHours.AutoSize = true;
            lblMonthlyHours.Location = new Point(42, 271);
            lblMonthlyHours.Name = "lblMonthlyHours";
            lblMonthlyHours.Size = new Size(38, 15);
            lblMonthlyHours.TabIndex = 14;
            lblMonthlyHours.Text = "label7";
            // 
            // Deletebtn
            // 
            Deletebtn.Location = new Point(105, 415);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.Size = new Size(75, 23);
            Deletebtn.TabIndex = 15;
            Deletebtn.Text = "حذف";
            Deletebtn.UseVisualStyleBackColor = true;
            Deletebtn.Click += Deletebtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(200, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "تحديث";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // OvertimeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(Deletebtn);
            Controls.Add(lblMonthlyHours);
            Controls.Add(cancelbtn);
            Controls.Add(btnSave);
            Controls.Add(dgvOvertime);
            Controls.Add(txtNotes);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbStatus);
            Controls.Add(label4);
            Controls.Add(txtHours);
            Controls.Add(label3);
            Controls.Add(dtpOvertimeDate);
            Controls.Add(cmbEmployees);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OvertimeForm";
            Text = "OvertimeForm";
            ((System.ComponentModel.ISupportInitialize)dgvOvertime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private void cancelbtn_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();  
            mainForm.Show();
            this.Close();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbEmployees;
        private DateTimePicker dtpOvertimeDate;
        private Label label3;
        private TextBox txtHours;
        private Label label4;
        private ComboBox cmbStatus;
        private Label label5;
        private Label label6;
        private TextBox txtNotes;
        private DataGridView dgvOvertime;
        private Button btnSave;
        private Button cancelbtn;
        private Label lblMonthlyHours;
        private Button Deletebtn;
        private Button button1;
    }
}