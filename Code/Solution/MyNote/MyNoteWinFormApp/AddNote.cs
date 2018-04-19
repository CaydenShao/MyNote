using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.Notes.Requests;
using MyNote.Contracts.DataContracts.NoteUser;
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
    public partial class AddNote : Form
    {
        private Note note = null;
        private List<NoteContent> noteContents = null;

        public AddNote()
        {
            InitializeComponent();
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (SysConfigInfo.OnlineUser == null)
                {
                    MessageBox.Show("没有用户在线！");
                    return;
                }

                if (string.IsNullOrEmpty(this.titleTextBox.Text.Trim())
                    || string.IsNullOrEmpty(this.remarkTextBox.Text.Trim())
                    || string.IsNullOrEmpty(this.contentTextBox.Text.Trim()))
                {
                    MessageBox.Show("请填写有效的内容！");
                    return;
                }

                NoteManager noteManager = new NoteManager(SysConfigInfo.WebServerBaseAddr);
                var response = noteManager.AddNoteAddContents(new AddNoteAndContentsRequest()
                {
                    Note = new Note()
                    {
                        AuthorId = SysConfigInfo.OnlineUser.Id,
                        IsShared = this.isSharedCheckBox.Checked,
                        Title = this.titleTextBox.Text,
                        Remark = this.remarkTextBox.Text
                    },
                    NoteContents = new List<NoteContent>()
                    {
                        new NoteContent()
                        {
                            Content = this.contentTextBox.Text,
                            Type = 0
                        }
                    }
                },
                new TokenCheckInfo()
                {
                    Token = SysConfigInfo.OnlineUser.Token,
                    UserId = SysConfigInfo.OnlineUser.Id,
                    Version = SysConfigInfo.Version
                });

                if (response == null)
                {
                    MessageBox.Show("找不到指定的服务！");
                    return;
                }

                if (response.Code != 0 || response.ResponseData == null)
                {
                    MessageBox.Show("添加失败！");
                }
                else
                {
                    MessageBox.Show("添加成功！");
                    this.note = response.ResponseData.Note;
                    this.noteContents = response.ResponseData.NoteContents;
                    this.addButton.Enabled = false;
                    this.titleTextBox.Text = this.note.Title;
                    this.remarkTextBox.Text = this.note.Remark;
                    this.contentTextBox.Text = this.noteContents[0].Content;
                    this.isSharedCheckBox.Checked = this.note.IsShared;
                    this.isSharedCheckBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
            }
        }
    }
}
