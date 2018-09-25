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
        **/
        public static IEnumerable<T[]> Combinations<T>(this IList<T> argList, int argSetSize)
        {
            if (argList == null) throw new ArgumentNullException("argList");
            if (argSetSize <= 0) throw new ArgumentException("argSetSize Must be greater than 0", "argSetSize");
            return combinationsImpl(argList, 0, argSetSize - 1);
        }

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
        * itemset : Array of codes of a itemset.
        **/
        public static int SupportCount<T>(T[] itemset,List<List<T>> dataBase)
        {
            int c = 0;

            for (int i = 0; i < dataBase.Count(); i++)
            {

                List<T> actualT = dataBase.ElementAt(i);
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


        public static double Support<T>(T[] itemset,List<List<T>> dataBase,int total)
        {
            int supportCount = SupportCount(itemset,dataBase);
            return supportCount / total;
        }

        public static List<T[]> FrequentItemset<T>(List<T[]> itemsets, List<List<T>> dataBase,int total, int threshold, int itemsetSize)
        {
            List<T[]> frequentItemset = new List<T[]>();


            for (int i = 0; i < itemsets.Count(); i++)
            {

                if (Support(itemsets.ElementAt(i),dataBase,total) > threshold)
                {
                    frequentItemset.Add(itemsets.ElementAt(i));
                }
            }
            return frequentItemset;
        }
    }
}
