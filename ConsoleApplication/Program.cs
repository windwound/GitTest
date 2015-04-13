using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
namespace ConsoleApplication
{
      [Serializable]
        public class tt
        {
            
            public sbtt name;
            public int age;
        }
    [Serializable]
      public class sbtt
      {

          public string firstname;
          public string lastfirstname;
      }
    class Program
    {
        static void Main(string[] args)
        {
            ///hello github
            tt xx = new tt()
            {
                name = new sbtt{
                    firstname = "Jim",
                    lastfirstname = "Green"
                },
                age = 18
            };
            string test;
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(tt));
                s.Serialize(stream, xx);

                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    test = reader.ReadToEnd();
                }
            }
            Regex reg = new Regex(@"<head.*?>[\s\S]+?</head>\r\n", RegexOptions.IgnoreCase);
            Regex reg1 = new Regex(@"<.*?sb>.*?</sb>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg2 = new Regex(@"<\w{0,5}:{0,1}name>.*?</name>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Regex reg3 = new Regex(@">(\r\n){0,1} {0,6}<", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match mc = reg2.Match(test);
            Console.WriteLine(mc.Groups[0]);
            Console.WriteLine("************************");
            string mc1 = reg2.Replace(test, "");
            Console.WriteLine(mc1);
            Console.WriteLine("************************");
            Console.WriteLine(test);
            Console.WriteLine("************************");
            Match tmp = reg3.Match(test);
            Console.WriteLine(tmp.Groups[1]);
            Console.WriteLine("************************");
            string mc2 = reg3.Replace(test, "><");
            Console.WriteLine(mc2);
            Console.ReadLine();
        }
    };
}
