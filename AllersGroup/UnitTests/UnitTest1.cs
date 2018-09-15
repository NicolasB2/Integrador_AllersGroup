using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private List<String> Data;

        public void SetUp1()
        {
            Data =new List<string>{ "Beer", "Milk", "Diapers", "Bread", "Eggs" };
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
