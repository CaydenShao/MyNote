using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.Contracts.DataContracts.NoteUser.Requests;
using MyNoteWebApiClient.Managements.NoteUser;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.addrTextBox.Text = SysConfigInfo.WebServerBaseAddr;
        }

        public void ChangeActionEnable(bool enable)
        {
            this.addNoteButton.Enabled = enable;
            this.listNoteButton.Enabled = enable;
            this.searchNoteButton.Enabled = enable;
        }

        private void OnLoginButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.accountTextBox.Text))
                {
                    MessageBox.Show("请输入账号！");
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.passwordTextBox.Text))
                {
                    MessageBox.Show("请输入密码");
                    return;
                }

                UserManager userManager = new UserManager(SysConfigInfo.WebServerBaseAddr);

                Response<User> response = userManager.Login(new LoginRequest()
                {
                    Account = this.accountTextBox.Text,
                    Password = this.passwordTextBox.Text

                }, new SignatureCheckInfo()
                {
                    AppId = "001",
                    Version = SysConfigInfo.Version
                });

                if (response == null)
                {
                    MessageBox.Show("登录异常！");
                    LogHelper.WriteLog(LogType.Info, this.GetType().ToString(), "OnLoginButtonClick", "登录返回响应值为NULL");
                }
                else
                {
                    if (response.Code != 0 || response.ResponseData == null || !response.HasAccessed)
                    {
                        MessageBox.Show(response.Description);
                        LogHelper.WriteLog(LogType.Info, this.GetType().ToString(), "OnLoginButtonClick", "登录结果：" + response.Description);
                    }
                    else
                    {
                        SysConfigInfo.OnlineUser = response.ResponseData;
                        this.nameTextBox.Text = SysConfigInfo.OnlineUser.Name;
                        this.tokenTextBox.Text = SysConfigInfo.OnlineUser.Token;
                        this.logoutButton.Visible = true;
                        this.ChangeActionEnable(true);
                    }
                }
            }
            catch (Exception ex)
            {
                this.loginButton.Enabled = true;
                LogHelper.WriteLog(LogType.Error, ex);
            }
        }

        private void OnLogoutButtonClick(object sender, EventArgs e)
        {
            try
            {
                SysConfigInfo.OnlineUser = null;
                this.nameTextBox.Text = string.Empty;
                this.tokenTextBox.Text = string.Empty;
                this.logoutButton.Visible = true;
                this.ChangeActionEnable(false);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogType.Error, ex);
            }
        }

        private void OnRegisterButtonClick(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void OnAddNoteButtonClick(object sender, EventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.ShowDialog();
        }

        private void OnListNoteButtonClick(object sender, EventArgs e)
        {
            ListNote listNote = new ListNote();
            listNote.ShowDialog();
        }

        private void searchNoteButton_Click(object sender, EventArgs e)
        {
            SearchNote searchNote = new SearchNote();
            searchNote.ShowDialog();
        }
    }
}
