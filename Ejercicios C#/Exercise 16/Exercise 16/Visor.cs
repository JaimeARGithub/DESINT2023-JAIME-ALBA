using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_16
{
    public class Visor
    {
        public static void ver(int[,] matriz)
        {
            for (int i=0; i<matriz.GetLength(0); i++)
            {
                for (int j=0; j<matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
        }

        public static void ver(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j].ToString("F2"));
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
