using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;



namespace Model
{
    public class Context
    {

        public static String dataBase = @"C:\Users\Nicolas\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\";

        public String path;
        public Dictionary<String, Client> Clients { get; set; }
        public Dictionary<int, Item> Items { get; set; }
        public Dictionary<int, Transaction> Transactions { get; set; }

        public Dictionary<int, List<Item[]>> Combinations { get; set; }


        //Constructor
        public Context()
        {
            Combinations = new Dictionary<int, List<Item[]>>();


            this.path = dataBase;
            DateTime tiempo1 = DateTime.Now;

            Items = new Dictionary<int, Item>();
            Clients = new Dictionary<String, Client>();
            Transactions = new Dictionary<int, Transaction>();

            LoadItems();
            LoadClients();
            LoadTransactions();
        }


        //Loads
        private void LoadItems()
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


        private void LoadClients()
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
                        datos[2] = "No indica departamento";
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

        private void LoadTransactions()
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
                                Transaction t = new Transaction(datos, Items[Int32.Parse(datos[4])]);
                                Transactions.Add(t.Code, t);
                                Items[Int32.Parse(datos[4])].AddTransaction(t);
                                Clients[datos[0]].AddTransaction(t);
                            }

                        }
                        else
                        {
                            if (Items.ContainsKey(Int32.Parse(datos[4])))
                                Transactions[int.Parse(datos[1])].AddAsset(datos[4], datos[5], datos[6], datos[7], Items[Int32.Parse(datos[4])]);
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




    }
}