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
        public List<String> FrequentItemSetsByClienttType(String clientType, double support)
        {
            List<int[]> itemsets = Transactions_ByClientsType(clientType).SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
            List<List<int>> transactions = Transactions_ByClientsType(clientType).Select(t => t.Items).ToList();
            var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();

            return formatItemSets(frequent);
        }
        public IEnumerable<String> dependencesbyClientType(String clientType, int itemCode, double support)
        {
            try
            {
                List<int[]> itemsets = Transactions_ByClientsType(clientType).SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
                List<List<int>> transactions = Transactions_ByClientsType(clientType).Select(t => t.Items).ToList();
                var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();
                Rules = new Dictionary<int, List<int[]>>();
                AssociatonRule.GenerateAllRules<int>(frequent, Rules);
                var y = Rules[itemCode];
                return formatItemSets(y);
            }
            catch
            {
                return null;
            }

        }
        public List<String> FrequentItemSetsByClient(String clientCode, double Support)
        {
            List<int[]> itemsets = context.Clients[clientCode].Transactions.SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
            List<List<int>> transactions = context.Clients[clientCode].Transactions.Select(t => t.Items).ToList();
            var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, Support).ToList();

            return formatItemSets(frequent);
        }

        public IEnumerable<String> dependencesbyCLientAndItem(String clientCode, int itemCode, double support)
        {
            try
            {
                List<int[]> itemsets = context.Clients[clientCode].Transactions.SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
                List<List<int>> transactions = context.Clients[clientCode].Transactions.Select(t => t.Items).ToList();
                var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();
                Rules = new Dictionary<int, List<int[]>>();
                AssociatonRule.GenerateAllRules<int>(frequent, Rules);
                var y = Rules[itemCode];
                return formatItemSets(y);
            }
            catch
            {
                return null;
            }

        }
        public List<String> FrequentItemSetsByDepartment(String department, double support)
        {
            List<int[]> itemsets = TransactionsByDepartment(department).SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
            List<List<int>> transactions = TransactionsByDepartment(department).Select(t => t.Items).ToList();
            var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();

            return formatItemSets(frequent);
        }
        public IEnumerable<String> dependencesbyDepartment(String department, int itemCode, double support)
        {
            try
            {
                List<int[]> itemsets = TransactionsByDepartment(department).SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
                List<List<int>> transactions = TransactionsByDepartment(department).Select(t => t.Items).ToList();
                var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();
                Rules = new Dictionary<int, List<int[]>>();
                AssociatonRule.GenerateAllRules<int>(frequent, Rules);
                var y = Rules[itemCode];
                return formatItemSets(y);
            }
            catch
            {
                return null;
            }

        }
        public List<String> FrequentItemSetsByMonth(int month, double support)
        {
            List<int[]> itemsets = TransactionsByMonth(month).SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
            List<List<int>> transactions = TransactionsByMonth(month).Select(t => t.Items).ToList();
            var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();

            return formatItemSets(frequent);
        }

        public IEnumerable<String> dependencesbyMonth(int month, int itemCode, double support)
        {
            try
            {
                List<int[]> itemsets = TransactionsByMonth(month).SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
                List<List<int>> transactions = TransactionsByMonth(month).Select(t => t.Items).ToList();
                var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, support).ToList();
                Rules = new Dictionary<int, List<int[]>>();
                AssociatonRule.GenerateAllRules<int>(frequent, Rules);
                var y = Rules[itemCode];
                return formatItemSets(y);
            }
            catch
            {
                return null;
            }

        }


        //**********************************************************************************************
        //************ PRUNNINGS ***********************************************************************
        //**********************************************************************************************
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


        //**********************************************************************************************
        //************ SUPPORTS ************************************************************************
        //**********************************************************************************************
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

        //**********************************************************************************************
        //************ FREQUENT ITEMSETS ***************************************************************
        //**********************************************************************************************
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
            String f = context.path + @"ItemSets\ItemSets_" + threshold + ".xml";
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
        public IEnumerable<String> list_departments()
        {
            return context.Clients.Select(c => c.Value.Departament).Distinct();
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

            String f = context.path + @"Clusters\Cluster_" + Similarity_level + ".xml";

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

        //[0] indice del cluster con mayor cantidad de clientes, [1] cuántos clientes tiene.
        public int[] ClusterWithMostClients()
        {
            int[] pos = new int[2];
            int mayor = 0;
            int posM = 0;
            for (int i = 0; i < clusterResult.Count(); i++)
            {
                if (clusterResult.ElementAt(i).ElementAt(0).Count() > mayor)
                {
                    mayor = clusterResult.ElementAt(i).ElementAt(0).Count();
                    posM = i;
                }
            }
            pos[0] = posM;
            pos[1] = mayor;
            return pos;
        }

        //[0] indice del cluster con menor cantidad de clientes, [1] cuántos clientes tiene.
        public int[] ClusterWithLeastClients()
        {
            int[] pos = new int[2];
            int menor = int.MaxValue;
            int posM = 0;
            for (int i = 0; i < clusterResult.Count(); i++)
            {
                if (clusterResult.ElementAt(i).ElementAt(0).Count() < menor)
                {
                    menor = clusterResult.ElementAt(i).ElementAt(0).Count();
                    posM = i;
                }
            }
            pos[0] = posM;
            pos[1] = menor;
            return pos;
        }

        //Retorna el cliente con mayor cantidad de transacciones de un clúster  y [1] cuántas son.
        public string[] Clustering_ClientWithMostTransactions(List<List<String>> clients)
        {
            string[] pos = new string[2];
            int mayor = 0;
            string client = "";
            for (int i = 0; i < clients.ElementAt(0).Count(); i++)
            {
                if (totalTransactionsClient(clients.ElementAt(0).ElementAt(i)) > mayor)
                {
                    mayor = totalTransactionsClient(clients.ElementAt(0).ElementAt(i));
                    client = clients.ElementAt(0).ElementAt(i);
                }
            }
            pos[0] = client + "";
            pos[1] = mayor + "";

            return pos;
        }

        //Retorna [0] el cliente con menor cantidad de transacciones de un clúster y [1] cuántas son.
        public string[] Clustering_ClientWithLeastTransactions(List<List<String>> clients)
        {
            string[] pos = new string[2];
            int menor = int.MaxValue;
            string client = "";
            for (int i = 0; i < clients.ElementAt(0).Count(); i++)
            {
                if (totalTransactionsClient(clients.ElementAt(0).ElementAt(i)) < menor)
                {
                    menor = totalTransactionsClient(clients.ElementAt(0).ElementAt(i));
                    client = clients.ElementAt(0).ElementAt(i);
                }
            }
            pos[0] = client + "";
            pos[1] = menor + "";

            return pos;
        }

        public string[] Clustering_ClientWithMostSells(List<List<String>> clients)
        {
            string[] pos = new string[2];
            double mayor = 0;
            string client = "";
            for (int i = 0; i < clients.ElementAt(0).Count(); i++)
            {
                if (TotalSellsClient(clients.ElementAt(0).ElementAt(i)) > mayor)
                {
                    mayor = TotalSellsClient(clients.ElementAt(0).ElementAt(i));
                    client = clients.ElementAt(0).ElementAt(i);
                }
            }
            pos[0] = client + "";
            pos[1] = mayor + "";

            return pos;
        }

        public string[] Clustering_ClientWithLeastSells(List<List<String>> clients)
        {
            string[] pos = new string[2];
            double menor = Double.MaxValue;
            string client = "";
            for (int i = 0; i < clients.ElementAt(0).Count(); i++)
            {
                if (TotalSellsClient(clients.ElementAt(0).ElementAt(i)) < menor)
                {
                    menor = TotalSellsClient(clients.ElementAt(0).ElementAt(i));
                    client = clients.ElementAt(0).ElementAt(i);
                }
            }
            pos[0] = client + "";
            pos[1] = menor + "";

            return pos;
        }

        //[0] = codigo del producto con mayor cantidad de transacciones, [1] en cuantas transacciones aparece.
        public string[] Clustering_ProductWithMostTransactions(List<List<String>> products)
        {
            string[] pos = new string[2];
            return pos;
        }

        //[0] = codigo del producto con menor cantidad de transacciones, [1] en cuantas transacciones aparece.
        public string[] Clustering_ProductoWithLeastTransactions(List<List<String>> products)
        {
            string[] pos = new string[2];
            return pos;
        }

        //**********************************************************************************************
        //************ RULES ***************************************************************************
        //**********************************************************************************************

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
                return null;
            }
            return x.Select(n=>n[0]+"").ToList();
        }

        public List<String> getDependence(int[] itemsCode, double threshold)
        {
            GenerateRules(threshold);
            List<int[]> x = new List<int[]>();

            for (int i = 0; i < itemsCode.Length; i++)
            {
                try
                {
                    x.AddRange(Rules[itemsCode[i]]);
                }
                catch
                {
                }
            }

            if (x.Any())
            {
                return formatItemSets(x);
            }
            else
            {
                return new List<string> { "No se pudo generar ninguna oferta con los items seleccionados" };
            }
        }

        //**********************************************************************************************
        //************ FORMATS *************************************************************************
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

        public IEnumerable<String> onlyItems_toKeep_support(IEnumerable<int> original, double support)
        {
            GenerateRules(support);
            List<String> items = new List<string>();

            foreach (int x in original)
            {
                if (Rules.ContainsKey(x))
                {
                    items.Add(x + "");
                }
            }

            return items;

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
        public List<String> ClientsOrderListByType(String type)
        {
            var x = Transactions_ByClientsType(type).GroupBy(t => t.ClientCode).OrderBy(t => t.Count()).Select(t => t.Key).ToList();
            return x;
        }
        //Itesm dado un tipo de cliente 
        public IEnumerable<int> Items_ClientsType(String type)
        {
            var n = Transactions_ByClientsType(type).SelectMany(t => t.Items).GroupBy(t => t).OrderBy(t => t.Count()).Select(t => t.Key);
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

        public IEnumerable<IGrouping<String, Client>> ClientsByDepartment1()
        {
            return context.Clients.Select(n => n.Value).GroupBy(n => n.Departament);
        }

        // Arreglo de clientes dado un departamento
        public IEnumerable<Client> ClientsByDepartment(String department)
        {
            var x = context.Clients.Select(n => n.Value).Where(n => n.Departament.Equals(department)).OrderByDescending(i => i.Transactions.Count());
            return x;
        }

        //[0] departamento con más clientes [1] cuántos clientes.
        public string[] Groups_DepartmentWithMostClients()
        {
            string[] info = new string[2];
            int mayor = 0;

            for (int i = 0; i < list_departments().ToList().Count; i++)
            {
                if (ClientsByDepartment(list_departments().ToList().ElementAt(i)).Count() > mayor)
                {
                    mayor = ClientsByDepartment(list_departments().ToList().ElementAt(i)).Count();
                    info[0] = list_departments().ToList().ElementAt(i);
                }
            }

            info[1] = mayor + "";
            return info;
        }

        //[0] departamento con menos clientes [1] cuántos clientes.
        public string[] Groups_DepartmentWithLeastClients()
        {
            string[] info = new string[2];
            int menor = int.MaxValue;

            for (int i = 0; i < list_departments().ToList().Count; i++)
            {
                if (ClientsByDepartment(list_departments().ToList().ElementAt(i)).Count() < menor)
                {
                    menor = ClientsByDepartment(list_departments().ToList().ElementAt(i)).Count();
                    info[0] = list_departments().ToList().ElementAt(i);
                }
            }

            info[1] = menor + "";
            return info;
        }

        // Arreglo de Transacciones dado un departamento
        public IEnumerable<Transaction> TransactionsByDepartment(String department)
        {
            var x = ClientsByDepartment(department).SelectMany(c => c.Transactions);
            return x;
        }

        //[0] departamento con más transacciones [1] cuántas transacciones
        public string[] Groups_DepartmentWithMostTransactions()
        {
            string[] info = new string[2];
            int mayor = 0;

            for (int i = 0; i < list_departments().ToList().Count; i++)
            {
                if (TransactionsByDepartment(list_departments().ToList().ElementAt(i)).Count() > mayor)
                {
                    mayor = TransactionsByDepartment(list_departments().ToList().ElementAt(i)).Count();
                    info[0] = list_departments().ToList().ElementAt(i);
                }
            }

            info[1] = mayor + "";
            return info;
        }

        //[0] departamento con menos transacciones [1] cuántas transacciones
        public string[] Groups_DepartmentWithLeastTransactions()
        {
            string[] info = new string[2];
            int menor = int.MaxValue;

            for (int i = 0; i < list_departments().ToList().Count; i++)
            {
                if (TransactionsByDepartment(list_departments().ToList().ElementAt(i)).Count() < menor)
                {
                    menor = TransactionsByDepartment(list_departments().ToList().ElementAt(i)).Count();
                    info[0] = list_departments().ToList().ElementAt(i);
                }
            }

            info[1] = menor + "";
            return info;
        }

        // Arreglo de ItemsCodes dado un departamento
        public IEnumerable<int> ItemsByDepartment(String department)
        {
            var x = TransactionsByDepartment(department).SelectMany(t => t.Items).Distinct();
            return x;
        }
        //[0] departamento con mayor cantidad de items [1] cuántos items
        public string[] Groups_DepartmentWithMostItems()
        {
            string[] info = new string[2];
            int mayor = 0;

            for (int i = 0; i < list_departments().ToList().Count; i++)
            {
                if (ItemsByDepartment(list_departments().ToList().ElementAt(i)).Count() > mayor)
                {
                    mayor = ItemsByDepartment(list_departments().ToList().ElementAt(i)).Count();
                    info[0] = list_departments().ToList().ElementAt(i);
                }
            }

            info[1] = mayor + "";
            return info;
        }

        //[0] departamento con menor cantidad de items [1] cuántos items
        public string[] Groups_DepartmentWithLeastItems()
        {
            string[] info = new string[2];
            int menor = int.MaxValue;

            for (int i = 0; i < list_departments().ToList().Count; i++)
            {
                if (ItemsByDepartment(list_departments().ToList().ElementAt(i)).Count() < menor)
                {
                    menor = ItemsByDepartment(list_departments().ToList().ElementAt(i)).Count();
                    info[0] = list_departments().ToList().ElementAt(i);
                }
            }

            info[1] = menor + "";
            return info;
        }

        //retorna un arreglo con [0]=codigo del item y [1]=porcentaje de aparicion del 
        // item en las compras de ese departamento
        public IEnumerable<String[]> FrequentItems_by_Department(String department)
        {

            var y = TransactionsByDepartment(department);
            var x = y.SelectMany(n => n.Items).GroupBy(i => i).Select(n => new String[] { n.Key + "", (n.Count() / (double)y.Count()) + "" });
            return x;
        }

        //[0] cliente con más transacciones de un departamento dado [1] cuántas transacciones.
        public string[] Groups_Department_ClientWithMostTransactions(string department)
        {
            string[] info = new string[2];
            int mayor = 0;

            List<Client> clients = ClientsByDepartment(department).ToList();
            for (int i = 0; i < clients.Count; i++)
            {
                if (totalTransactionsClient(clients.ElementAt(i).Code) > mayor)
                {
                    mayor = totalTransactionsClient(clients.ElementAt(i).Code);
                    info[0] = clients.ElementAt(i).Code;
                }
            }

            return info;
        }

        //[0] cliente con menos transacciones de un departamento dado [1] cuántas transacciones.
        public string[] Groups_Department_ClientWithLeastTransactions(string department)
        {
            string[] info = new string[2];
            int menor = int.MaxValue;

            List<Client> clients = ClientsByDepartment(department).ToList();
            for (int i = 0; i < clients.Count; i++)
            {
                if (totalTransactionsClient(clients.ElementAt(i).Code) < menor)
                {
                    menor = totalTransactionsClient(clients.ElementAt(i).Code);
                    info[0] = clients.ElementAt(i).Code;
                }
            }

            return info;
        }

        //[0] cliente con más dinero en compras de un departamento dado [1] cuánto.
        public string[] Groups_Department_ClientWithMostSells(string department)
        {
            string[] info = new string[2];
            double mayor = 0;

            List<Client> clients = ClientsByDepartment(department).ToList();
            for (int i = 0; i < clients.Count; i++)
            {
                if (TotalSellsClient(clients.ElementAt(i).Code) > mayor)
                {
                    mayor = TotalSellsClient(clients.ElementAt(i).Code);
                    info[0] = clients.ElementAt(i).Code;
                }
            }

            return info;
        }

        //[0] cliente con menos dinero en compras de un departamento dado [1] cuánto.
        public string[] Groups_Department_ClientLeastSells(string department)
        {
            string[] info = new string[2];
            double menor = double.MaxValue;

            List<Client> clients = ClientsByDepartment(department).ToList();
            for (int i = 0; i < clients.Count; i++)
            {
                if (TotalSellsClient(clients.ElementAt(i).Code) < menor)
                {
                    menor = TotalSellsClient(clients.ElementAt(i).Code);
                    info[0] = clients.ElementAt(i).Code;
                }
            }

            return info;
        }


        //************** MONTH CROUP ***********************
        // Arreglo de clientesCode dado un mes
        public IEnumerable<String> ClientsByMonth(int month)
        {
            var x = TransactionsByMonth(month).Select(t => t.ClientCode).Distinct();
            return x;
        }

        //[0] cliente con más transacciones [1] cuantas transacciones.
        public string[] Groups_ClientWithMostTransactions(List<string[]> clients)
        {
            string[] info = new string[2];
            int mayor = 0;

            for (int i = 0; i < clients.Count; i++)
            {
                if (totalTransactionsClient(clients.ElementAt(i)[0]) > mayor)
                {
                    mayor = totalTransactionsClient(clients.ElementAt(i)[0]);
                    info[0] = clients.ElementAt(i)[0];
                }
            }
            info[1] = mayor + "";
            return info;
        }

        //[0] cliente con más transacciones [1] cuantas transacciones.
        public string[] Groups_ClientWithLeastTransactions(List<string[]> clients)
        {
            string[] info = new string[2];
            int menor = int.MaxValue;

            for (int i = 0; i < clients.Count; i++)
            {
                if (totalTransactionsClient(clients.ElementAt(i)[0]) < menor)
                {
                    menor = totalTransactionsClient(clients.ElementAt(i)[0]);
                    info[0] = clients.ElementAt(i)[0];
                }
            }
            info[1] = menor + "";
            return info;
        }


        //[0] mes con más clientes [1] cuantos
        public int[] Groups_MonthWithMostClients()
        {
            int[] info = new int[2];
            int mayor = 0;

            for (int i = 1; i < 7; i++)
            {
                if (ClientsByMonth(i).Count() > mayor)
                {
                    mayor = ClientsByMonth(i).Count();
                    info[0] = i;
                }
            }
            info[1] = mayor;
            return info;
        }

        //[0] mes con menos clientes [1] cuantos
        public int[] Groups_MonthWithLeastClients()
        {
            int[] info = new int[2];
            int menor = int.MaxValue;

            for (int i = 1; i < 7; i++)
            {
                if (ClientsByMonth(i).Count() < menor)
                {
                    menor = ClientsByMonth(i).Count();
                    info[0] = i;
                }
            }
            info[1] = menor;
            return info;
        }

        //[0] mes con mas ventas y [1] cuanto($)
        public string[] Groups_MonthWithMostSells()
        {
            string[] info = new string[2];
            double mayor = 0;

            for (int i = 1; i < 7; i++)
            {
                if (totalSellsListClients2(ClientsByMonth(i).ToList()) > mayor)
                {
                    mayor = totalSellsListClients2(ClientsByMonth(i).ToList());
                    info[0] = i + "";
                }
            }

            info[1] = mayor + "";
            return info;
        }

        //[0] mes con menos ventas y [1] cuanto($)
        public string[] Groups_MonthWithLeastSells()
        {
            string[] info = new string[2];
            double menor = double.MaxValue;

            for (int i = 1; i < 7; i++)
            {
                if (totalSellsListClients2(ClientsByMonth(i).ToList()) < menor)
                {
                    menor = totalSellsListClients2(ClientsByMonth(i).ToList());
                    info[0] = i + "";
                }
            }

            info[1] = menor + "";
            return info;
        }

        // Arreglo de Transacciones dado un mes
        public IEnumerable<Transaction> TransactionsByMonth(int month)
        {
            var x = context.Transactions.Select(n => n.Value).Where(n => n.Date.Month == month);
            return x;
        }

        // [0] mes con más transacciones [1] cuantas transacciones
        public int[] Groups_MonthWithMostTransactions()
        {
            int[] info = new int[2];
            int mayor = 0;

            for (int i = 1; i < 7; i++)
            {

                if (TransactionsByMonth(i).Count() > mayor)
                {
                    mayor = TransactionsByMonth(i).Count();
                    info[0] = i;
                }
            }
            info[1] = mayor;
            return info;
        }

        // [0] mes con menos transacciones [1] cuantas transacciones
        public int[] Groups_MonthWithLeastTransactions()
        {
            int[] info = new int[2];
            int menor = int.MaxValue;

            for (int i = 1; i < 7; i++)
            {

                if (TransactionsByMonth(i).Count() < menor)
                {
                    menor = TransactionsByMonth(i).Count();
                    info[0] = i;
                }
            }
            info[1] = menor;

            return info;
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
            var x = y.SelectMany(n => n.Items).GroupBy(i => i).Select(n => new String[] { n.Key + "", Math.Round((n.Count() / (double)y.Count()) * 100, 2) + "" });
            return x.OrderByDescending(i => Double.Parse(i[1]));
        }

        public IEnumerable<String[]> ItemsByTimePeriod(int month1, int month2)
        {
            var i1 = Frequent_Items_ByMonth(month1);
            var i2 = Frequent_Items_ByMonth(month2);

            var list = i1.Union(i2).Distinct().OrderByDescending(i => Double.Parse(i[1]));

            return list;
        }

        //***********************************************************************************
        //******************* Clients Methods ***********************************************
        //***********************************************************************************

        //Returns the codes of all clients.
        public string[] clientsCodes()
        {
            return context.Clients.Select(n => n.Key).ToArray();
        }

        //Returns the total of transactions of a client.
        public int totalTransactionsClient(string clientCode)
        {
            return context.Clients[clientCode].Transactions.Count();
        }

        public int totalTransactionsItem(int itemCode)
        {
            return context.Items[itemCode].Transactions.Count();
        }

        public int totalTransactionsListClients(List<string[]> clients)
        {
            int total = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                total += int.Parse(clients.ElementAt(i)[1]);
            }

            return total;
        }

        //Arreglar metodo.
        //Devuelve el total en ventas ($) de un cliente.
        public double TotalSellsClient(string clientCode)
        {
            double total = 0;

            if (context.Clients.ContainsKey(clientCode))
            {
                total = context.Clients[clientCode].Transactions.Select(t => t.Total).Sum();
            }
            return total;
        }

        public double TotalSellsItem(int itemCode)
        {
            double total = 0;

            if (context.Items.ContainsKey(itemCode))
            {
                total = context.Items[itemCode].Transactions.Select(t => t.Total).Sum();
            }

            return total;
        }

        //Devuelve el [0] cliente con mayor cantidad de dinero en ventas en ($) y [1] cuanto
        public string[] clientWithMostSells(List<string[]> clients)
        {
            string[] cliente = new string[2];
            double mayor = 0;
            for (int i = 0; i < clients.Count(); i++)
            {
                if (TotalSellsClient(clients.ElementAt(i)[1]) > mayor)
                {
                    mayor = TotalSellsClient(clients.ElementAt(i)[1]);
                    cliente[0] = clients.ElementAt(i)[0];
                }
            }

            cliente[1] = mayor + "";
            return cliente;
        }

        //Devuelve el [0] cliente con mayor cantidad de dinero en ventas en ($) y [1] cuanto
        public string[] clientWithLeastSells(List<string[]> clients)
        {
            string[] cliente = new string[2];
            double menor = double.MaxValue;
            for (int i = 0; i < clients.Count(); i++)
            {
                if (TotalSellsClient(clients.ElementAt(i)[1]) < menor)
                {
                    menor = TotalSellsClient(clients.ElementAt(i)[1]);
                    cliente[0] = clients.ElementAt(i)[0];
                }
            }

            cliente[1] = menor + "";
            return cliente;
        }

        //Devuelve el total en ventas ($) de una lista de clientes.
        public double totalSellsListClients(List<string[]> clients)
        {
            double total = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                total += TotalSellsClient(clients.ElementAt(i)[0]);
            }

            return total;
        }

        public double totalSellsListClients2(List<string> clients)
        {
            double total = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                total += TotalSellsClient(clients.ElementAt(i));
            }

            return total;
        }


        public double totalSellsListClients(List<string> clients)
        {
            double total = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                total += TotalSellsClient(clients.ElementAt(i));
            }

            return total;
        }

        //Lista con arreglo: en [0] = codigo cliente, [1] = total de sus ventas. 
        public List<string[]> totalSells(List<string[]> clients)
        {
            List<string[]> list = new List<string[]>();
            for (int i = 0; i < clients.Count; i++)
            {
                string[] aux = new string[2];
                aux[0] = clients.ElementAt(0)[0];
                aux[1] = TotalSellsClient(clients.ElementAt(i)[0]) + "";
            }

            return list;
        }

        public List<String> itemsbyClient(String clientCode)
        {
            List<String> itemsets = context.Clients[clientCode].Transactions.SelectMany(t => t.Items).Distinct().Select(t => "" + t).ToList();
            return itemsets;
        }

        public List<String> itemSetsFrecuentesByClient(String clientCode, double Support)
        {
            List<int[]> itemsets = context.Clients[clientCode].Transactions.SelectMany(t => t.Items).Distinct().Select(s => new int[] { s }).ToList();
            List<List<int>> transactions = context.Clients[clientCode].Transactions.Select(t => t.Items).ToList();
            var frequent = Apriori.GenerateAllFrecuentItemsets(itemsets, transactions, Support).ToList();

            return formatItemSets(frequent);
        }

        //Metodos sin categoria **** ultimo momento

        public String Type_of_payment(int item)
        {
            var n = context.Items[item].Transactions.GroupBy(t=>context.Clients[ t.ClientCode].Payment).OrderBy(g=>g.Count()).Last().Key;
            return n;
        }


        public IEnumerable<String> Items_without_sales(List<int> purchased)
        {
            List<int> aux = new List<int>();
            List<int> data = new List<int>();

            foreach (int x in purchased)
            {
                var r = Rules[x];
                aux.AddRange(r.SelectMany(n => n));
            }

            aux.Distinct();
            data = aux;
            data.Where(n => !purchased.Contains(n));

            data.Distinct();


            return data.Select(n => n + "");
        }



        static void Main(string[] args)
        {
            Consult c = new Consult();

            Console.WriteLine("Initial clients {0}", c.context.Clients.Count());
            Console.WriteLine("Initial Transactions {0}", c.context.Transactions.Count());
            Console.WriteLine("Initial Items {0}", c.context.Items.Count());

            c.Clustering(0.1);
            Console.WriteLine("-------------");
            c.clusterResult.ForEach(i => Console.WriteLine(i.ElementAt(0).Count()));
            //c.FrequentItemsets_Apriori(0.01);
            //c.GenerateRules(0.05);

            //c.itemSetsFrecuentesByClient("CN0001", 0.5).ForEach(e => Console.WriteLine(e));
            //c.itemsbyClient("CN0012").ForEach(e => Console.WriteLine(e));
            //c.getDependence(23, 0.005).ForEach(e => Console.WriteLine(e));

            //var x = c.Frequent_Items_ByMonth(1).ToList();
            //var x = c.FrequentItems_by_Department("NARIÑO").ToList();
            //var x = c.FrequentItems_by_ClientType("CLINICAS PRIVADAS").ToList();

            //foreach (String[] a in x)
            //{
            //    Console.WriteLine(a[0] + "    " + a[1]);
            //}

            //var x = c.Purchase_prediction_from_Clustering("23",0.95);
            //foreach (String a in x)
            //{
            //    Console.WriteLine(a);
            //}


            //var x = c.Purchase_prediction_from_Clustering("23", 0.7);
            //foreach (String a in x)
            //{
            //    Console.WriteLine(a);
            //}

            //c.GenerateRules(Double.Parse("3") / 100);
            //var x  = c.ItemsByMonth(2).Where(n => c.Rules.ContainsKey(n));
            //var y=  c.Items_without_sales(x.ToList());


            Console.WriteLine("END");
            Console.ReadLine();
        }

    }
}
