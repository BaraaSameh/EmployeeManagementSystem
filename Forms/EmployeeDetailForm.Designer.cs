namespace EmployeeManagementSystem.Forms
{
    partial class EmployeeDetailForm
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
            lblTitle = new Label();
            picPhoto = new PictureBox();
            btnChoosePhoto = new Button();
            label1 = new Label();
            txtFullName = new TextBox();
            txtNationalId = new TextBox();
            lblNationalId = new Label();
            lblHireDate = new Label();
            dtpHireDate = new DateTimePicker();
            lblBaseSalary = new Label();
            txtBaseSalary = new TextBox();
            label2 = new Label();
            cmbPosition = new ComboBox();
            lblPosition = new Label();
            cmbDepartment = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            Shift = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 50F);
            lblTitle.Location = new Point(176, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(453, 89);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "بيانات الموظف";
            // 
            // picPhoto
            // 
            picPhoto.Location = new Point(21, 23);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(149, 109);
            picPhoto.TabIndex = 1;
            picPhoto.TabStop = false;
            // 
            // btnChoosePhoto
            // 
            btnChoosePhoto.Location = new Point(52, 138);
            btnChoosePhoto.Name = "btnChoosePhoto";
            btnChoosePhoto.Size = new Size(75, 23);
            btnChoosePhoto.TabIndex = 2;
            btnChoosePhoto.Text = "اختيار صورة";
            btnChoosePhoto.UseVisualStyleBackColor = true;
            btnChoosePhoto.Click += btnChoosePhoto_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(626, 118);
            label1.Name = "label1";
            label1.Size = new Size(157, 37);
            label1.TabIndex = 3;
            label1.Text = "الاسم الكامل";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(426, 132);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(174, 23);
            txtFullName.TabIndex = 4;
            txtFullName.TextChanged += txtFullName_TextChanged;
            // 
            // txtNationalId
            // 
            txtNationalId.Location = new Point(426, 207);
            txtNationalId.Name = "txtNationalId";
            txtNationalId.Size = new Size(174, 23);
            txtNationalId.TabIndex = 6;
            txtNationalId.TextChanged += txtNationalId_TextChanged;
            // 
            // lblNationalId
            // 
            lblNationalId.AutoSize = true;
            lblNationalId.FlatStyle = FlatStyle.Flat;
            lblNationalId.Font = new Font("Segoe UI", 20F);
            lblNationalId.Location = new Point(626, 193);
            lblNationalId.Name = "lblNationalId";
            lblNationalId.Size = new Size(162, 37);
            lblNationalId.TabIndex = 5;
            lblNationalId.Text = "الرقم القومي";
            // 
            // lblHireDate
            // 
            lblHireDate.AutoSize = true;
            lblHireDate.FlatStyle = FlatStyle.Flat;
            lblHireDate.Font = new Font("Segoe UI", 20F);
            lblHireDate.Location = new Point(621, 261);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(162, 37);
            lblHireDate.TabIndex = 7;
            lblHireDate.Text = "تاريخ التعيين ";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(400, 273);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(200, 23);
            dtpHireDate.TabIndex = 8;
            // 
            // lblBaseSalary
            // 
            lblBaseSalary.AutoSize = true;
            lblBaseSalary.FlatStyle = FlatStyle.Flat;
            lblBaseSalary.Font = new Font("Segoe UI", 20F);
            lblBaseSalary.Location = new Point(607, 330);
            lblBaseSalary.Name = "lblBaseSalary";
            lblBaseSalary.Size = new Size(181, 37);
            lblBaseSalary.TabIndex = 9;
            lblBaseSalary.Text = "الراتب الأساسي";
            // 
            // txtBaseSalary
            // 
            txtBaseSalary.Location = new Point(426, 344);
            txtBaseSalary.Name = "txtBaseSalary";
            txtBaseSalary.Size = new Size(174, 23);
            txtBaseSalary.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(267, 159);
            label2.Name = "label2";
            label2.Size = new Size(86, 37);
            label2.TabIndex = 11;
            label2.Text = "القسم";
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Items.AddRange(new object[] { "المبيعات  ", "المصنع", "المشتريات", "السوشيال ميديا ", "التكنولوجيا ", "الإنشائات " });
            cmbPosition.Location = new Point(112, 174);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(121, 23);
            cmbPosition.TabIndex = 12;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.FlatStyle = FlatStyle.Flat;
            lblPosition.Font = new Font("Segoe UI", 20F);
            lblPosition.Location = new Point(267, 233);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(110, 37);
            lblPosition.TabIndex = 13;
            lblPosition.Text = "المنصب";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Items.AddRange(new object[] { "موظف", "نائب مدير", "مدير", "تنفيذي", "اداري" });
            cmbDepartment.Location = new Point(112, 247);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(121, 23);
            cmbDepartment.TabIndex = 14;
            cmbDepartment.SelectedIndexChanged += cmbPosition_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(21, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 15;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(125, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // Shift
            // 
            Shift.FormattingEnabled = true;
            Shift.Items.AddRange(new object[] { "موظف", "نائب مدير", "مدير", "تنفيذي", "اداري" });
            Shift.Location = new Point(112, 309);
            Shift.Name = "Shift";
            Shift.Size = new Size(121, 23);
            Shift.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(267, 295);
            label3.Name = "label3";
            label3.Size = new Size(104, 37);
            label3.TabIndex = 17;
            label3.Text = "الشيفت";
            // 
            // EmployeeDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Shift);
            Controls.Add(label3);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbDepartment);
            Controls.Add(lblPosition);
            Controls.Add(cmbPosition);
            Controls.Add(label2);
            Controls.Add(txtBaseSalary);
            Controls.Add(lblBaseSalary);
            Controls.Add(dtpHireDate);
            Controls.Add(lblHireDate);
            Controls.Add(txtNationalId);
            Controls.Add(lblNationalId);
            Controls.Add(txtFullName);
            Controls.Add(label1);
            Controls.Add(btnChoosePhoto);
            Controls.Add(picPhoto);
            Controls.Add(lblTitle);
            Name = "EmployeeDetailForm";
            Text = "EmployeeDetailForm";
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private PictureBox picPhoto;
        private Button btnChoosePhoto;
        private Label label1;
        private TextBox txtFullName;
        private TextBox txtNationalId;
        private Label lblNationalId;
        private Label lblHireDate;
        private DateTimePicker dtpHireDate;
        private Label lblBaseSalary;
        private TextBox txtBaseSalary;
        private Label label2;
        private ComboBox cmbPosition;
        private Label lblPosition;
        private ComboBox cmbDepartment;
        private Button btnSave;
        private Button btnCancel;
        private ComboBox Shift;
        private Label label3;
    }
}