using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class AprioriTest
    { 
        [TestMethod]
        public void TestCandidateNull()
        {
            var aprioriTest = Apriori.GenerateCandidate(new[] { "A", "B" }, new[] { "C", "D" });
            Assert.IsTrue(aprioriTest == null);
            aprioriTest = Apriori.GenerateCandidate(new[] { "A", "B" }, new[] { "Z", "X" });
            Assert.IsTrue(aprioriTest == null);
            aprioriTest = Apriori.GenerateCandidate(new[] { "A", "B" }, new[] { "W", "N" });
            Assert.IsTrue(aprioriTest == null);
        }

        [TestMethod]
        public void TestCandidate2x2()
        {
            var aprioriTest = Apriori.GenerateCandidate(new[]{ "A", "B" }, new[] { "A", "D" });
            Assert.IsTrue(aprioriTest != null);
            Assert.IsTrue(aprioriTest.Length==3);
            Assert.IsTrue(aprioriTest[2]=="D");
            aprioriTest = Apriori.GenerateCandidate(new[] { "X", "Y" }, new[] { "X", "Z" });
            Assert.IsTrue(aprioriTest != null);
            Assert.IsTrue(aprioriTest[2] == "Z");
            aprioriTest = Apriori.GenerateCandidate(new[] { "A", "B" }, new[] { "A", "N" });
            Assert.IsTrue(aprioriTest != null);
            Assert.IsTrue(aprioriTest[2] == "N");
        }

        [TestMethod]
        public void TestCandidate3x3()
        {
            var aprioriTest = Apriori.GenerateCandidate(new[] { "A", "B","C" }, new[] { "A", "D", "C" });
            Assert.IsTrue(aprioriTest == null);
            aprioriTest = Apriori.GenerateCandidate(new[] { "X", "Y","Z" }, new[] { "X", "Y", "ZA" });
            Assert.IsTrue(aprioriTest != null);
            Assert.IsTrue(aprioriTest[2] == "Z");
            Assert.IsTrue(aprioriTest[3] == "ZA");
            aprioriTest = Apriori.GenerateCandidate(new[] { "A", "B" ,"D"}, new[] { "A", "B", "N" });
            Assert.IsTrue(aprioriTest != null);
            Assert.IsTrue(aprioriTest[2] == "D");
            Assert.IsTrue(aprioriTest[3] == "N");
        }
    }
}
