using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;

namespace Model
{
    public class Context
    {
       
        public String path = @"C:\Users\Nicolas\Source\Repos\saradrada\AllersGroup_IntegradorI\AllersGroup\Model\Data\";
        public String[] pathNames = { "PrunnedItems.txt", "PrunnedClients.txt", "PrunnedTransactions.txt"  };
        public String[] Departments = { "Amazonas", "Antioquia","Arauca", "Atlántico", "Bolívar" , "Boyacá" ,
            "Caldas", "Caquetá", "Casanare", "Cauca", "Cesar", "Chocó", "Córdoba", "Cundinamarca",
            "Guainía", "Guaviare", "Huila", "La Guajira", "Magdalena", "Meta", "Nariño", "Norte de Santander",
            "Putumayo","Quindío", "Risaralda", "San Andrés y Providencia", "Santander", "Sucre", "Tolima",
            "Valle del Cauca", "Vaupés", "Vichada"};
        public Dictionary<String, double[]> Locations; 


        public Dictionary<String, Client> Clients { get; set; }
        public Dictionary<int, Item> Items { get; set; }
        public Dictionary<int, Transaction> Transactions { get; set; }
        public List<Item[]> FrecuentItemsets { get; set; }

        /**
         * Creates a Context.
         **/
        public Context()
        {
            Locations = new Dictionary<string, double[]>();

            Locations.Add("VALLE DEL CAUCA", new double[] { -77.7504494, 4.0376296 });
            Locations.Add("NARIÑO", new double[] { -79.0437364, 1.5289959 });
            Locations.Add("ANTIOQUIA", new double[] { -77.7484384, 7.1508907 });
            Locations.Add("QUINDIO", new double[] { -75.9198936, 4.3983318 });
            Locations.Add("RISARALDA", new double[] { -76.3731545, 5.0981112 });
            Locations.Add("CAUCA", new double[] { -78.1050057, 2.1471982 });
            Locations.Add("CUNDINAMARCA", new double[] { -75.0922165, 4.7843227 });
            Locations.Add("META", new double[] { -74.1167019, 3.2692921 });
            Locations.Add("BOGOTA", new double[] { -74.2478958, 4.6486259 });
            Locations.Add("BOLIVAR", new double[] { -77.0181585, 8.9001022 });
            Locations.Add("CALDAS", new double[] { -75.8344415, 5.2909803 });

            FrecuentItemsets = new List<Item[]>();

            Items = new Dictionary<int, Item>();
            Clients = new Dictionary<String, Client>();
            Transactions = new Dictionary<int, Transaction>();

            LoadItems();
            LoadClients();
            LoadTransactions();
        }

        //
        /**
         * Load the items.
         * If the item has it's clasifications as 'NULL' then it's given the '0' clasification. 
         **/
        private void LoadItems()
        {
            try
            {
                StreamReader sr = null;

                if (File.Exists(path + pathNames[0]))
                {
                    sr = new StreamReader(path + pathNames[0]);
                }
                else
                {
                   sr = new StreamReader(path + "Items.csv");
                }
                    
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

        /**
         * Load the clients.
         * If the city equals to 'NULL' then is asigned the value of 'No indica ciudad' 
         * If the department equals to 'NULL' then is asigned the value 'No indica departamento'
         **/
        private void LoadClients()
        {
            try
            {
                StreamReader sr = null;

                if (File.Exists(path + pathNames[1]))
                {
                    sr = new StreamReader(path + pathNames[1]);
                }
                else
                {
                    sr = new StreamReader(path + "Clients.csv");
                }
                    

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

        /**
         * Load the Transactions 
         **/
        private void LoadTransactions()
        {
            try
            {

                StreamReader sr = null;

                if (File.Exists(path + pathNames[2]))
                {
                    sr = new StreamReader(path + pathNames[2]);
                }
                else
                {
                    sr = new StreamReader(path + "Transactions.csv");
                }

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
                                Items[Int32.Parse(datos[4])].AddTransaction(t);
                            }
                        }
                        else
                        {
                            if (Items.ContainsKey(Int32.Parse(datos[4])))
                            {
                                Transactions[int.Parse(datos[1])].AddAsset(datos[4], datos[5], datos[6], datos[7]);
                                Transactions[int.Parse(datos[1])].AddItem(Int32.Parse(datos[4]));
                                Items[Int32.Parse(datos[4])].AddTransaction(Transactions[int.Parse(datos[1])]);
                            }
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

        public void SavePrunns()
        {
            try
            {

                File.Create(path + pathNames[0]).Dispose();
                File.Create(path + pathNames[1]).Dispose();
                File.Create(path + pathNames[2]).Dispose();

                using (TextWriter tw = new StreamWriter(path + pathNames[0]))
                {
                    Items.Select(c => c.Value).ToList().ForEach(n => tw.WriteLine(n.ToString()));
                }

                using (TextWriter tw = new StreamWriter(path + pathNames[1]))
                {
                    Clients.Select(c => c.Value).ToList().ForEach(n => tw.WriteLine(n.ToString()));
                }

                using (TextWriter tw = new StreamWriter(path + pathNames[2]))
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

