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
            context = new Context(Context.dataBase);
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
                var m = context.Items.Select(s => s.Value).ToList();
                itemset = BruteForce.Combinations(m, size).ToList();
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
            List<List<Item>> dataBase = context.Transactions.Select(t => t.Value.Items).ToList(); 
            return BruteForce.SupportCount(itemset, dataBase);
        }

        public double Support(Item[] itemset)
        {
            List<List<Item>> dataBase = context.Transactions.Select(t => t.Value.Items).ToList();
            int supportCount = SupportCount(itemset);
            int totalTransactions = context.Transactions.Select(t=>t.Value).GroupBy(t => t.Code).ToList().Count();

            return BruteForce.Support(itemset,dataBase,totalTransactions);
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

       
    }
}
