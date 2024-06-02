using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DNSChanger.Properties;

namespace DNSChanger
{
    public enum ModifyMode
    {
        Null,
        Add,
        Edit,
    }

    public class DNS
    {
        public string Name { get; set; }
        public string Preferred { get; set; }
        public string Alternate { get; set; }

        /// <summary>
        /// Create default DNS file
        /// </summary>
        public static void CreateOrUpdateDefaultDNSFile(out string error)
        {
            List<DNS> dnsList = GetDefaultDNS();
            WriteXML(dnsList, out error);
        }

        /// <summary>
        /// Get Default DNS
        /// </summary>
        /// <returns></returns>
        private static List<DNS> GetDefaultDNS()
        {
            List<DNS> dnsList = new List<DNS>();
            dnsList.Add(new DNS { Name = "Loopback DNS", Preferred = "127.0.0.1", Alternate = "127.0.0.2" });
            dnsList.Add(new DNS { Name = "Google DNS", Preferred = "8.8.8.8", Alternate = "8.8.4.4" });
            dnsList.Add(new DNS { Name = "403.Online DNS", Preferred = "10.202.10.202", Alternate = "10.202.10.102" });
            dnsList.Add(new DNS { Name = "Radar.Game DNS", Preferred = "10.202.10.10", Alternate = "10.202.10.11" });
            dnsList.Add(new DNS { Name = "Shecan DNS", Preferred = "178.22.122.100", Alternate = "185.51.200.2" });
            dnsList.Add(new DNS { Name = "Begzar DNS", Preferred = "185.55.226.26", Alternate = "185.55.225.25" });
            dnsList.Add(new DNS { Name = "Electro DNS", Preferred = "78.157.42.101", Alternate = "78.157.42.100" });
            dnsList.Add(new DNS { Name = "Host Iran DNS", Preferred = "172.29.0.100", Alternate = "172.29.2.100" });
            dnsList.Add(new DNS { Name = "Abr Barani DC DNS", Preferred = "172.16.1.100 ", Alternate = "172.16.2.100" });
            dnsList.Add(new DNS { Name = "Open DNS", Preferred = "208.67.222.222", Alternate = "208.67.220.220" });
            dnsList.Add(new DNS { Name = "Level3", Preferred = "209.244.0.3", Alternate = "209.244.0.4" });
            dnsList.Add(new DNS { Name = "Verisign", Preferred = "64.6.64.6", Alternate = "64.6.65.6" });
            dnsList.Add(new DNS { Name = "DNS.Watch", Preferred = "84.200.69.80", Alternate = "84.200.70.40" });
            dnsList.Add(new DNS { Name = "Comodo Secure DNS", Preferred = "8.26.56.26", Alternate = "8.20.247.20" });
            dnsList.Add(new DNS { Name = "DNS Advantage", Preferred = "156.154.70.1", Alternate = "156.154.71.1" });
            dnsList.Add(new DNS { Name = "Norton ConnectSafe", Preferred = "199.85.126.10", Alternate = "199.85.127.10" });
            dnsList.Add(new DNS { Name = "GreenTeamDNS", Preferred = "81.218.119.11", Alternate = "209.88.198.133" });
            dnsList.Add(new DNS { Name = "SafeDNS(1)", Preferred = "195.46.39.39", Alternate = "195.56.39.40" });
            dnsList.Add(new DNS { Name = "SafeDNS(2)", Preferred = "195.46.39.39", Alternate = "195.46.39.40" });
            dnsList.Add(new DNS { Name = "OpenNIC(1)", Preferred = "96.90.175.167", Alternate = "193.183.98.154" });
            dnsList.Add(new DNS { Name = "OpenNIC(2)", Preferred = "107.150.40.234", Alternate = "50.116.23.211" });
            dnsList.Add(new DNS { Name = "SmartViper", Preferred = "208.76.50.50", Alternate = "208.76.51.51" });
            dnsList.Add(new DNS { Name = "Dyn DNS", Preferred = "216.146.35.35", Alternate = "216.146.36.36" });
            dnsList.Add(new DNS { Name = "FreeDNS(1)", Preferred = "37.235.1.174", Alternate = "37.235.1.117" });
            dnsList.Add(new DNS { Name = "FreeDNS(2)", Preferred = "37.235.1.174", Alternate = "37.235.1.177" });
            dnsList.Add(new DNS { Name = "Alternare DNS", Preferred = "198.101.242.72", Alternate = "23.253.163.53" });
            dnsList.Add(new DNS { Name = "Yandex.DNS", Preferred = "77.88.8.8", Alternate = "77.88.8.1" });
            dnsList.Add(new DNS { Name = "censurfridns.dk DNS", Preferred = "91.239.100.100", Alternate = "89.233.43.71" });
            dnsList.Add(new DNS { Name = "Cloudflare DNS", Preferred = "1.1.1.1", Alternate = "1.0.0.1" });
            dnsList.Add(new DNS { Name = "Quad9 DNS", Preferred = "9.9.9.9", Alternate = "149.112.112.112" });
            dnsList.Add(new DNS { Name = "Quad101 DNS", Preferred = "101.101.101.101", Alternate = "101.102.103.104" });
            dnsList.Add(new DNS { Name = "CleanBrowsing DNS", Preferred = "185.228.168.9", Alternate = "185.228.169.9" });
            dnsList.Add(new DNS { Name = "Keyweon DNS", Preferred = "176.9.62.58", Alternate = "176.9.62.62" });
            dnsList.Add(new DNS { Name = "Neustar DNS", Preferred = "156.154.70.5", Alternate = "156.154.71.5" });
            dnsList.Add(new DNS { Name = "French Data Network DNS", Preferred = "80.67.169.12", Alternate = "80.67.169.40" });
            dnsList.Add(new DNS { Name = "Freenom Work DNS", Preferred = "80.80.80.80", Alternate = "80.80.81.81" });
            dnsList.Add(new DNS { Name = "UncensoredDNS", Preferred = "91.239.100.100", Alternate = "89.233.43.71" });
            dnsList.Add(new DNS { Name = "AdGuard DNS", Preferred = "176.103.130.130", Alternate = "176.103.130.131" });
            return dnsList;
        }

