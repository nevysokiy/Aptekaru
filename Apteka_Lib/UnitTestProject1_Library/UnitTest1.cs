using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PeMoHT_Lib;

namespace UnitTestProject1_Library
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetProfitOfOrders()
        {
            Database database = new Database();
            var expected = database.CalcProfit();
            double actual = 107000.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProfitOfOrdersIsNotNull()
        {
            Database database = new Database();
            var expected = database.CalcProfit();
            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void GetTechnicianWithMostExpensiveRepair()
        {
            Database database = new Database();
            var expected = database.TechinicianWithMostExpensiveRepair();
            string actual = "Robken";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TechnicianWithMostExpensiveRepairIsNotNull()
        {
            Database database = new Database();
            var expected = database.TechinicianWithMostExpensiveRepair();
            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void GetMostExpensiveSalary()
        {
            Database database = new Database();
            var expected = database.MostExpensiveSalary();
            string actual = "Poegorov";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MostExpensiveSalaryIsNotNull()
        {
            Database database = new Database();
            var expected = database.MostExpensiveSalary();
            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void GetMostExpensiveRepair()
        {
            Database database = new Database();
            var expected = database.MostExpensiveRepair();
            string actual = "Bread maker";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MostExpensiveRepairIsNotNull()
        {
            Database database = new Database();
            var expected = database.MostExpensiveRepair();
            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void GetCountOfTechnician()
        {
            Database database = new Database();
            var expected = database.CountOfTechnician();
            int actual = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOfTechnicianIsNotNull()
        {
            Database database = new Database();
            var expected = database.CountOfTechnician();
            Assert.IsNotNull(expected);
        }
    }
}
