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
            generatePosition();
            GenerateMatrix();
        }

        private void generatePosition()
        {

            int size = Clients.Count();
            Position = new String[size];
            int x = 0;

            foreach (var n in Clients)
            {
                Position[x] = n.Key;
                x++;
            }
        }

        private void GenerateMatrix()
        {
            int size = Clients.Count();
            matrix = new double[size, size];

            for (int i =0; i < size; i++)
            {
                //String aux = "";
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        matrix[i, i] = -1;
                    }

                    else
                    {
                        double relation = Statistic.Relation_level(Clients[Position[i]], Clients[Position[j]]);
                        matrix [i, j] = relation ;
                        //aux += relation + " ";
                    }
                }
                //Console.WriteLine(aux);
            }
        }

        public Boolean Merge()
        {
            
            bool success = false;
            double max = 0.5;
            string one = "";
            string two = "";

            for (int i = 0; i < Position.Length; i++)
            {
                for (int j = 0; j < Position.Length; j++)
                {
                    
                    if (matrix[i, j] > max && matrix[i, j]<1.0)
                    {
                        max = matrix[i, j];
                        one = Position[i];
                        two = Position[j];

                        //if (max == 1.0)
                        //{
                        //    i = Position.Length;
                        //    j = Position.Length;
                        //}
                    }
                }
                
            }

            
            if (max>0.5)
            {
                
                Clients[one].AddRange(Clients[two]);
                List<T> aux = Clients[one].Distinct().ToList();
                Clients.Remove(one);
                Clients.Remove(two);


                String n = one + "," + two;
                Clients.Add(n, aux);
                success = true;

                Console.WriteLine(one);
                Console.WriteLine(two);
                Console.WriteLine((double)max);
                Console.WriteLine(Clients.Count());
                Console.WriteLine();
            }

            return success;
        }

        public void Clustering()
        {
            bool aux = true;

            while (aux)
            {
                aux = Merge();
                generatePosition();
                GenerateMatrix();
            }  
        }
    }
}
