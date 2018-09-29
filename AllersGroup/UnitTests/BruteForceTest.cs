using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class BruteForceTest
    {
        private List<List<String>> model;
        private List<String> data;
        private int threshold;

        private IEnumerable<String[]> solution;

        public void SetUp()
        {
            data = new List<string> { "Bread", "Milk", "Diapers", "Bread", "Eggs", "Coke" };

            model = new List<List<String>>
            {
                new List<String>{"Bread", "Milk"},
                new List<String>{"Bread", "Diapers", "Beer", "Eggs"},
                new List<String>{"Milk", "Diapers", "Beer", "Coke"},
                new List<String>{"Bread", "Milk", "Diapers", "Beer"},
                new List<String>{"Bread", "Milk", "Diapers", "Coke"}
                

             };

        }

        public void SetUp1()
        {
            data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            solution = new List<String[]>{ new String[]{"Beer"},
                                           new String[]{"Milk"},
                                           new String[]{"Diapers"},
                                           new String[]{"Bread"},
                                           new String[]{"Eggs"}
            };
        }

        public void SetUp2()
        {
            data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            solution = new List<String[]>{ new String[]{"Beer", "Milk" },
                                           new String[]{"Beer", "Diapers" },
                                           new String[]{"Beer", "Bread" },
                                           new String[]{"Beer", "Milk" },
                                           new String[]{"Milk", "Diapers" },
                                           new String[]{"Milk", "Bread" },
                                           new String[]{"Milk", "Eggs" },
                                           new String[]{"Diapers", "Bread" },
                                           new String[]{"Diapers", "Eggs" },
                                           new String[]{"Bread", "Eggs"}};
        }

        public void SetUp3()
        {
            data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            solution = new List<String[]>{ new String[]{"Beer", "Milk", "Diapers"},
                                           new String[]{"Beer", "Milk", "Bread" },
                                           new String[]{"Beer", "Milk", "Eggs" },
                                           new String[]{"Beer", "Diapers", "Bread" },
                                           new String[]{"Beer", "Diapers", "Eggs" },
                                           new String[]{"Beer", "Bread", "Eggs" },
                                           new String[]{"Milk", "Diapers", "Bread" },
                                           new String[]{"Milk", "Diapers", "Eggs" },
                                           new String[]{"Milk", "Bread", "Eggs" },
                                           new String[]{ "Diapers", "Bread", "Eggs"}};
        }

        public void SetUp4()
        {
            data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            solution = new List<String[]>{ new String[]{"Beer", "Milk", "Diapers", "Bread"},
                                           new String[]{"Beer", "Milk", "Diapers", "Eggs" },
                                           new String[]{"Beer", "Milk", "Bread", "Eggs" },
                                           new String[]{"Beer", "Diapers", "Bread", "Eggs" },
                                           new String[]{"Milk", "Diapers", "Bread", "Eggs" }
            };
        }

        public void SetUp5()
        {
            data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            solution = new List<String[]> { new String[] { "Beer", "Milk", "Diapers", "Bread", "Eggs" } };
        }

        private void Comparer(int x)
        {
            IEnumerable<String[]> a = Algorithms.BruteForce.Combinations(data, x);
            int aux = 0;
            foreach (String[] n in a)
            {
                n.SequenceEqual(solution.ToList().ElementAt(aux));
                aux++;
            }
        }


        [TestMethod]
        public void Combinations_size_1()
        {
            SetUp1();
            Comparer(1);
        }

        [TestMethod]
        public void Combinations_size_2()
        {
            SetUp2();
            Comparer(2);
        }

        [TestMethod]
        public void Combinations_size_3()
        {
            SetUp3();
            Comparer(3);
        }

        [TestMethod]
        public void Combinations_size_4()
        {
            SetUp4();
            Comparer(4);
        }

        [TestMethod]
        public void Combinations_size_5()
        {
            SetUp5();
            Comparer(5);
        }

        [TestMethod]
        public void SupportCountTest()
        {
            SetUp();
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Bread", "Milk", "Diapers" }, model) == 2);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Milk", "Diapers" }, model) == 3);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Eggs", "Coke" }, model) == 0);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Bread", "Milk" }, model) == 3);
            Assert.IsTrue(BruteForce.SupportCount(new String[] { "Beer", "Diapers" }, model) == 3);


        }

        [TestMethod]
        public void SupportTest()
        {
            SetUp();
            Assert.IsTrue(BruteForce.Support(new String[] { "Bread", "Milk", "Diapers" }, model) == 2/5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Milk", "Diapers" }, model) == 3 / 5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Eggs", "Coke" }, model) == 0 / 5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Bread", "Milk" }, model) == 3 / 5);
            Assert.IsTrue(BruteForce.Support(new String[] { "Beer", "Diapers" }, model) == 3 / 5); ;

        }

        [TestMethod]
        public void FrequentItemsetTest_()
        {
            
        }
    }
}
