using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DNSChanger
{
    class Adapter
    {
        public string Name { get; set; }
        public IPAddressCollection DnsAddresses { get; set; }

        private static bool isExecuteCommands;

        /// <summary>
        /// Get the list of all network adapters on your computer
        /// </summary>
        /// <param name="adapterList">List of adapter</param>
        public static void GetAdapters(List<Adapter> adapterList)
        {
            adapterList.Add(new Adapter());

            adapterList.AddRange
                (
                    NetworkInterface.GetAllNetworkInterfaces().ToList()
                    .Select
                    (
                        x => new Adapter()
                        {
                            Name = x.Name,
                            DnsAddresses = x.GetIPProperties().DnsAddresses,
                        }
                    )
                );
        }

        /// <summary>
        /// show adapter connected to a DNS name of the DNS list
        /// </summary>
        /// <param name="adapterList">List of adapter</param>
        /// <param name="dnsList">List of DNS</param>
        /// <param name="adapterName">Adapter Namne</param>
        /// <returns>this adapter connected to a DNS name in the DNS list or not</returns>
        public static string GetDnsNameOfAdapter(List<Adapter> adapterList, List<DNS> dnsList, string adapterName)
        {
            string dnsName = null;

            IList<string> dnsOfAdapter =
                adapterList
                .Where(a => a.Name == adapterName).SingleOrDefault()
                .DnsAddresses
                .Select(a => a.ToString()).ToList();

            if (dnsOfAdapter.Count == 2)
            {
                dnsName = dnsList.Where(d => d.Preferred == dnsOfAdapter[0] && d.Alternate == dnsOfAdapter[1])
                    .Select(d => d.Name).ToList().FirstOrDefault();
            }

            return string.Format(
                "This adapter {0}connected to {1}.",
                (dnsName != null ? "" : "not ").ToString(),
                (dnsName ?? "any bellow DNS").ToString()
            );
        }

        /// <summary>
        /// Change DNS of adaper
        /// </summary>
        /// <param name="adaperName">Adaper name</param>
        /// <param name="preferred">Preferred IP</param>
        /// <param name="alternate">Alternate IP</param>
        public static void ChangeAdapterDNS(string adaperName, string preferred, string alternate)
        {
            //netsh interface ip add dns name="Wi-Fi" addr=178.22.122.100 && netsh interface ip add dns name="Wi-Fi" addr=185.51.200.2 index=2
            var command = new StringBuilder();
            command.Append("/c ");
            command.Append($"netsh interface ip add dns name=\"{adaperName}\" addr={preferred}");
            command.Append(" && ");
            command.Append($"netsh interface ip add dns name=\"{adaperName}\" addr={alternate}");
            command.Append(" index=2");
            RunCommand(command.ToString());
        }

        /// <summary>
        /// Reset DNS of the adapter to default
        /// </summary>
        /// <param name="adaperName"></param>
        public static void ResetAdapterDNS(string adaperName)
        {
            // netsh interface ip set dns "Wi-Fi" dhcp
            var command = new StringBuilder();
            command.Append("/c ");
            command.Append($"netsh interface ip set dns \"{adaperName}\" dhcp");
            RunCommand(command.ToString());
        }

        /// <summary>
        /// Run command
        /// </summary>
        /// <param name="command">command</param>
        private static void RunCommand(string command)
        {
            isExecuteCommands = false;
            RunProcessAsync(command);
            do { } while (!isExecuteCommands);
            isExecuteCommands = false;
        }

        /// <summary>
        /// Run async process (Wait for the command to execute)
        /// </summary>
        /// <param name="command">command</param>
        /// <returns></returns>
        private static Task<int> RunProcessAsync(string command)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            Process process = new Process()
            {
                StartInfo = {
                    FileName = "CMD.EXE",
                    Arguments = command,
                    WindowStyle = ProcessWindowStyle.Hidden
                },
                EnableRaisingEvents = true,
            };
            process.Exited += (EventHandler)((sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                isExecuteCommands = true;
                process.Dispose();
            });
            process.Start();
            return tcs.Task;
        }

        internal static void SetIpv6(string adaperName, bool Enabled)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string format = "powershell -command {0}-NetAdapterBinding -Name \"{1}\" -ComponentID ms_tcpip6";
            string str = Enabled ? "Enable" : "Disable";
            stringBuilder.Append("/c ");
            stringBuilder.Append(string.Format(format, (object)str, (object)adaperName));
            Adapter.RunCommand(stringBuilder.ToString());
        }
    }
}
