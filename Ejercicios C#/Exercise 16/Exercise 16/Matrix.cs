using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_16
{
    public class Matrix
    {
        public static int[,] addition(int[,] elem1, int[,] elem2)
        {
            int[,] result = null;

            bool sameSize = true;
            if ((elem1.GetLength(0) != elem2.GetLength(0)) || (elem1.GetLength(1) != elem2.GetLength(1)))
            {
                sameSize = false;
            }

            if (!sameSize)
            {
                Console.WriteLine("Operation is not possible; the parameters have different sizes.");
            }
            else
            {
                result = new int[elem1.GetLength(0), elem1.GetLength(1)];


                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = elem1[i, j] + elem2[i, j];
                    }
                }
            }

            return result;

        }
    }
}
