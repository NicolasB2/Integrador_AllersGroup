using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Algorithms;


namespace UnitTests
{
    [TestClass]
    public class BruteForceText
    {
        private List<String> Data;
        private IEnumerable<String[]> Solution;

        public void SetUp1()
        {
            Data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Solution = new List<String[]>{ new String[]{"Beer"},
                                           new String[]{"Milk"},
                                           new String[]{"Diapers"},
                                           new String[]{"Bread"},
                                           new String[]{"Eggs"}
            };
        }

        public void SetUp2()
        {
            Data =new List<string>{ "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Solution = new List<String[]>{ new String[]{"Beer", "Milk" },
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
            Data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Solution = new List<String[]>{ new String[]{"Beer", "Milk", "Diapers"},
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
            Data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Solution = new List<String[]>{ new String[]{"Beer", "Milk", "Diapers", "Bread"},
                                           new String[]{"Beer", "Milk", "Diapers", "Eggs" },
                                           new String[]{"Beer", "Milk", "Bread", "Eggs" },
                                           new String[]{"Beer", "Diapers", "Bread", "Eggs" },
                                           new String[]{"Milk", "Diapers", "Bread", "Eggs" }
            };            
        }

        public void SetUp5()
        {
            Data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Solution = new List<String[]>{ new String[] { "Beer", "Milk", "Diapers", "Bread", "Eggs" }};
        }


        private void Comparer(int x) {
            IEnumerable<String[]> a = Algorithms.BruteForce.Combinations(Data, x);
            int aux = 0;
            foreach (String[] n in a)
            {
                    n.SequenceEqual(Solution.ToList().ElementAt(aux));
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
    }
}
