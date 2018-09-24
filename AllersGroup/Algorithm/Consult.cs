using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Algorithms
{
    public class Consult
    {
        public Context context;

        public Consult()
        {
            context = new Context();
        }

        /**
         * Return a list of all the itemsets of a determinated size.
         * size: the size of the itemset. 
         **/
        public List<Item[]> GenerateItemSet(int size) {

            List<Item[]> itemset = null;
            if (context.Combinations.ContainsKey(size)) {
                itemset= context.Combinations[size];
            }
            else
            {
                itemset= BruteForce.Combinations(context.Items, size).ToList();
                context.Combinations.Add(size, itemset);
            }

            
            return itemset;
        }

         /**
          * Frecuency of occurrence of an itemset: Counts in how many transactions a given itemset occurs.
         * itemset : Array of codes of a itemset.
         **/
        public int SupportCount(Item[] itemset)
        {            
            int c = 0;

            List<IGrouping<int, Transaction>> transactionsByCode = context.Transactions.GroupBy(t => t.Code).ToList();

            for (int i = 0; i < transactionsByCode.Count(); i++)
            {
                IGrouping<int, Transaction> actualT = transactionsByCode.ElementAt(i);
                List<int> listItemCodes = actualT.Select(g => g.ItemCode).Distinct().ToList();

                bool containsAll = true;

                for (int j = 0; j < itemset.Count() && containsAll; j++)
                {
                    if (!listItemCodes.Contains(itemset.ElementAt(j).Code))
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

        public List<Item[]> FrequentItemset(int threshold, int itemsetSize)
        {
            List<Item[]> itemsets = GenerateItemSet(itemsetSize);
            List<Item[]> frequentItemset = new List<Item[]>();


            for (int i = 0; i < itemsets.Count(); i++)
            {

                if (Support(itemsets.ElementAt(i)) > threshold )
                {
                    frequentItemset.Add(itemsets.ElementAt(i)); 
                }
            }
            return frequentItemset; 
        }

        public double Support(Item[] itemset)
        {
            int supportCount = SupportCount(itemset);
            int totalTransactions = context.Transactions.GroupBy(t => t.Code).ToList().Count();

            return supportCount / totalTransactions; 
        }
    }
}
