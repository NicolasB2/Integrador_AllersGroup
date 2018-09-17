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
        public List<Client> Clients { get; set; }
        public List<Item> Items { get; set; }
        public List<Transaction> Transactions { get; set; }


        //Constructor
        public Context()
        {

            DateTime tiempo1 = DateTime.Now;

            Items = new List<Item>();
            Clients = new List<Client>();
            Transactions = new List<Transaction>();
            LoadItems();
            LoadClients();
            LoadTransactions();

            Console.ReadLine();
        }


        //Loads
        private void LoadItems()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\manuel\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\Items.csv");

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
        }

        private void LoadClients()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\manuel\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\Clients.csv");

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
        }

        private void LoadTransactions()
        {
            int c = 0;
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\manuel\source\repos\AllersGroup_IntegradorI\AllersGroup\Model\Data\Transactions.csv");

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

                Console.WriteLine("Exception: " + e.StackTrace + "     " + c);
            }
        }


        //consults
        public List<List<Item>> Group_Products()
        {
            List<List<Item>> prodAgrupados = new List<List<Item>>();

            List<string> clasificacionesAgrupadas = new List<string>();

            for (int i = 0; i < Items.Count; i++)
            {
                if (!Items.ElementAt(i).Clasification.Equals("NULL") && !clasificacionesAgrupadas.Contains(Items.ElementAt(i).Clasification))
                {
                    clasificacionesAgrupadas.Add(Items.ElementAt(i).Clasification);
                    List<Item> lista = new List<Item>();

                    for (int j = i; j < Items.Count; j++)
                    {
                        if (Items.ElementAt(j).Clasification.Equals(Items.ElementAt(i).Clasification))
                        {
                            lista.Add(Items.ElementAt(j));
                        }
                    }

                    prodAgrupados.Add(lista);
                }

            }
            return prodAgrupados;
        }

        public List<List<Client>> Group_clients_by_Deparment()
        {
            List<List<Client>> agrupacion = new List<List<Client>>();


            List<string> regionesAgrupadas = new List<string>();

            for (int i = 0; i < Clients.Count; i++)
            {
                if (!regionesAgrupadas.Contains(Clients.ElementAt(i).Departament))
                {
                    regionesAgrupadas.Add(Clients.ElementAt(i).Departament);
                    List<Client> lista = new List<Client>();

                    for (int j = i; j < Clients.Count; j++)
                    {
                        if (Clients.ElementAt(j).Departament.Equals(Clients.ElementAt(i).Departament))
                        {
                            lista.Add(Clients.ElementAt(j));
                        }
                    }

                    agrupacion.Add(lista);
                }

            }
            return agrupacion;
        }

    }

}
