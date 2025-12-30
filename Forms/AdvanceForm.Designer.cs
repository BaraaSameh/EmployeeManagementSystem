namespace EmployeeManagementSystem.Forms
{
    partial class AdvanceForm
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
            label3 = new Label();
            txtAmount = new TextBox();
            dtpAdvanceDate = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            txtNotes = new TextBox();
            btnSave = new Button();
            dgvAdvances = new DataGridView();
            lblTotalAdvances = new Label();
            Backbtn = new Button();
            deletebtn = new Button();
            updatebtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAdvances).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F);
            label1.Location = new Point(154, 9);
            label1.Name = "label1";
            label1.Size = new Size(442, 89);
            label1.TabIndex = 0;
            label1.Text = "تسجيل السلف ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(655, 125);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 1;
            label2.Text = "الموظف";
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(465, 127);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(184, 23);
            cmbEmployees.TabIndex = 2;
            cmbEmployees.SelectedIndexChanged += cmbEmployees_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(630, 186);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 3;
            label3.Text = "مبلغ السلفة";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(465, 188);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(163, 23);
            txtAmount.TabIndex = 4;
            // 
            // dtpAdvanceDate
            // 
            dtpAdvanceDate.Location = new Point(428, 249);
            dtpAdvanceDate.Name = "dtpAdvanceDate";
            dtpAdvanceDate.Size = new Size(200, 23);
            dtpAdvanceDate.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(634, 249);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 6;
            label4.Text = "تاريخ السلفة";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(276, 122);
            label5.Name = "label5";
            label5.Size = new Size(83, 25);
            label5.TabIndex = 7;
            label5.Text = "ملاحظات";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(85, 125);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(162, 23);
            txtNotes.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // dgvAdvances
            // 
            dgvAdvances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdvances.Location = new Point(45, 290);
            dgvAdvances.Name = "dgvAdvances";
            dgvAdvances.Size = new Size(629, 109);
            dgvAdvances.TabIndex = 10;
            // 
            // lblTotalAdvances
            // 
            lblTotalAdvances.AutoSize = true;
            lblTotalAdvances.Location = new Point(168, 258);
            lblTotalAdvances.Name = "lblTotalAdvances";
            lblTotalAdvances.Size = new Size(38, 15);
            lblTotalAdvances.TabIndex = 11;
            lblTotalAdvances.Text = "label6";
            // 
            // Backbtn
            // 
            Backbtn.Location = new Point(645, 409);
            Backbtn.Name = "Backbtn";
            Backbtn.Size = new Size(75, 23);
            Backbtn.TabIndex = 12;
            Backbtn.Text = "إلغاء";
            Backbtn.UseVisualStyleBackColor = true;
            Backbtn.Click += Backbtn_Click;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(93, 409);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(75, 23);
            deletebtn.TabIndex = 13;
            deletebtn.Text = "حذف";
            deletebtn.UseVisualStyleBackColor = true;
            deletebtn.Click += deletebtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(174, 409);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(75, 23);
            updatebtn.TabIndex = 14;
            updatebtn.Text = "تحديث";
            updatebtn.UseVisualStyleBackColor = true;
            updatebtn.Click += updatebtn_Click;
            // 
            // AdvanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 444);
            Controls.Add(updatebtn);
            Controls.Add(deletebtn);
            Controls.Add(Backbtn);
            Controls.Add(lblTotalAdvances);
            Controls.Add(dgvAdvances);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpAdvanceDate);
            Controls.Add(txtAmount);
            Controls.Add(label3);
            Controls.Add(cmbEmployees);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdvanceForm";
            Text = "AdvanceForm";
            ((System.ComponentModel.ISupportInitialize)dgvAdvances).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbEmployees;
        private Label label3;
        private TextBox txtAmount;
        private DateTimePicker dtpAdvanceDate;
        private Label label4;
        private Label label5;
        private TextBox txtNotes;
        private Button btnSave;
        private DataGridView dgvAdvances;
        private Label lblTotalAdvances;
        private Button Backbtn;
        private Button deletebtn;
        private Button updatebtn;
    }
}