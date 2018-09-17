using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String> data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };

            IEnumerable<List<String>> a = Algorithms.BruteForce.Combinations(data, 2);
            
            var b = a.ToList();
            foreach (var x in b) {
                String mmm = "";
                foreach (var q in x.ToList())
                {
                    mmm += q + "    ";
                }
                Console.WriteLine(mmm);
            }

         Console.ReadLine();
        }
    }
}
