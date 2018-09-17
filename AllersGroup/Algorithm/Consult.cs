using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    static class Consult
    {

        public static List<Item> MostFrequentItemset(Context c, int size)
        {
            IEnumerable<List<Item>> itemsets = Algorithms.BruteForce.Combinations(c.itemsOnTransactions(), size);



            return null;
        }

        public static List<Item> LargestItemset(Context c)
        {
            int maxItemSet = c.Transactions.GroupBy(t => t.Code).Select(g => g.Count()).Max();

            for (int i = maxItemSet; i<0;i++)
            {
                IEnumerable<List<Item>> itemsets = Algorithms.BruteForce.Combinations(c.itemsOnTransactions(), i);
                var aux = itemsets.ToList().Select(n => new {

                    items = n,
                    cant = c.Transactions.GroupBy(t => t.Code).ToList().Count(g => g.All(j => n.Select(its => its.Code).Contains(j.ItemCode)))

                }).OrderBy(gr=>gr).Max();
                if (aux.cant > 0)
                    return aux.items;
            }
                return null;
        }

    }
}
