using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BruteForce
    {
     
        public static IEnumerable<List<T>> Combinations<T>(this IEnumerable<T> elements, int k){
            List<List<T>> result = new List<List<T>>();

            if (k == 0)
            {
                // Single combination: empty set
                result.Add(new List<T>());
            }
            else
            {
                int current = 1;
                foreach (T element in elements)
                {
                    // Combine each element with (k - 1)-combinations of subsequent elements
                    result.AddRange(elements.Skip(current++).Combinations(k-1).Select(combination=>(new List<T> {element}).Concat(combination).ToList()));
                }
            }

            return result;
        }

    }
}
