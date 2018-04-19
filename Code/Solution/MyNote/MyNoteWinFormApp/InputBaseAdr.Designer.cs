namespace MyNoteWinFormApp
{
    partial class InputBaseAdr
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
            this.ipLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.versionComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(29, 21);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(29, 12);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "IP：";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(17, 56);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(41, 12);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port：";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(60, 17);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(212, 21);
            this.ipTextBox.TabIndex = 1;
            this.ipTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(60, 53);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(212, 21);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "80";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(49, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(163, 120);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(-1, 89);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(59, 12);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "Version：";
            // 
            // versionComboBox
            // 
            this.versionComboBox.FormattingEnabled = true;
            this.versionComboBox.Items.AddRange(new object[] {
            "V1.0",
            "V2.0"});
            this.versionComboBox.Location = new System.Drawing.Point(65, 86);
            this.versionComboBox.Name = "versionComboBox";
            this.versionComboBox.Size = new System.Drawing.Size(121, 20);
            this.versionComboBox.TabIndex = 3;
            this.versionComboBox.Text = "V1.0";
            // 
            // InputBaseAdr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.ControlBox = false;
            this.Controls.Add(this.versionComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "InputBaseAdr";
            this.Text = "其输入服务的IP和端口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.ComboBox versionComboBox;
    }
}