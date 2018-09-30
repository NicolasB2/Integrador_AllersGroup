using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String[]>  data = new List<String[]>{ new[] {"Beer",   "Eggs" }};
            Console.WriteLine("a");
            List<String[]> sara = Apriori.GenerateNextCandidates(data);

            Console.WriteLine(sara.Count());
            //Console.WriteLine(sara.Count());
            Console.WriteLine("b");
            Console.ReadLine();
        }  
    }
}
