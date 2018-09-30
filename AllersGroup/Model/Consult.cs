using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;


namespace Model
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
        public List<Item[]> GenerateItemSet_BruteForce(int size)
        {

            List<Item[]> itemset = null;

            if (context.Combinations.ContainsKey(size))
            {
                itemset = context.Combinations[size];
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
            int totalTransactions = context.Transactions.Select(t => t.Value).GroupBy(t => t.Code).ToList().Count();

            return BruteForce.Support(itemset, dataBase);
        }


        public List<Item[]> FrequentItemset(int threshold, int itemsetSize)
        {
            List<Item[]> itemsets = GenerateItemSet_BruteForce(itemsetSize);
            List<Item[]> frequentItemset = new List<Item[]>();


            for (int i = 0; i < itemsets.Count(); i++)
            {

                if (Support(itemsets.ElementAt(i)) > threshold)
                {
                    frequentItemset.Add(itemsets.ElementAt(i));
                }
            }
            return frequentItemset;
        }

        public void PrunningClientsAndTransactions()
        {
            List<String> clientsD = new List<String>();
            List<int> transactiondsD = new List<int>();

            foreach (var c in context.Clients)
            {
                if (context.Transactions.Count(t => t.Value.ClientCode == c.Key) <= 6)
                {
                    clientsD.Add(c.Key);

                    foreach (var t in context.Transactions)
                    {

                        if (t.Value.ClientCode == c.Key)
                        {
                            transactiondsD.Add(t.Key);
                        }
                    }
                }
            }

            foreach (var c in clientsD)
            {
                context.Clients.Remove(c);
            }

            foreach (var t in transactiondsD)
            {
                context.Transactions.Remove(t);
            }
        }

        public void PrunningItems()
        {
            List<int> itemsD = new List<int>();

            List<Item[]> itemset_1 = GenerateItemSet_BruteForce(1);
            foreach (var i in itemset_1)
            {
                if (SupportCount(i) == 0)
                {
                    itemsD.Add(i[0].Code);
                    Console.WriteLine(SupportCount(i));
                }
            }

            foreach (var i in itemsD)
            {
                context.Items.Remove(i);
            }
        }


        public List<Item[]> Apriori(int threshold)
        {
            //Itemsets of size 1.
            List<Item[]> itemsets = GenerateItemSet_BruteForce(1);
            List<List<Item>> transactions = context.Transactions.Select(t => t.Value.Items).ToList();
            Algorithms.Apriori.GenerateAllFrecuentItemsets(itemsets,transactions,threshold);
            return null;

        }

        static void Main(string[] args)
        {
            Consult c = new Consult();

            Console.WriteLine("Initial clients {0}", c.context.Clients.Count());
            Console.WriteLine("Initial Transactions {0}", c.context.Transactions.Count());
            Console.WriteLine("Initial Items {0}", c.context.Items.Count());

            c.PrunningClientsAndTransactions();
            c.PrunningItems();

            Console.WriteLine("Clients {0}", c.context.Clients.Count());
            Console.WriteLine("Transactions {0}", c.context.Transactions.Count());
            Console.WriteLine("Items {0}", c.context.Items.Count());

            Console.WriteLine("yes");
            Console.ReadLine();
        }

    }
}
