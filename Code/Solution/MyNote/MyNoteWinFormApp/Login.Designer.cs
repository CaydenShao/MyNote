namespace MyNoteWinFormApp
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tokenTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.addNoteButton = new System.Windows.Forms.Button();
            this.listNoteButton = new System.Windows.Forms.Button();
            this.searchNoteButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // addrTextBox
            // 
            this.addrTextBox.Location = new System.Drawing.Point(50, 2);
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.ReadOnly = true;
            this.addrTextBox.Size = new System.Drawing.Size(422, 21);
            this.addrTextBox.TabIndex = 1;
            this.addrTextBox.Text = "http://127.0.0.1:80/";
            // 
            // accountTextBox
            // 
            this.accountTextBox.Location = new System.Drawing.Point(50, 29);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.Size = new System.Drawing.Size(422, 21);
            this.accountTextBox.TabIndex = 1;
            this.accountTextBox.Text = "18827389685";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(50, 56);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(422, 21);
            this.passwordTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "账号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Token：";
            // 
            // tokenTextBox
            // 
            this.tokenTextBox.Location = new System.Drawing.Point(50, 81);
            this.tokenTextBox.Name = "tokenTextBox";
            this.tokenTextBox.ReadOnly = true;
            this.tokenTextBox.Size = new System.Drawing.Size(422, 21);
            this.tokenTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "姓名：";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(50, 108);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(422, 21);
            this.nameTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(397, 136);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.OnLoginButtonClick);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(316, 136);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "退出";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.OnLogoutButtonClick);
            // 
            // addNoteButton
            // 
            this.addNoteButton.Enabled = false;
            this.addNoteButton.Location = new System.Drawing.Point(5, 207);
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Size = new System.Drawing.Size(75, 75);
            this.addNoteButton.TabIndex = 3;
            this.addNoteButton.Text = "Add Note";
            this.addNoteButton.UseVisualStyleBackColor = true;
            this.addNoteButton.Click += new System.EventHandler(this.OnAddNoteButtonClick);
            // 
            // listNoteButton
            // 
            this.listNoteButton.Enabled = false;
            this.listNoteButton.Location = new System.Drawing.Point(86, 207);
            this.listNoteButton.Name = "listNoteButton";
            this.listNoteButton.Size = new System.Drawing.Size(75, 75);
            this.listNoteButton.TabIndex = 3;
            this.listNoteButton.Text = "List Note";
            this.listNoteButton.UseVisualStyleBackColor = true;
            this.listNoteButton.Click += new System.EventHandler(this.OnListNoteButtonClick);
            // 
            // searchNoteButton
            // 
            this.searchNoteButton.Enabled = false;
            this.searchNoteButton.Location = new System.Drawing.Point(167, 207);
            this.searchNoteButton.Name = "searchNoteButton";
            this.searchNoteButton.Size = new System.Drawing.Size(75, 75);
            this.searchNoteButton.TabIndex = 3;
            this.searchNoteButton.Text = "Search Note";
            this.searchNoteButton.UseVisualStyleBackColor = true;
            this.searchNoteButton.Click += new System.EventHandler(this.searchNoteButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(397, 165);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "注册";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.OnRegisterButtonClick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 294);
            this.Controls.Add(this.searchNoteButton);
            this.Controls.Add(this.listNoteButton);
            this.Controls.Add(this.addNoteButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.tokenTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.accountTextBox);
            this.Controls.Add(this.addrTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.TextBox accountTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tokenTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button addNoteButton;
        private System.Windows.Forms.Button listNoteButton;
        private System.Windows.Forms.Button searchNoteButton;
        private System.Windows.Forms.Button registerButton;
    }
}

