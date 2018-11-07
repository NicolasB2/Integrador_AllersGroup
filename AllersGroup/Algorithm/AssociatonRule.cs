using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AssociatonRule
    {

        private static List<T[]> GenerateSubsets<T>(List<T> itemset)
        {
            List<T[]> subsets = new List<T[]>();
            bool flag = true;



            for (int i = 0; flag; i++)
            {
                subsets.AddRange(BruteForce.Combinations(itemset, i + 1));
                flag = i < subsets.Count();

                //if (flag)
                //{
                //    foreach (var a in subsets.ElementAt(i))
                //    {
                //        Console.Write(a + " ");
                //    }
                //    Console.WriteLine(" ");
                //}

            }
            return subsets;
        }

        public static void GenerateRules<T>(T[] itemset, Dictionary<T, List<T[]>> rules)
        {

            for (int i = 0; i < itemset.Length; i++)
            {
                var x = itemset.ToList();
                x.Remove(itemset[i]);
                List<T[]> sub = GenerateSubsets(x);

                //foreach (T[] aux in sub)
                //{

                //    String a = "";
                //    for (int j = 0; j < aux.Length; j++)
                //    {
                //        a += aux[j] + " ";

                //    }
                //    Console.WriteLine(a + " -> " + itemset[i]);
                //}

                if (rules.ContainsKey(itemset[i]))
                {
                    List<T[]> implicant = rules[itemset[i]];
                    implicant.AddRange(sub);
                    rules.Remove(itemset[i]);
                    rules.Add(itemset[i], implicant);
                }
                else
                {
                    rules.Add(itemset[i], sub);
                }


            }
        }

        public static void GenerateAllRules<T>(List<T[]> itemset, Dictionary<T, List<T[]>> rules)
        {
            var x = itemset.Where(i=>i.Length==2);

            foreach(T[] iset in x)
            {
                GenerateRules(iset, rules);
            }
        }

    }
}