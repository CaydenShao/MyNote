namespace MyNoteWinFormApp
{
    partial class ListNoteUnit
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.remarkLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.createTimeLabel = new System.Windows.Forms.Label();
            this.browserTimesLabel = new System.Windows.Forms.Label();
            this.lastBrowserTimeLabel = new System.Windows.Forms.Label();
            this.approveTimesLabel = new System.Windows.Forms.Label();
            this.commentCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remarkLabel
            // 
            this.remarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.remarkLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(217)))), ((int)(((byte)(234)))));
            this.remarkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remarkLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.remarkLabel.ForeColor = System.Drawing.Color.Black;
            this.remarkLabel.Location = new System.Drawing.Point(10, 10);
            this.remarkLabel.Name = "remarkLabel";
            this.remarkLabel.Size = new System.Drawing.Size(100, 100);
            this.remarkLabel.TabIndex = 0;
            this.remarkLabel.Text = "C#";
            this.remarkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remarkLabel.Click += new System.EventHandler(this.remarkLabel_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(217)))), ((int)(((byte)(234)))));
            this.titleLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(120, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(350, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "C#";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createTimeLabel
            // 
            this.createTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.createTimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.createTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.createTimeLabel.Location = new System.Drawing.Point(120, 46);
            this.createTimeLabel.Name = "createTimeLabel";
            this.createTimeLabel.Size = new System.Drawing.Size(171, 28);
            this.createTimeLabel.TabIndex = 0;
            this.createTimeLabel.Text = "C#";
            this.createTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // browserTimesLabel
            // 
            this.browserTimesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserTimesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.browserTimesLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.browserTimesLabel.ForeColor = System.Drawing.Color.Black;
            this.browserTimesLabel.Location = new System.Drawing.Point(120, 82);
            this.browserTimesLabel.Name = "browserTimesLabel";
            this.browserTimesLabel.Size = new System.Drawing.Size(111, 28);
            this.browserTimesLabel.TabIndex = 0;
            this.browserTimesLabel.Text = "C#";
            this.browserTimesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastBrowserTimeLabel
            // 
            this.lastBrowserTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastBrowserTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.lastBrowserTimeLabel.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lastBrowserTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.lastBrowserTimeLabel.Location = new System.Drawing.Point(299, 46);
            this.lastBrowserTimeLabel.Name = "lastBrowserTimeLabel";
            this.lastBrowserTimeLabel.Size = new System.Drawing.Size(171, 28);
            this.lastBrowserTimeLabel.TabIndex = 0;
            this.lastBrowserTimeLabel.Text = "C#";
            this.lastBrowserTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // approveTimesLabel
            // 
            this.approveTimesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.approveTimesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.approveTimesLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.approveTimesLabel.ForeColor = System.Drawing.Color.Black;
            this.approveTimesLabel.Location = new System.Drawing.Point(240, 82);
            this.approveTimesLabel.Name = "approveTimesLabel";
            this.approveTimesLabel.Size = new System.Drawing.Size(111, 28);
            this.approveTimesLabel.TabIndex = 0;
            this.approveTimesLabel.Text = "C#";
            this.approveTimesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // commentCountLabel
            // 
            this.commentCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.commentCountLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commentCountLabel.ForeColor = System.Drawing.Color.Black;
            this.commentCountLabel.Location = new System.Drawing.Point(359, 82);
            this.commentCountLabel.Name = "commentCountLabel";
            this.commentCountLabel.Size = new System.Drawing.Size(111, 28);
            this.commentCountLabel.TabIndex = 0;
            this.commentCountLabel.Text = "C#";
            this.commentCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListNoteUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.commentCountLabel);
            this.Controls.Add(this.approveTimesLabel);
            this.Controls.Add(this.browserTimesLabel);
            this.Controls.Add(this.lastBrowserTimeLabel);
            this.Controls.Add(this.createTimeLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.remarkLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ListNoteUnit";
            this.Size = new System.Drawing.Size(480, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label remarkLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label createTimeLabel;
        private System.Windows.Forms.Label browserTimesLabel;
        private System.Windows.Forms.Label lastBrowserTimeLabel;
        private System.Windows.Forms.Label approveTimesLabel;
        private System.Windows.Forms.Label commentCountLabel;
    }
}
