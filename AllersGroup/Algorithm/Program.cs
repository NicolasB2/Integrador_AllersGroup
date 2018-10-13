using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            String[]data = new String[] { "Bread", "Milk", "Diapers", "Bread", "Eggs", "Coke" };
            Apriori.GenerateRules(data);

            Console.ReadLine();
        }  
    }
}
