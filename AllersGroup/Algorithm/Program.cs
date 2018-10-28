using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {

            String[] aux = new string[] { "Bread", "Milk", "Eggs", };
            List<String[]> input2 = new List<String[]>() { aux};
            //List<String[]> n = Apriori.GenerateSubsets(input2);
            AssociatonRule.GenerateAllRules(input2 ,new Dictionary<string, List<string[]>>());
            Console.ReadLine();
        }
    }
}
