using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    static class Combination
    {
        public static void Merge<T>(List<T> input, List<T> original)
        {
            input.Select(n => new List<T> { n });
            Merge(input, original);

        }

        public static void Merge<T>(List<List<T>> input, List<T> original)
        {
            foreach (List<T> elements in input)
            {
                foreach (T data in original)
                {
                    if (!elements.Contains(data))
                    {
                        elements.Add(data);
                    }
                }
            }
        }

    }
}
