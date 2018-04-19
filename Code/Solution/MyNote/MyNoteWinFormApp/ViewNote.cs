using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNote.Contracts.DataContracts.Notes.Responses;
using MyNoteWebApiClient.Managements.Notes;
using MyNoteWebApiClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNoteWinFormApp
{
    public partial class ViewNote : Form
    {
        private Note note = null;
        private List<NoteContent> noteContents = null;

        public ViewNote()
        {
            InitializeComponent();
        }

        #region Private methods

        private void ReloadNote(int noteId)
        {
            NoteManager noteManager = new NoteManager(SysConfigInfo.WebServerBaseAddr);
            Response<Note> response = noteManager.GetNoteById(new GetNoteByIdRequest()
            {
                Id = noteId
            },
            new TokenCheckInfo()
            {
                UserId = SysConfigInfo.OnlineUser.Id,
                Token = SysConfigInfo.OnlineUser.Token,
                Version = SysConfigInfo.Version
            });

            if (response == null)
            {
                MessageBox.Show("找不到指定的服务！");
            }
            else
            {
                if (!response.HasAccessed)
                {
                    MessageBox.Show("身份验证未通过，请重新登录！");
                    return;
                }

                if (response.Code < 0)
                {
                    MessageBox.Show("服务端异常");
                }
                else
                {
                    if (response.ResponseData == null)
                    {
                        MessageBox.Show("指定的Note不存在！");
                    }
                    else
                    {
                        NoteApprovedRecordManager noteApprovedRecordManager = new NoteApprovedRecordManager(SysConfigInfo.WebServerBaseAddr);
                        
                        this.note = response.ResponseData;
                        this.titleTextBox.Text = this.note.Title;
                        this.remarkTextBox.Text = this.note.Remark;
                        this.lastBrowsedDateTextBox.Text = this.note.LastBrowsedTime.ToString();
                        this.browsedTimesLabel.Text = string.Format("浏览（{0}）", this.note.BrowsedTimes);
                        this.approveLabel.Text = string.Format("赞（{0}）", this.note.ApprovedTimes);
                        this.commentLabel.Text = string.Format("评论（{0}）", this.note.CommentCount);

                        Response<NoteBrowsedRecord> browsedResponse = noteManager.NoteGetBrowsed(new NoteGetBrowsedRequest()
                        {
                            NoteId = this.note.Id,
                            UserId = SysConfigInfo.OnlineUser.Id
                        },
                        new TokenCheckInfo()
                        {
                            UserId = SysConfigInfo.OnlineUser.Id,
                            Token = SysConfigInfo.OnlineUser.Token,
                            Version = SysConfigInfo.Version
                        });

                        if (browsedResponse != null 
                            && browsedResponse.HasAccessed 
                            && browsedResponse.Code == 0 
                            && browsedResponse.ResponseData != null)
                        {
                            MessageBox.Show("浏览成功！");
                        }

                        NoteContentManager noteContentManager = new NoteContentManager(SysConfigInfo.WebServerBaseAddr);
                        Response<List<NoteContent>> contentsResponse = noteContentManager.GetNoteContentByNoteId(new GetNoteContentsByNoteIdRequest()
                        {
                            NoteId = this.note.Id
                        },
                        new TokenCheckInfo()
                        {
                            Token = SysConfigInfo.OnlineUser.Token,
                            UserId = SysConfigInfo.OnlineUser.Id,
                            Version = SysConfigInfo.Version
                        });

                        this.noteContents = contentsResponse.ResponseData;

                        if (this.noteContents != null && this.noteContents.Count != 0)
                        {
                            this.contentTextBox.Text = this.noteContents[0].Content;
                        }
                    }
                }
            }
        }

        private void approveLabel_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Public methods

        public void ShowNote(int noteId, bool isModel)
        {
            this.ReloadNote(noteId);

            if (isModel)
            {
                this.ShowDialog();
            }
            else
            {
                this.Show();
            }
        }

        #endregion
    }
}
