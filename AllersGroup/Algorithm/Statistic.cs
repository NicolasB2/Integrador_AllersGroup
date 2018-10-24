using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Statistic
    {

        /**
        * Frecuency of occurrence of an itemset: Counts in how many transactions a given itemset occurs.
        * itemset : Itemset
        * transactions: List of all transactions
        **/
        public static int SupportCount<T>(T[] itemset, IEnumerable<IEnumerable<T>> transactions)
        {
            int c = 0;

            for (int i = 0; i < transactions.Count(); i++)
            {
                IEnumerable<T> actualT = transactions.ElementAt(i);
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
        public static double Support<T>(T[] itemset, IEnumerable<IEnumerable<T>> transactions)
        {
            double supportCount = SupportCount(itemset, transactions);
            return (double)supportCount / transactions.Count();
        }


        /**
        * 
        * itemset: A given itemset.
        * transactionsDataBase: List of all the transactions.
        **/
        public static double Confidence<T>(T[] completeItemset, T[] itemset, IEnumerable<IEnumerable<T>> transactions)
        {
            return (SupportCount(completeItemset, transactions) / SupportCount(itemset, transactions));
        }


        /**
         *Finds all the itemsets whose support is greater than or equal to a given threshold.
         * Returns a List
         *itemsets:
         * dataBase: List of all the itemsets
         * total:
         * threshold:
         **/
        public static IEnumerable<T[]> FrequentItemset<T>(IEnumerable<T[]> itemsets,IEnumerable<IEnumerable<T>> transactions, double threshold)
        {
            {
                List<T[]> frequentItemset = new List<T[]>();
                for (int i = 0; i < itemsets.Count(); i++)
                {

                    double support = Support(itemsets.ElementAt(i), transactions);
                    if (support > threshold)
                    {

                        String a = "";
                        for (int m = 0; m < itemsets.ElementAt(i).Length; m++)
                        {
                            a += itemsets.ElementAt(i)[m] + " ";
                        }

                        Console.WriteLine(a);

                        frequentItemset.Add(itemsets.ElementAt(i));
                    }
                }
                return frequentItemset;
            }
        }

    }
}
