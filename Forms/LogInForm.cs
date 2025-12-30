using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeeManagementSystem.Data;

namespace EmployeeManagementSystem.Forms
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            this.AcceptButton = signinbtn;
        }

        private void signupLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        private void signinbtn_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(usernameB.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameB.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordB.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordB.Focus();
                return;
            }

            // Check credentials
            using var db = new AppDbContext();
            var user = db.Users.FirstOrDefault(u => u.Username == usernameB.Text);

            if (user != null && BCrypt.Net.BCrypt.Verify(PasswordB.Text, user.PasswordHash))
            {
                // Store current user information
                CurrentUser.UserId = user.Id;
                CurrentUser.Username = user.Username;
                CurrentUser.Role = user.Role;
                CurrentUser.EmployeeId = user.EmployeeId;

                // Navigate to main form
                this.Hide();
                var mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordB.Clear();
                PasswordB.Focus();
            }
        }
    }

    // Store current user session data
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static int? EmployeeId { get; set; }
    }
}
