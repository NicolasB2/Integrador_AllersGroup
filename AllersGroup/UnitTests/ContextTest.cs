
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Model;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class ContextTest
    {
        private Context ctx;
        public void SetUp1()
        {
            ctx = new Context();
        }

        [TestMethod]
        public void Text1()
        {
            SetUp1();

            Assert.IsNotNull(ctx.Clients);
            Assert.IsNotNull(ctx.Items);
            Assert.IsNotNull(ctx.Transactions);

            Assert.IsTrue(ctx.Clients.Any());
            Assert.IsTrue(ctx.Items.Any());
            Assert.IsTrue(ctx.Transactions.Any());

            Assert.IsTrue(ctx.Clients.Count() == 4862);
            Assert.IsTrue(ctx.Items.Count() == 10932);
            Assert.IsTrue(ctx.Transactions.Count()== 149299);
        }

 

    }
}
