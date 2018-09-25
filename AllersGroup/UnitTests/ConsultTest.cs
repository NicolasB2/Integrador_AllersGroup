using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class ConsultTest
    {
        private List<Item[]> itemSets;
        public int[] Solution;
        private Consult consult; 

        public void SetUp()
        {
           

                                         
        }


        [TestMethod]
        public void SupportCountTest()
        {
            SetUp();
            int cont = 0;
            foreach (Item[] data in itemSets)
            {
                Assert.IsTrue(consult.SupportCount(data) == Solution[cont]);
                cont++;
            }

        }

        [TestMethod]
        public void SupportTest()
        {
            SetUp();
            foreach (Item[] data in itemSets)
            {
                Assert.IsTrue(consult.Support(data) == 0);
            }

        }
    }
}
