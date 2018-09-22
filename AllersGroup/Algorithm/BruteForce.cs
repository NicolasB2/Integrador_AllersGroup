using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BruteForce
    {

        public static IEnumerable<T[]> Combinations<T>(this IList<T> argList, int argSetSize)
        {
            if (argList == null) throw new ArgumentNullException("argList");
            if (argSetSize <= 0) throw new ArgumentException("argSetSize Must be greater than 0", "argSetSize");
            return combinationsImpl(argList, 0, argSetSize - 1);
        }

        private static IEnumerable<T[]> combinationsImpl<T>(IList<T> argList, int argStart, int argIteration, List<int> argIndicies = null)
        {
            argIndicies = argIndicies ?? new List<int>();
            for (int i = argStart; i < argList.Count; i++)
            {
                argIndicies.Add(i);
                if (argIteration > 0)
                {
                    foreach (var array in combinationsImpl(argList, i + 1, argIteration - 1, argIndicies))
                    {
                        yield return array;
                    }
                }
                else
                {
                    var array = new T[argIndicies.Count];
                    for (int j = 0; j < argIndicies.Count; j++)
                    {
                        array[j] = argList[argIndicies[j]];
                    }

                    yield return array;
                }
                argIndicies.RemoveAt(argIndicies.Count - 1);
            }
        }
    }
}