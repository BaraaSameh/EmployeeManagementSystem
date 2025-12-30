using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Forms
{
    public partial class EmployeeDetailForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();
        private Employee? _employee;
        private Image? _selectedImage;

        public EmployeeDetailForm(Employee? employee = null)
        {
            InitializeComponent();
            _employee = employee ?? new Employee();
            LoadCombos();
            LoadData();
        }

        private void LoadCombos()
        {
            // تحميل الأقسام (Departments)
            cmbDepartment.DataSource = _db.Departments.ToList();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "Id";

            // تحميل المناصب (Positions)
            cmbPosition.DataSource = _db.Positions.ToList();
            cmbPosition.DisplayMember = "Title";
            cmbPosition.ValueMember = "Id";

            // تحميل الشيفتات (Shifts)
            var shifts = _db.Shifts.ToList();
            shifts.Insert(0, new Shift { Id = 0, Name = "-- لا يوجد --" });
            Shift.DataSource = shifts;
            Shift.DisplayMember = "Name";
            Shift.ValueMember = "Id";

            // تحميل المستخدمين اللي مش مربوطين بموظف (أو كلهم لو تعديل)
            var users = _db.Users
                .Where(u => u.EmployeeId == null || u.EmployeeId == _employee.Id)
                .ToList();
            users.Insert(0, new User { Id = 0, Username = "-- لا يوجد --" });

            //cmbUser.DataSource = users;
            //cmbUser.DisplayMember = "Username";
            //cmbUser.ValueMember = "Id";
        }

        private void LoadData()
        {
            if (_employee.Id == 0) // جديد
            {
                this.Text = "إضافة موظف جديد";
                dtpHireDate.Value = DateTime.Today;
                Shift.SelectedIndex = 0; // اختيار "لا يوجد" بشكل افتراضي
            }
            else // تعديل
            {
                this.Text = "تعديل بيانات الموظف";

                txtFullName.Text = _employee.FullName;
                txtNationalId.Text = _employee.NationalId;
                dtpHireDate.Value = _employee.HireDate;
                txtBaseSalary.Text = _employee.BaseSalary.ToString();
                cmbDepartment.SelectedValue = _employee.DepartmentId;
                cmbPosition.SelectedValue = _employee.PositionId;

                // اختيار الشيفت
                if (_employee.ShiftId.HasValue)
                    Shift.SelectedValue = _employee.ShiftId.Value;
                else
                    Shift.SelectedIndex = 0; // لا يوجد

                // الصورة
                if (_employee.PhotoData != null)
                {
                    _selectedImage = ImageHelper.ByteArrayToImage(_employee.PhotoData);
                    picPhoto.Image = _selectedImage;
                }

                //// ربط اليوزر
                //if (_employee.User != null)
                //    cmbUser.SelectedValue = _employee.User.Id;
            }
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "صور (|*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "اختار صورة الموظف";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _selectedImage = Image.FromFile(ofd.FileName);
                picPhoto.Image = _selectedImage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("الاسم الكامل مطلوب");
                return;
            }

            if (!decimal.TryParse(txtBaseSalary.Text, out decimal salary))
            {
                MessageBox.Show("الراتب يجب أن يكون رقم");
                return;
            }

            // حفظ البيانات
            _employee.FullName = txtFullName.Text;
            _employee.NationalId = txtNationalId.Text;
            _employee.HireDate = dtpHireDate.Value;
            _employee.BaseSalary = salary;
            _employee.DepartmentId = (int)cmbDepartment.SelectedValue;
            _employee.PositionId = (int)cmbPosition.SelectedValue;

            // الصورة
            _employee.PhotoData = _selectedImage != null
                ? ImageHelper.ImageToByteArray(_selectedImage)
                : _employee.PhotoData; // لو تعديل وما غيرش الصورة

            //// ربط اليوزر
            //int selectedUserId = (int)cmbUser.SelectedValue;
            //if (selectedUserId > 0)
            //{
            //    var user = _db.Users.Find(selectedUserId);
            //    if (user != null)
            //        user.EmployeeId = _employee.Id;
            //}

            // حفظ في الداتابيز
            if (_employee.Id == 0)
                _db.Employees.Add(_employee);
            else
                _db.Employees.Update(_employee);

            _db.SaveChanges();

            MessageBox.Show("تم الحفظ بنجاح!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            //var employyeForm = new EmployeesForm();
            //employyeForm.Show();
            //this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("الاسم الكامل مطلوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNationalId.Text))
            {
                MessageBox.Show("الرقم القومي مطلوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalId.Focus();
                return;
            }

            // Check if National ID already exists (for new employee or different employee)
            var existingEmployee = _db.Employees
                .FirstOrDefault(e => e.NationalId == txtNationalId.Text.Trim() && e.Id != _employee.Id);

            if (existingEmployee != null)
            {
                MessageBox.Show("الرقم القومي موجود بالفعل لموظف آخر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalId.Focus();
                return;
            }

            if (!decimal.TryParse(txtBaseSalary.Text, out decimal salary) || salary <= 0)
            {
                MessageBox.Show("الراتب يجب أن يكون رقم أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBaseSalary.Focus();
                return;
            }

            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار القسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return;
            }

            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار المنصب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPosition.Focus();
                return;
            }

            try
            {
                // Assign data to employee object
                _employee.FullName = txtFullName.Text.Trim();
                _employee.NationalId = txtNationalId.Text.Trim();
                _employee.HireDate = dtpHireDate.Value;
                _employee.BaseSalary = salary;
                _employee.DepartmentId = (int)cmbDepartment.SelectedValue;
                _employee.PositionId = (int)cmbPosition.SelectedValue;

                // حفظ الشيفت
                if (Shift.SelectedValue != null && (int)Shift.SelectedValue > 0)
                {
                    _employee.ShiftId = (int)Shift.SelectedValue;
                }
                else
                {
                    _employee.ShiftId = null;
                }

                // Handle photo data
                if (_selectedImage != null)
                {
                    _employee.PhotoData = ImageHelper.ImageToByteArray(_selectedImage);
                }
                // If editing and no new image selected, keep existing photo

                // Save to database
                if (_employee.Id == 0)
                {
                    // Adding new employee
                    _db.Employees.Add(_employee);
                }
                else
                {
                    // Updating existing employee
                    _db.Employees.Update(_employee);
                }

                _db.SaveChanges();

                MessageBox.Show("تم حفظ بيانات الموظف بنجاح!", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoosePhoto_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "صور|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.Title = "اختر صورة الموظف";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image from file
                    _selectedImage = Image.FromFile(ofd.FileName);

                    // Display the image in the picture box
                    picPhoto.Image = _selectedImage;
                    picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء تحميل الصورة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
                return;

            int cursorPosition = txtFullName.SelectionStart;
            string currentText = txtFullName.Text;
            string validText = "";

            foreach (char c in currentText)
            {
                // Allow Arabic characters (U+0600 to U+06FF), English letters (a-z, A-Z), and spaces
                if ((c >= '\u0600' && c <= '\u06FF') ||
                    (c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z') ||
                    c == ' ')
                {
                    validText += c;
                }
            }

            // Only update if text changed (to avoid infinite loop)
            if (currentText != validText)
            {
                txtFullName.Text = validText;
                // Restore cursor position, accounting for removed characters
                txtFullName.SelectionStart = Math.Min(cursorPosition, validText.Length);
            }
        }

        private void txtNationalId_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalId.Text))
                return;

            int cursorPosition = txtNationalId.SelectionStart;
            string currentText = txtNationalId.Text;
            string validText = "";

            foreach (char c in currentText)
            {
                // Only allow digits (0-9)
                if (char.IsDigit(c))
                {
                    validText += c;
                }
            }

            // Limit to maximum 14 characters
            if (validText.Length > 14)
            {
                validText = validText.Substring(0, 14);
            }

            // Only update if text changed (to avoid infinite loop)
            if (currentText != validText)
            {
                txtNationalId.Text = validText;
                // Restore cursor position, accounting for removed characters
                txtNationalId.SelectionStart = Math.Min(cursorPosition, validText.Length);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}