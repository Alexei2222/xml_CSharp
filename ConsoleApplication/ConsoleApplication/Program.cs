using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
            
        {
            Console.WriteLine("XML");
            CreateXmlFile();
            //ReadXMLFile();
            RegexSample();

            Console.ReadKey();

        }
            public static void CreateXmlFile()
            // create list of users
        {
            var listUsers = new List<User>() {

                new User { Name="Max Payne", Age=27, Company="Gamelab"},
                new User { Name="Bruce Wayne", Age=25, Company="Hollywood"},
                new User { Name="Donald Duck", Age=75, Company="Disney"},
            };
            XmlSerializer serialiser = new XmlSerializer(typeof(List<User>));
            TextWriter FileStream = new StreamWriter(@"D:\Users.xml");
            serialiser.Serialize(FileStream, listUsers);
            FileStream.Close();
        }
        public static void ReadXMLFile() {
            var xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(@"D:\Users.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("User");
            for (i = 0; i <= xmlnode.Count - 1; i++) {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                Console.WriteLine(str);
            }
            fs.Close();
            Console.WriteLine("\n End Of File");
            Console.ReadKey();
        }

        public static void RegexSample() {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match("Dot 25 Step");
            if (match.Success) {
                Console.WriteLine(match.Value);
            }
            
          

        }
    }
}
