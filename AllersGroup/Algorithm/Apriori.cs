using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms
{
    public static class Apriori
    {

        public static IEnumerable<T[]> GenerateAllFrecuentItemsets<T>(List<T[]> items, List<List<T>> transactions,double threshold)
        {
            List<T[]> frecuentItemsSets = new List<T[]>();
            IEnumerable<T[]> itemsets = GenerateFrequentCandidates(items, transactions, threshold);
            int size = 1;
            
            while (itemsets.Count() != 0)
            {
                
                itemsets = GenerateNextCandidates(itemsets);

                itemsets = GenerateFrequentCandidates(itemsets, transactions, threshold);
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

        public static IEnumerable<T[]> GenerateFrequentCandidates<T>(IEnumerable<T[]> itemsets, 
            List<List<T>> dataBse, double threshold)
        {
            return BruteForce.FrequentItemset(itemsets, dataBse, threshold);
        }

        public static double RuleConfidence<T>(T[] imtemsetLeft, T[] imtemsetRight, IEnumerable<IEnumerable<T>> transactions)
        {

            int supportCountLeft = BruteForce.SupportCount(imtemsetLeft, transactions);
            List<T> combItemsets = new List<T>();
            combItemsets.AddRange(imtemsetLeft.ToList());
            combItemsets.AddRange(imtemsetRight.ToList());

            int supportCountRight = BruteForce.SupportCount(imtemsetRight, transactions);


            return supportCountRight/supportCountLeft ;
        }

        public static void RuleGenerator<T>(List<T[]> items, List<List<T>> transactions, int threshold)
        {
            IEnumerable<T[]> frequentItemsets = GenerateAllFrecuentItemsets(items, transactions, threshold);
            foreach (var f in frequentItemsets)
            {
                T[] actual = f;
            }

        }

        public static Dictionary<T[],List<T[]>> ApGenerateRules<T>(IEnumerable<T[]> itemsets, T[] itemset)
        {
            int sizeItemsets = itemsets.Count();
            int sizeSingleItemset = itemset.Count();

            if (sizeItemsets > sizeSingleItemset + 1 )
            {

            }
            return null; 
        }

    }

}
