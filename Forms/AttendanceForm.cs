using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Forms
{
    public partial class AttendanceForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();
        private Employee? _selectedEmployee;

        public AttendanceForm()
        {
            InitializeComponent();
            CheckPermission();
            LoadEmployees();
            dtpDate.Value = DateTime.Today;

            // تأكد من توصيل الحدث
            cmbEmployees.SelectionChangeCommitted += cmbEmployees_SelectionChangeCommitted;
            cmbEmployees.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CheckPermission()
        {
            if (CurrentUser.Role != "Admin" && CurrentUser.Role != "Manager")
            {
                MessageBox.Show("غير مصرح لك بالدخول إلى هذه الشاشة.", "وصول ممنوع",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void LoadEmployees()
        {
            var employees = _db.Employees
                .Include(e => e.Department)
                .OrderBy(e => e.FullName)
                .Select(e => new { e.Id, e.FullName, DepartmentName = e.Department.Name })
                .ToList();

            if (employees.Count == 0)
            {
                MessageBox.Show("لا توجد سجلات موظفين.");
                return;
            }

            cmbEmployees.DataSource = employees;
            cmbEmployees.DisplayMember = "FullName";
            cmbEmployees.ValueMember = "Id";

            cmbEmployees.SelectedIndex = -1;
        }

        private void cmbEmployees_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedValue == null) return;

            int employeeId = Convert.ToInt32(cmbEmployees.SelectedValue);
            _selectedEmployee = _db.Employees
                .Include(e => e.Department)
                .FirstOrDefault(emp => emp.Id == employeeId);

            if (_selectedEmployee != null)
            {
                this.Text = $"إدارة حضور: {_selectedEmployee.FullName} - {_selectedEmployee.Department.Name}";
                LoadMonthlyAttendance(employeeId);

                // ✅ تصفير الحقول بدل تحميل آخر حضور
                txtCheckIn.Text = "";
                txtCheckOut.Text = "";
            }
        }

        private void LoadTodayAttendance(int employeeId)
        {
            var today = DateOnly.FromDateTime(dtpDate.Value);

            var attendance = _db.Attendances
                .FirstOrDefault(a => a.EmployeeId == employeeId && a.Date == today);

            // Convert to 12-hour format with AM/PM
            txtCheckIn.Text = attendance?.CheckIn != null 
                ? DateTime.Today.Add(attendance.CheckIn.Value.ToTimeSpan()).ToString("hh:mm tt") 
                : "";
            
            txtCheckOut.Text = attendance?.CheckOut != null 
                ? DateTime.Today.Add(attendance.CheckOut.Value.ToTimeSpan()).ToString("hh:mm tt") 
                : "";
        }

        private void LoadMonthlyAttendance(int employeeId)
        {
            var monthStart = new DateOnly(dtpDate.Value.Year, dtpDate.Value.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var monthly = _db.Attendances
                .Where(a => a.EmployeeId == employeeId &&
                            a.Date >= monthStart && a.Date <= monthEnd)
                .OrderByDescending(a => a.Date)
                .Select(a => new
                {
                    a.Id,
                    a.Date,
                    CheckIn = a.CheckIn != null 
                        ? DateTime.Today.Add(a.CheckIn.Value.ToTimeSpan()).ToString("hh:mm tt") 
                        : "",
                    CheckOut = a.CheckOut != null 
                        ? DateTime.Today.Add(a.CheckOut.Value.ToTimeSpan()).ToString("hh:mm tt") 
                        : "",
                    a.TotalHours
                })
                .ToList();

            dgvAttendance.DataSource = monthly;

            // Hide ID column
            if (dgvAttendance.Columns.Contains("Id"))
                dgvAttendance.Columns["Id"]!.Visible = false;

            dgvAttendance.Columns["Date"]!.HeaderText = "التاريخ";
            dgvAttendance.Columns["CheckIn"]!.HeaderText = "الدخول";
            dgvAttendance.Columns["CheckOut"]!.HeaderText = "الخروج";
            dgvAttendance.Columns["TotalHours"]!.HeaderText = "الساعات";

            var total = monthly.Sum(a => a.TotalHours);
          
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                LoadTodayAttendance(_selectedEmployee.Id);
                LoadMonthlyAttendance(_selectedEmployee.Id);
            }
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null || cmbEmployees.SelectedValue == null)
            {
                MessageBox.Show("اختار موظف أولاً");
                cmbEmployees.Focus();
                return;
            }

            TimeOnly? checkIn = null;
            TimeOnly? checkOut = null;

            if (!string.IsNullOrWhiteSpace(txtCheckIn.Text))
            {
                if (!TimeOnly.TryParse(txtCheckIn.Text, out var ci))
                {
                    MessageBox.Show("وقت الدخول غير صحيح (مثال: 09:00)");
                    return;
                }
                checkIn = ci;
            }

            if (!string.IsNullOrWhiteSpace(txtCheckOut.Text))
            {
                if (!TimeOnly.TryParse(txtCheckOut.Text, out var co))
                {
                    MessageBox.Show("وقت الخروج غير صحيح (مثال: 17:30)");
                    return;
                }
                checkOut = co;
            }

            // شرط إضافي: وقت الخروج لازم يكون بعد وقت الدخول
            if (checkIn != null && checkOut != null && checkOut <= checkIn)
            {
                MessageBox.Show("وقت الخروج يجب أن يكون بعد وقت الدخول");
                return;
            }

            var date = DateOnly.FromDateTime(dtpDate.Value);

            var attendance = _db.Attendances
                .FirstOrDefault(a => a.EmployeeId == _selectedEmployee.Id && a.Date == date);

            if (attendance == null)
            {
                attendance = new Attendance
                {
                    EmployeeId = _selectedEmployee.Id,
                    Date = date,
                    CheckIn = checkIn,
                    CheckOut = checkOut
                };
                _db.Attendances.Add(attendance);
            }
            else
            {
                attendance.CheckIn = checkIn;
                attendance.CheckOut = checkOut;
            }

            _db.SaveChanges();
            MessageBox.Show("تم حفظ تسجيل الحضور بنجاح!");
            LoadMonthlyAttendance(_selectedEmployee.Id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCheckIn.Text = "";
            txtCheckOut.Text = "";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }

        private void btnSaveAttendance_Click_1(object sender, EventArgs e)
        {
            // Check if employee is selected
            if (_selectedEmployee == null || cmbEmployees.SelectedValue == null)
            {
                MessageBox.Show("اختار موظف أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployees.Focus();
                return;
            }

            TimeOnly? checkIn = null;
            TimeOnly? checkOut = null;

            // Validate and parse check-in time
            if (!string.IsNullOrWhiteSpace(txtCheckIn.Text))
            {
                if (!TimeOnly.TryParse(txtCheckIn.Text, out var ci))
                {
                    MessageBox.Show("وقت الدخول غير صحيح. استخدم صيغة HH:mm (مثال: 09:00)", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCheckIn.Focus();
                    return;
                }
                checkIn = ci;
            }

            // Validate and parse check-out time
            if (!string.IsNullOrWhiteSpace(txtCheckOut.Text))
            {
                if (!TimeOnly.TryParse(txtCheckOut.Text, out var co))
                {
                    MessageBox.Show("وقت الخروج غير صحيح. استخدم صيغة HH:mm (مثال: 17:30)", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCheckOut.Focus();
                    return;
                }
                checkOut = co;
            }

            // Validate that check-out is after check-in
            if (checkIn.HasValue && checkOut.HasValue && checkOut.Value <= checkIn.Value)
            {
                MessageBox.Show("وقت الخروج يجب أن يكون بعد وقت الدخول", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCheckOut.Focus();
                return;
            }

            try
            {
                var date = DateOnly.FromDateTime(dtpDate.Value);

                // Check if attendance record already exists for this employee and date
                var attendance = _db.Attendances
                    .FirstOrDefault(a => a.EmployeeId == _selectedEmployee.Id && a.Date == date);

                if (attendance == null)
                {
                    // Create new attendance record
                    attendance = new Attendance
                    {
                        EmployeeId = _selectedEmployee.Id,
                        Date = date,
                        CheckIn = checkIn,
                        CheckOut = checkOut
                    };
                    _db.Attendances.Add(attendance);
                }
                else
                {
                    // Update existing attendance record
                    attendance.CheckIn = checkIn;
                    attendance.CheckOut = checkOut;
                }

                // Save changes to database
                _db.SaveChanges();

                MessageBox.Show("تم حفظ تسجيل الحضور بنجاح!", "نجح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the displays
                LoadMonthlyAttendance(_selectedEmployee.Id);
                LoadTodayAttendance(_selectedEmployee.Id);

                // Clear input fields
                txtCheckIn.Text = "";
                txtCheckOut.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}