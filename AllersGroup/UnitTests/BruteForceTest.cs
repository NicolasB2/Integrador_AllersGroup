using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class BruteForceTest
    {
        private List<List <String>> model;
        private List<String> data;
 

        public void SetUp()
        {
            data = new List<string> { "Bread", "Milk", "Diapers", "Bread", "Eggs","Coke" };

            model = new List<List<String>>
            {
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
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Bread", "Milk", "Diapers" }, model) == 2);
            Assert.IsTrue(BruteForce.SupportCount(new String[] {"Milk", "Diapers" }, model) == 3);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Eggs", "Coke" }, model) == 0);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Bread", "Milk"}, model) == 3);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Beer","Diapers" }, model) == 3);


        }

        [TestMethod]
        public void SupportTest()
        {
            SetUp();
            Assert.IsTrue(BruteForce.Support(new String[] { "Bread", "Milk", "Diapers" }, model,model.Count()) == 2/5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Milk", "Diapers" }, model, model.Count()) == 3 / 5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Eggs", "Coke" }, model, model.Count()) == 0 / 5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Bread", "Milk" }, model, model.Count()) == 3 / 5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Beer", "Diapers" }, model, model.Count()) == 3 / 5); ;

        }
    }
}
