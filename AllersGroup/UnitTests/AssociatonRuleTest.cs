using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AssociatonRuleTest
    {
        private List<String[]> solution; 
        private List<String> input2;
        private String[] candidates;

        private void SetUp7()
        {
            input2 = new List<String>() { "Bread", "Milk" };
            solution = new List<String[]> { new[] { "Bread" }, new[] { "Milk" }, new[] { "Bread", "Milk" } };
        }

        private void SetUp8()
        {
            input2 = new List<String>() { "Beer", "Bread", "Milk" };
            solution = new List<String[]> { new[] { "Beer" }, new[] { "Bread" },
            new[] { "Milk" }, new[] { "Beer", "Bread" }, new[] { "Beer", "Milk" },new[] { "Bread", "Milk" },new[]{ "Beer", "Bread", "Milk" }};
        }

        private void SetUp9()
        {
            input2 = new List<String>() { "Beer", "Bread", "Diapers", "Milk" };
            solution = new List<String[]> { new[] { "Beer" },  new[] { "Bread" },new[] { "Diapers" }, new[] { "Milk" },
                new[] { "Beer", "Bread" }, new[] { "Beer", "Diapers" }, new[] { "Beer", "Milk" },
                new[] { "Bread", "Diapers" },new[] { "Bread", "Milk" }, new[] { "Diapers", "Milk" },
                new[] { "Beer", "Bread", "Diapers" }, new[] { "Beer", "Bread", "Milk" },
                new[] { "Beer",  "Diapers" , "Milk" },new[] { "Bread" , "Diapers" , "Milk"},
                new[] {"Beer", "Bread", "Diapers", "Milk"},};

        }

        private void SetUp10()
        {
            candidates = new String[] { "Bread", "Milk", "Eggs", };

            solution = new List<String[]> {
                new[] { "Milk" },  new[] { "Eggs" },new[] { "Nilk","Eggs" }
            };

        }

        [TestMethod]
        public void TestGenerateSubsets_Size2()
        {

            SetUp7();
            List<String[]> subsets = AssociatonRule.GenerateSubsets(input2);

            Assert.IsTrue(subsets.Count() == 3);

            for (int i = 0; i < solution.Count(); i++)
            {
                for (int j = 0; j < solution.ElementAt(i).Count(); j++)
                {
                    Assert.IsTrue(subsets.ElementAt(i).Contains(solution.ElementAt(i)[j]));
                }
            }
        }


        [TestMethod]
        public void TestGenerateSubsets_Size3()
        {
            SetUp8();
            List<String[]> subsets = AssociatonRule.GenerateSubsets(input2);

            Assert.IsTrue(subsets.Count() == 7);

            for (int i = 0; i < solution.Count(); i++)
            {
                for (int j = 0; j < solution.ElementAt(i).Count(); j++)
                {
                    Assert.IsTrue(subsets.ElementAt(i).Contains(solution.ElementAt(i)[j]));
                }
            }
        }

        [TestMethod]
        public void TestGenerateSubsets_Size4()
        {
            SetUp9();
            List<String[]> subsets = AssociatonRule.GenerateSubsets(input2);

            Assert.IsTrue(subsets.Count() == 15);

            for (int i = 0; i < solution.Count(); i++)
            {
                for (int j = 0; j < solution.ElementAt(i).Count(); j++)
                {
                    Assert.IsTrue(subsets.ElementAt(i).Contains(solution.ElementAt(i)[j]));
                }
            }

        }

        [TestMethod]
        public void TestGenerateRules()
        {
            SetUp10();

            Dictionary<string, List<string[]>> rules = new Dictionary<string, List<string[]>>();
            AssociatonRule.GenerateRules(candidates, rules);

            var n = rules["Bread"];
            Assert.IsTrue(n.Count() == 3);
            List<String[]> res = new List<string[]> { new[] { "Milk" }, new[] { "Eggs" }, new[] { "Milk", "Eggs" } };
            for (int i = 0; i < res.Count(); i++)
            {
                Assert.IsTrue(n.ElementAt(i).SequenceEqual(res.ElementAt(i)));
            }

            n = rules["Milk"];
            Assert.IsTrue(n.Count() == 3);
            res = new List<string[]> { new[] { "Bread" }, new[] { "Eggs" }, new[] { "Bread", "Eggs" } };
            for (int i = 0; i < res.Count(); i++)
            {
                Assert.IsTrue(n.ElementAt(i).SequenceEqual(res.ElementAt(i)));
            }

            n = rules["Eggs"];
            Assert.IsTrue(n.Count() == 3);
            res = new List<string[]> { new[] { "Bread" }, new[] { "Milk" }, new[] { "Bread", "Milk" } };
            for (int i = 0; i < res.Count(); i++)
            {
                Assert.IsTrue(n.ElementAt(i).SequenceEqual(res.ElementAt(i)));
            }

        }
    }
}
