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
        private List<String[]> itemsets;
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
            Assert.IsTrue(BruteForce.SupportCount(new String[] { }, model) == 2);


        }

        [TestMethod]
        public void SupportTest()
        {
            SetUp();
            Assert.IsTrue(BruteForce.Support(new String[] { },model,model.Count())==(2/5));

        }
    }
}
