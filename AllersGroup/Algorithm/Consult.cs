using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Algorithms
{
    public static class Consult
    {

        public static List<Item> MostFrequentItemset(Context c, int size)
        {
            IEnumerable<List<Item>> itemsets = Algorithms.BruteForce.Combinations(c.itemsOnTransactions(), size);

            for (int i = 0; i < itemsets.Count(); i++)
            {

            }
            
            return null;
        }

        private static int TransactionContainsItemset(Context c, List<Item> itemset)
        {
           var transaction = c.Transactions.GroupBy(t => t.Code).ToList();

            int x = 0; 
                foreach (var t in transaction)
                {
                for (int i = 0; i < itemset.Count(); i++)
                {
                    if (t.Equals(itemset.ElementAt(i)))
                    {
                        x++;
                    }
                }
                }

                    items = n,
                    //cant = c.Transactions.GroupBy(t => t.Code).ToList().Count(g => g.All(j => n.Select(its => its.Code).Contains(j.ItemCode)))

                }).First();
                //if (aux.cant > 0)
                    return aux.items;
            }
                return null;
        }

    }
}
