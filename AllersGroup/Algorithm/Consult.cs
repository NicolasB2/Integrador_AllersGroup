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
        private Context context;

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
    }
}
