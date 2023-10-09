using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSimulation
{
    public class Matrix
    {
        // Atributos
        MatrixCharacter[,] matrix;
        int numberOfCreated=0;
        const int DEFAULT_X = 5;
        const int DEFAULT_Y = 5;


        // Constructor
        public Matrix(MatrixCharacter[] queue, int xValue, int yValue)
        {
            // Primero creamos la matriz con el tamaño parametrizado
            this.matrix = new MatrixCharacter[xValue, yValue];


            // Después metemos a Neo con una ubicación aleatoria dentro
            // de las dimensiones de la matriz
            matrix[AuxiliarMethods.generateRandom(0, xValue-1), AuxiliarMethods.generateRandom(0, yValue-1)] = new Neo();


            // Tras eso, metemos a Smith con el mismo criterio, sumado
            // a que no pueda coincidir en casilla con Neo
            int xSmith = AuxiliarMethods.generateRandom(0, xValue - 1);
            int ySmith = AuxiliarMethods.generateRandom(0, yValue - 1);
            while (matrix[xSmith, ySmith] != null)
            {
                xSmith = AuxiliarMethods.generateRandom(0, xValue - 1);
                ySmith = AuxiliarMethods.generateRandom(0, yValue - 1);
            }
            matrix[xSmith, ySmith] = new Smith();


            // Una vez ubicados Neo y Smith, rellenamos con personajes
            int posQueue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==null)
                    {
                        posQueue = AuxiliarMethods.generateRandom(0, queue.Length-1);

                        while (queue[posQueue] == null)
                        {
                            posQueue = AuxiliarMethods.generateRandom(0, queue.Length-1);
                        }

                        matrix[i, j] = queue[posQueue];
                        this.numberOfCreated++;
                        queue[posQueue] = null;

                    }
                }
                Console.WriteLine("");
            }
        }


        // Métodos
    }
}
