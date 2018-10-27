using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;


namespace Model
{
    public class Consult
    {
        public Context context;
        public Cluster<int> cluster;
        public Dictionary<int, int> AssociationRules;

        public Consult()
        {
            context = new Context();
        }

        private void  PrunningClientsAndTransactions()
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

        private void PrunningItems()
        {
            List<int> dataBase = context.Transactions.SelectMany(t => t.Value.Items).Distinct().ToList();
            Dictionary<int, Item> aux = new Dictionary<int, Item>();

            foreach (KeyValuePair<int, Item> entry in context.Items)
            {
                if (dataBase.Contains(entry.Key))
                {
                    aux.Add(entry.Key, (Item)entry.Value);
                }

            }

            context.Items = aux;
        }

        /**
         * Frecuency of occurrence of an itemset: Counts in how many transactions a given itemset occurs.
        * itemset : Array of codes of a itemset.
        **/
        private int SupportCount(int[] itemset)
        {
            List<List<int>> dataBase = context.Transactions.Select(t => t.Value.Items).ToList();
            return Statistic.SupportCount(itemset, dataBase);
        }


        /**
         * Fraction of the transactions in which an itemset appears.
         * itemset: A given itemset.
         * transactionsDataBase: List of all the transactions.
         **/
        private double Support(int[] itemset)
        {
            List<List<int>> dataBase = context.Transactions.Select(t => t.Value.Items).ToList();
            int supportCount = SupportCount(itemset);
            int totalTransactions = context.Transactions.Select(t => t.Value).GroupBy(t => t.Code).ToList().Count();

            return Statistic.Support(itemset, dataBase);
        }

        /**
         * Return a list of all the itemsets of a determinated size.
         * size: the size of the itemset. 
         **/
        private List<int[]> GenerateItemSet_BruteForce(int size)
        {
            List<int[]> itemset = null;
            var m = context.Items.Select(s => s.Value.Code).ToList();

            itemset = BruteForce.Combinations(m, size).ToList();

            return itemset;
        }

        /**
         * Returns a list of all the frequent itemset and it's support is bigger than the threshold.
         * threshold: minimum of support.
         * itemsetSize: size of the itemset.
         * **/
        public List<int[]> FrequentItemsets_BruteForce(double threshold, int itemsetSize)
        {
            List<List<int>> transactions = context.Transactions.Select(t => t.Value.Items).ToList();
            var itemset = context.Items.Select(s => s.Value.Code).ToList();
            return BruteForce.GenerateAllFrecuentItemsets(itemset, transactions, itemsetSize, threshold).ToList();
        }

        public List<int[]> FrequentItemsets_Apriori(double threshold)
        {
            //No hacerlo con BruteForce, hacerlo con Consult.
            
            List<int[]> itemsets = GenerateItemSet_BruteForce(1);
            List<List<int>> transactions = context.Transactions.Select(t => t.Value.Items).ToList();
            return Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, threshold).ToList();
        }

        private Dictionary<String, List<int>> GenerateDictionary_CLient_items()
        {
            Dictionary<String, List<int>> aux = context.Transactions.Select(t => t.Value).GroupBy(t => t.ClientCode).Select(g => new {

                code = g.Key,
                items = g.SelectMany(n => n.Items).Distinct().ToList()

            }).ToDictionary(k => k.code, value => value.items);

            return aux;
        }

        public void Clustering(double Similarity_level)
        {
            Dictionary<String, List<int>> dic = GenerateDictionary_CLient_items();
            Console.WriteLine();
            cluster = new Cluster<int>(dic);
            Console.WriteLine();
            cluster.Clustering(Similarity_level);
        }


        public void GenerateRules()
        {

        }

        public String GenerateReport_Itemset() {
            return "";
        }

        public String GenerateReport_Client()
        {
            return "";
        }

        public IGrouping ClientsByDepartment()
        {
            return null;
        }

        public IGrouping ClientsByType()
        {
            return null;
        }

        public IGrouping ClientsByMonth()
        {
            return null;
        }

        public IGrouping ItemsByDepartment()
        {
            return null;
        }

        public IGrouping ItemsByMonth()
        {
            return null;
        }


        static void Main(string[] args)
        {
            Consult c = new Consult();

            Console.WriteLine("Initial clients {0}", c.context.Clients.Count());
            Console.WriteLine("Initial Transactions {0}", c.context.Transactions.Count());
            Console.WriteLine("Initial Items {0}", c.context.Items.Count());

            //c.PrunningClientsAndTransactions();
            //c.PrunningItems();

            //Console.WriteLine();

            //Console.WriteLine("Clients {0}", c.context.Clients.Count());
            //Console.WriteLine("Transactions {0}", c.context.Transactions.Count());
            //Console.WriteLine("Items {0}", c.context.Items.Count());

            //c.context.SavePrunns();
            //Console.WriteLine();

            //c.Clustering(0.8);
            //c.FrequentItemsets_Apriori(0.005);

            Console.WriteLine();
            Console.WriteLine("END");
            Console.ReadLine();
        }

    }
}
