using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms
{
    public static class Apriori
    {


        //GENERATE FRECUENT ITEM SETS ************************************************************

        public static T[] GenerateCandidate<T>(T[] itemset1, T[] itemset2)
        {
            T[] candidate = null;

            if (itemset1.Count() == itemset2.Count())
            {
                int length = itemset1.Count();
                candidate = new T[length + 1];
                bool flag = true;

                for (int i = 0; i < length - 1 && flag; i++)
                {
                    if (itemset1.ElementAt(i).Equals(itemset2.ElementAt(i)))
                    {
                        candidate[i] = itemset1[i];
                    }
                    else
                    {
                        flag = false;
                        candidate = null;
                    }
                }

                if (flag)
                {
                    candidate[length - 1] = itemset1[length - 1];
                    candidate[length] = itemset2[length - 1];
                }
            }
            return candidate;
        }

        public static IEnumerable<T[]> GenerateNextCandidates<T>(IEnumerable<T[]> itemsets)
        {
            List<T[]> candidates = new List<T[]>();

            for (int i = 0; i < itemsets.Count(); i++)
            {
                for (int j = i + 1; j < itemsets.Count(); j++)
                {
                    T[] newItemSet = GenerateCandidate(itemsets.ElementAt(i), itemsets.ElementAt(j));
                    if (newItemSet != null)
                    {
                        candidates.Add(newItemSet);
                    }
                }
            }
            return candidates;
        }
       

        public static IEnumerable<T[]> GenerateAllFrecuentItemsets<T>(List<T[]> items, List<List<T>> transactions, double threshold)
        {
            List<T[]> frecuentItemsSets = new List<T[]>();
            IEnumerable<T[]> itemsets = Statistic.FrequentItemset(items, transactions, threshold);
            int size = 1;

            while (itemsets.Count() != 0)
            {
                itemsets = GenerateNextCandidates(itemsets);
                itemsets = Statistic.FrequentItemset(itemsets, transactions, threshold);
                frecuentItemsSets.AddRange(itemsets);

                //foreach (T[] pre in itemsets)
                //{
                //    String a = "";
                //    for (int i = 0; i < pre.Length; i++)
                //    {
                //        a += pre[i] + " ";
                //    }
                //    Console.WriteLine(a);
                //}

                size++;
            }
            return frecuentItemsSets;
        }



        //GENERATE ASOSATION RULE *****************************************************************************


        public static List<T[]> GenerateSubsets<T>(List<T> itemset)
        {
            List<T[]> subsets = new List<T[]>();
            bool flag = true;



            for (int i = 0; flag; i++)
            {
                subsets.AddRange(BruteForce.Combinations(itemset, i + 1));
                flag = i < subsets.Count();

                if (flag)
                {
                    foreach (var a in subsets.ElementAt(i))
                    {
                        Console.Write(a + " ");
                    }
                    Console.WriteLine(" ");
                }

            }
            return subsets;
        }

        public static void GenerateRules<T>(T[] itemset)
        {
            for (int i = 0; i < itemset.Length; i++)
            {
                var x = itemset.ToList();
                x.Remove(itemset[i]);
                List<T[]> m = GenerateSubsets(x);

                //foreach (T[] sara in m)
                //{
                //    String a = "";
                //    for (int j = 0; j < sara.Length; j++)
                //    {
                //        a += sara[j]+" ";
                //    }
                //    Console.WriteLine(a + " -> " + itemset[i]);
                //}

            }

        }

        
    }
}
