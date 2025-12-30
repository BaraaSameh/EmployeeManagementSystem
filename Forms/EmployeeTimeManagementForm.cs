using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Forms
{
    public partial class EmployeeTimeManagementForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();
        private Employee? _selectedEmployee;

        // Constants
        private const int STANDARD_WORK_HOURS = 8;
        private const int MONTHLY_WORK_HOURS = 160;
        private const string HOURLY_LEAVE_TYPE = "إذن ساعات";
        private const string FULL_DAY_LEAVE_TYPE = "إجازة يوم كامل";
        private const string ABSENCE_TYPE = "غياب";
        private const string STATUS_PENDING = "Pending";
        private const string STATUS_APPROVED = "Approved";
        private const string STATUS_REJECTED = "Rejected";

        public EmployeeTimeManagementForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        #region Initialization

        private void InitializeForm()
        {
            CheckPermission();
            LoadEmployees();
            LoadShifts();
            InitializeControls();
        }

        private void InitializeControls()
        {
            dtpDate.Value = DateTime.Today;

            // Initialize leave type combo box
            cmbType.Items.AddRange(new[] { HOURLY_LEAVE_TYPE, FULL_DAY_LEAVE_TYPE, ABSENCE_TYPE });
            cmbType.SelectedIndex = 0;

            // Initialize status combo box
            cmbStatus.Items.AddRange(new[] { STATUS_PENDING, STATUS_APPROVED, STATUS_REJECTED });
            cmbStatus.SelectedIndex = 0;

            // Hide hours textbox initially
            txtHours.Visible = true;

        }

        private void CheckPermission()
        {
            if (CurrentUser.Role is not ("Admin" or "Manager"))
            {
                MessageBox.Show("غير مصرح لك بالدخول إلى هذه الشاشة.", "وصول ممنوع",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
        }

        #endregion

        #region Data Loading

        private void LoadEmployees()
        {
            try
            {
                var employees = _db.Employees
                    .Include(e => e.Department)
                    .Include(e => e.Shift)  // إضافة تحميل الشيفت
                    .OrderBy(e => e.FullName)
                    .ToList();

                cmbEmployees.DataSource = employees;
                cmbEmployees.DisplayMember = "FullName";
                cmbEmployees.ValueMember = "Id";
                cmbEmployees.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowError($" حدث خطأ أثناء تحميل قائمة الموظفين: {ex.Message}");
            }
        }

        private void LoadShifts()
        {
            try
            {
                var shifts = _db.Shifts.OrderBy(s => s.Name).ToList();

                if (!shifts.Any())
                {
                    ShowWarning("لا توجد شيفتات في النظام. يرجى إضافة شيفتات أولاً.");
                    return;
                }

                cmbShift.DataSource = shifts;
                cmbShift.DisplayMember = "Name";
                cmbShift.ValueMember = "Id";
                cmbShift.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء تحميل قائمة الشيفتات: {ex.Message}");
            }
        }

        private void LoadTodayLeave()
        {
            if (_selectedEmployee == null) return;

            try
            {
                var date = DateOnly.FromDateTime(dtpDate.Value);
                var leave = _db.LeaveRequests
                    .AsNoTracking()
                    .FirstOrDefault(l => l.EmployeeId == _selectedEmployee.Id && l.Date == date);

                if (leave != null)
                {
                    PopulateLeaveData(leave);
                }
                else
                {
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء تحميل بيانات الإذن: {ex.Message}");
            }
        }

        private void LoadLeavesForEmployee(int employeeId)
        {
            try
            {
                // إزالة تحديد الشهر لعرض كل البيانات
                var leaves = _db.LeaveRequests
                    .Include(l => l.ApprovedBy)
                    .Include(l => l.Employee)
                        .ThenInclude(e => e.Shift)  // تحميل بيانات الشيفت للموظف
                    .Where(l => l.EmployeeId == employeeId)
                    .OrderByDescending(l => l.Date)
                    .AsNoTracking()
                    .ToList();

                dgvLeaves.DataSource = leaves;
                ConfigureGridViewColumns();
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء تحميل سجلات الإذن: {ex.Message}");
            }
        }

        #endregion

        #region Grid View Configuration

        private void ConfigureGridViewColumns()
        {
            // Hide unnecessary columns
            HideColumn("Id");
            HideColumn("EmployeeId");
            HideColumn("Employee");
            HideColumn("ApprovedById");
            HideColumn("ApprovedBy");
            HideColumn("FromTime");  // إخفاء عمود من الساعة
            HideColumn("ToTime");    // إخفاء عمود إلى الساعة

            // Set Arabic headers
            SetColumnHeader("Date", "التاريخ");
            SetColumnHeader("Type", "النوع");
            SetColumnHeader("Reason", "السبب");
            SetColumnHeader("Status", "الحالة");
            SetColumnHeader("RejectReason", "ملاحظات / سبب الرفض");

            // إزالة الأعمدة المخصصة إذا كانت موجودة لتجنب التكرار
            if (dgvLeaves.Columns.Contains("LeaveHours"))
                dgvLeaves.Columns.Remove("LeaveHours");
            if (dgvLeaves.Columns.Contains("ShiftName"))
                dgvLeaves.Columns.Remove("ShiftName");

            // إضافة عمود عدد ساعات الإذن
            var leaveHoursColumn = new DataGridViewTextBoxColumn
            {
                Name = "LeaveHours",
                HeaderText = "عدد ساعات الإذن",
                ReadOnly = true,
                Width = 120
            };
            dgvLeaves.Columns.Insert(2, leaveHoursColumn); // بعد عمود التاريخ والنوع

            // إضافة عمود الشيفت
            var shiftNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ShiftName",
                HeaderText = "الشيفت",
                ReadOnly = true,
                Width = 100
            };
            dgvLeaves.Columns.Insert(3, shiftNameColumn); // بعد عمود عدد الساعات

            // ملء الأعمدة المخصصة
            foreach (DataGridViewRow row in dgvLeaves.Rows)
            {
                var leave = row.DataBoundItem as LeaveRequest;
                if (leave != null)
                {
                    decimal hours = 0;

                    if (leave.FromTime.HasValue && leave.ToTime.HasValue)
                    {
                        // حساب عدد الساعات من FromTime و ToTime
                        hours = CalculateHours(leave.FromTime.Value, leave.ToTime.Value);
                    }
                    else if (leave.Type != HOURLY_LEAVE_TYPE)
                    {
                        // إذا كان يوم كامل أو غياب
                        hours = STANDARD_WORK_HOURS;
                    }

                    row.Cells["LeaveHours"].Value = $"{hours:F1} ساعة";

                    // عرض اسم الشيفت من خلال الموظف
                    if (leave.Employee?.Shift != null)
                    {
                        row.Cells["ShiftName"].Value = leave.Employee.Shift.Name;
                    }
                    else
                    {
                        row.Cells["ShiftName"].Value = "-- لا يوجد --";
                    }
                }
            }
        }

        private void HideColumn(string columnName)
        {
            if (dgvLeaves.Columns.Contains(columnName))
                dgvLeaves.Columns[columnName]!.Visible = false;
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvLeaves.Columns.Contains(columnName))
                dgvLeaves.Columns[columnName]!.HeaderText = headerText;
        }

        #endregion

        #region Calculations

        private void CalculateMonthlyTotal(int employeeId)
        {
            try
            {
                var monthStart = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, 1);
                var monthEnd = monthStart.AddMonths(1).AddDays(-1);

                var approvedLeaves = _db.LeaveRequests
                    .Where(l => l.EmployeeId == employeeId &&
                                l.Date >= monthStart &&
                                l.Date <= monthEnd &&
                                l.Status == STATUS_APPROVED)
                    .AsNoTracking()
                    .ToList();

                decimal totalHours = CalculateTotalLeaveHours(approvedLeaves);

                lblMonthlyTotal.Text = $"إجمالي ساعات الخصم هذا الشهر: {totalHours:F1} ساعة";

                if (_selectedEmployee != null)
                {
                    CalculateDeduction(totalHours);
                }
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء حساب الإجمالي الشهري: {ex.Message}");
            }
        }

        private decimal CalculateTotalLeaveHours(List<LeaveRequest> leaves)
        {
            decimal totalHours = 0m;

            foreach (var leave in leaves)
            {
                if (leave.FromTime.HasValue && leave.ToTime.HasValue)
                {
                    totalHours += CalculateHours(leave.FromTime.Value, leave.ToTime.Value);
                }
                else if (leave.Type != HOURLY_LEAVE_TYPE)
                {
                    totalHours += STANDARD_WORK_HOURS;
                }
            }

            return totalHours;
        }

        private void CalculateDeduction(decimal totalHours)
        {
            if (_selectedEmployee == null) return;

            decimal hourlyRate = _selectedEmployee.BaseSalary / MONTHLY_WORK_HOURS;
            decimal deduction = totalHours * hourlyRate;

            // Uncomment if you have a deduction label
            // lblDeduction.Text = $"المبلغ المخصوم هذا الشهر: {deduction:N0} جنيه";
        }

        private static decimal CalculateHours(TimeOnly from, TimeOnly to)
        {
            var fromSpan = from.ToTimeSpan();
            var toSpan = to.ToTimeSpan();

            // Handle crossing midnight
            if (toSpan < fromSpan)
                toSpan = toSpan.Add(TimeSpan.FromDays(1));

            return (decimal)(toSpan - fromSpan).TotalHours;
        }

        #endregion

        #region Event Handlers

        private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedIndex == -1 || cmbEmployees.SelectedValue == null)
            {
                _selectedEmployee = null;
                ClearEmployeeData();
                return;
            }

            try
            {
                int employeeId = (int)cmbEmployees.SelectedValue;
                _selectedEmployee = _db.Employees
                    .Include(e => e.Shift)  // إضافة تحميل بيانات الشيفت
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == employeeId);

                if (_selectedEmployee == null)
                {
                    ShowWarning("لم يتم العثور على بيانات الموظف");
                    return;
                }

                LoadEmployeeData(employeeId);
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء تحديد الموظف: {ex.Message}");
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isHourly = cmbType.Text == HOURLY_LEAVE_TYPE;
            txtHours.Visible = isHourly;
            txtHours.Text = isHourly ? "0" : STANDARD_WORK_HOURS.ToString();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedEmployee != null)
            {
                LoadTodayLeave();
                LoadLeavesForEmployee(_selectedEmployee.Id);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                SaveLeaveRequest();
                ShowSuccess("تم الحفظ بنجاح!");

                if (_selectedEmployee != null)
                {
                    LoadLeavesForEmployee(_selectedEmployee.Id);
                    CalculateMonthlyTotal(_selectedEmployee.Id);
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء الحفظ: {ex.Message}");
            }
        }


        private void btnClear_Click(object sender, EventArgs e) => ResetForm();

        private void lblMonthlyTotal_Click(object sender, EventArgs e)
        {
            // Reserved for future functionality
        }

        private void EmployeeTimeManagementForm_Load(object sender, EventArgs e)
        {
            cmbEmployees.SelectedIndexChanged += cmbEmployees_SelectedIndexChanged;
        }

        #endregion

        #region Data Manipulation

        private void LoadEmployeeData(int employeeId)
        {
            LoadLeavesForEmployee(employeeId);
            CalculateMonthlyTotal(employeeId);
            LoadTodayLeave();
        }

        private void ClearEmployeeData()
        {
            dgvLeaves.DataSource = null;
            lblMonthlyTotal.Text = "إجمالي ساعات الخصم هذا الشهر: 0.0 ساعة";
            ResetForm();
        }

        private void PopulateLeaveData(LeaveRequest leave)
        {
            cmbType.Text = leave.Type;
            txtReason.Text = leave.Reason;
            txtNotes.Text = leave.RejectReason ?? "";
            cmbStatus.Text = leave.Status;

            if (leave.FromTime.HasValue && leave.ToTime.HasValue)
            {
                txtHours.Text = CalculateHours(leave.FromTime.Value, leave.ToTime.Value).ToString("F1");
            }
        }

        private void SaveLeaveRequest()
        {
            var date = DateOnly.FromDateTime(dtpDate.Value);

            var leave = _db.LeaveRequests
                .FirstOrDefault(l => l.EmployeeId == _selectedEmployee!.Id && l.Date == date)
                ?? new LeaveRequest
                {
                    EmployeeId = _selectedEmployee!.Id,
                    Date = date
                };

            PopulateLeaveRequest(leave);

            if (leave.Id == 0)
                _db.LeaveRequests.Add(leave);
            else
                _db.LeaveRequests.Update(leave);

            _db.SaveChanges();
        }

        private void PopulateLeaveRequest(LeaveRequest leave)
        {
            leave.Type = cmbType.Text;
            leave.Reason = txtReason.Text.Trim();
            leave.RejectReason = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();
            leave.Status = cmbStatus.Text;
            leave.ApprovedById = CurrentUser.UserId;

            if (cmbType.Text == HOURLY_LEAVE_TYPE)
            {
                SetHourlyLeaveTime(leave);
            }
            else
            {
                leave.FromTime = null;
                leave.ToTime = null;
            }
        }

        private void SetHourlyLeaveTime(LeaveRequest leave)
        {
            if (cmbShift.SelectedItem is not Shift selectedShift)
            {
                throw new InvalidOperationException("لم يتم اختيار شيفت صحيح");
            }

            decimal hours = decimal.Parse(txtHours.Text);

            leave.FromTime = selectedShift.FromTime;

            var fromDateTime = DateTime.Today.Add(selectedShift.FromTime.ToTimeSpan());
            var toDateTime = fromDateTime.AddHours((double)hours);
            leave.ToTime = TimeOnly.FromDateTime(toDateTime);
        }

        #endregion

        #region Validation

        private bool ValidateInput()
        {
            if (_selectedEmployee == null)
            {
                ShowWarning("اختار موظف أولاً");
                cmbEmployees.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                ShowWarning("اكتب سبب الإذن أو الغياب");
                txtReason.Focus();
                return false;
            }

            if (cmbType.Text == HOURLY_LEAVE_TYPE)
            {
                if (!ValidateHourlyLeave())
                    return false;
            }

            return true;
        }

        private bool ValidateHourlyLeave()
        {
            if (!decimal.TryParse(txtHours.Text, out decimal hours) || hours <= 0)
            {
                ShowWarning("ادخل عدد ساعات أكبر من صفر");
                txtHours.Focus();
                return false;
            }

            if (cmbShift.SelectedItem is not Shift)
            {
                ShowWarning("اختار شيفت صحيح");
                cmbShift.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region UI Helpers

        private void ResetForm()
        {
            txtReason.Clear();
            txtNotes.Clear();
            txtHours.Text = "0";
            cmbType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Cleanup

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }

        #endregion

        private void txtHours_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                SaveLeaveRequest();
                ShowSuccess("تم الحفظ بنجاح!");

                if (_selectedEmployee != null)
                {
                    LoadLeavesForEmployee(_selectedEmployee.Id);
                    CalculateMonthlyTotal(_selectedEmployee.Id);
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء الحفظ: {ex.Message}");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            // التحقق من وجود صف محدد في الجريد
            if (dgvLeaves.SelectedRows.Count == 0)
            {
                ShowWarning("اختر سجل إذن للحذف من الجدول");
                return;
            }

            try
            {
                // الحصول على السجل المحدد
                var selectedRow = dgvLeaves.SelectedRows[0];
                var leaveRequest = selectedRow.DataBoundItem as LeaveRequest;

                if (leaveRequest == null)
                {
                    ShowError("لم يتم العثور على بيانات السجل");
                    return;
                }

                // تأكيد الحذف
                var result = MessageBox.Show(
                    $"هل أنت متأكد من حذف سجل الإذن؟\n\n" +
                    $"التاريخ: {leaveRequest.Date}\n" +
                    $"النوع: {leaveRequest.Type}\n" +
                    $"السبب: {leaveRequest.Reason}\n" +
                    $"الحالة: {leaveRequest.Status}",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // استخدام context جديد للحذف لتجنب مشاكل التتبع
                    using (var deleteDb = new AppDbContext())
                    {
                        var leaveToDelete = deleteDb.LeaveRequests.Find(leaveRequest.Id);

                        if (leaveToDelete != null)
                        {
                            deleteDb.LeaveRequests.Remove(leaveToDelete);
                            deleteDb.SaveChanges();

                            ShowSuccess("تم حذف السجل بنجاح!");

                            // إعادة تحميل البيانات
                            if (_selectedEmployee != null)
                            {
                                LoadLeavesForEmployee(_selectedEmployee.Id);
                                CalculateMonthlyTotal(_selectedEmployee.Id);
                            }

                            // مسح الحقول
                            ResetForm();
                        }
                        else
                        {
                            ShowError("لم يتم العثور على السجل في قاعدة البيانات");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"حدث خطأ أثناء حذف السجل: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // تحديث قائمة الموظفين
            LoadEmployees();

            // إذا كان في موظف محدد، أعد تحميل بياناته
            if (_selectedEmployee != null)
            {
                LoadLeavesForEmployee(_selectedEmployee.Id);
                CalculateMonthlyTotal(_selectedEmployee.Id);
                LoadTodayLeave();
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();  
               mainForm.Show();
                this.Close();
        }
    }
}