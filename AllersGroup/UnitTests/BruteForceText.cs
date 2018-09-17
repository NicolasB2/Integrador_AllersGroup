using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        public void SetUp2()
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
        private void Comparer(int x) {
            IEnumerable<List<String>> a = Algorithms.BruteForce.Combinations(Data, x);
            int aux = 0;
            foreach (List<String> n in a)
            {
                n.SequenceEqual(Solution.ToList().ElementAt(aux));
                aux++;
            }
        }

        [TestMethod]
        public void Combinations_size_2()
        {
            SetUp1();
            Comparer(2);
        }

        [TestMethod]
        public void Combinations_size_3()
        {
            SetUp2();
            Comparer(3);
        }
    }
}
