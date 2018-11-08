using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;
using serializables;


namespace Model
{
    public class Consult
    {
        public Context context;
        public Cluster<int> cluster;
        public List<List<List<String>>> clusterResult;
        public Dictionary<int, List<int[]>> Rules;


        public Consult()
        {
            context = new Context();
            Rules = new Dictionary<int, List<int[]>>();
            clusterResult = new List<List<List<string>>>();
        }

        private void PrunningClientsAndTransactions()
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

        private void PrunningItemsBythreshold(double threshold)
        {
            List<int[]> itemsets = context.Items.Select(s => new int[] { s.Value.Code }).ToList();
            foreach (int[] item in itemsets)
            {
                if (Support(item) < threshold)
                {
                    context.Items.Remove(item[0]);
                }
            }
        }
        private void PrunningTransactions(int minnimum)
        {
            var m = context.Transactions.Where(t => t.Value.Items.Count > minnimum);
            context.Transactions = m.ToDictionary(k => k.Key, v => v.Value);
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

        private int SupportCount2(int[] itemset)
        {
            var x = itemset.Select(i => context.Items[i]).OrderBy(i => i.Transactions.Count).First().Transactions.Select(t => t.Items).ToList();
            int c = 0;
            foreach (var t in x)
            {
                bool containsAll = true;

                for (int j = 0; j < itemset.Count() && containsAll; j++)
                {
                    if (!t.Contains(itemset.ElementAt(j)))
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
        public double Support(int[] itemset)
        {
            List<List<int>> dataBase = context.Transactions.Select(t => t.Value.Items).ToList();
            int supportCount = SupportCount2(itemset);
            int totalTransactions = context.Transactions.Select(t => t.Value).GroupBy(t => t.Code).ToList().Count();

            return (double)supportCount / totalTransactions;
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
            List<int[]> itemsets = context.Items.Select(s => new int[] { s.Value.Code }).ToList();
            List<List<int>> transactions = context.Transactions.Select(t => t.Value.Items).ToList();
            return Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, threshold).ToList();
        }

        public List<int[]> Final_FrequentItemsets_Apriori(double threshold)
        {
            List<int[]> apr = new List<int[]>();
            String f = context.path + "ItemSets_" + threshold + ".xml";
            if (File.Exists(f))
            {
                SerializableItemSets.Deserialize(apr, f);
            }
            else
            {
                PrunningTransactions(1);
                PrunningItemsBythreshold(threshold);
                apr = FrequentItemsets_Apriori(threshold);
                SerializableItemSets.SerializeObject(apr, f);
            }

            context = new Context();

            return apr;
        }

        //**********************************************************************************************
        //************ CLUSTERING **********************************************************************
        //**********************************************************************************************
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

            String f = context.path + "Cluster_" + Similarity_level + ".xml";

            if (File.Exists(f))
            {
                serializableCluster.Deserialize(clusterResult, f);
            }
            else
            {
                Dictionary<String, List<int>> dic = GenerateDictionary_CLient_items();
                cluster = new Cluster<int>(dic);
                cluster.Clustering(Similarity_level);
                clusterResult = cluster.results();
                serializableCluster.SerializeObject(clusterResult, f);
            }
        }

        public IEnumerable<String> findClients_byItem(string itemCode)
        {
            var x = clusterResult.First(c => c.ElementAt(1).Contains(itemCode)).ElementAt(0);
            return x;
        }

        public IEnumerable<String> findItems_byClient(String clientCode)
        {
            var x = clusterResult.First(c => c.ElementAt(0).Contains(clientCode)).ElementAt(1);
            return x;
        }

        public IEnumerable<String> Purchase_prediction_from_Clustering(String itemCode, double support)
        {
            Clustering(support);
            var x = findClients_byItem(itemCode);
            return x;
        }


        //**********************************************************************************************
        //************ RULES ***************************************************************************
        //**********************************************************************************************
        public List<String> formatItemSets(IEnumerable<int[]> frequent)
        {
            List<String> ret = new List<string>();
            foreach (var i in frequent)
            {
                String a = "(";
                for (int j = 0; j < i.Length; j++)
                {
                    if (j == i.Length - 1)
                    {
                        a += i[j] + ")";
                    }
                    else
                    {
                        a += i[j] + ",";
                    }
                }

                ret.Add(a);
            }
            return ret;
        }


        public void GenerateRules(double threshold)
        {
            Rules = new Dictionary<int, List<int[]>>();
            AssociatonRule.GenerateAllRules<int>(Final_FrequentItemsets_Apriori(threshold), Rules);
        }

        public List<String> getDependence(int itemCode, double threshold)
        {
            GenerateRules(threshold);
            List<int[]> x = new List<int[]>();
            try
            {
                x = Rules[itemCode];
            }
            catch
            {
                return new List<string> { "No se pudo generar ninguna oferta con el item de codigo " + itemCode };
            }
            return formatItemSets(x);
        }


        //**********************************************************************************************
        //************ METODOS DE AGRUPACION ***********************************************************
        //**********************************************************************************************


        //************** CLIENT TYPE ***********************

        //lista con los tipos de cliente
        public IEnumerable<String> ClientTypes()
        {
            return context.Clients.Select(c => c.Value.Type).Distinct();
        }

        //clients dado un tipo de clientes
        public IEnumerable<Client> Clients_ByType(String type)
        {
            var n = context.Clients.Select(c => c.Value).Where(c => c.Type.Equals(type));
            return n;
        }

        //Transacciones dado un tipo de cliente
        public IEnumerable<Transaction> Transactions_ByClientsType(String type)
        {
            var n = context.Transactions.Select(t => t.Value).Where(t => context.Clients[t.ClientCode].Type.Equals(type));
            return n;
        }

        //Itesm dado un tipo de cliente 
        public IEnumerable<int> Items_ClientsType(String type)
        {
            var n = Transactions_ByClientsType(type).SelectMany(t => t.Items).Distinct();
            return n;
        }

        //retorna un arreglo con [0]=codigo del item y [1]=porsentaje de aparicion del item en las compras de un tipo determinado de cliente
        public IEnumerable<String[]> FrequentItems_by_ClientType(String clientType)
        {

            var y = Transactions_ByClientsType(clientType);
            var x = y.SelectMany(n => n.Items).GroupBy(i => i).Select(n => new String[] { n.Key + "", (n.Count() / (double)y.Count()) + "" });
            return x;
        }

        //************** DEPARTMENT CROUP ***********************

        // Arreglo de clientes dado un departamento
        public IEnumerable<Client> ClientsByDepartment(String department)
        {
            var x = context.Clients.Select(n => n.Value).Where(n => n.Departament.Equals(department));
            return x;
        }

        // Arreglo de Transacciones dado un departamento
        public IEnumerable<Transaction> TransactionsByDepartment(String department)
        {
            var x = ClientsByDepartment(department).SelectMany(c => c.Transactions);
            return x;
        }

        // Arreglo de ItemsCodes dado un departamento
        public IEnumerable<int> ItemsByDepartment(String department)
        {
            var x = TransactionsByDepartment(department).SelectMany(t => t.Items).Distinct();
            return x;
        }

        //retorna un arreglo con [0]=codigo del item y [1]=porcentaje de aparicion del 
        // item en las compras de ese departamento
        public IEnumerable<String[]> FrequentItems_by_Department(String department)
        {

            var y = TransactionsByDepartment(department);
            var x = y.SelectMany(n => n.Items).GroupBy(i => i).Select(n => new String[] { n.Key + "", (n.Count() / (double)y.Count()) + "" });
            return x.OrderByDescending(i => int.Parse(i[1]));
        }


        //************** MONTH CROUP ***********************
        // Arreglo de clientesCode dado un mes
        public IEnumerable<String> ClientsByMonth(int month)
        {
            var x = TransactionsByMonth(month).Select(t=>t.ClientCode).Distinct();
            return x;
        }

        // Arreglo de Transacciones dado un mes
        public IEnumerable<Transaction> TransactionsByMonth(int month)
        {
            var x = context.Transactions.Select(n => n.Value).Where(n => n.Date.Month == month);
            return x;
        }

        // Arreglo de ItemsCodes dado un mes
        public IEnumerable<int> ItemsByMonth(int month)
        {
            var x = TransactionsByMonth(month).SelectMany(t => t.Items).Distinct();
            return x;
        }

        //Arreglo de ItemCodes dado un rango de tiempo (mes-mes)
        public IEnumerable<int> ItemCodesByTimePeriod(int month1, int month2)
        {
            var m1 = ItemsByMonth(month1);
            var m2 = ItemsByMonth(month2);

            var list = m1.Union(m2).Distinct();

            return list;
            
        }
        
        //retorna un arreglo con [0]=codigo del cliente y [1]=numero de compras de compras de ese cliente en ese mes
        public IEnumerable<String[]> Frequent_Clients_ByMonth(int month)
        {
            
            var x = TransactionsByMonth(month).GroupBy(t => t.ClientCode).
                OrderBy(g => g.Count()).Select(n => new String[] { n.Key, n.Count() + "" });
            return x.OrderByDescending(n => int.Parse(n[1]));
        }

        //Arreglo con [0]=codigo del cliente y [1]=numero de compras de compras de ese cliente 
        //en un rango de tiempo (mes-mes)
        public IEnumerable<String[]> ClientsByTimePeriod(int month1, int month2)
        {
            var c1 = Frequent_Clients_ByMonth(month1);
            var c2 = Frequent_Clients_ByMonth(month2);

            var list = c1.Union(c2).Distinct().OrderByDescending(n => int.Parse(n[1]));

            return list; 
        }

        //retorna un arreglo con [0]=codigo del item y [1]=porcentaje de aparición del 
        //item en las compras de ese mes
        public IEnumerable<String[]> Frequent_Items_ByMonth(int month)
        {
            var y = TransactionsByMonth(month);
            var x = y.SelectMany(n => n.Items).GroupBy(i=>i).Select(n => new String[] { n.Key+"", Math.Round((n.Count()/ (double)y.Count())*100,2) + "" });
            return x.OrderByDescending(i => Double.Parse(i[1]));
        }

        public IEnumerable<String[]> ItemsByTimePeriod(int month1, int month2)
        {
            var i1 = Frequent_Items_ByMonth(month1);
            var i2 = Frequent_Items_ByMonth(month2);
            
            var list = i1.Union(i2).Distinct().OrderByDescending(i => Double.Parse(i[1]));

            return list;
        }

        //***********************************************************
        // CARRO DE COMPRAS CREO (Clients Methods) 
        //***********************************************************

        //Returns the codes of all clients.
        public string[] clientsCodes()
        {
            return context.Clients.Select(n => n.Key).ToArray();
        }

        public int totalTransactionsClient(string clientCode)
        {
            return context.Clients[clientCode].Transactions.Count();
        }

        public List<String> itemsbyClient(String clientCode)
        {
            List<String> itemsets = context.Clients[clientCode].Transactions.SelectMany(t => t.Items).Distinct().Select(t=>""+t).ToList();
            return itemsets;
        }

        public List<String> itemSetsFrecuentesByClient(String clientCode, double Support)
        {
            List<int[]> itemsets = context.Clients[clientCode].Transactions.SelectMany(t=>t.Items).Distinct().Select(s => new int[] { s }).ToList();
            List<List<int>> transactions = context.Clients[clientCode].Transactions.Select(t => t.Items).ToList();
            var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, Support).ToList();

            return formatItemSets(frequent);
        }

        static void Main(string[] args)
        {
            Consult c = new Consult();

            //Console.WriteLine("Initial clients {0}", c.context.Clients.Count());
            //Console.WriteLine("Initial Transactions {0}", c.context.Transactions.Count());
            //Console.WriteLine("Initial Items {0}", c.context.Items.Count());

            c.Clustering(0.4);
            //Console.WriteLine(c.clusterResult.Count());
            //c.FrequentItemsets_Apriori(0.01);
            //c.GenerateRules(0.1);

            //c.itemSetsFrecuentesByClient("CN0001", 0.5).ForEach(e => Console.WriteLine(e));
            //c.itemsbyClient("CN0012").ForEach(e => Console.WriteLine(e));
            //c.getDependence(23, 0.005).ForEach(e => Console.WriteLine(e));

            var x = c.Frequent_Items_ByMonth(1).ToList();
            //var x = c.FrequentItems_by_Department("NARIÑO").ToList();
            //var x = c.FrequentItems_by_ClientType("CLINICAS PRIVADAS").ToList();

            foreach (String[] a in x)
            {
                Console.WriteLine(a[0] + "    " + a[1]);
            }


            //var x = c.Purchase_prediction_from_Clustering("23",0.95);
            //foreach (String a in x)
            //{
            //    Console.WriteLine(a);
            //}


            //var x = c.Purchase_prediction_from_Clustering("23", 0.90);
            //foreach (String a in x)
            //{
            //    Console.WriteLine(a);
            //}

            Console.WriteLine();
            Console.WriteLine("END");
            
            Console.ReadLine();
        }

    }
}
