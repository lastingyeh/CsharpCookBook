using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CookBook.Ch4
{
    public static class EX410
    {
        public static void Run()
        {
            XML();
            EventLogs();
            ArrayListEnum();
        }

        public static void XML()
        {
            XElement xmlFragment = new XElement("NonGenericLinqableTypes",
                 new XElement("IEnumerable",
                     new XElement("System.Collections",
                        new XElement("ArrayList"),
                        new XElement("BitArray"),
                        new XElement("Hashtable"),
                        new XElement("Queue"),
                        new XElement("SortedList"),
                        new XElement("Stack")
                    ),
                    new XElement("System.Net",
                        new XElement("CredentialCache")
                    ),
                    new XElement("System.Xml",
                        new XElement("XmlNodeList")
                    ),
                    new XElement("System.Xml.XPath",
                        new XElement("XPathNodeIterator")
                    )
                 ),
                 new XElement("ICollection",
                    new XElement("System.Diagnostics",
                        new XElement("EventLogEntryCollection")
                    ),
                    new XElement("System.Net",
                        new XElement("CookieCollection")
                    ),
                    new XElement("System.Security.AccessControl",
                        new XElement("GenericAcl")
                    ),
                    new XElement("System.Security",
                        new XElement("PermissionSet")
                    )
                 )
            );

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlFragment.ToString());

            var query = from node in
                            doc.SelectNodes("/NonGenericLinqableTypes/IEnumerable/*").Cast<XmlNode>()
                        where node.HasChildNodes && node.Name == "System.Collections"
                        from XmlNode xmlNode in node.ChildNodes
                        where xmlNode.Name.Contains('S')
                        orderby xmlNode.Name descending
                        select xmlNode.Name;

            foreach (string name in query)
                Console.WriteLine(name);
        }

        public static void EventLogs()
        {
            EventLog log = new EventLog("Application");

            var query = from EventLogEntry entry in log.Entries
                        where entry.EntryType == EventLogEntryType.Error &&
                            entry.TimeGenerated > DateTime.Now.Subtract(new TimeSpan(6, 0, 0))
                        select entry.Message;

            Console.WriteLine($"There were {query.Count<string>()}" +
                $" Application Event Log error messages in the last 6 hours!");

            foreach (string message in query)
                Console.WriteLine(message);

        }

        public static void ArrayListEnum()
        {
            ArrayList stuff = new ArrayList();
            stuff.Add(DateTime.Now);
            stuff.Add(DateTime.Now);
            stuff.Add(1);
            stuff.Add(DateTime.Now);

            // lazy exception
            var expr = from item in stuff.Cast<DateTime>()
                       select item;
            
            expr = from item in stuff.OfType<DateTime>()
                   select item;

            foreach (DateTime item in expr)
                Console.WriteLine(item);

        }


    }
}
