using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String> Data = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            List<List<String>> x =  Combination.Merge(Data);
            foreach(List<String> d in x)
            {
                String ret = "";
                foreach (String j in d)
                {
                    ret += "    "+j;
                } ;

                Console.WriteLine(ret);
            }
            Console.ReadLine();
        }
    }
}
