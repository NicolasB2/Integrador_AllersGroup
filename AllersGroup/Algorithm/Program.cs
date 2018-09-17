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

            IEnumerable<String[]> a = Algorithms.BruteForce.Combinations(data, 2);

            var b = a.ToList();
            foreach (var x in b) {
                Console.WriteLine("Grupo: ");
                foreach (var q in x.ToList())
                {
                    Console.WriteLine(q);
                }
            }

         Console.ReadLine();
        }
    }
}
