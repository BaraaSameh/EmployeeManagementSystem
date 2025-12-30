namespace EmployeeManagementSystem.Forms
{
    partial class EmployeesForm
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
            dgvEmployees = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            picEmployee = new PictureBox();
            lblEmployeeName = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            Backbtn = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEmployee).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(3, 226);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(798, 159);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 410);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "اضافة";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(174, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(255, 410);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "تحديث";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // picEmployee
            // 
            picEmployee.Location = new Point(12, 12);
            picEmployee.Name = "picEmployee";
            picEmployee.Size = new Size(174, 164);
            picEmployee.TabIndex = 5;
            picEmployee.TabStop = false;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 20F);
            lblEmployeeName.Location = new Point(233, 21);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(90, 37);
            lblEmployeeName.TabIndex = 6;
            lblEmployeeName.Text = "label1";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(548, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث بالاسم أو الرقم القومي";
            txtSearch.Size = new Size(228, 23);
            txtSearch.TabIndex = 7;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(626, 65);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // Backbtn
            // 
            Backbtn.Location = new Point(713, 410);
            Backbtn.Name = "Backbtn";
            Backbtn.Size = new Size(75, 23);
            Backbtn.TabIndex = 9;
            Backbtn.Text = "رجوع";
            Backbtn.UseVisualStyleBackColor = true;
            Backbtn.Click += Backbtn_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(93, 410);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "تعديل";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Backbtn);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblEmployeeName);
            Controls.Add(picEmployee);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvEmployees);
            Name = "EmployeesForm";
            Text = "EmployeesForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dgvEmployees;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnRefresh;
        private PictureBox picEmployee;
        private Label lblEmployeeName;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button Backbtn;
        private Button btnEdit;
    }
}