using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public  class Combination
    {
        //Receives a list with the elements T and generates a list of the combinations
        public List<List<T>> Merge<T>(List<T> original)
        {
            List<List<T>> input = new List<List<T>>();
            original.ForEach(n => input.Add(new List<T> { n }));
            return Merge(input, original);

        }

        //Recive a itemset whit a Previous combination and combines it with the list of initial elements
        public List<List<T>> Merge<T>(List<List<T>> input, List<T> original)
        {
            List<List<T>> output = new List<List<T>>();

            foreach (List<T> elements in input)
            {
                foreach (T data in original)
                {
                   
                    if (!elements.Contains(data))
                    {
                        List<T> temp = new List<T>();
                        temp.AddRange(elements);
                        temp.Add(data);
                        temp.OrderBy(n => n);

                        output.Add(temp);
                        
                    }
                }
            }
            return output;
        }


        public  List<T> BruteForce<T>()
        {
            return null;
        }

    }
}
