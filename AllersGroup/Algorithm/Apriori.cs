using System.Collections.Generic;
using System.Linq;


namespace Algorithms
{
    public static class Apriori
    {
        public static T[] GenerateCandidates<T>(T[] itemset1, T[] itemset2)
        {

            if (itemset1.Count() == itemset2.Count())
            {

                int length = itemset1.Count();
                T[] candidate = new T[length];

                bool flag = true;

                for (int i = 0; i < length - 1 && flag; i++)
                {
                    if (itemset1.ElementAt(i).Equals(itemset2.ElementAt(i)))
                    {
                        Console.WriteLine("bb");
                        candidate[i] = itemset1[i];
                    }
                    else
                    {
                        flag = false;
                    }
                }

                if (flag)
                {
                    candidate[length - 2] = itemset1[length - 1];
                    candidate[length - 1] = itemset2[length - 1];
                }

            }
            return null;
        }

        public static List<T[]> GenerateNextCandidates<T>(List<T[]> itemsets)
        {
            List<T[]> candidates = new List<T[]>();

            for (int i = 0; i < itemsets.Count(); i++)
            {
                for (int j = i + 1; j < itemsets.Count(); j++)
                {
                    T[] newItemSet = GenerateCandidates(itemsets.ElementAt(i), itemsets.ElementAt(j));
                    if (newItemSet != null)
                    {
                        candidates.Add(newItemSet);
                    }
                }
            }
            return candidates;
        }

        public static List<T[]> GenerateFrequentItemsets<T>(List<T[]> itemsets, List<List<T>> dataBse, int threshold)
        {
            return BruteForce.FrequentItemset(itemsets, dataBse, threshold);
        }

    }
}
