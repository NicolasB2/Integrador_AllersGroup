using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            Consult consult = new Consult();
            List<Item[]>  itemSets = new List<Item[]>
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

            foreach (Item[] data in itemSets)
            {
              Console.WriteLine( consult.SupportCount(data));
            }

            Console.ReadLine();
        }
    }
}
