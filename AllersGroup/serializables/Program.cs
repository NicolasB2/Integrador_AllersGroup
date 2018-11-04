using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serializables
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int[]> myList = new List<int[]>();
            myList.Add(new int[] { 12 });
            myList.Add(new int[] {56 });
            myList.Add(new int[] {2 });
            myList.Add(new int[] { 6});
            myList.Add(new int[] { 72});
            String path = @"C:\Users\Nicolas\Source\Repos\saradrada\AllersGroup_IntegradorI\AllersGroup\Model\Data\prueba.xml";
            SerializableItemSets.SerializeObject(myList, path);



            //List<String> test = new List<string>();
            //SerializableItemSets.Deserialize(test, path);

            //foreach (String x in test)
            //{
            //    Console.WriteLine(x);
            //}

            Console.WriteLine("fin");
            Console.ReadLine();
        }
    }
}
