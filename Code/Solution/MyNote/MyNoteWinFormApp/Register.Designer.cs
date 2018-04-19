namespace MyNoteWinFormApp
{
    partial class Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.confirmPwdTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.verificationTextBox = new System.Windows.Forms.TextBox();
            this.getVerificationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "确认密码：";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(65, 6);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(207, 21);
            this.phoneNumberTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(65, 38);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(207, 21);
            this.nameTextBox.TabIndex = 1;
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Location = new System.Drawing.Point(65, 69);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = '*';
            this.pwdTextBox.Size = new System.Drawing.Size(207, 21);
            this.pwdTextBox.TabIndex = 1;
            // 
            // confirmPwdTextBox
            // 
            this.confirmPwdTextBox.Location = new System.Drawing.Point(65, 101);
            this.confirmPwdTextBox.Name = "confirmPwdTextBox";
            this.confirmPwdTextBox.PasswordChar = '*';
            this.confirmPwdTextBox.Size = new System.Drawing.Size(207, 21);
            this.confirmPwdTextBox.TabIndex = 1;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(12, 171);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(260, 79);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.OnRegisterButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "验证码：";
            // 
            // verificationTextBox
            // 
            this.verificationTextBox.Location = new System.Drawing.Point(65, 132);
            this.verificationTextBox.Name = "verificationTextBox";
            this.verificationTextBox.Size = new System.Drawing.Size(69, 21);
            this.verificationTextBox.TabIndex = 1;
            // 
            // getVerificationButton
            // 
            this.getVerificationButton.Location = new System.Drawing.Point(140, 132);
            this.getVerificationButton.Name = "getVerificationButton";
            this.getVerificationButton.Size = new System.Drawing.Size(132, 23);
            this.getVerificationButton.TabIndex = 3;
            this.getVerificationButton.Text = "获取验证码";
            this.getVerificationButton.UseVisualStyleBackColor = true;
            this.getVerificationButton.Click += new System.EventHandler(this.OnGetVerificationButtonClick);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.getVerificationButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.verificationTextBox);
            this.Controls.Add(this.confirmPwdTextBox);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.TextBox confirmPwdTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox verificationTextBox;
        private System.Windows.Forms.Button getVerificationButton;
    }
}