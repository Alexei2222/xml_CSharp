using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
            
        {
            Console.WriteLine("XML");
            CreateXmlFile();


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
    }
}
