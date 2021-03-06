using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EVSoft.HRMS.Common;
using EVSoft.HRMSLisence;

namespace EVSoft.HRMS.UI
{
    public partial class frmActivation : Form
    {
        public frmActivation()
        {
            InitializeComponent();
            serialBox1.ReadOnly = true;
            serialBox2.ReadOnly = false;
            serialBox1.Text = HRMSLicense.License.GetSystemInfo();
            serialBox2.Focus();
            if (TrialVersion.IsRegister())//Nếu đã đăng ký trial thì thôi
                btnTrial.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string registryKey = HRMSLicense.License.GenerationKey(HRMSLicense.License.GetSystemInfo());
            if (serialBox2.Text == registryKey)
            {
                HRMSLicense.FileReadWrite.WriteFile(Application.StartupPath + "\\" + frmMain.strFileRegistion, registryKey);

                MessageBox.Show("HRMS activation successfully.",
                                       this.Text,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                WorkingContext.RegistionType = RegistionType.Registered;
                TrialVersion.DeleteRegistry();
                this.Close();
            }
            else
            {
                WorkingContext.RegistionType = RegistionType.ErrorRegistered;
                MessageBox.Show("HRMS activation unsuccessfully.",
                                       this.Text,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
            }
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            WorkingContext.RegistionType = RegistionType.Trial;
            TrialVersion.RegisterRegistry();
            FileInfo f = new FileInfo(Application.StartupPath + "\\" + frmMain.strFileRegistion);
            if (f.Exists)
              f.Delete();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}