        /// <summary>
        /// Write DNS list in DNS.XML.
        /// </summary>
        /// <param name="dnsList">List of DNS value</param>
        /// <param name="isAppend">Is append data</param>
        public static void WriteXML(List<DNS> dnsList, out string error)
        {
            try
            {
                if (!IsExistsXMLFile())
                {
                    WriteNewXML(dnsList);
                }
                else
                {
                    WriteAppendXML(dnsList);
                }
                error = null;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            
        }

        /// <summary>
        /// Write a dns value in DNS.XML.
        /// </summary>
        /// <param name="dns">DNS value</param>
        /// <param name="isAppend">Is append data</param>
        public static void WriteXML(DNS dns, out string error)
        {
            WriteXML(new List<DNS>() { dns }, out error);
        }

        /// <summary>
        /// Write the DNS list in DNS.XML. (Append it)
        /// </summary>
        /// <param name="dnsList">List of DNS value</param>
        private static void WriteAppendXML(List<DNS> dnsList)
        {
            XDocument xDocument = XDocument.Load(Resources.XMLFileName);
            XElement root = xDocument.Element(Resources.TagDNS);

            string errorString;
            List<DNS> dnsFileList = new List<DNS>();
            ReadXMLFile(dnsFileList, out errorString);

            foreach (var item in dnsList)
            {
                IEnumerable<XElement> rows = root.Descendants(Resources.TagItem);
                var isExists = dnsFileList.Any(x => x.Name == item.Name);
                if (!isExists)
                {
                    XElement firstRow = rows.Last(); //rows.First();
                    firstRow.AddAfterSelf(/*AddBeforeSelf(*/
                        new XElement(Resources.TagItem,
                        new XElement(Resources.TagName, item.Name),
                        new XElement(Resources.TagPreferred, item.Preferred),
                        new XElement(Resources.TagAlternate, item.Alternate)));
                }
            }
            xDocument.Save(Resources.XMLFileName);
        }

        /// <summary>
        /// Write the DNS list in DNS.XML. (Replase it)
        /// </summary>
        /// <param name="dnsList">List of DNS value</param>
        private static void WriteNewXML(List<DNS> dnsList)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create(Resources.XMLFileName, settings);
            writer.WriteStartElement(Resources.TagDNS);
            foreach (DNS dns in dnsList)
            {
                writer.WriteStartElement(Resources.TagItem);
                writer.WriteStartElement(Resources.TagName);
                writer.WriteString(dns.Name);
                writer.WriteEndElement();
                writer.WriteStartElement(Resources.TagPreferred);
                writer.WriteString(dns.Preferred);
                writer.WriteEndElement();
                writer.WriteStartElement(Resources.TagAlternate);
                writer.WriteString(dns.Alternate);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }

        /// <summary>
        /// Update oldDNS in XML file with newDNS
        /// </summary>
        /// <param name="oldDNS">Old DNS in XML file</param>
        /// <param name="newDNS">New updated DNS</param>
        /// <param name="error">Output error string</param>
        public static void EditXML(DNS oldDNS, DNS newDNS, out string error)
        {
            try
            {
                var xmlDocument = XDocument.Load(Resources.XMLFileName);
                XElement item = xmlDocument.Elements(Resources.TagDNS).Elements(Resources.TagItem)
                    .SingleOrDefault(x => x.Element(Resources.TagName).Value == oldDNS.Name);

                var name = item.Element(Resources.TagName);
                var preferred = item.Element(Resources.TagPreferred);
                var alternate = item.Element(Resources.TagAlternate);

                name.Value = newDNS.Name;
                preferred.Value = newDNS.Preferred;
                alternate.Value = newDNS.Alternate;

                xmlDocument.Save(Resources.XMLFileName);

                error = null;

            }
            catch (Exception e)
            {
                error = e.Message;
            }
            
        }

        /// <summary>
        /// Delete DNS in XML file
        /// </summary>
        /// <param name="dns">DNS</param>
        /// <param name="error">Output error string</param>
        public static void DeleteDNS(DNS dns, out string error)
        {
            try
            {
                var xmlDocument = XDocument.Load(Resources.XMLFileName);

                XElement item = xmlDocument.Elements(Resources.TagDNS).Elements(Resources.TagItem)
                    .SingleOrDefault(x => x.Element(Resources.TagName).Value == dns.Name);

                item.Remove();

                xmlDocument.Save(Resources.XMLFileName);

                error = null;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
        }

        /// <summary>
        /// Is exists XML file
        /// </summary>
        /// <returns></returns>
        public static bool IsExistsXMLFile()
        {
            return File.Exists(Resources.XMLFileName);
        }

        /// <summary>
        /// Read DNS.XML
        /// </summary>
        /// <param name="dnsList">List of DNS value</param>
        public static List<DNS> ReadXMLFile(List<DNS> _dnsList, out string errore)
        {
            XElement.Load(Resources.XMLFileName)
                .Elements(Resources.TagItem)
                .ToList()
                .ForEach
                (
                    x => _dnsList.Add(
                        new DNS
                        {
                            Name = x.Elements(Resources.TagName).ToList()[0].Value,
                            Preferred = x.Elements(Resources.TagPreferred).ToList()[0].Value,
                            Alternate = x.Elements(Resources.TagAlternate).ToList()[0].Value
                        }
                )
            );

            IsExistsDuplicateName(_dnsList, out errore);

            return _dnsList.OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Is exists duplicate name in List of DNS value (from XML file)
        /// </summary>
        /// <param name="dnsList">List of DNS value</param>
        /// <param name="error">Output error string</param>
        /// <returns></returns>
        public static bool IsExistsDuplicateName(List<DNS> dnsList, out string error)
        {
            var counterDuplicate = dnsList.GroupBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Counter = x.Count()
                })
                .Count(x => x.Counter > 1);

            error = counterDuplicate > 0 ? Resources.DuplicateInDNSFile : null;

            return counterDuplicate > 0;
        }

        /// <summary>
        /// Is exists dnsName in List of DNS value
        /// </summary>
        /// <param name="dnsList">List of DNS value</param>
        /// <param name="dnsName">DNS name</param>
        /// <param name="error">Output error string</param>
        /// <returns></returns>
        public static bool IsExistsDuplicateName(List<DNS> dnsList, string dnsName, out string error, ModifyMode modifyMode)
        {
            object isExists;

            if (modifyMode == ModifyMode.Edit)
            {
                isExists = dnsList.Where(x => x.Name == dnsName).ToList();
                error = (isExists as List<DNS>).Count > 1 ? Resources.ExistsDuplicateDNS : null;
            }
            else
            {
                isExists = dnsList.Where(x => x.Name == dnsName).FirstOrDefault();
                error = isExists != null ? Resources.ExistsDuplicateDNS : null;
            }

            return error != null;
        }
    }
}
