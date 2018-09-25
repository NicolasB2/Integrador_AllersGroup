using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Context
    {
        //public List<Client> Clients { get; set; }
        //public List<Item> Items { get; set; }
        //public List<Transaction> Transactions { get; set; }

        public Dictionary<String, Client> Clients { get; set; }
        public Dictionary<int,Item> Items { get; set; }
        public Dictionary<int, Transaction> Transactions { get; set; }
        public Dictionary<int, List<Item[]>> Combinations { get; set; }

        //Constructor
        public Context()
        {

            DateTime tiempo1 = DateTime.Now;

            Items = new Dictionary<int, Item>();
            Clients = new Dictionary<String, Client>() ;
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
                StreamReader sr = new StreamReader(@"C:\Users\Nicolas\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\Items.csv");

                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] datos = line.Split(';');
                    if (datos[2].Equals("NULL"))
                    {
                        datos[2] = "0";
                    }
                    Item i = new Item(datos);
                    Items.Add(i.Code,i);
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
                StreamReader sr = new StreamReader(@"C:\Users\Nicolas\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\Clients.csv");

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
                StreamReader sr = new StreamReader(@"C:\Users\Nicolas\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\Transactions.csv");

                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] datos = line.Split(';');

                    if (!datos[4].Equals("NULL"))
                    {
                        //if (Clients.FirstOrDefault(c => c.Code.Equals(datos[0])) != null && Items.FirstOrDefault(i => i.Code.Equals(datos[4])) != null)
                        //{
                        if (!Transactions.ContainsKey(int.Parse(datos[1])))
                        {
                            if (Items.ContainsKey(Int32.Parse(datos[4])))
                            {
                                Transaction t = new Transaction(datos, Items[Int32.Parse(datos[4])]);
                                Transactions.Add(t.Code, t);
                            }
                            
                        }
                        else
                        {
                            if (Items.ContainsKey(Int32.Parse(datos[4])))
                                Transactions[int.Parse(datos[1])].AddSold(datos[4], datos[5], datos[6], datos[7],Items[Int32.Parse(datos[4])]);
                        }
                            
                            //Clients.Find(c => c.Code.Equals(t.ClientCode)).Transactions.Add(t);
                            //Items.Find(i => i.Code.Equals(t.ItemCode)).Transactions.Add(t);
                        //}
                    }

                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        //Consults

        public void TrimClients()
        {
            foreach (var c in Clients)
            {
                if (Transactions.Count(t => t.Value.ClientCode == c.Key) <= 6)
                {
                    Clients.Remove(c.Key);
                    foreach (var t in Transactions)
                    {
                        if (t.Value.ClientCode == c.Key)
                            Transactions.Remove(t.Key);
                    }
                }                   
            }
        }

        static void Main(string[] args)
        {
            Context ctx = new Context();
            Console.WriteLine("clients {0}", ctx.Clients.Count());
            Console.WriteLine("Items {0}", ctx.Items.Count());
            Console.WriteLine("Transactions {0}", ctx.Transactions.Count());

            Console.WriteLine("yes");
            Console.ReadLine();
        }
    }
}