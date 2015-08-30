using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using ConsoleApplication;
using System.Collections.Generic;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<CouponPaymentType> orils = new List<CouponPaymentType>()
            {
                new CouponPaymentType{ID="APAY", Start = 0, End = 1, Times = 3},
                new CouponPaymentType{ID="CPAY", Start = 2, End = 3, Times = 3}
            };
            List<CouponPayment> result = ConsoleApplication.Program.enumtest(orils);
            Assert.AreEqual("hello world", Class1.helloworld());
        }
    }
}
