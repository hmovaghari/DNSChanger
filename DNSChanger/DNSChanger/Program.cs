using System;
using System.Windows.Forms;

namespace DNSChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateDNSPath();
            CreateOrUpdateDNSXMLFile();
            RunApplication();
        }

        public static void CreateDNSPath()
        {
            if (DNSPAthForm.IsOpenForm())
            {
                var frm = new DNSPAthForm();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// If DNS.XML does not exist crate it automatically.
        /// </summary>
        private static void CreateOrUpdateDNSXMLFile()
        {
            string error;
            DNS.CreateOrUpdateDefaultDNSFile(out error);
            if (DNSChangerForm.IsErrorOccurred(error))
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Run Application
        /// </summary>
        private static void RunApplication()
        {
            Application.Run(new DNSChangerForm());
        }
    }
}
