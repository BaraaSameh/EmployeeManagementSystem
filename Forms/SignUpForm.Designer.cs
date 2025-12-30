namespace EmployeeManagementSystem.Forms
{
    partial class SignUpForm
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
            PasswordBup = new TextBox();
            usernameBup = new TextBox();
            passwordL = new Label();
            usernameL = new Label();
            signupbtn = new Button();
            signupLLL = new LinkLabel();
            label2 = new Label();
            SSNTB = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F);
            label1.Location = new Point(35, 9);
            label1.Name = "label1";
            label1.Size = new Size(500, 89);
            label1.TabIndex = 1;
            label1.Text = "عمل حساب جديد";
            // 
            // PasswordBup
            // 
            PasswordBup.Location = new Point(100, 240);
            PasswordBup.Name = "PasswordBup";
            PasswordBup.Size = new Size(138, 23);
            PasswordBup.TabIndex = 8;
            // 
            // usernameBup
            // 
            usernameBup.Location = new Point(100, 176);
            usernameBup.Name = "usernameBup";
            usernameBup.Size = new Size(138, 23);
            usernameBup.TabIndex = 7;
            // 
            // passwordL
            // 
            passwordL.AutoSize = true;
            passwordL.Font = new Font("Segoe UI", 20F);
            passwordL.Location = new Point(306, 225);
            passwordL.Name = "passwordL";
            passwordL.Size = new Size(143, 37);
            passwordL.TabIndex = 6;
            passwordL.Text = "كلمة المرور";
            // 
            // usernameL
            // 
            usernameL.AutoSize = true;
            usernameL.Font = new Font("Segoe UI", 20F);
            usernameL.Location = new Point(306, 162);
            usernameL.Name = "usernameL";
            usernameL.Size = new Size(187, 37);
            usernameL.TabIndex = 5;
            usernameL.Text = "اسم المستخدم ";
            // 
            // signupbtn
            // 
            signupbtn.Location = new Point(210, 315);
            signupbtn.Name = "signupbtn";
            signupbtn.Size = new Size(179, 49);
            signupbtn.TabIndex = 9;
            signupbtn.Text = "تسجيل";
            signupbtn.UseVisualStyleBackColor = true;
            signupbtn.Click += signupbtn_Click;
            // 
            // signupLLL
            // 
            signupLLL.AutoSize = true;
            signupLLL.Location = new Point(35, 391);
            signupLLL.Name = "signupLLL";
            signupLLL.Size = new Size(80, 15);
            signupLLL.TabIndex = 10;
            signupLLL.TabStop = true;
            signupLLL.Text = "تسجيل الدخول ";
            signupLLL.LinkClicked += signupLLL_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(306, 111);
            label2.Name = "label2";
            label2.Size = new Size(162, 37);
            label2.TabIndex = 11;
            label2.Text = "الرقم القومي";
            label2.Click += label2_Click;
            // 
            // SSNTB
            // 
            SSNTB.Location = new Point(100, 125);
            SSNTB.Name = "SSNTB";
            SSNTB.Size = new Size(138, 23);
            SSNTB.TabIndex = 12;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 425);
            Controls.Add(SSNTB);
            Controls.Add(label2);
            Controls.Add(signupLLL);
            Controls.Add(signupbtn);
            Controls.Add(PasswordBup);
            Controls.Add(usernameBup);
            Controls.Add(passwordL);
            Controls.Add(usernameL);
            Controls.Add(label1);
            Name = "SignUpForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox PasswordBup;
        private TextBox usernameBup;
        private Label passwordL;
        private Label usernameL;
        private Button signupbtn;
        private LinkLabel signupLLL;
        private Label label2;
        private TextBox SSNTB;
    }
}