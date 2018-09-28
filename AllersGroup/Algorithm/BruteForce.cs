using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BruteForce
    {
        /**
        * Return a list of all the itemsets of a determinated size.
        * size: the size of the itemset. 
        * items: List of items to co
        **/
        public static IEnumerable<T[]> Combinations<T>(this IList<T> items, int size)
        {
            if (items == null) throw new ArgumentNullException("The item list can't be empty.");
            if (size <= 0) throw new ArgumentException("The size of the itemset must be greater than 0");
            return combinationsImpl(items, 0, size - 1);
        }

        /**  
         * 
         **/
        private static IEnumerable<T[]> combinationsImpl<T>(IList<T> argList, int argStart, int argIteration, List<int> argIndicies = null)
        {
            argIndicies = argIndicies ?? new List<int>();
            for (int i = argStart; i < argList.Count; i++)
            {
                argIndicies.Add(i);
                if (argIteration > 0)
                {
                    foreach (var array in combinationsImpl(argList, i + 1, argIteration - 1, argIndicies))
                    {
                        yield return array;
                    }
                }
                else
                {
                    var array = new T[argIndicies.Count];
                    for (int j = 0; j < argIndicies.Count; j++)
                    {
                        array[j] = argList[argIndicies[j]];
                    }

                    yield return array;
                }
                argIndicies.RemoveAt(argIndicies.Count - 1);
            }
        }


        /**
        * Frecuency of occurrence of an itemset: Counts in how many transactions a given itemset occurs.
        * itemset : Itemset
        * transactions: List of all transactions
        **/
        public static int SupportCount<T>(T[] itemset, List<List<T>> transactions)
        {
            int c = 0;

            for (int i = 0; i < transactions.Count(); i++)
            {
                List<T> actualT = transactions.ElementAt(i);
                bool containsAll = true;

                for (int j = 0; j < itemset.Count() && containsAll; j++)
                {
                    if (!actualT.Contains(itemset.ElementAt(j)))
                    {
                        containsAll = false;
                    }
                }

                if (containsAll)
                {
                    c++;
                }
            }
            return c;
        }

        /**
         * Fraction of the transactions in which an itemset appears.
         * itemset: A given itemset.
         * transactionsDataBase: List of all the transactions.
         **/
        public static double Support<T>(T[] itemset, List<List<T>> transactionsDataBase)
        {
            int supportCount = SupportCount(itemset, transactionsDataBase);
            return supportCount / transactionsDataBase.Count();
        }

        /**
         *Finds all the itemsets whose support is greater than or equal to a given threshold.
         * Returns a List
         *itemsets:
         * dataBase: List of all the itemsets
         * total:
         * threshold:
         **/

        public static List<T[]> FrequentItemset<T>(List<T[]> itemsets, List<List<T>> dataBase, int threshold)
        {
            List<T[]> frequentItemset = new List<T[]>();
            for (int i = 0; i < itemsets.Count(); i++)
            {

                if (Support(itemsets.ElementAt(i), dataBase) > threshold)
                {
                    frequentItemset.Add(itemsets.ElementAt(i));
                }
            }
            return frequentItemset;
        }


    }
}
