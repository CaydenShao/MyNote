namespace MyNoteWinFormApp
{
    partial class ViewNote
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lastBrowsedDateTextBox = new System.Windows.Forms.TextBox();
            this.browsedTimesLabel = new System.Windows.Forms.Label();
            this.approveLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(44, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 12);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "标题：";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(99, 9);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(417, 21);
            this.titleTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备注：";
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox.Location = new System.Drawing.Point(99, 36);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.ReadOnly = true;
            this.remarkTextBox.Size = new System.Drawing.Size(417, 21);
            this.remarkTextBox.TabIndex = 1;
            // 
            // contentTextBox
            // 
            this.contentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTextBox.Location = new System.Drawing.Point(99, 90);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ReadOnly = true;
            this.contentTextBox.Size = new System.Drawing.Size(417, 342);
            this.contentTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "内容：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "上次浏览：";
            // 
            // lastBrowsedDateTextBox
            // 
            this.lastBrowsedDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastBrowsedDateTextBox.Location = new System.Drawing.Point(99, 61);
            this.lastBrowsedDateTextBox.Name = "lastBrowsedDateTextBox";
            this.lastBrowsedDateTextBox.ReadOnly = true;
            this.lastBrowsedDateTextBox.Size = new System.Drawing.Size(417, 21);
            this.lastBrowsedDateTextBox.TabIndex = 1;
            // 
            // browsedTimesLabel
            // 
            this.browsedTimesLabel.AutoSize = true;
            this.browsedTimesLabel.Location = new System.Drawing.Point(12, 442);
            this.browsedTimesLabel.Name = "browsedTimesLabel";
            this.browsedTimesLabel.Size = new System.Drawing.Size(59, 12);
            this.browsedTimesLabel.TabIndex = 0;
            this.browsedTimesLabel.Text = "浏览（0）";
            // 
            // approveLabel
            // 
            this.approveLabel.AutoSize = true;
            this.approveLabel.Location = new System.Drawing.Point(77, 442);
            this.approveLabel.Name = "approveLabel";
            this.approveLabel.Size = new System.Drawing.Size(47, 12);
            this.approveLabel.TabIndex = 0;
            this.approveLabel.Text = "赞（0）";
            this.approveLabel.Click += new System.EventHandler(this.approveLabel_Click);
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(130, 442);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(59, 12);
            this.commentLabel.TabIndex = 0;
            this.commentLabel.Text = "评论（0）";
            // 
            // ViewNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 463);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.lastBrowsedDateTextBox);
            this.Controls.Add(this.remarkTextBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.approveLabel);
            this.Controls.Add(this.browsedTimesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "ViewNote";
            this.Text = "ViewNote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastBrowsedDateTextBox;
        private System.Windows.Forms.Label browsedTimesLabel;
        private System.Windows.Forms.Label approveLabel;
        private System.Windows.Forms.Label commentLabel;
    }
}