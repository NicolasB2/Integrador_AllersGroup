using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            //List<String>  input2 = new List<String>() { "Bread", "Milk", "Eggs", };
            //List<String[]> n =  Apriori.GenerateSubsets(input2);

            

            Dictionary<String, List<String>> Clients = new Dictionary<string, List<string>>();
            //Left = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Coke" };
            Clients.Add("A0", new List<string> { "Beer", "Milk", "Diapers", "Bread", "Coke" });
            Clients.Add("A1", new List<string> { "Beer", "Milk", "Candies", "Soap", "Coke" });
            Clients.Add("A2", new List<string> { "Beer", "Milk", "Diapers", "Soap", "Eggs" });
            Clients.Add("A3", new List<string> { "Candies", "Milk", "toothbrush", "Bread", "Coke" });
            Clients.Add("A4", new List<string> { "Beer", "Milk", "Diapers", "Bread", "Coke" });

            Cluster<String> Clus = new Cluster<String>(Clients);
            Clus.Clustering(0.7);
            Console.ReadLine();
        }
    }
}
