using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNote.Contracts.DataContracts.Notes;

namespace MyNoteWinFormApp
{
    public partial class ListNoteUnit : UserControl
    {
        private Note note = null;

        public ListNoteUnit()
        {
            InitializeComponent();
        }

        public void Init(Note note)
        {
            this.note = note;
            this.commentCountLabel.Text = string.Format("评论({0})", this.note.CommentCount.ToString());
            this.remarkLabel.Text = note.Remark;
            this.titleLabel.Text = note.Title;
            this.createTimeLabel.Text = string.Format("创建({0})", this.note.CreateTime);
            this.lastBrowserTimeLabel.Text = string.Format("上次浏览({0})", this.note.LastBrowsedTime);
            this.browserTimesLabel.Text = string.Format("浏览({0})", this.note.BrowsedTimes);
            this.approveTimesLabel.Text = string.Format("赞({0})", this.note.ApprovedTimes);
        }

        private void remarkLabel_Click(object sender, EventArgs e)
        {
            ViewNote viewNote = new ViewNote();
            viewNote.ShowNote(this.note.Id, true);
        }
    }
}
