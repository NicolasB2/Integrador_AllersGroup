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

        public Context()
        {

            DateTime tiempo1 = DateTime.Now;

            Items = new List<Item>();
            Clients = new List<Client>();
            Transactions = new List<Transaction>();
            LoadItems();
            LoadClients();
            LoadTransactions();

            agruparProductos();

            DateTime tiempo2 = DateTime.Now;
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            Console.Write("TIEMPO: " + total.ToString());

            Console.ReadLine();
        }


        public void generarCombinacionesClientes()
        {
            for(int i = 0; i < Clients.Count; i++) {
                Client c = Clients.ElementAt(i);
                List<string> itemsRelacionados = new List<string>();
                string code = c.Code;
                for(int j = 0; j < Transactions.Count; j++)
                {
                    if (Transactions.ElementAt(j).ClientCode.Equals(code))
                    {
                        itemsRelacionados.Add(Transactions.ElementAt(j).ItemCode+"");
                    }
                }
                c.ItemsRelacionados = itemsRelacionados;

            }
            
            List<List<Client>> combinaciones = new List<List<Client>>();

            for(int i = 0; i < Clients.Count; i++)
            {
                Client actual = Clients.ElementAt(i);
                List<Client> combinacionActual = new List<Client>();
                combinacionActual.Add(actual);

                for(int j = 0; j < Clients.Count; j++)
                {
                    if(i!=j && actual.ItemsRelacionados.Equals(Clients.ElementAt(j).ItemsRelacionados))
                    {
                        combinacionActual.Add(Clients.ElementAt(j));
                    }
                }

                combinaciones.Add(combinacionActual);
            }

            //for(int i = 0; i < combinaciones.Count; i++)
            //{
            //    List<Client> actual = combinaciones.ElementAt(i);
            //    Console.WriteLine("Cliente relacionados con: {0}",actual.First().Code);
            //    for(int j = 0; j < actual.Count; j++)
            //    {
            //        Console.WriteLine(actual.ElementAt(j).Code);
            //    }

            //    Console.WriteLine("---------------------------------------------");
            //}

        }



        public void agruparProductos()
        {
            List<List<Item>> prodAgrupados = new List<List<Item>>();

            List<string> clasificacionesAgrupadas = new List<string>();

            for(int i = 0; i < Items.Count; i++)
            {
                if(!Items.ElementAt(i).Clasification.Equals("NULL") && !clasificacionesAgrupadas.Contains(Items.ElementAt(i).Clasification))
                {
                    clasificacionesAgrupadas.Add(Items.ElementAt(i).Clasification);
                    List<Item> lista = new List<Item>();

                    for(int j = i; j < Items.Count; j++)
                    {
                        if (Items.ElementAt(j).Clasification.Equals(Items.ElementAt(i).Clasification))
                        {
                            lista.Add(Items.ElementAt(j));
                        }
                    }

                    prodAgrupados.Add(lista);
                }
                
            }


            for(int i = 0; i < prodAgrupados.Count; i++)
            {
                Console.WriteLine("-------------------------------------");
                for(int j = 0; j < prodAgrupados.ElementAt(i).Count; j++)
                {
                    Console.WriteLine(prodAgrupados.ElementAt(i).ElementAt(j).Name);
                }
            }

        }

        

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
            Console.WriteLine("Numero de items: "+Items.Count + "");
            //Console.ReadLine();
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
            Console.WriteLine("Numero de clientes: "+Clients.Count + "");
            //Console.ReadLine();
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
                Console.WriteLine("Exception: " + e.Message + "     " + c);
            }
            Console.WriteLine("Numero de transacciones: "+Transactions.Count + "");
            //Console.ReadLine();
        }

    }

}
