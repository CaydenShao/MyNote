using MyNote.Common.Enums;
using MyNote.Common.Helpers;
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
    public partial class SearchNote : Form
    {
        private readonly int PageSize = 5;

        private int index = 1;
        private int totalRows = 0;
        private List<ListNoteUnit> notes = new List<ListNoteUnit>();

        #region Constructors

        public SearchNote()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int WebCount
        {
            get
            {
                if (totalRows <= 0)
                {
                    return 1;
                }
                else
                {
                    return totalRows % this.PageSize == 0 ? totalRows / this.PageSize : totalRows / this.PageSize + 1;
                }
            }
        }

        #endregion

        #region Private methods

        private void titleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.titleRadioButton.Checked)
            {
                this.remarkRadioButton.Checked = false;
                this.timespanRadioButton.Checked = false;
            }
        }

        private void remarkRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.remarkRadioButton.Checked)
            {
                this.titleRadioButton.Checked = false;
                this.timespanRadioButton.Checked = false;
            }
        }

        private void timespanRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.timespanRadioButton.Checked)
            {
                this.titleRadioButton.Checked = false;
                this.remarkRadioButton.Checked = false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.index = 1;
            this.RefreshCurrentNotes();
        }

        private void OnPrevButtonClick(object sender, EventArgs e)
        {
            this.index--;
            this.RefreshCurrentNotes();
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            this.index++;
            this.RefreshCurrentNotes();
        }

        private void OnEnterButtonClick(object sender, EventArgs e)
        {
            int enterIndex = 1;

            if (int.TryParse(this.enterTextBox.Text, out enterIndex))
            {
                if (enterIndex > 0 && enterIndex <= this.WebCount)
                {
                    this.index = enterIndex;
                    this.RefreshCurrentNotes();
                }
                else
                {
                    MessageBox.Show("输入的页码超出范围！");
                }
            }
            else
            {
                MessageBox.Show("输入的页码不规范！");
            }
        }

        private void RefreshCurrentNotes()
        {
            NoteManager noteManager = new NoteManager(SysConfigInfo.WebServerBaseAddr);
            Response<SearchNotesResponse> response = null;

            if (this.titleRadioButton.Checked)
            {
                response = noteManager.SearchNotesByTitleAndAuthorId(new SearchNotesByKeyStrAndAuthorIdRequest()
                {
                    AuthorId = SysConfigInfo.OnlineUser.Id,
                    KeyStr = this.keystrTextBox.Text,
                    PageIndex = this.index,
                    PageSize = this.PageSize
                },
                new TokenCheckInfo()
                {
                    Token = SysConfigInfo.OnlineUser.Token,
                    UserId = SysConfigInfo.OnlineUser.Id,
                    Version = SysConfigInfo.Version
                });
            }
            else if (this.remarkRadioButton.Checked)
            {
                response = noteManager.SearchNotesByRemarkAndAuthorId(new SearchNotesByKeyStrAndAuthorIdRequest()
                {
                    AuthorId = SysConfigInfo.OnlineUser.Id,
                    KeyStr = this.keystrTextBox.Text,
                    PageIndex = this.index,
                    PageSize = this.PageSize
                },
                new TokenCheckInfo()
                {
                    Token = SysConfigInfo.OnlineUser.Token,
                    UserId = SysConfigInfo.OnlineUser.Id,
                    Version = SysConfigInfo.Version
                });
            }
            else
            {
                response = noteManager.SearchNotesByTimeSpanAndAuthorId(new SearchNotesByTimeSpanAndAuthorIdRequest()
                {
                    AuthorId = SysConfigInfo.OnlineUser.Id,
                    StartTime = this.startDateTimePicker.Value,
                    EndTime = this.endDateTimePicker.Value,
                    PageIndex = this.index,
                    PageSize = this.PageSize
                },
                new TokenCheckInfo()
                {
                    Token = SysConfigInfo.OnlineUser.Token,
                    UserId = SysConfigInfo.OnlineUser.Id,
                    Version = SysConfigInfo.Version
                });
            }

            if (response == null)
            {
                MessageBox.Show("找不到指定的服务！");
            }
            else
            {
                if (response.Code != 0 || response.ResponseData == null || !response.HasAccessed)
                {
                    MessageBox.Show(response.Description);
                    LogHelper.WriteLog(LogType.Info, this.GetType().ToString(), "RefreshCurrentNotes", response.Description);
                }
                else
                {
                    this.totalRows = response.ResponseData.TotalRows;
                    this.notes.Clear();

                    if (response.ResponseData.Notes != null)
                    {
                        foreach (Note note in response.ResponseData.Notes)
                        {
                            ListNoteUnit unit = new ListNoteUnit();
                            unit.Init(note);
                            this.notes.Add(unit);
                        }
                    }

                    this.ReloadNoteUnits();
                }
            }
        }

        private void ReloadNoteUnits()
        {
            this.notesFlowLayoutPanel.Controls.Clear();

            foreach (var noteUnit in this.notes)
            {
                this.notesFlowLayoutPanel.Controls.Add(noteUnit);
            }

            this.webLabel.Text = string.Format("{0}/{1} 共{2}条记录", this.index, this.WebCount, this.totalRows);

            if (this.index <= 1)
            {
                this.prevButton.Enabled = false;
            }
            else
            {
                this.prevButton.Enabled = true;
            }

            if (this.index >= this.WebCount)
            {
                this.nextButton.Enabled = false;
            }
            else
            {
                this.nextButton.Enabled = true;
            }
        }

        #endregion

        #region Public methods



        #endregion
    }
}
