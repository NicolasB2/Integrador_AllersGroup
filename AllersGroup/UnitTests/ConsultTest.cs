using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Algorithms;

namespace UnitTests
{
    [TestClass]
    public class ConsultTest
    {
        private List<Item[]> itemSets;
        public int[] Solution;
        private Consult consult; 

        public void SetUp()
        {
            consult = new Consult();
            Solution =new [] {0,0,0,0,0,0,3,4,3,3};


            itemSets = new List<Item[]>
            {   new Item[]{consult.context.Items.First(n=> n.Value.Code == 18210).Value, consult.context.Items.First(n => n.Value.Code == 516).Value, consult.context.Items.First(n => n.Value.Code == 524).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 18210).Value, consult.context.Items.First(n => n.Value.Code == 516).Value, consult.context.Items.First(n => n.Value.Code == 514).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 18210).Value, consult.context.Items.First(n => n.Value.Code == 516).Value, consult.context.Items.First(n => n.Value.Code == 552).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 18210).Value, consult.context.Items.First(n => n.Value.Code == 524).Value, consult.context.Items.First(n => n.Value.Code == 514).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 18210).Value, consult.context.Items.First(n => n.Value.Code == 524).Value, consult.context.Items.First(n => n.Value.Code == 552).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 18210).Value, consult.context.Items.First(n => n.Value.Code == 514).Value, consult.context.Items.First(n => n.Value.Code == 552).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 516).Value, consult.context.Items.First(n => n.Value.Code == 524).Value, consult.context.Items.First(n => n.Value.Code == 514).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 516).Value, consult.context.Items.First(n => n.Value.Code == 524).Value, consult.context.Items.First(n => n.Value.Code == 552).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 516).Value, consult.context.Items.First(n => n.Value.Code == 514).Value, consult.context.Items.First(n => n.Value.Code == 552).Value},
                new Item[]{consult.context.Items.First(n=> n.Value.Code == 524).Value, consult.context.Items.First(n => n.Value.Code == 514).Value, consult.context.Items.First(n => n.Value.Code == 552).Value }
            };

                                         
        }


        [TestMethod]
        public void SupportCountTest()
        {
            SetUp();
            int cont = 0;
            foreach (Item[] data in itemSets)
            {
                Assert.IsTrue(consult.SupportCount(data) == Solution[cont]);
                cont++;
            }

        }

        [TestMethod]
        public void SupportTest()
        {
            SetUp();
            foreach (Item[] data in itemSets)
            {
                Assert.IsTrue(consult.Support(data) == 0);
            }

        }
    }
}
