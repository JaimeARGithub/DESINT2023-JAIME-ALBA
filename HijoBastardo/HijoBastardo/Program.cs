using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HijoBastardo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPartidos = 10;
            int escañosMadrid = 37;
            int habitantesVotaron = 4345230;
            int votosNulos = habitantesVotaron / 20;

            int votosValidos = habitantesVotaron - votosNulos;

            double[] porcentajes = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25 };
            for (int i = 0; i < porcentajes.Length; i++)
            {
                if (porcentajes[i] < 3)
                {
                    porcentajes[i] = 0;
                }
            }


            int[,] votos = new int[numPartidos, escañosMadrid];


            for (int i = 0; i < numPartidos; i++)
            {
                votos[i, 0] = (int)((porcentajes[i] * votosValidos) / 100);
            }



            for (int i = 0; i < votos.GetLength(0); i++)
            {
                for (int j = 1; j < votos.GetLength(1); j++)
                {
                    votos[i, j] = votos[i, 0] / (j + 1);
                }
            }


            imprimir(votos);


            int[] partidos = new int[numPartidos];

            int partidoMayor = 0;
            for (int i = 0; i < escañosMadrid; i++)
            {
                partidoMayor = encontrarMayor(votos);
                partidos[partidoMayor]++;
            }

            imprimir(partidos);

            Console.ReadLine();
        }

        public static void imprimir(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void imprimir(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.WriteLine(v[i]);
            }
        }

        //devuelve la fila del partido mayor
        public static int encontrarMayor(int[,] m)
        {
            int mayor = m[0, 0];
            int fila = 0;
            int col = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 1; j < m.GetLength(1); j++)
                {
                    if (m[i, j] > mayor)
                    {
                        mayor = m[i, j];
                        fila = i;
                        col = j;
                    }
                }
            }

            m[fila, col] = 0;
            return fila;

        }


    }


}