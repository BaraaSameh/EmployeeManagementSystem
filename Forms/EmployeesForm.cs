using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();
        private Employee? _selectedEmployee;

        public EmployeesForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadEmployees();
            dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;
            dgvEmployees.CellEndEdit += DgvEmployees_CellEndEdit;
            dgvEmployees.KeyDown += DgvEmployees_KeyDown;
            if (CurrentUser.Role != "Admin" && CurrentUser.Role != "Manager")
            {
                MessageBox.Show("غير مصرح لك.");
                this.Close();
            }
        }

        private void ConfigureDataGridView()
        {
            // Enable inline editing
            dgvEmployees.ReadOnly = false;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadEmployees()
        {
            var employees = _db.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Include(e => e.User)
                .Include(e => e.Shift)
                .ToList();

            dgvEmployees.DataSource = employees;

            // Configure columns
            dgvEmployees.Columns["Id"]!.ReadOnly = true;
            dgvEmployees.Columns["PhotoData"]!.Visible = false;
            dgvEmployees.Columns["PhotoPath"]!.Visible = false;
            dgvEmployees.Columns["User"]!.Visible = false;
            dgvEmployees.Columns["DepartmentId"]!.Visible = false;
            dgvEmployees.Columns["PositionId"]!.Visible = false;
            dgvEmployees.Columns["ShiftId"]!.Visible = false;
            dgvEmployees.Columns["Shift"]!.Visible = false;

            // Hide the original Department and Position columns
            dgvEmployees.Columns["Department"]!.Visible = false;
            dgvEmployees.Columns["Position"]!.Visible = false;

            // Set Arabic headers for editable columns
            dgvEmployees.Columns["Id"]!.HeaderText = "الرقم";
            dgvEmployees.Columns["FullName"]!.HeaderText = "الاسم الكامل";
            dgvEmployees.Columns["NationalId"]!.HeaderText = "الرقم القومي";
            dgvEmployees.Columns["HireDate"]!.HeaderText = "تاريخ التوظيف";
            dgvEmployees.Columns["BaseSalary"]!.HeaderText = "الراتب الأساسي";

            // Remove existing combo columns if they exist
            if (dgvEmployees.Columns.Contains("DepartmentCombo"))
                dgvEmployees.Columns.Remove("DepartmentCombo");
            if (dgvEmployees.Columns.Contains("PositionCombo"))
                dgvEmployees.Columns.Remove("PositionCombo");
            if (dgvEmployees.Columns.Contains("ShiftCombo"))
                dgvEmployees.Columns.Remove("ShiftCombo");
            if (dgvEmployees.Columns.Contains("UserRole"))
                dgvEmployees.Columns.Remove("UserRole");

            // Add Department ComboBox Column
            var departments = _db.Departments.ToList();
            var deptColumn = new DataGridViewComboBoxColumn
            {
                Name = "DepartmentCombo",
                HeaderText = "القسم",
                DataSource = departments,
                DisplayMember = "Name",
                ValueMember = "Id",
                DataPropertyName = "DepartmentId",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            dgvEmployees.Columns.Add(deptColumn);

            // Add Position ComboBox Column
            var positions = _db.Positions.ToList();
            var posColumn = new DataGridViewComboBoxColumn
            {
                Name = "PositionCombo",
                HeaderText = "المنصب",
                DataSource = positions,
                DisplayMember = "Title",
                ValueMember = "Id",
                DataPropertyName = "PositionId",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            dgvEmployees.Columns.Add(posColumn);

            // Add Shift ComboBox Column
            var shifts = _db.Shifts.ToList();
            shifts.Insert(0, new Shift { Id = 0, Name = "-- لا يوجد --" });
            var shiftColumn = new DataGridViewComboBoxColumn
            {
                Name = "ShiftCombo",
                HeaderText = "الشيفت",
                DataSource = shifts,
                DisplayMember = "Name",
                ValueMember = "Id",
                DataPropertyName = "ShiftId",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            dgvEmployees.Columns.Add(shiftColumn);

            // Add Role column
            var roleColumn = new DataGridViewTextBoxColumn
            {
                Name = "UserRole",
                HeaderText = "الدور الوظيفي",
                ReadOnly = true
            };
            dgvEmployees.Columns.Add(roleColumn);

            // Populate Role column
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                var employee = row.DataBoundItem as Employee;
                if (employee != null)
                {
                    row.Cells["UserRole"].Value = employee.User?.Role ?? "غير محدد";
                }
            }

            if (employees.Any())
                ShowEmployeeDetails(employees.First());
        }

        private void DgvEmployees_KeyDown(object? sender, KeyEventArgs e)
        {
            // Handle Enter key to save changes
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (dgvEmployees.IsCurrentCellInEditMode)
                {
                    dgvEmployees.EndEdit();

                    if (dgvEmployees.CurrentRow != null && dgvEmployees.CurrentRow.Index < dgvEmployees.Rows.Count - 1)
                    {
                        dgvEmployees.CurrentCell = dgvEmployees.Rows[dgvEmployees.CurrentRow.Index + 1].Cells[dgvEmployees.CurrentCell.ColumnIndex];
                    }
                }
                else
                {
                    if (dgvEmployees.CurrentCell != null && !dgvEmployees.CurrentCell.ReadOnly)
                    {
                        dgvEmployees.BeginEdit(true);
                    }
                }
            }
        }

        private void DgvEmployees_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var selected = dgvEmployees.SelectedRows[0].DataBoundItem as Employee;
                if (selected != null)
                    ShowEmployeeDetails(selected);
            }
        }

        private void ShowEmployeeDetails(Employee employee)
        {
            _selectedEmployee = employee;
            lblEmployeeName.Text = employee.FullName;

            var photo = ImageHelper.ByteArrayToImage(employee.PhotoData);
            //picEmployee.Image = photo ?? Properties.Resources.default_avatar;
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("اختر موظف أولاً");
                return;
            }

            if (MessageBox.Show($"هل أنت متأكد من حذف {_selectedEmployee.FullName}؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _db.Employees.Remove(_selectedEmployee);
                _db.SaveChanges();
                LoadEmployees();
            }
        }

        private void DgvEmployees_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var editedEmployee = dgvEmployees.Rows[e.RowIndex].DataBoundItem as Employee;

                if (editedEmployee == null)
                    return;

                string columnName = dgvEmployees.Columns[e.ColumnIndex].Name;

                // Validate based on column
                if (columnName == "FullName")
                {
                    if (string.IsNullOrWhiteSpace(editedEmployee.FullName))
                    {
                        MessageBox.Show("الاسم الكامل مطلوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadEmployees();
                        return;
                    }
                }
                else if (columnName == "NationalId")
                {
                    if (string.IsNullOrWhiteSpace(editedEmployee.NationalId))
                    {
                        MessageBox.Show("الرقم القومي مطلوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadEmployees();
                        return;
                    }

                    if (editedEmployee.NationalId.Length != 14 || !editedEmployee.NationalId.All(char.IsDigit))
                    {
                        MessageBox.Show("الرقم القومي يجب أن يكون 14 رقم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadEmployees();
                        return;
                    }

                    var duplicate = _db.Employees
                        .Any(e => e.NationalId == editedEmployee.NationalId && e.Id != editedEmployee.Id);

                    if (duplicate)
                    {
                        MessageBox.Show("الرقم القومي موجود بالفعل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadEmployees();
                        return;
                    }
                }
                else if (columnName == "BaseSalary")
                {
                    if (editedEmployee.BaseSalary <= 0)
                    {
                        MessageBox.Show("الراتب يجب أن يكون أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadEmployees();
                        return;
                    }
                }
                else if (columnName == "DepartmentCombo")
                {
                    var deptId = dgvEmployees.Rows[e.RowIndex].Cells["DepartmentCombo"].Value;
                    if (deptId != null)
                    {
                        editedEmployee.DepartmentId = (int)deptId;
                    }
                }
                else if (columnName == "PositionCombo")
                {
                    var posId = dgvEmployees.Rows[e.RowIndex].Cells["PositionCombo"].Value;
                    if (posId != null)
                    {
                        editedEmployee.PositionId = (int)posId;
                    }
                }
                else if (columnName == "ShiftCombo")
                {
                    var shiftId = dgvEmployees.Rows[e.RowIndex].Cells["ShiftCombo"].Value;
                    if (shiftId != null)
                    {
                        editedEmployee.ShiftId = (int)shiftId;
                    }
                }

                // Update in database
                //var dbEmployee = _db.Employees.Find(editedEmployee.Id);

                //if (dbEmployee != null)
                //{
                //    dbEmployee.FullName = editedEmployee.FullName;
                //    dbEmployee.NationalId = editedEmployee.NationalId;
                //    dbEmployee.HireDate = editedEmployee.HireDate;
                //    dbEmployee.BaseSalary = editedEmployee.BaseSalary;
                //    dbEmployee.DepartmentId = editedEmployee.DepartmentId;
                //    dbEmployee.PositionId = editedEmployee.PositionId;
                //    dbEmployee.ShiftId = editedEmployee.ShiftId;

                //    _db.SaveChanges();

                //    //MessageBox.Show("تم التحديث بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadEmployees();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("يرجى اختيار موظف من القائمة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var editedEmployee = _selectedEmployee;
            var dbEmployee = _db.Employees.Find(editedEmployee.Id);

            if (dbEmployee != null)
            {
                dbEmployee.FullName = editedEmployee.FullName;
                dbEmployee.NationalId = editedEmployee.NationalId;
                dbEmployee.HireDate = editedEmployee.HireDate;
                dbEmployee.BaseSalary = editedEmployee.BaseSalary;
                dbEmployee.DepartmentId = editedEmployee.DepartmentId;
                dbEmployee.PositionId = editedEmployee.PositionId;
                dbEmployee.ShiftId = editedEmployee.ShiftId;

                _db.SaveChanges();

                MessageBox.Show("تم التحديث بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Open EmployeeDetailForm for complex edits (photo, department, position)
            //var detailForm = new EmployeeDetailForm(_selectedEmployee);
            //if (detailForm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadEmployees();
            //    MessageBox.Show("تم تحديث بيانات الموظف بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var detailForm = new EmployeeDetailForm();
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            var search = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadEmployees();
                return;
            }

            var results = _db.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Include(e => e.User)
                .Where(e => e.FullName.Contains(search) || e.NationalId.Contains(search))
                .ToList();

            dgvEmployees.DataSource = results;

            // Repopulate Role column after search
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                var employee = row.DataBoundItem as Employee;
                if (employee != null && dgvEmployees.Columns.Contains("UserRole"))
                {
                    row.Cells["UserRole"].Value = employee.User?.Role ?? "غير محدد";
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}