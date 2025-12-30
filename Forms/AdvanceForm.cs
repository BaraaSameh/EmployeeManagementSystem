using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Forms
{
    public partial class AdvanceForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();
        private Employee? _selectedEmployee;

        public AdvanceForm()
        {
            InitializeComponent();
            CheckPermission();
            LoadEmployees();
            dtpAdvanceDate.Value = DateTime.Today;
        }

        private void CheckPermission()
        {
            if (CurrentUser.Role != "Admin" && CurrentUser.Role != "Manager")
            {
                MessageBox.Show("غير مصرح لك بالدخول إلى إدارة السلف.", "وصول ممنوع",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void LoadEmployees()
        {
            var employees = _db.Employees
                .OrderBy(e => e.FullName)
                .ToList();

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
                this.Text = $"إدارة السلف - {_selectedEmployee.FullName}";
                LoadAdvancesForEmployee(employeeId);
                CalculateTotalAdvances(employeeId);
            }
        }

        private void LoadAdvancesForEmployee(int employeeId)
        {
            try
            {
                var advances = _db.Advances
                    .Include(a => a.CreatedBy)
                    .Where(a => a.EmployeeId == employeeId)
                    .OrderByDescending(a => a.AdvanceDate)
                    .ThenByDescending(a => a.CreatedAt)
                    .AsNoTracking()
                    .ToList();

                dgvAdvances.DataSource = advances;

                if (advances.Any())
                {
                    // تنسيق الجدول - إخفاء الأعمدة غير الضرورية
                    if (dgvAdvances.Columns.Contains("Id"))
                        dgvAdvances.Columns["Id"]!.Visible = false;
                    if (dgvAdvances.Columns.Contains("EmployeeId"))
                        dgvAdvances.Columns["EmployeeId"]!.Visible = false;
                    if (dgvAdvances.Columns.Contains("Employee"))
                        dgvAdvances.Columns["Employee"]!.Visible = false;
                    if (dgvAdvances.Columns.Contains("CreatedById"))
                        dgvAdvances.Columns["CreatedById"]!.
                        Visible = false;
                    if (dgvAdvances.Columns.Contains("CreatedBy"))
                        dgvAdvances.Columns["CreatedBy"]!.Visible = false; // إخفاء العمود الأصلي

                    // تعيين العناوين العربية
                    if (dgvAdvances.Columns.Contains("Amount"))
                    {
                        dgvAdvances.Columns["Amount"]!.HeaderText = "المبلغ";
                        dgvAdvances.Columns["Amount"]!.DefaultCellStyle.Format = "N0";
                    }
                    if (dgvAdvances.Columns.Contains("AdvanceDate"))
                        dgvAdvances.Columns["AdvanceDate"]!.HeaderText = "تاريخ السلفة";
                    if (dgvAdvances.Columns.Contains("Notes"))
                        dgvAdvances.Columns["Notes"]!.HeaderText = "ملاحظات";
                    if (dgvAdvances.Columns.Contains("CreatedAt"))
                        dgvAdvances.Columns["CreatedAt"]!.HeaderText = "تاريخ التسجيل";

                    // إزالة عمود "مسجل بواسطة" إذا كان موجوداً
                    if (dgvAdvances.Columns.Contains("CreatedByName"))
                        dgvAdvances.Columns.Remove("CreatedByName");

                    // إضافة عمود مخصص لاسم المستخدم
                    var createdByColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "CreatedByName",
                        HeaderText = "مسجل بواسطة",
                        ReadOnly = true,
                        Width = 120
                    };
                    dgvAdvances.Columns.Insert(dgvAdvances.Columns.Count, createdByColumn);

                    // ملء عمود "مسجل بواسطة" بأسماء المستخدمين
                    foreach (DataGridViewRow row in dgvAdvances.Rows)
                    {
                        var advance = row.DataBoundItem as Advance;
                        if (advance?.CreatedBy != null)
                        {
                            row.Cells["CreatedByName"].Value = advance.CreatedBy.Username;
                        }
                        else
                        {
                            row.Cells["CreatedByName"].Value = "غير معروف";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل السلف: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalAdvances(int employeeId)
        {
            decimal total = _db.Advances
                .Where(a => a.EmployeeId == employeeId)
                .Sum(a => a.Amount);

            lblTotalAdvances.Text = $"إجمالي السلف لهذا الموظف: {total:N0} جنيه";
            lblTotalAdvances.ForeColor = total > 0 ? Color.Red : Color.Green;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("اختار موظف أولاً");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("ادخل مبلغ صحيح أكبر من صفر");
                return;
            }

            var advance = new Advance
            {
                EmployeeId = _selectedEmployee.Id,
                Amount = amount,
                AdvanceDate = DateOnly.FromDateTime(dtpAdvanceDate.Value),
                Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text,
                CreatedById = CurrentUser.UserId
            };

            _db.Advances.Add(advance);
            _db.SaveChanges();

            MessageBox.Show($"تم تسجيل سلفة بقيمة {amount:N0} جنيه بنجاح!", "نجاح");

            LoadAdvancesForEmployee(_selectedEmployee.Id);
            CalculateTotalAdvances(_selectedEmployee.Id);
            //btnClear.PerformClick();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
            txtNotes.Clear();
            dtpAdvanceDate.Value = DateTime.Today;
            txtAmount.Focus();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("اختار موظف أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployees.Focus();
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("ادخل مبلغ صحيح أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            try
            {
                var advance = new Advance
                {
                    EmployeeId = _selectedEmployee.Id,
                    Amount = amount,
                    AdvanceDate = DateOnly.FromDateTime(dtpAdvanceDate.Value),
                    Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim(),
                    CreatedById = CurrentUser.UserId
                };

                _db.Advances.Add(advance);
                _db.SaveChanges();

                MessageBox.Show($"تم تسجيل سلفة بقيمة {amount:N0} جنيه بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadAdvancesForEmployee(_selectedEmployee.Id);
                CalculateTotalAdvances(_selectedEmployee.Id);
                btnClear_Click(sender, e); // مسح الحقول بعد الحفظ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ السلفة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Close();

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            // التحقق من وجود صف محدد في الجريد
            if (dgvAdvances.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر سلفة للحذف من الجدول", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // الحصول على السجل المحدد
                var selectedRow = dgvAdvances.SelectedRows[0];
                var advance = selectedRow.DataBoundItem as Advance;

                if (advance == null)
                {
                    MessageBox.Show("لم يتم العثور على بيانات السلفة", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تأكيد الحذف
                var result = MessageBox.Show(
                    $"هل أنت متأكد من حذف السلفة؟\n\n" +
                    $"المبلغ: {advance.Amount:N0} جنيه\n" +
                    $"التاريخ: {advance.AdvanceDate}\n" +
                    $"ملاحظات: {advance.Notes ?? "لا توجد"}",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // استخدام context جديد للحذف لتجنب مشاكل التتبع
                    using (var deleteDb = new AppDbContext())
                    {
                        var advanceToDelete = deleteDb.Advances.Find(advance.Id);

                        if (advanceToDelete != null)
                        {
                            deleteDb.Advances.Remove(advanceToDelete);
                            deleteDb.SaveChanges();

                            MessageBox.Show("تم حذف السلفة بنجاح!", "نجح",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // إعادة تحميل البيانات
                            if (_selectedEmployee != null)
                            {
                                LoadAdvancesForEmployee(_selectedEmployee.Id);
                                CalculateTotalAdvances(_selectedEmployee.Id);
                            }

                            // مسح الحقول
                            txtAmount.Clear();
                            txtNotes.Clear();
                            dtpAdvanceDate.Value = DateTime.Today;
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على السلفة في قاعدة البيانات", "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف السلفة: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            // تحديث قائمة الموظفين
            LoadEmployees();

            // إذا كان في موظف محدد، أعد تحميل بياناته
            if (_selectedEmployee != null)
            {
                LoadAdvancesForEmployee(_selectedEmployee.Id);
                CalculateTotalAdvances(_selectedEmployee.Id);
            }
        }
    }
}