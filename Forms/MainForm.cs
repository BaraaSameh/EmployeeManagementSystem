using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadUserData();
            ApplyRolePermissions();
        }

        private void LoadUserData()
        {
            lblWelcome.Text = $"أهلاً وسهلاً، {CurrentUser.Username}";

            using var db = new AppDbContext();

            // جلب بيانات الموظف المرتبط باليوزر (لو موجود)
            if (CurrentUser.EmployeeId.HasValue)
            {
                var employee = db.Employees
                    .FirstOrDefault(e => e.Id == CurrentUser.EmployeeId.Value);

                if (employee != null)
                {
                    lblWelcome.Text = $"أهلاً وسهلاً، {employee.FullName}";

                    // عرض الصورة لو موجودة
                    if (employee.PhotoData != null && employee.PhotoData.Length > 0)
                    {
                        using var ms = new MemoryStream(employee.PhotoData);
                        picUserPhoto.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        //// صورة افتراضية (هنضيفها بعدين)
                        //picUserPhoto.Image = Resources.default_avatar; // أو صورة من Resources

                    }
                }
            }

            // تلوين الدور
            lblRole.Text = $"الدور: {GetRoleArabic(CurrentUser.Role)}";
            lblRole.ForeColor = CurrentUser.Role switch
            {
                "Admin" => Color.DarkRed,
                "Manager" => Color.DarkBlue,
                "Employee" => Color.DarkGreen,
                _ => Color.Black
            };
        }

        private string GetRoleArabic(string role)
        {
            return role switch
            {
                "Admin" => "مدير النظام",
                "Manager" => "مدير قسم",
                "Employee" => "موظف",
                _ => role
            };
        }

        private void ApplyRolePermissions()
        {
            bool isAdmin = CurrentUser.Role == "Admin";
            bool isManager = CurrentUser.Role == "Manager" || isAdmin; // Manager يشوف معظم الحاجات

            // الأدمن يشوف كل حاجة
            btnSettings.Visible = isAdmin;
            btnEmployees.Visible = isManager;
            btnReports.Visible = isManager;

            // الشاشة الجديدة (بدل Attendance وLeaves)
            // نضيف زر جديد اسمه btnTimeManagement, Text = "إدارة الوقت والإذن"

            // الموظف العادي يشوف بس الترحيب وLogout
            if (!isManager)
            {
                btnEmployees.Visible = false;
                btnReports.Visible = false;
                btnSettings.Visible = false;


                MessageBox.Show("مرحبًا! بياناتك الشخصية متاحة فقط. تواصل مع الإدارة للمزيد.", "معلومات");
            }
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.UserId = 0;
            CurrentUser.Username = "";
            CurrentUser.Role = "";
            CurrentUser.EmployeeId = null;

            this.Hide();
            new LogInForm().ShowDialog();
            this.Close();
        }

        // الأزرار التانية هنكملها واحد واحد في الخطوات الجاية
        //private void btnEmployees_Click(object sender, EventArgs e)
        //{
        //    new EmployeesForm().ShowDialog();
        //}

        //private void btnAttendance_Click(object sender, EventArgs e)
        //{
        //    new AttendanceForm().ShowDialog();
        //}

        //private void btnLeaves_Click(object sender, EventArgs e)
        //{
        //    new LeavesForm().ShowDialog();
        //}

        //private void btnReports_Click(object sender, EventArgs e)
        //{
        //    new ReportsForm().ShowDialog();
        //}

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("صفحة الإعدادات (هنعملها بعدين)");
        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            // Confirm logout
            var result = MessageBox.Show("هل أنت متأكد من تسجيل الخروج؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear current user session
                CurrentUser.UserId = 0;
                CurrentUser.Username = string.Empty;
                CurrentUser.Role = string.Empty;
                CurrentUser.EmployeeId = null;

                // Navigate to login form
                this.Hide();
                var logInForm = new LogInForm();
                logInForm.FormClosed += (s, args) => this.Close();
                logInForm.Show();
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var employeesForm = new EmployeesForm();
            employeesForm.Show();
            this.Hide();

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            var attendanceForm = new AttendanceForm();
            attendanceForm.Show();
            this.Hide();
        }

        private void btnLeaves_Click(object sender, EventArgs e)
        {
            var leavesForm = new EmployeeTimeManagementForm();
            leavesForm.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var advancesForm = new AdvanceForm();
            advancesForm.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var overtimeForm = new OvertimeForm();
            overtimeForm.Show();
            this.Hide();
        }
    }
}