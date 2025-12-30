namespace EmployeeManagementSystem.Forms
{
    partial class LogInForm
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
            label1 = new Label();
            usernameL = new Label();
            passwordL = new Label();
            usernameB = new TextBox();
            PasswordB = new TextBox();
            signinbtn = new Button();
            signupLL = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(619, 89);
            label1.TabIndex = 0;
            label1.Text = "نظام ادارة الموظفين ";
            // 
            // usernameL
            // 
            usernameL.AutoSize = true;
            usernameL.Font = new Font("Segoe UI", 20F);
            usernameL.Location = new Point(330, 139);
            usernameL.Name = "usernameL";
            usernameL.Size = new Size(187, 37);
            usernameL.TabIndex = 1;
            usernameL.Text = "اسم المستخدم ";
            // 
            // passwordL
            // 
            passwordL.AutoSize = true;
            passwordL.Font = new Font("Segoe UI", 20F);
            passwordL.Location = new Point(330, 202);
            passwordL.Name = "passwordL";
            passwordL.Size = new Size(143, 37);
            passwordL.TabIndex = 2;
            passwordL.Text = "كلمة المرور";
            // 
            // usernameB
            // 
            usernameB.Location = new Point(124, 153);
            usernameB.Name = "usernameB";
            usernameB.Size = new Size(138, 23);
            usernameB.TabIndex = 3;
            // 
            // PasswordB
            // 
            PasswordB.Location = new Point(124, 217);
            PasswordB.Name = "PasswordB";
            PasswordB.PasswordChar = '*';
            PasswordB.Size = new Size(138, 23);
            PasswordB.TabIndex = 4;
            // 
            // signinbtn
            // 
            signinbtn.Location = new Point(210, 284);
            signinbtn.Name = "signinbtn";
            signinbtn.Size = new Size(179, 49);
            signinbtn.TabIndex = 5;
            signinbtn.Text = "تسجيل دخول ";
            signinbtn.UseVisualStyleBackColor = true;
            signinbtn.Click += signinbtn_Click;
            // 
            // signupLL
            // 
            signupLL.AutoSize = true;
            signupLL.Location = new Point(12, 339);
            signupLL.Name = "signupLL";
            signupLL.Size = new Size(99, 15);
            signupLL.TabIndex = 6;
            signupLL.TabStop = true;
            signupLL.Text = "ليس لديك حساب؟ ";
            signupLL.LinkClicked += signupLL_LinkClicked;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 373);
            Controls.Add(signupLL);
            Controls.Add(signinbtn);
            Controls.Add(PasswordB);
            Controls.Add(usernameB);
            Controls.Add(passwordL);
            Controls.Add(usernameL);
            Controls.Add(label1);
            Name = "LogInForm";
            Text = " ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label usernameL;
        private Label passwordL;
        private TextBox usernameB;
        private TextBox PasswordB;
        private Button signinbtn;
        private LinkLabel signupLL;
    }
}