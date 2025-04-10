using DNSChanger.Properties;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace DNSChanger
{
    public partial class DNSPAthForm : Form
    {
        public DNSPAthForm()
        {
            InitializeComponent();
        }

        public static bool IsOpenForm()
        {
            return string.IsNullOrEmpty(Settings.Default.DNSPath) || !File.Exists(Settings.Default.DNSPath);
        }

        private void SaveDNSPath(string fileName)
        {
            Settings.Default.DNSPath = fileName;
            Settings.Default.Save();
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (newFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDNSPath(newFileDialog.FileName);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDNSPath(openFileDialog.FileName);
            }
        }

        private void DNSPAthForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            DNSChangerForm.OpenSupportURL();
        }
    }
}
