using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class DownloadUpdateDialog : Form
    {
        public DownloadUpdateDialog()
        {
            InitializeComponent();
        }

        private async void DownloadUpdateDialog_Load(object sender, EventArgs e)
        {
            try
            {
                Action<int> progressbarAction = delegate (int i)
                {
                    progressBar.Value = i;
                };
                //ServicePointManager.Expect100Continue = true;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var mgr = new UpdateManager("http://10.10.12.25/html/mb/"))
                {
                    await mgr.UpdateApp(progressbarAction);
                    
                }
                this.Close();
                UpdateManager.RestartApp();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WindowsFormsApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
