using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VanCongTuan_KTPM;
namespace TestPT_VCT
{
    [TestClass]
    public class UnitTest1
    {
        private GiaiPhuongTrinh c;
        [TestInitialize] // thiet lap du lieu dung chung cho TC
        public void SetUp()
        {
            c = new GiaiPhuongTrinh(5, 10);

        }
        [TestMethod] //TC1: a =5, b = 10, kq= -2
        public void Test_PhuongTrinhBacNhat_TC1()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(5, 10);
            expected = "-2";
            actual = c.PhuongTrinhBacNhat();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod] //TC1: a =0, b = 10, kq= PTVN
        public void Test_PhuongTrinhBacNhat_TC2()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(0, 10);
            expected = "PTVN";
            actual = c.PhuongTrinhBacNhat();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod] //TC1: a =0, b = 0, kq= PTVSN
        public void Test_PhuongTrinhBacNhat_TC3()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(0, 0);
            expected = "PTVSN";
            actual = c.PhuongTrinhBacNhat();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod] //TC1: a =0, b = 0, kq= 0
        public void Test_PhuongTrinhBacHai_TC1()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(0, 0, 0);
            expected = "PTVSN";
            actual = c.PhuongTrinhBacHai();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TC1: a =0, b = 0,c=1, kq= PTVN
        public void Test_PhuongTrinhBacHai_TC2()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(0, 0, 1);
            expected = "PTVN";
            actual = c.PhuongTrinhBacHai();
            Assert.AreEqual(expected, actual);
        }



        [TestMethod] //TC1: a =0, b = 1,c=2, kq= -2
        public void Test_PhuongTrinhBacHai_TC3()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(0, 1, 2);
            expected = "-2";
            actual = c.PhuongTrinhBacHai();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TC1: a =1, b = 2,c=1, kq= 1
        public void Test_PhuongTrinhBacHai_TC4()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(1, 2, 1);
            expected = "-1";
            actual = c.PhuongTrinhBacHai();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod] //TC1: a =1, b = -3,c=2, kq= 1 và 2
        public void Test_PhuongTrinhBacHai_TC5()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(1, -3, 2);
            expected = "X1=1 X2=2";
            actual = c.PhuongTrinhBacHai();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod] //TC6: a =1, b = -3,c=2, kq= PTVN
        public void Test_PhuongTrinhBacHai_TC6()
        {
            string expected, actual;
            c = new GiaiPhuongTrinh(1, 1, 1);
            expected = "PTVN";
            actual = c.PhuongTrinhBacHai();
            Assert.AreEqual(expected, actual);

        }
    }
}
