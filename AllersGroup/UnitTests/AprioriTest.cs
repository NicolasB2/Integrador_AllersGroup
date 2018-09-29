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
            var sara = Apriori.GenerateCandidates(new[] { "A", "B" }, new[] { "C", "D" });
            Assert.IsTrue(sara == null);
            sara = Apriori.GenerateCandidates(new[] { "A", "B" }, new[] { "Z", "X" });
            Assert.IsTrue(sara == null);
            sara = Apriori.GenerateCandidates(new[] { "A", "B" }, new[] { "W", "N" });
            Assert.IsTrue(sara == null);
        }

        [TestMethod]
        public void TestCandidate2x2()
        {
            var sara = Apriori.GenerateCandidates(new[]{ "A", "B" }, new[] { "A", "D" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara.Length==3);
            Assert.IsTrue(sara[2]=="D");
            sara = Apriori.GenerateCandidates(new[] { "X", "Y" }, new[] { "X", "Z" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "Z");
            sara = Apriori.GenerateCandidates(new[] { "A", "B" }, new[] { "A", "N" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "N");
        }

        [TestMethod]
        public void TestCandidate3x3()
        {
            var sara = Apriori.GenerateCandidates(new[] { "A", "B","C" }, new[] { "A", "D", "C" });
            Assert.IsTrue(sara == null);
            sara = Apriori.GenerateCandidates(new[] { "X", "Y","Z" }, new[] { "X", "Y", "ZA" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "Z");
            Assert.IsTrue(sara[3] == "ZA");
            sara = Apriori.GenerateCandidates(new[] { "A", "B" ,"D"}, new[] { "A", "B", "N" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "D");
            Assert.IsTrue(sara[3] == "N");
        }
    }
}
