namespace MyNoteWinFormApp
{
    partial class SearchNote
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
            this.notesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.webLabel = new System.Windows.Forms.Label();
            this.enterTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.titleRadioButton = new System.Windows.Forms.RadioButton();
            this.remarkRadioButton = new System.Windows.Forms.RadioButton();
            this.keystrTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timespanRadioButton = new System.Windows.Forms.RadioButton();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notesFlowLayoutPanel
            // 
            this.notesFlowLayoutPanel.AutoScroll = true;
            this.notesFlowLayoutPanel.Location = new System.Drawing.Point(12, 53);
            this.notesFlowLayoutPanel.Name = "notesFlowLayoutPanel";
            this.notesFlowLayoutPanel.Size = new System.Drawing.Size(560, 519);
            this.notesFlowLayoutPanel.TabIndex = 1;
            // 
            // webLabel
            // 
            this.webLabel.AutoSize = true;
            this.webLabel.Location = new System.Drawing.Point(176, 583);
            this.webLabel.Name = "webLabel";
            this.webLabel.Size = new System.Drawing.Size(83, 12);
            this.webLabel.TabIndex = 8;
            this.webLabel.Text = "1/1 共0条记录";
            // 
            // enterTextBox
            // 
            this.enterTextBox.Location = new System.Drawing.Point(437, 579);
            this.enterTextBox.Name = "enterTextBox";
            this.enterTextBox.Size = new System.Drawing.Size(54, 21);
            this.enterTextBox.TabIndex = 7;
            this.enterTextBox.Text = "1";
            this.enterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(497, 579);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 23);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.OnEnterButtonClick);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(93, 578);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.OnNextButtonClick);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(12, 578);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 6;
            this.prevButton.Text = "Prev";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.OnPrevButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "选择搜索方式：";
            // 
            // titleRadioButton
            // 
            this.titleRadioButton.AutoSize = true;
            this.titleRadioButton.Checked = true;
            this.titleRadioButton.Location = new System.Drawing.Point(107, 7);
            this.titleRadioButton.Name = "titleRadioButton";
            this.titleRadioButton.Size = new System.Drawing.Size(53, 16);
            this.titleRadioButton.TabIndex = 10;
            this.titleRadioButton.TabStop = true;
            this.titleRadioButton.Text = "title";
            this.titleRadioButton.UseVisualStyleBackColor = true;
            this.titleRadioButton.CheckedChanged += new System.EventHandler(this.titleRadioButton_CheckedChanged);
            // 
            // remarkRadioButton
            // 
            this.remarkRadioButton.AutoSize = true;
            this.remarkRadioButton.Location = new System.Drawing.Point(178, 7);
            this.remarkRadioButton.Name = "remarkRadioButton";
            this.remarkRadioButton.Size = new System.Drawing.Size(59, 16);
            this.remarkRadioButton.TabIndex = 10;
            this.remarkRadioButton.Text = "remark";
            this.remarkRadioButton.UseVisualStyleBackColor = true;
            this.remarkRadioButton.CheckedChanged += new System.EventHandler(this.remarkRadioButton_CheckedChanged);
            // 
            // keystrTextBox
            // 
            this.keystrTextBox.Location = new System.Drawing.Point(320, 6);
            this.keystrTextBox.Name = "keystrTextBox";
            this.keystrTextBox.Size = new System.Drawing.Size(141, 21);
            this.keystrTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "关键字：";
            // 
            // timespanRadioButton
            // 
            this.timespanRadioButton.AutoSize = true;
            this.timespanRadioButton.Location = new System.Drawing.Point(107, 29);
            this.timespanRadioButton.Name = "timespanRadioButton";
            this.timespanRadioButton.Size = new System.Drawing.Size(59, 16);
            this.timespanRadioButton.TabIndex = 10;
            this.timespanRadioButton.Text = "时间段";
            this.timespanRadioButton.UseVisualStyleBackColor = true;
            this.timespanRadioButton.CheckedChanged += new System.EventHandler(this.timespanRadioButton_CheckedChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(178, 28);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(121, 21);
            this.startDateTimePicker.TabIndex = 12;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(340, 28);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(121, 21);
            this.endDateTimePicker.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "——";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(468, 7);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(104, 42);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "开始搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // SearchNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 602);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.keystrTextBox);
            this.Controls.Add(this.remarkRadioButton);
            this.Controls.Add(this.timespanRadioButton);
            this.Controls.Add(this.titleRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webLabel);
            this.Controls.Add(this.enterTextBox);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.notesFlowLayoutPanel);
            this.Name = "SearchNote";
            this.Text = "SearchNote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel notesFlowLayoutPanel;
        private System.Windows.Forms.Label webLabel;
        private System.Windows.Forms.TextBox enterTextBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton titleRadioButton;
        private System.Windows.Forms.RadioButton remarkRadioButton;
        private System.Windows.Forms.TextBox keystrTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton timespanRadioButton;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchButton;
    }
}