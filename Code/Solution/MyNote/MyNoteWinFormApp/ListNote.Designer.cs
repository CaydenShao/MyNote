namespace MyNoteWinFormApp
{
    partial class ListNote
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
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.enterTextBox = new System.Windows.Forms.TextBox();
            this.webLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notesFlowLayoutPanel
            // 
            this.notesFlowLayoutPanel.AutoScroll = true;
            this.notesFlowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.notesFlowLayoutPanel.Name = "notesFlowLayoutPanel";
            this.notesFlowLayoutPanel.Size = new System.Drawing.Size(560, 519);
            this.notesFlowLayoutPanel.TabIndex = 0;
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(12, 537);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "Prev";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.OnPrevButtonClick);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(93, 537);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.OnNextButtonClick);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(497, 538);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 23);
            this.enterButton.TabIndex = 1;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.OnEnterButtonClick);
            // 
            // enterTextBox
            // 
            this.enterTextBox.Location = new System.Drawing.Point(437, 538);
            this.enterTextBox.Name = "enterTextBox";
            this.enterTextBox.Size = new System.Drawing.Size(54, 21);
            this.enterTextBox.TabIndex = 2;
            this.enterTextBox.Text = "1";
            this.enterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // webLabel
            // 
            this.webLabel.AutoSize = true;
            this.webLabel.Location = new System.Drawing.Point(176, 542);
            this.webLabel.Name = "webLabel";
            this.webLabel.Size = new System.Drawing.Size(83, 12);
            this.webLabel.TabIndex = 3;
            this.webLabel.Text = "1/1 共0条记录";
            // 
            // ListNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.webLabel);
            this.Controls.Add(this.enterTextBox);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.notesFlowLayoutPanel);
            this.Name = "ListNote";
            this.Text = "ListNote";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel notesFlowLayoutPanel;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.TextBox enterTextBox;
        private System.Windows.Forms.Label webLabel;
    }
}