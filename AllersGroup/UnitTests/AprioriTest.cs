using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class AprioriTest
    {
        private  List<String[]> data;
        private List<String[]> solution;

        private void SetUp()
        {
            data = new List<String[]> { new[] { "Beer" }, new[] { "Bread" }, new[] { "Eggs" }, new[] { "Diapers" }, new[] { "Milk" } };
            solution = new List<String[]>
                        { new[] {"Beer",   "Bread" },
                        new[] {"Beer",   "Eggs" },
                        new[] {"Beer"   ,"Diapers" },
                        new[] {"Beer"   ,"Milk" },
                        new[] {"Bread"   ,"Eggs" },
                        new[] {"Bread"   ,"Diapers" },
                        new[] {"Bread"   ,"Milk" },
                        new[] {"Eggs"   ,"Diapers" },
                        new[] {"Eggs"   ,"Milk" },
                        new[] {"Diapers"   ,"Milk" },
                        };
        }

        [TestMethod]
        public void TestCandidateNull()
        {
            var sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk" }, new[] { "Beer", "Diapers" });
            Assert.IsTrue(sara == null);
            sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk" }, new[] { "Cola", "Diapers" });
            Assert.IsTrue(sara == null);
            sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk" }, new[] { "Cola", "Beer" });
            Assert.IsTrue(sara == null);
        }

        [TestMethod]
        public void TestCandidate2x2()
        {
            var sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk" }, new[] { "Bread", "Diapers" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara.Length == 3);
            Assert.IsTrue(sara[2] == "Diapers");
            sara = Apriori.GenerateCandidate(new[] { "Beer", "Diapers" }, new[] { "Beer", "Cola" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "Cola");
            sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk" }, new[] { "Bread", "Eggs" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "Eggs");
        }

        [TestMethod]
        public void TestCandidate3x3()
        {
            var sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk", "Beer" }, new[] { "Bread", "Diapers", "Beer" });
            Assert.IsTrue(sara == null);
            sara = Apriori.GenerateCandidate(new[] { "Beer", "Diapers", "Cola" }, new[] { "Beer", "Diapers", "Eggs" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "Cola");
            Assert.IsTrue(sara[3] == "Eggs");
            sara = Apriori.GenerateCandidate(new[] { "Bread", "Milk", "Diapers" }, new[] { "Bread", "Milk", "Eggs" });
            Assert.IsTrue(sara != null);
            Assert.IsTrue(sara[2] == "Diapers");
            Assert.IsTrue(sara[3] == "Eggs");
        }

        [TestMethod]
        public void TestNextCandidates()
        {
            SetUp();
            var a =  Apriori.GenerateNextCandidates(data);
            int aux = 0;
            foreach (String[] n in a)
            {
                n.SequenceEqual(solution.ToList().ElementAt(aux));
                aux++;
            }
        }
    }
}
