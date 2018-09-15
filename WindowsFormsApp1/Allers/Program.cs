using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Allers
{
    class Program
    {

        public static List<Item> items;
        public static List<Transaction> transactions;
        public static List<Client> clients;

        public static void LoadItems()
        {
            items = new List<Item>();
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Sara\Source\Repos\AllersGroup_IntegradorI\WindowsFormsApp1\Allers\Data\Items.csv");

                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] datos = line.Split(';');
                    if (!(datos[0].Equals("NULL")|| datos[1].Equals("NULL")|| datos[2].Equals("NULL")))
                    {
                        Item i = new Item(datos);
                        items.Add(i);
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

        public static void LoadTransactions()
        {
            transactions = new List<Transaction>();
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
                        transactions.Add(t);
                        
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + "     "+c);
            }
            //Console.WriteLine(transactions.Count +"");
            //Console.ReadLine();
        }

        public static void LoadClients()
        {
            clients = new List<Client>();
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
                        clients.Add(c);
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine(clients.Count +"");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            LoadItems();
            LoadTransactions();
            LoadClients();
        }
    }
}
