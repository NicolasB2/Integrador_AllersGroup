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
        private static Context context;

        public Consult()
        {
            context = new Context();
        }

        /**
         * Return a list of all the itemsets of a determinated size.
         * size: the size of the itemset. 
         **/
        public static List<Item[]> GenerateItemSet(int size) {

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
         * Counts in how many transactions a given itemset occurs.
         * itemsetCodes : Array of codes of a itemset.
         **/
        public static int FrecuencyItemSet(int[] itemsetCodes)
        {            
            int c = 0;

            List<IGrouping<int, Transaction>> transactionsByCode = context.Transactions.GroupBy(t => t.Code).ToList();

            for (int i = 0; i < transactionsByCode.Count(); i++)
            {
                IGrouping<int, Transaction> actualT = transactionsByCode.ElementAt(i);
                List<int> listItemCodes = actualT.Select(g => g.ItemCode).Distinct().ToList();

                bool containsAll = true;

                for (int j = 0; j < itemsetCodes.Count() && containsAll; j++)
                {
                    if (!listItemCodes.Contains(itemsetCodes.ElementAt(j)))
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
    }
}
