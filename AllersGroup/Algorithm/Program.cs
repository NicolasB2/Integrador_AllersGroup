using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String>  input2 = new List<String>() { "Bread", "Milk" };
            List<String[]> solution = new List<String[]> { new String[] { "Milk" } };
            List<String[]> n =  Apriori.GenerateSubsets(input2);


            Console.ReadLine();
        }  
    }
}
