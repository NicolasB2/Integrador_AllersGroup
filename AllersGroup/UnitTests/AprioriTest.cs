using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using Algorithm;

namespace UnitTests
{
    [TestClass]
    public class AprioriTest
    { 

        public Apriori apriori;


        private void SetUp()
        {
            apriori = new Apriori();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var sara = apriori.GenerateCandidates(new[] { "A", "B" }, new[] { "C", "D" });
            Assert.IsTrue(sara == null);
        }
    }
}
