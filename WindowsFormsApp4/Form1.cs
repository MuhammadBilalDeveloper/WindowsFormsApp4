using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WindowsFormsApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task UpdateApplication()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/MuhammadBilalDeveloper/WindowsFormsApp4"))
                {
                    await mgr.UpdateApp();
                }
                MessageBox.Show("Release is updated.", "WindowsFormsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WindowsFormsApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
