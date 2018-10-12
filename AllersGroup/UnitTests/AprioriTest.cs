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
        private List<String[]> imput;
        private String[] candidates;


        private void SetUp1()
        {
            imput = new List<String[]>();
            imput.Add(new[] { "Bread", "Milk" });
            imput.Add(new[] { "Beer", "Diapers" });
            imput.Add(new[] { "Cola", "Diapers" });
            imput.Add(new[] { "Beer", "Cola" });

        }

        private void SetUp2()
        {
            imput = new List<String[]>();
            imput.Add(new[] { "Bread", "Diapers" });
            imput.Add(new[] { "Bread", "Milk" });
            imput.Add(new[] { "Beer", "Cola" });
            imput.Add(new[] { "Beer", "Diapers" });
            imput.Add(new[] { "Bread", "Eggs" });
        }

        private void SetUp3()
        {
            imput = new List<String[]>();
            imput.Add(new[] { "Beer", "Bread", "Milk" });
            imput.Add(new[] { "Beer", "Bread", "Diapers" });
            imput.Add(new[] { "Beer", "Cola", "Diapers" });
            imput.Add(new[] { "Beer", "Cola", "Eggs" });
            imput.Add(new[] { "Bread", "Diapers", "Eggs" });
            imput.Add(new[] { "Bread", "Diapers", "Milk" });
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
            candidates = Apriori.GenerateCandidate(imput.ElementAt(0), imput.ElementAt(1));
            Assert.IsTrue(candidates == null);
            candidates = Apriori.GenerateCandidate(imput.ElementAt(0), imput.ElementAt(2));
            Assert.IsTrue(candidates == null);
            candidates = Apriori.GenerateCandidate(imput.ElementAt(0), imput.ElementAt(3));
            Assert.IsTrue(candidates == null);
        }

        [TestMethod]
        public void TestCandidate2x2()
        {
            SetUp2();
            candidates = Apriori.GenerateCandidate(imput.ElementAt(0), imput.ElementAt(1));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates.Length == 3);
            Assert.IsTrue(candidates[2] == "Milk");
            candidates = Apriori.GenerateCandidate(imput.ElementAt(2), imput.ElementAt(3));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[1] == "Cola");
            candidates = Apriori.GenerateCandidate(imput.ElementAt(0), imput.ElementAt(4));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[2] == "Eggs");
        }

        [TestMethod]
        public void TestCandidate3x3()
        {
            SetUp3();
            candidates = Apriori.GenerateCandidate(imput.ElementAt(0), imput.ElementAt(4));
            Assert.IsTrue(candidates == null);
            candidates = Apriori.GenerateCandidate(imput.ElementAt(2), imput.ElementAt(3));
            Assert.IsTrue(candidates != null);
            Assert.IsTrue(candidates[2] == "Diapers");
            Assert.IsTrue(candidates[3] == "Eggs");
            candidates = Apriori.GenerateCandidate(imput.ElementAt(4), imput.ElementAt(5));
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

   

        private void SetUp7()
        {
            imput = new List<String[]> { new[] { "Bread", "Milk" } };
            solution = new List<String[]> { new[] { "Milk" } };
        }

        private void SetUp8()
        {
            imput = new List<String[]> { new[] { "Beer", "Bread", "Milk" } };
            solution = new List<String[]> { new[] { "Bread" },
            new[] { "Milk" }, new[] { "Bread", "Milk" }};
        }


        private void SetUp9()
        {
            imput = new List<String[]> { new[] { "Beer", "Bread", "Diapers", "Milk" } };
            solution = new List<String[]> { new[] { "Bread" },
            new[] { "Diapers" }, new[] { "Milk" }, new[] { "Bread", "Diapers" },
            new[] { "Bread", "Milk" }, new[] { "Diapers", "Milk" }};

        }

        [TestMethod]
        public void TestGenerateSubsets_Size2()
        {

            SetUp7();

            List<String[]> subsets = Apriori.GenerateSubsets(imput);
            for (int i = 0; i < solution.Count(); i++)
            {
                Assert.IsTrue(subsets.Contains(solution.ElementAt(i)));
            }
        }


        [TestMethod]
        public void TestGenerateSubsets_Size3()
        {
            SetUp8();

            List<String[]> subsets = Apriori.GenerateSubsets(imput);
            for (int i = 0; i < solution.Count(); i++)
            {
                Assert.IsTrue(subsets.Contains(solution.ElementAt(i)));
            }
        }

        [TestMethod]
        public void TestGenerateSubsets_Size4()
        {
            SetUp9();

            List<String[]> subsets = Apriori.GenerateSubsets(imput);
            for (int i =0; i < solution.Count(); i++)
            {
                Assert.IsTrue(subsets.Contains(solution.ElementAt(i)));
            }
            
        }


        private void SetUp10()
        {

        }

        [TestMethod]
        public void T()
        {
           
        }


    }
}
