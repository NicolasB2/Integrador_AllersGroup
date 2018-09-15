using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Allers
{
    class Program
    {

        public static List<Item> items; 

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

        static void Main(string[] args)
        {
            LoadItems();
        }
    }
}
