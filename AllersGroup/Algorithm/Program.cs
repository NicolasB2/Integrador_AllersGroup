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
            Context ctx = new Context();
            var x = Algorithms.BruteForce.Combinations(ctx.Items,3);
            foreach (List<Item> a in x)
            {
                String j = "";
                foreach(Item n in a)
                {
                    j += n.Code + " ";
                }
                Console.WriteLine(j);
            }

            Console.WriteLine("****************************");
            Console.WriteLine(x.ToList().Count());
            Console.ReadLine();
        }
    }
}
