using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms
{
    public static class Apriori
    {

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


        public static IEnumerable<T[]> GenerateAllFrecuentItemsets<T>(IEnumerable<T[]> itemsets, List<List<T>> transactions, double threshold)
        {
            List<T[]> frecuentItemsSets = new List<T[]>();

            int size = 1;

            while (itemsets.Count() != 0)
            {
                size++;
                itemsets = GenerateNextCandidates(itemsets);
                itemsets = Statistic.FrequentItemset(itemsets, transactions, threshold);
                frecuentItemsSets.AddRange(itemsets);
            }

            return frecuentItemsSets;
        }
    }
}
