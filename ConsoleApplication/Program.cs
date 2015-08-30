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
    [Flags]
    public enum Switch
    {
        ReUseBit=1,
        CancelBit=2
    }
    public class Program:IDisposable
    {
        ~Program()
        {
            
            Dispose();
        }
        public void Dispose()
        {
            System.Diagnostics.Trace.TraceInformation(Thread.CurrentThread.ManagedThreadId.ToString() + "Program");
        }
        public static int cmp(string s1, string s2)
        {
            if (s1[1] <= s2[1])
                return 1;
            else
                return -1;
        }
        public int testparam;
        public delegate void testdel();
        public static Task<int> nice1(int sum)
        {
           return  Task.Run(() =>
           {
               System.Diagnostics.Trace.TraceInformation(Thread.CurrentThread.ManagedThreadId.ToString() + "nice1");
               for (int i = 0; i < 5; i++)
               {
                   Thread.Sleep(500);
                   sum += i;
               }
               Console.WriteLine(sum);
               return sum;
           }
           );
            
        }

        public Task dddd()
        {
            return Task.Run(() =>
                {

                    Thread.Sleep(3000);

                });
        }
        public  async void nice2()
        {
            await dddd();
            Console.WriteLine("nice2");
        }

        public static void nice3()
        {
            System.Diagnostics.Trace.TraceInformation(Thread.CurrentThread.ManagedThreadId.ToString() + "nice3");
            using(CouponPayment T = new CouponPayment())
            {
                Console.WriteLine("using");
            }
            using (Program p = new Program())
            {
                p.nice2();
            }
      
        }
        public static int a = 0;
        public static int b = 0; 
        public static void tcs(int[,] arr, int w, int h, int k)
        {


            int j = k-1;
            int i = k-1;

            if (i >= w || j >= h)
                return;

            for (; i < w - 1; i++)
            {
                if (arr[i, j] == 0)
                {
                    arr[i, j] = k;
                    b++;
                }
            }

            for (; j < h - 1; j++)
            {
                if (arr[i, j] == 0)
                {
                    arr[i, j] = k;
                    b++;
                }
            }
            for (; i > k-1; i--)
            {
                if (arr[i, j] == 0)
                {
                    arr[i, j] = k;
                    b++;
                }
            }
            for (; j > k-1; j--)
            {
                if (arr[i, j] == 0)
                {
                    arr[i, j] = k;
                    b++;
                }
                
            }
            k++;
            a = a + 1;
            tcs(arr, w - 1, h - 1, k);
        }

        public static int len = 2;
        public static StringBuilder sb = new StringBuilder();

        public class MArray
        {
            public int pos = 0;
            public int[] arr;
        }
        public static void createlosertree(MArray[] m)
        {
            int[] ls = new int[len];
            int[] b = new int[len + 1];
            b[len] = -999;
            for (int i = 0; i < len; i++)
                b[i] = m[i].arr[0];
            for (int i = 0; i < len; i++)
                ls[i] = len;
            for (int i = len - 1; i >= 0; i--)
            {
                ajust(b, ls, i);
                m[i].pos++;
            }
            int ct = 0;
            while (b[ls[0]] != 999)
            {
                sb.Append(b[ls[0]]);
                sb.Append(' ');
                int q = ls[0];
                ct++;
                if (m[q].pos >= m[q].arr.Length)
                    b[q] = 999;
                else
                {
                    b[q] = m[q].arr[m[q].pos];
                    m[q].pos++;
                }
                ajust(b, ls, q);
            }

        }

        public static void ajust(int[] b, int [] ls, int s)
        {
            for(int t= (s + len) /2; t > 0; t=t/2)
            {
                if(b[s] > b[ls[t]])
                {
                    int tmp = s;
                    s = ls[t];
                    ls[t] = tmp;
                }
            }
            ls[0] = s;
        }
        public static int partsort(int[] A, int s ,int e)
        {
            int key = A[e-1];
            int i = s - 1;
            for(int j = s; j < e -1; j++)
            {
                if(A[j] <= key)
                {
                    i++;
                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;       
                }
            }
            int tmp2 = A[i+1];
            A[i + 1] = A[e - 1];
            A[e - 1] = tmp2;
            return i + 1;
            
        }
        public static void qsort(int []A, int s, int e)
        {
            if (s >= e)
                return;
            int q = partsort(A, s, e);
            qsort(A, s, q-1);
            qsort(A, q + 1, e);

        }
        static void Main(string[] args)
        {
            int[] arr = new int[8] { 13, 6, 1, 3, 5, 8, 19, 0 };
            qsort(arr, 0, 8);
            foreach(int a in arr)
            {
                Console.Write(a + ",");
            }
            //MArray[] m = new MArray[3];
            //m[0] = new MArray();
            //m[1] = new MArray();
            //m[2] = new MArray();
            //m[0].arr = new int[5] { 1, 3, 5, 7 ,9};
            //m[1].arr = new int[5] { 2, 4, 6, 8 ,10};
            //m[2].arr = new int[5] { 2, 4, 6, 8, 10 };
            //createlosertree(m);

            //Console.WriteLine(sb.ToString());
           // Snake();
           //// AutoResetEvent ev = new AutoResetEvent(false);
            //Thread t2 = new Thread((x) =>
            //{
            //    if (ev.WaitOne(100))
            //        Console.WriteLine("t2");
            //});
            ////Thread t1 = new Thread((x) =>
            ////{
            ////    ev.Reset();
            ////    Thread.Sleep(500);
            ////    Console.WriteLine("t1");
            ////    ev.Set();
            ////});
           // t1.Start(ev);
           // t2.Start(ev);
           // t1.Join(1000);
           // t2.Join();
         //   Console.WriteLine("main");

            // nice3();
            //Action A = new Action(act1);
            //Thread.CurrentThread.Name = "mainthread";
            //IAsyncResult res = A.BeginInvoke(delegate (IAsyncResult re)
            //{
            //    Console.WriteLine("IAsyncResult");
            //    Action aa = re.AsyncState as Action;
            //    Console.WriteLine(Thread.CurrentThread.Name);
            //    //aa.EndInvoke(re);
            //    Console.WriteLine("EndInvoke");
            //}, 
            //A);
            //Thread.Sleep(2);

            //a |= Switch.ReUseBit;
            Console.ReadLine();
        }

        private static void Snake()
        {
            FileStream f = new FileStream("1.txt", FileMode.Create);
            StreamWriter fw = new StreamWriter(f);

            int w = 3;
            int h = 3;
            int[,] arr = new int[w, h];
            tcs(arr, w, h, 1);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    // Console.Write(arr[i, j] + " ");
                    fw.Write(string.Format("{0:000} ", arr[i, j]));

                }
                fw.WriteLine();
            }
            fw.Close();
            f.Close();
            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        public static int act()
        {
            Console.WriteLine("act1");
            return 1;
        }
        public static void act1()
        {
            Console.WriteLine("act1");
            Thread.Sleep(8000);
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
        public static List<CouponPayment> enumtest(List<CouponPaymentType> orils)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("APAY", "PAY1");
            dic.Add("BPAY", "PAY1");
            dic.Add("CPAY", "PAY2");
            List<CouponPayment> ls = new List<CouponPayment>();
            foreach (CouponPaymentType t in orils)
            {
                string pay = dic[t.ID];
                int current = ls.FindIndex(x => x.PaymentCategory == pay);
                if (current == -1) //不存在支付大类，新建大类和小类
                {
                    CouponPayment cp = new CouponPayment();
                    cp.SubPaymentWayList = new List<SubCouponPayment>();
                    cp.PaymentCategory = pay;

                    SubCouponPayment scp = new SubCouponPayment()
                    {
                        MaxActivityNum = t.Times,
                        PaymentWay = t.ID,
                        StartEndNo = new List<string>()
                    };
                    scp.StartEndNo.Add(string.Format("%d,%d", t.Start, t.End));
                    cp.SubPaymentWayList.Add(scp);

                    ls.Add(cp);
                }
                else         //存在支付大类
                {
                    int subcurrent = ls[current].SubPaymentWayList.FindIndex(x => x.PaymentWay == t.ID);
                    if (subcurrent == -1) //不存在支付小类，新建小类
                    {
                        SubCouponPayment scp = new SubCouponPayment()
                        {
                            MaxActivityNum = t.Times,
                            PaymentWay = t.ID,
                            StartEndNo = new List<string>()
                        };
                        scp.StartEndNo.Add(string.Format("%d,%d", t.Start, t.End));
                        ls[current].SubPaymentWayList.Add(scp);
                    }
                    else                //已经存在支付小类，卡号直接加入原卡段集合
                    {
                        ls[current].SubPaymentWayList[subcurrent].StartEndNo.Add(string.Format("%d,%d", t.Start, t.End));
                    }
                }

            }
            return ls;
        }
    };
}
public class CouponPaymentType
{
    public string ID { get; set; }
    public ulong Start { get; set; }
    public ulong End { get; set; }
    public int Times { get; set; }
}
public class SubCouponPayment
{
    private string _paymentway;
    /// <summary>
    /// 支付小类
    /// </summary>
    public string PaymentWay
    {
        get { return _paymentway; }
        set { _paymentway = value; }
    }
    /// <summary>
    /// 卡段集合
    /// </summary>
    public List<string> StartEndNo;

    private int maxactivitynum;
    /// <summary>
    /// 最大使用次数
    /// </summary>
    public int MaxActivityNum
    {
        get { return maxactivitynum; }
        set { maxactivitynum = value; }
    }
}
public class CouponPayment :IDisposable
{
    public CouponPayment()
    {

    }

    ~CouponPayment()
    {
        
        Dispose();
    }
    public void Dispose()
    {
        System.Diagnostics.Trace.TraceInformation(Thread.CurrentThread.ManagedThreadId.ToString() + "coupon");
    }
    private string _PaymentCategory;
    /// <summary>
    /// 支付方式大类
    /// </summary>
    public string PaymentCategory
    {
        get { return _PaymentCategory; }
        set { _PaymentCategory = value; }
    }

    public List<SubCouponPayment> SubPaymentWayList;
}

