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
    public partial class Register : Form
    {
        private Timer canGetVerificationCountDownTimer = null;
        private int canGetVerificationCountDown = 0;

        public Register()
        {
            InitializeComponent();
        }

        #region Private methods

        private void ResetCanGetVerificationCountDownTimer()
        {
            this.getVerificationButton.Enabled = false;
            this.canGetVerificationCountDown = 60;
            this.getVerificationButton.Text = string.Format("获取验证码（{0}）", this.canGetVerificationCountDown);

            if (this.canGetVerificationCountDownTimer == null)
            {
                this.canGetVerificationCountDownTimer = new Timer();
                this.canGetVerificationCountDownTimer.Tick += new EventHandler((sender, args) => 
                {
                    if (this.canGetVerificationCountDown > 0)
                    {
                        this.canGetVerificationCountDown--;
                        this.getVerificationButton.Text = string.Format("获取验证码（{0}）", this.canGetVerificationCountDown);
                    }
                    else
                    {
                        this.getVerificationButton.Enabled = true;
                        this.canGetVerificationCountDownTimer.Stop();
                        this.getVerificationButton.Text = "获取验证码";
                    }
                });
            }

            this.canGetVerificationCountDownTimer.Stop();
            this.canGetVerificationCountDownTimer.Interval = 1000;
            this.canGetVerificationCountDownTimer.Start();
        }

        private void OnGetVerificationButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.phoneNumberTextBox.Text))
            {
                MessageBox.Show("请输入手机号!");
                return;
            }

            UserManager userManager = new UserManager(SysConfigInfo.WebServerBaseAddr);
            Response<bool> checkPhoneNumberResponse = userManager.CheckPhoneNumberRegistered(new CheckPhoneNumberRegisteredRequest()
            {
                PhoneNumber = this.phoneNumberTextBox.Text
            },
            new SignatureCheckInfo()
            {
                AppId = "001",
                Version = SysConfigInfo.Version
            });

            if (checkPhoneNumberResponse.ResponseData)
            {
                MessageBox.Show("手机号已被注册！");
                return;
            }

            VerificationManager verificationManager = new VerificationManager(SysConfigInfo.WebServerBaseAddr);
            Response<bool> response = verificationManager.GenerateVerification(new GenerateVerificationRequest()
            {
                PhoneNumber = this.phoneNumberTextBox.Text,
            },
            new SignatureCheckInfo()
            {
                AppId = "001",
                Version = SysConfigInfo.Version
            });

            if (response == null)
            {
                MessageBox.Show("找不到指定的服务！");
                return;
            }

            if (response.ResponseData)
            {
                Response<Verification> getResponse = verificationManager.GetVerificationByPhoneNumber(new GetVerificationByPhoneNumberRequest()
                {
                    PhoneNumber = this.phoneNumberTextBox.Text,
                },
                new SignatureCheckInfo()
                {
                    AppId = "001",
                    Version = SysConfigInfo.Version
                });

                if (getResponse.ResponseData == null || getResponse.Code != 0)
                {
                    MessageBox.Show("验证码获取失败！");
                }
                else
                {
                    this.verificationTextBox.Text = getResponse.ResponseData.Code;
                    this.ResetCanGetVerificationCountDownTimer();
                }
            }
            else
            {
                MessageBox.Show("验证码生成失败，请点击重试！");
            }
        }

        private void OnRegisterButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.phoneNumberTextBox.Text))
            {
                MessageBox.Show("请输入手机号!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.nameTextBox.Text))
            {
                MessageBox.Show("请输入用户名!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.pwdTextBox.Text))
            {
                MessageBox.Show("请输入密码!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.confirmPwdTextBox.Text))
            {
                MessageBox.Show("请输入确认密码!");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.verificationTextBox.Text))
            {
                MessageBox.Show("请输入验证码!");
                return;
            }

            if (this.pwdTextBox.Text != this.confirmPwdTextBox.Text)
            {
                MessageBox.Show("密码与确认密码不一致!");
                return;
            }

            VerificationManager verificationManager = new VerificationManager(SysConfigInfo.WebServerBaseAddr);
            Response<bool> checkResponse = verificationManager.CheckVerification(new CheckVerificationRequest()
            {
                PhoneNumber = this.phoneNumberTextBox.Text,
                Code = verificationTextBox.Text
            },
            new SignatureCheckInfo()
            {
                AppId = "001",
                Version = SysConfigInfo.Version
            });

            if (checkResponse == null)
            {
                MessageBox.Show("找不到指定的服务！");
                return;
            }

            if (checkResponse.Code == 0 && checkResponse.ResponseData)
            { }
            else
            {
                if (checkResponse.Code == 1)
                {
                    MessageBox.Show("验证码验证失败，手机号无效！");
                }
                else if (checkResponse.Code == 2)
                {
                    MessageBox.Show("验证码错误！");
                }
                else if (checkResponse.Code == 3)
                {
                    MessageBox.Show("验证码已超时，请重新获取验证码！");
                }
                else
                {
                    MessageBox.Show("验证码验证失败，请重新验证！");
                }

                return;
            }

            UserManager userManager = new UserManager(SysConfigInfo.WebServerBaseAddr);
            Response<User> registerResponse = userManager.Register(new RegisterRequest() {
                User = new User()
                {
                    Name = this.nameTextBox.Text,
                    PhoneNumber = this.phoneNumberTextBox.Text,
                    LastLoginAddress = "192.168.2.29"
                },
                PwdHashStr = this.pwdTextBox.Text
            }, new SignatureCheckInfo()
            {
                AppId = "001",
                Version = SysConfigInfo.Version
            });

            if (registerResponse == null)
            {
                MessageBox.Show("找不到指定的服务！");
                return;
            }

            if (registerResponse.Code != 0 || registerResponse.ResponseData == null)
            {
                MessageBox.Show("注册失败！");
            }
            else
            {
                MessageBox.Show("注册成功！");
                this.Close();
            }
        }

        #endregion
    }
}
