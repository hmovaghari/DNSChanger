using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

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
            CreateOrUpdateDNSXMLFile();
            RunApplication();
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DNSChangerForm());
        }
    }
}
