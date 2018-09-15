using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Context
    {
        public List<Client> Clients { get; set; }
        public List<Item> Items { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Context()
        {
            Items = new List<Item>();
            Clients = new List<Client>();
            Transactions = new List<Transaction>();
            LoadItems();
            LoadClients();
            LoadTransactions();
        }
        private void LoadItems()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Sara\Source\Repos\AllersGroup_IntegradorI\WindowsFormsApp1\Allers\Data\Items.csv");

                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] datos = line.Split(';');
                    if (!(datos[0].Equals("NULL") || datos[1].Equals("NULL") || datos[2].Equals("NULL")))
                    {
                        Item i = new Item(datos);
                        Items.Add(i);
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //Console.WriteLine(items.Count +"");
            //Console.ReadLine();
        }

        private void LoadClients()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Sara\Source\Repos\AllersGroup_IntegradorI\WindowsFormsApp1\Allers\Data\Clients.csv");

                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] datos = line.Split(';');
                    if (!(datos[0].Equals("NULL") || datos[1].Equals("NULL") || datos[2].Equals("NULL") || datos[3].Equals("NULL") || datos[4].Equals("NULL")))
                    {
                        Client c = new Client(datos);
                        Clients.Add(c);
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine(Clients.Count + "");
            Console.ReadLine();
        }

        private void LoadTransactions()
        {
            int c = 0;
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Sara\Source\Repos\AllersGroup_IntegradorI\WindowsFormsApp1\Allers\Data\Transactions.csv");

                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    c++;
                    String[] datos = line.Split(';');
                    if (!(datos[4].Equals("NULL")))
                    {
                        Transaction t = new Transaction(datos);
                        Transactions.Add(t);

                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + "     " + c);
            }
            //Console.WriteLine(transactions.Count +"");
            //Console.ReadLine();
        }

    }

}
