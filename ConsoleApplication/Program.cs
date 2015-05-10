using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
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
    public enum Switch
    {
        ReUseBit=1,
        CancelBit=2
    }
    class Program
    {
        public static int cmp(string s1, string s2)
        {
            if (s1[1] <= s2[1])
                return 1;
            else
                return -1;
        }
        public delegate void testdel();
        public static void nice1()
        {
            Console.WriteLine("nice1");
        }
        public static void nice2()
        {
            Console.WriteLine("nice2");
        }
        static void Main(string[] args)
        {
            Action A = new Action(act1);
            Thread.CurrentThread.Name = "mainthread";
            IAsyncResult res = A.BeginInvoke(delegate (IAsyncResult re)
            {
                Action aa = re.AsyncState as Action;
                Console.WriteLine(Thread.CurrentThread.Name);
                aa.EndInvoke(re);
                Console.WriteLine("EndInvoke");
            }, 
            A);
            Thread.Sleep(2);
            Console.WriteLine("waitcompleled");
            Console.ReadLine();
        }

        public static int act()
        {
            Console.WriteLine("act1");
            return 1;
        }
        public static void act1()
        {
            Console.WriteLine("act1");
            Thread.Sleep(2000);
        }
        private static void sqltest()
        {
            o_orders ds = new o_orders();
            string source = "Server=(localdb)\\v11.0;Integrated Security=SSPI;Database=fltorderdb";
            try
            {

                StringBuilder sb = new StringBuilder();
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                SqlCommand sqlcmd = new SqlCommand("select * from o_orders", conn);
                // SqlParameter spa = new SqlParameter("@orderid", System.Data.SqlDbType.BigInt);
                //spa.Value = 12000000001;
                // sqlcmd.Parameters.Add(spa);
                sqlcmd.CommandTimeout = 1;
                // SqlDataReader reader = sqlcmd.ExecuteReader();
                SqlDataAdapter ad = new SqlDataAdapter(sqlcmd);
                ad.Fill(ds, "order");

                if (ds.Tables.Count > 0)
                {
                    o_orders.orderDataTable order = ds.order;
                    foreach (o_orders.orderRow row in order.Rows)
                    {
                        Console.WriteLine(row.orderid);
                    }
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void onbtnclick(object sender, Eavr e)
        {
            Console.WriteLine(e.clicker + ",i wanna fuck you");
        }
        public static void  regtest()
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
        }
        public static void enumtest()
        {
            Switch x = (Switch)2;
            if (x.HasFlag(Switch.CancelBit) && x.HasFlag(Switch.ReUseBit))
            {
                Console.WriteLine("dd");
            }
        }
    };
}
