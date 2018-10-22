using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class StatisticTest
    {

            
        private List<List<String>> model;
        private List<String> data;
        private IEnumerable<String[]> solution;

        public void SetUp()
        {
            data = new List<string> { "Bread", "Milk", "Diapers", "Bread", "Eggs", "Coke" };
            model = new List<List<String>> {
                new List<String>{"Bread", "Milk"},
                new List<String>{"Bread", "Diapers", "Beer", "Eggs"},
                new List<String>{"Milk", "Diapers", "Beer", "Coke"},
                new List<String>{"Bread", "Milk", "Diapers", "Beer"},
                new List<String>{"Bread", "Milk", "Diapers", "Coke"}
             };

        }

        [TestMethod]
        public void SupportCountTest()
        {
            SetUp();
            Assert.IsTrue(Statistic.SupportCount(new String[] { "Bread", "Milk", "Diapers" }, model) == 2);
            Assert.IsTrue(Statistic.SupportCount(new String[] { "Milk", "Diapers" }, model) == 3);
            Assert.IsTrue(Statistic.SupportCount(new String[] { "Eggs", "Coke" }, model) == 0);
            Assert.IsTrue(Statistic.SupportCount(new String[] { "Bread", "Milk" }, model) == 3);
            Assert.IsTrue(Statistic.SupportCount(new String[] { "Beer", "Diapers" }, model) == 3);


        }

        [TestMethod]
        public void SupportTest()
        {
            SetUp();
            Assert.IsTrue(Statistic.Support(new String[] { "Bread", "Milk", "Diapers" }, model) == 2 / 5);
            Assert.IsTrue(Statistic.Support(new String[] { "Milk", "Diapers" }, model) == 3 / 5);
            Assert.IsTrue(Statistic.Support(new String[] { "Eggs", "Coke" }, model) == 0 / 5);
            Assert.IsTrue(Statistic.Support(new String[] { "Bread", "Milk" }, model) == 3 / 5);
            Assert.IsTrue(Statistic.Support(new String[] { "Beer", "Diapers" }, model) == 3 / 5); ;

        }

    }
}
