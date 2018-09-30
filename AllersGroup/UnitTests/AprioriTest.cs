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
        private List<String[]> data;
        private List<String[]> solution;
        private List<String[]> imputs;
        private String[] candidates;


        private void SetUp1()
        {
            imputs = new List<String[]>();
            imputs.Add(new[] { "Bread", "Milk" });
            imputs.Add(new[] { "Beer", "Diapers" });
            imputs.Add(new[] { "Cola", "Diapers" });
            imputs.Add(new[] { "Beer", "Cola" });

        }

        private void SetUp2()
        {
            imputs = new List<String[]>();
            imputs.Add(new[] { "Bread", "Diapers" });
            imputs.Add(new[] { "Bread", "Milk" });
            imputs.Add(new[] { "Beer", "Cola" });
            imputs.Add(new[] { "Beer", "Diapers" });
            imputs.Add(new[] { "Bread", "Eggs" });
        }

        private void SetUp3()
        {
            imputs = new List<String[]>();
            imputs.Add(new[] { "Beer", "Bread", "Milk" });
            imputs.Add(new[] { "Beer", "Bread", "Diapers" });
            imputs.Add(new[] { "Beer", "Cola", "Diapers" });
            imputs.Add(new[] { "Beer", "Cola", "Eggs" });
            imputs.Add(new[] { "Bread", "Diapers", "Eggs" });
            imputs.Add(new[] { "Bread", "Diapers", "Milk" });
        }

        private void SetUp4()
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

        private void SetUp5()
        {
            data = new List<String[]>
                        {
                        new[] {"Beer",   "Cola" },
                        new[] {"Beer"   ,"Diapers" },
                        new[] {"Bread"   ,"Eggs" },
                        new[] {"Bread"   ,"Milk" },
                        new[] {"Eggs"   ,"Milk" },
                        new[] {"Diapers"   ,"Milk" },
                        };

            solution = new List<String[]>
                        {
                        new[] {"Beer",   "Cola" ,  "Diapers"},
                        new[] { "Bread",   "Eggs", "Milk" }
                         };
        }

        private void SetUp6()
        {

        }

        [TestMethod]
        public void TestCandidateNull()
        {
            SetUp1();
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(0), imputs.ElementAt(1));
            Assert.IsTrue(candidates == null);
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(0), imputs.ElementAt(2));
            Assert.IsTrue(candidates == null);
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(0), imputs.ElementAt(3));
            Assert.IsTrue(candidates == null);
        }

        [TestMethod]
        public void TestCandidate2x2()
        {
            SetUp2();
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(0), imputs.ElementAt(1));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates.Length == 3);
            Assert.IsTrue(candidates[2] == "Milk");
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(2), imputs.ElementAt(3));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[1] == "Cola");
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(0), imputs.ElementAt(4));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[2] == "Eggs");
        }

        [TestMethod]
        public void TestCandidate3x3()
        {
            SetUp3();
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(0), imputs.ElementAt(4));
            Assert.IsTrue(candidates == null);
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(2), imputs.ElementAt(3));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[2] == "Diapers");
            Assert.IsTrue(candidates[3] == "Eggs");
            candidates = Apriori.GenerateCandidate(imputs.ElementAt(4), imputs.ElementAt(5));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[2] == "Eggs");
            Assert.IsTrue(candidates[3] == "Milk");
        }

        [TestMethod]
        public void TestNextCandidates_Size2()
        {
            SetUp4();
            var a = Apriori.GenerateNextCandidates(data);
            int aux = 0;
            foreach (String[] n in a)
            {
                n.SequenceEqual(solution.ToList().ElementAt(aux));
                aux++;
            }
        }

        [TestMethod]
        public void TestNextCandidates_Size3()
        {
            SetUp5();
            var a = Apriori.GenerateNextCandidates(data);
            int aux = 0;
            foreach (String[] n in a)
            {
                n.SequenceEqual(solution.ToList().ElementAt(aux));
                aux++;
            }
        }

        [TestMethod]
        public void GenerateFrequentCandidates()
        {
        }
    }
}
