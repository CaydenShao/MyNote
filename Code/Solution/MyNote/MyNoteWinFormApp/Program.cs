using MyNote.Contracts.DataContracts;
using MyNote.Contracts.DataContracts.NoteUser.Requests;
using MyNoteWebApiClient.Managements.Config;
using MyNoteWebApiClient.Managements.NoteUser;
using MyNoteWebApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNoteWinFormApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InputBaseAdr inputBaseAdr = new InputBaseAdr();

            if (inputBaseAdr.ShowDialog() == DialogResult.OK)
            {
                SysConfigInfo.WebServerBaseAddr = String.Format(@"http://{0}:{1}/", inputBaseAdr.IP, inputBaseAdr.Port);
                SysConfigInfo.Version = inputBaseAdr.Version;
                SysInfoManager sysInfoManager = new SysInfoManager(SysConfigInfo.WebServerBaseAddr);
                Response<DateTime> response = sysInfoManager.GetServerDateTime(new PublicCheckInfo());

                if (response == null)
                {
                    MessageBox.Show("无法连接服务！");
                    Application.Exit();
                }
                else
                {
                    UserManager userManager = new UserManager(SysConfigInfo.WebServerBaseAddr);
                    userManager.GetUserById(new GetUserByIdRequest()
                    {
                        UserId = 1
                    },
                    new TokenCheckInfo()
                    {
                        UserId = 1,
                        Token = "8d0003af-541c-4d86-8a4e-5437d79a964f",
                        Version = "V1.0"
                    });
                    MessageBox.Show(string.Format("服务器当前时间：{0}", response.ResponseData.ToString("yyyy-MM-dd HH:mm:ss")));
                    Application.Run(new Login());
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
