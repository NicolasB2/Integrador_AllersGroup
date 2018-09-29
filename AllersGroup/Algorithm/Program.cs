using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String[]>  data = new List<String[]>
                        {
                        new[] {"Beer",   "Eggs" },
                        new[] {"Beer"   ,"Diapers" },
                        new[] {"Bread"   ,"Eggs" },
                        new[] {"Bread"   ,"Milk" },
                        new[] {"Eggs"   ,"Milk" },
                        new[] {"Diapers"   ,"Milk" },
                        };

            var sara = Apriori.GenerateNextCandidates(data);
            foreach(String[] s in sara)
            {
                String a = "";
                for(int i = 0; i < s.Length; i++)
                {
                    a += s[i] + "   ";
                }
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }  
    }
}
