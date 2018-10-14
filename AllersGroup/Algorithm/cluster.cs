using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Cluster<T>
    {
        public Dictionary<String,List<T>> Clients;
        public String[] Position;
        public double[,] matrix;

        public Cluster(Dictionary<String, List<T>> dic)
        {
            Clients= dic;
            int size = Clients.Count();
            Position = new String[size];
            matrix = new double[size,size];

            generatePosition();
            generateMatrix();
        }

        private void generatePosition()
        {
            int x = 0;
            foreach (var n in Clients)
            {
                Position[x] = n.Key;
                x++;
            }
        }

        private void generateMatrix()
        {

            for(int i =0; i < Position.Length; i++)
            {
                String aux = "";
                for(int j = 0; j < Position.Length; j++)
                {
                    if (i == j)
                    {
                        matrix[i, i] = 2;
                    }

                    else
                    {
                        double relation = Statistic.Relation_level(Clients[Position[i]], Clients[Position[j]]);
                        matrix [i, i] = relation ;
                        aux += relation+" ";
                    }
                }

                Console.WriteLine(aux);
            }

        }

    }
}
