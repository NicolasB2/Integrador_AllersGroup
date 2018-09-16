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

            agruparClientesPorRegion();
            agruparProductos();


            

            DateTime tiempo2 = DateTime.Now;
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            Console.Write("TIEMPO: " + total.ToString());

            Console.ReadLine();
        }


        



        public List<List<Item>> agruparProductos()
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


            //for(int i = 0; i < prodAgrupados.Count; i++)
            //{
            //    Console.WriteLine("-------------------------------------");
            //    for(int j = 0; j < prodAgrupados.ElementAt(i).Count; j++)
            //    {
            //        Console.WriteLine(prodAgrupados.ElementAt(i).ElementAt(j).Name);
            //    }
            //}


            return prodAgrupados;
        }


        public List<List<Client>> agruparClientesPorRegion()
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
            
            

            //for (int i = 0; i < agrupacion.Count; i++)
            //{
            //    Console.WriteLine("-------------------------------------");
            //    for (int j = 0; j < agrupacion.ElementAt(i).Count; j++)
            //    {
            //        Console.WriteLine(agrupacion.ElementAt(i).ElementAt(j).Name);
            //    }
            //}


            return agrupacion;

        }



        //public List<List<Client>> agrupacionClientes()
        //{
        //    List<List<Client>> agrupacionFinal = new List<List<Client>>();
        //    List<List<Client>> agrupacionRegion = agruparClientesPorRegion();
        //    List<List<Item>> agrupacionItems = agruparProductos();


        //    for(int i = 0; i < agrupacionRegion.Count; i++)
        //    {

        //        //Empieza a analizar los clientes que ya estan agrupados por region


        //        List<Client> agrupacionActual = agrupacionRegion.ElementAt(i);

                

        //        for(int j = 0; j < agrupacionActual.Count; j++)
        //        {
        //            Client clienteActual = agrupacionActual.ElementAt(j);
        //            List<Client> nuevaAgrupacion = new List<Client>();
        //            //nuevaAgrupacion.Add(clienteActual);

        //            for (int h = 0; h < agrupacionActual.Count; h++)
        //            {

        //                //Compara un cliente con todos los otros de la misma region

        //                Client clienteAComparar = agrupacionActual.ElementAt(h);

        //                Boolean cond = false;

        //                for(int y = 0;!cond && y < agrupacionItems.Count; y++)
        //                {

        //                    Boolean contieneActual = false;
        //                    Boolean contieneAComparar = false;

        //                    for (int x = 0; !cond && x < agrupacionItems.ElementAt(y).Count; x++)
        //                    {
        //                        if (clienteActual.ItemsRelacionados.Contains(agrupacionItems.ElementAt(y).ElementAt(x))){
        //                            contieneActual = true;
        //                        }

        //                        if (clienteAComparar.ItemsRelacionados.Contains(agrupacionItems.ElementAt(y).ElementAt(x))){
        //                            contieneAComparar = true;
        //                        }

        //                        if(contieneAComparar && contieneActual)
        //                        {
        //                            cond = true;
        //                        }

        //                        Console.WriteLine(clienteActual.ItemsRelacionados.Count+" "+ clienteAComparar.ItemsRelacionados.Count);
        //                    }
        //                }

        //                if (cond)
        //                {
        //                    nuevaAgrupacion.Add(clienteAComparar);
        //                }
        //            }
        //            Console.WriteLine(nuevaAgrupacion.Count);
        //            agrupacionFinal.Add(nuevaAgrupacion);

                    
        //        }

        //        Console.WriteLine("Terminaron las agrupaciones de la región {0}", agrupacionRegion.ElementAt(i).ElementAt(0).Departament);

        //    }
            

        //    return agrupacionFinal;
        //}
        

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

                        //try
                        //{
                        //    Boolean cond = Clients.Where(cl => cl.Code.Equals(t.ClientCode)).First().ItemsRelacionados.Contains(t.Item);
                        //    if (!cond)
                        //    {
                        //        Clients.Where(cl => cl.Code.Equals(t.ClientCode)).First().ItemsRelacionados.Add(t.Item);
                        //    }
                        //}
                        //catch
                        //{

                        //}
                        

                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.StackTrace + "     " + c);
            }
            Console.WriteLine("Numero de transacciones: "+Transactions.Count + "");
            //Console.ReadLine();
        }

    }

}
