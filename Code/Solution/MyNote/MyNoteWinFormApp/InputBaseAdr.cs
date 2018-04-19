using MyNote.Common.Helpers;
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
    public partial class InputBaseAdr : Form
    {
        public InputBaseAdr()
        {
            InitializeComponent();
        }

        #region Properties

        public string IP
        {
            get
            {
                return this.ipTextBox.Text;
            }
        }

        public string Port
        {
            get
            {
                return this.portTextBox.Text;
            }
        }

        public string Version
        {
            get
            {
                return this.versionComboBox.Text;
            }
        }

        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!RegexHelper.IsIPv4(this.ipTextBox.Text))
            {
                MessageBox.Show("请输入正确格式的IP！");
                return;
            }

            if (!RegexHelper.IsPort(this.portTextBox.Text))
            {
                MessageBox.Show("请输入正确格式的Port！");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (!RegexHelper.IsIPv4(this.ipTextBox.Text))
            {
                MessageBox.Show("请输入正确格式的IP！");
                return;
            }

            if (!RegexHelper.IsPort(this.portTextBox.Text))
            {
                MessageBox.Show("请输入正确格式的Port！");
                return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
