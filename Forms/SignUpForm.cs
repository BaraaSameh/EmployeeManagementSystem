using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void signupLLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var logInForm = new LogInForm();
            logInForm.Show();
            this.Hide();
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(SSNTB.Text))
            {
                MessageBox.Show("يرجى إدخال الرقم القومي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SSNTB.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(usernameBup.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameBup.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordBup.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordBup.Focus();
                return;
            }

            if (PasswordBup.Text.Length < 6)
            {
                MessageBox.Show("كلمة المرور يجب أن تكون 6 أحرف على الأقل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordBup.Focus();
                return;
            }

            using var db = new AppDbContext();

            // Check if employee exists with the provided SSN (National ID)
            var employee = db.Employees.FirstOrDefault(e => e.NationalId == SSNTB.Text.Trim());

            if (employee == null)
            {
                MessageBox.Show("الرقم القومي غير موجود في النظام. يرجى التواصل مع المسؤول لإضافة بياناتك أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SSNTB.Focus();
                return;
            }

            // Check if this employee already has a user account (ONE ACCOUNT PER SSN)
            if (db.Users.Any(u => u.EmployeeId == employee.Id))
            {
                MessageBox.Show("هذا الرقم القومي لديه حساب بالفعل. لا يمكن إنشاء أكثر من حساب لنفس الموظف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SSNTB.Clear();
                SSNTB.Focus();
                return;
            }

            // Check if username already exists
            if (db.Users.Any(u => u.Username == usernameBup.Text))
            {
                MessageBox.Show("اسم المستخدم موجود بالفعل، يرجى اختيار اسم آخر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameBup.Focus();
                return;
            }

            // Create new user and link to employee
            var newUser = new User
            {
                Username = usernameBup.Text.Trim(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordBup.Text),
                Role = "Employee", // Default role for new users
                EmployeeId = employee.Id
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            MessageBox.Show($"تم إنشاء الحساب بنجاح للموظف: {employee.FullName}\nيمكنك الآن تسجيل الدخول", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navigate to login form
            var logInForm = new LogInForm();
            logInForm.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
