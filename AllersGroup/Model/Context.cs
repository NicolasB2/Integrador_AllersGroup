using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;

namespace Model
{
    public class Context
    {
        public String path = @"C:\Users\Sara\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\";
        public String[] pathNames = { "PrunnedClients.txt", "PrunnedTransactions.txt", "PrunnedItems.txt" };

        public Dictionary<String, Client> Clients { get; set; }
        public Dictionary<int, Item> Items { get; set; }
        public Dictionary<int, Transaction> Transactions { get; set; }
        public List<Item[]> FrecuentItemsets { get; set; }

        /**
         * Creates a Context.
         **/
        public Context()
        {

            FrecuentItemsets = new List<Item[]>();

            //Items = new Dictionary<int, Item>();
            Clients = new Dictionary<String, Client>();
            Transactions = new Dictionary<int, Transaction>();

            //LoadItems();
            LoadClients();
            LoadTransactions();
        }


        /**
         * Load the items.
         * If the item has it's clasifications as 'NULL' then it's given the '0' clasification. 
         **/
        private void LoadItems()
        {
            if (File.Exists(path + pathNames[2]))
            {
                try
                {
                    StreamReader sr = new StreamReader(path + pathNames[2]);

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] datos = line.Split(';');
                        Item i = new Item(datos);
                        Items.Add(i.Code, i);
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }


            }
            else
            {


                try
                {
                    StreamReader sr = new StreamReader(path + "Items.csv");

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] datos = line.Split(';');
                        if (datos[2].Equals("NULL"))
                        {
                            datos[2] = "0";
                        }
                        Item i = new Item(datos);
                        Items.Add(i.Code, i);
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

            }
        }

        /**
         * Load the clients.
         * If the city equals to 'NULL' then is asigned the value of 'No indica ciudad' 
         * If the department equals to 'NULL' then is asigned the value 'No indica departamento'
         **/
        private void LoadClients()
        {


            if (File.Exists(path + pathNames[0]))
            {

                try
                {
                    StreamReader sr = new StreamReader(path + pathNames[0]);

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] datos = line.Split(';');

                        Client c = new Client(datos);
                        Clients.Add(c.Code, c);

                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

            }
            else
            {

                try
                {
                    StreamReader sr = new StreamReader(path + "Clients.csv");

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] datos = line.Split(';');

                        if (datos[2].Equals("NULL"))
                        {
                            datos[2] = "No indica ciudad";
                        }
                        else if (datos[3].Equals("NULL"))
                        {
                            datos[3] = "No indica departamento";
                        }

                        if (!Clients.ContainsKey(datos[0]))
                        {
                            Client c = new Client(datos);
                            Clients.Add(c.Code, c);
                        }
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        /**
         * Load the Transactions 
         **/
        private void LoadTransactions()
        {

            if (File.Exists(path + pathNames[1]))
            {

                try
                {
                    StreamReader sr = new StreamReader(path + pathNames[1]);

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] datos = line.Split(';');
                        if (!Transactions.ContainsKey(int.Parse(datos[1])))
                        {
                            if (Items.ContainsKey(Int32.Parse(datos[4])) && Clients.ContainsKey(datos[0]))
                            {
                                Transaction t = new Transaction(datos);

                                //t.AddItem(Items[Int32.Parse(datos[4])]);


                                t.AddItem(Int32.Parse(datos[4]));

                                Transactions.Add(t.Code, t);
                                Clients[datos[0]].AddTransaction(t);
                            }
                        }
                        else
                        {
                            if (Items.ContainsKey(Int32.Parse(datos[4])))
                            {
                                Transactions[int.Parse(datos[1])].AddAsset(datos[4], datos[5], datos[6], datos[7]);
                            }
                        }
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {


                try
                {
                    StreamReader sr = new StreamReader(path + "Transactions.csv");

                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] datos = line.Split(';');

                        if (!datos[4].Equals("NULL"))
                        {
                            if (!Transactions.ContainsKey(int.Parse(datos[1])))
                            {
                                if (Items.ContainsKey(Int32.Parse(datos[4])) && Clients.ContainsKey(datos[0]))
                                {
                                    Transaction t = new Transaction(datos);
                                    t.AddItem(Int32.Parse(datos[4]));
                                    Transactions.Add(t.Code, t);
                                    Clients[datos[0]].AddTransaction(t);
                                }
                            }
                            else
                            {
                                if (Items.ContainsKey(Int32.Parse(datos[4])))
                                {
                                    Transactions[int.Parse(datos[1])].AddAsset(datos[4], datos[5], datos[6], datos[7]);
                                    Transactions[int.Parse(datos[1])].AddItem(Int32.Parse(datos[4]));
                                }
                            }

                            Transactions[int.Parse(datos[1])].AddItem(Int32.Parse(datos[4]));
                        }

                    }
                    sr.Close();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void createTxt()
        {
            try
            {

                File.Create(path + pathNames[0]).Dispose();
                File.Create(path + pathNames[1]).Dispose();
                File.Create(path + pathNames[2]).Dispose();


                using (TextWriter tw = new StreamWriter(path + pathNames[0]))
                {
                    Clients.Select(c => c.Value).ToList().ForEach(n => tw.WriteLine(n.ToString()));
                }

                using (TextWriter tw = new StreamWriter(path + pathNames[2]))
                {
                    Items.Select(c => c.Value).ToList().ForEach(n => tw.WriteLine(n.ToString()));
                }

                using (TextWriter tw = new StreamWriter(path + pathNames[1]))
                {
                    Transactions.Select(c => c.Value).ToList().ForEach(n => tw.WriteLine(n.ToString()));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}

