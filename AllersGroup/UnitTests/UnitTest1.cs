using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using Model;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private List<String> Data;
        private Context ctx;
        private Combination com;

        public void SetUp1()
        {
            com = new Combination();
            ctx = new Context();
            Data =new List<string>{ "Beer", "Milk", "Diapers", "Bread", "Eggs" };
        }

        [TestMethod]
        public void TestMethod1()
        {
            ctx.agruparClientesPorRegion();
        }
    }
}
