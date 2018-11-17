using System;
using System.Collections.Generic;
using System.Linq;

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
            return CombinationsImpl(items, 0, size - 1);
        }

        /**  
         * argList:
         * argStart:
         * argIteration:
         * argIndices:
         **/
        private static IEnumerable<T[]> CombinationsImpl<T>(IList<T> argList, int argStart, int argIteration, List<int> argIndicies = null)
        {
            argIndicies = argIndicies ?? new List<int>();
            for (int i = argStart; i < argList.Count; i++)
            {
                argIndicies.Add(i);
                if (argIteration > 0)
                {
                    foreach (var array in CombinationsImpl(argList, i + 1, argIteration - 1, argIndicies))
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
         * 
         **/
        public static IEnumerable<T[]> GenerateAllFrecuentItemsets<T>(IList<T> items, List<List<T>> transactions, int size, double threshold)
        {
            IEnumerable<T[]> itemSet = Combinations(items, size);
            itemSet = Statistic.FrequentItemset(itemSet, transactions, threshold);
            return itemSet;
        }
    }
}
