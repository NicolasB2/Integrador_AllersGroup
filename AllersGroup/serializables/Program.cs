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
            
            //SerializableItemSets.SerializeObject(myList, );


            Console.WriteLine("fin");
            Console.ReadLine();
        }
    }
}
