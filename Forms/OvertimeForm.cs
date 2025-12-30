using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Forms
{
    public partial class OvertimeForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();
        private Employee? _selectedEmployee;

        public OvertimeForm()
        {
            InitializeComponent();
            CheckPermission();
            LoadEmployees();
            dtpOvertimeDate.Value = DateTime.Today;

            cmbStatus.Items.AddRange(new[] { "معلق", "موافقة", "مرفوض" });
            cmbStatus.SelectedIndex = 0;

            // ربط الـ event handlers
            cmbEmployees.SelectedIndexChanged += cmbEmployees_SelectedIndexChanged;
            dtpOvertimeDate.ValueChanged += dtpOvertimeDate_ValueChanged;
        }

        private void CheckPermission()
        {
            if (CurrentUser.Role != "Admin" && CurrentUser.Role != "Manager")
            {
                MessageBox.Show("غير مصرح لك بالدخول إلى إدارة العمل الإضافي.", "وصول ممنوع",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void LoadEmployees()
        {
            var employees = _db.Employees.OrderBy(e => e.FullName).ToList();
            cmbEmployees.DataSource = employees;
            cmbEmployees.DisplayMember = "FullName";
            cmbEmployees.ValueMember = "Id";
            cmbEmployees.SelectedIndex = -1;
            cmbEmployees.Text = "اختار موظف...";
        }

        private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedIndex == -1) return;

            int employeeId = (int)cmbEmployees.SelectedValue;
            _selectedEmployee = _db.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (_selectedEmployee != null)
            {
                this.Text = $"العمل الإضافي - {_selectedEmployee.FullName}";
                LoadOvertimeForEmployee(employeeId);
                CalculateMonthlyOvertime(employeeId);
                LoadTodayOvertime();
            }
        }

        private void dtpOvertimeDate_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
                LoadTodayOvertime();
        }

        private void LoadTodayOvertime()
        {
            if (_selectedEmployee == null) return;

            var date = DateOnly.FromDateTime(dtpOvertimeDate.Value);
            var overtime = _db.Overtimes
                .FirstOrDefault(o => o.EmployeeId == _selectedEmployee.Id && o.OvertimeDate == date);

            if (overtime != null)
            {
                txtHours.Text = overtime.Hours.ToString("F1");
                cmbStatus.Text = overtime.Status;
                txtNotes.Text = overtime.Notes ?? "";
            }
            else
            {
                txtHours.Text = "0";
                cmbStatus.SelectedIndex = 0; // معلق
                txtNotes.Clear();
            }
        }

        private void LoadOvertimeForEmployee(int employeeId)
        {
            try
            {
                var overtimeList = _db.Overtimes
                    .Include(o => o.CreatedBy)
                    .Where(o => o.EmployeeId == employeeId)
                    .OrderByDescending(o => o.OvertimeDate)
                    .AsNoTracking()
                    .ToList();

                dgvOvertime.DataSource = overtimeList;

                // إخفاء الأعمدة الغير ضرورية
                var columnsToHide = new[] { "Id", "EmployeeId", "Employee", "HourlyRate", "OvertimeRate", "CreatedById", "CreatedBy", "TotalAmount" };
                foreach (var col in columnsToHide)
                {
                    if (dgvOvertime.Columns.Contains(col))
                        dgvOvertime.Columns[col]!.Visible = false;
                }

                // تنسيق الأعمدة
                if (dgvOvertime.Columns.Contains("OvertimeDate"))
                    dgvOvertime.Columns["OvertimeDate"]!.HeaderText = "التاريخ";
                if (dgvOvertime.Columns.Contains("Hours"))
                {
                    dgvOvertime.Columns["Hours"]!.HeaderText = "عدد الساعات";
                    dgvOvertime.Columns["Hours"]!.DefaultCellStyle.Format = "F1";
                }
                if (dgvOvertime.Columns.Contains("Status"))
                    dgvOvertime.Columns["Status"]!.HeaderText = "الحالة";
                if (dgvOvertime.Columns.Contains("Notes"))
                    dgvOvertime.Columns["Notes"]!.HeaderText = "ملاحظات";
                if (dgvOvertime.Columns.Contains("CreatedAt"))
                    dgvOvertime.Columns["CreatedAt"]!.HeaderText = "تاريخ التسجيل";

                // إزالة عمود اسم المسجل إذا كان موجوداً
                if (dgvOvertime.Columns.Contains("CreatedByName"))
                    dgvOvertime.Columns.Remove("CreatedByName");

                // إضافة عمود اسم المسجل
                var createdByColumn = new DataGridViewTextBoxColumn
                {
                    Name = "CreatedByName",
                    HeaderText = "مسجل بواسطة",
                    ReadOnly = true,
                    Width = 120
                };
                dgvOvertime.Columns.Add(createdByColumn);

                // ملء عمود اسم المسجل
                foreach (DataGridViewRow row in dgvOvertime.Rows)
                {
                    var overtime = row.DataBoundItem as Overtime;
                    if (overtime?.CreatedBy != null)
                    {
                        row.Cells["CreatedByName"].Value = overtime.CreatedBy.Username;
                    }
                    else
                    {
                        row.Cells["CreatedByName"].Value = "غير معروف";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateMonthlyOvertime(int employeeId)
        {
            if (_selectedEmployee == null) return;

            try
            {
                var monthStart = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, 1);
                var monthEnd = monthStart.AddMonths(1).AddDays(-1);

                var approved = _db.Overtimes
                    .Where(o => o.EmployeeId == employeeId &&
                                o.OvertimeDate >= monthStart &&
                                o.OvertimeDate <= monthEnd &&
                                o.Status == "موافقة")
                    .AsNoTracking()
                    .ToList();

                decimal totalHours = approved.Sum(o => o.Hours);

                lblMonthlyHours.Text = $"إجمالي ساعات الإضافي المعتمد هذا الشهر: {totalHours:F1} ساعة";
                lblMonthlyHours.ForeColor = totalHours > 0 ? Color.Green : Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حساب الإجمالي: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("اختار موظف أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtHours.Text, out decimal hours) || hours <= 0)
            {
                MessageBox.Show("ادخل عدد ساعات إضافية أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var date = DateOnly.FromDateTime(dtpOvertimeDate.Value);
                string status = cmbStatus.Text;

                var overtime = _db.Overtimes
                    .FirstOrDefault(o => o.EmployeeId == _selectedEmployee.Id && o.OvertimeDate == date)
                    ?? new Overtime
                    {
                        EmployeeId = _selectedEmployee.Id,
                        OvertimeDate = date,
                        Status = status
                    };

                overtime.Hours = hours;
                overtime.Status = status;
                overtime.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();
                overtime.CreatedById = CurrentUser.UserId;

                if (overtime.Id == 0)
                    _db.Overtimes.Add(overtime);

                _db.SaveChanges();

                MessageBox.Show($"تم حفظ {hours:F1} ساعة إضافية بحالة \"{status}\" بنجاح!",
                    "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOvertimeForEmployee(_selectedEmployee.Id);
                CalculateMonthlyOvertime(_selectedEmployee.Id);

                // مسح الحقول
                txtHours.Text = "0";
                txtNotes.Clear();
                cmbStatus.SelectedIndex = 0;
                dtpOvertimeDate.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHours.Text = "0";
            txtNotes.Clear();
            cmbStatus.SelectedIndex = 0;
            dtpOvertimeDate.Value = DateTime.Today;
            txtHours.Focus();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            // التحقق من وجود صف محدد في الجريد
            if (dgvOvertime.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر سجل عمل إضافي للحذف من الجدول", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // الحصول على السجل المحدد
                var selectedRow = dgvOvertime.SelectedRows[0];
                var overtime = selectedRow.DataBoundItem as Overtime;

                if (overtime == null)
                {
                    MessageBox.Show("لم يتم العثور على بيانات السجل", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تأكيد الحذف
                var result = MessageBox.Show(
                    $"هل أنت متأكد من حذف سجل العمل الإضافي؟\n\n" +
                    $"التاريخ: {overtime.OvertimeDate}\n" +
                    $"عدد الساعات: {overtime.Hours:F1} ساعة\n" +
                    $"الحالة: {overtime.Status}",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // استخدام context جديد للحذف لتجنب مشاكل التتبع
                    using (var deleteDb = new AppDbContext())
                    {
                        var overtimeToDelete = deleteDb.Overtimes.Find(overtime.Id);

                        if (overtimeToDelete != null)
                        {
                            deleteDb.Overtimes.Remove(overtimeToDelete);
                            deleteDb.SaveChanges();

                            MessageBox.Show("تم حذف السجل بنجاح!", "نجح",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // إعادة تحميل البيانات
                            if (_selectedEmployee != null)
                            {
                                LoadOvertimeForEmployee(_selectedEmployee.Id);
                                CalculateMonthlyOvertime(_selectedEmployee.Id);
                            }

                            // مسح الحقول
                            txtHours.Text = "0";
                            txtNotes.Clear();
                            cmbStatus.SelectedIndex = 0;
                            dtpOvertimeDate.Value = DateTime.Today;
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على السجل في قاعدة البيانات", "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف السجل: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // تحديث قائمة الموظفين
            LoadEmployees();

            // إذا كان في موظف محدد، أعد تحميل بياناته
            if (_selectedEmployee != null)
            {
                LoadOvertimeForEmployee(_selectedEmployee.Id);
                CalculateMonthlyOvertime(_selectedEmployee.Id);
                LoadTodayOvertime();
            }
        }
    }
}