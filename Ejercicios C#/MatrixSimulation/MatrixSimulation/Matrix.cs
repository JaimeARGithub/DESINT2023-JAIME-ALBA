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
        MatrixCharacter[] queue;
        int numberOfCreated;
        const int DEFAULT_X = 5;
        const int DEFAULT_Y = 5;
        Casilla casillaNeo;
        Casilla casillaSmith;


        // Constructores
        // Constructor pequeño que llama al grande utilizando como parámetros
        // la cola de personajes y los tamaños por defecto
        public Matrix(MatrixCharacter[] queueIntr): this(queueIntr, DEFAULT_X, DEFAULT_Y)
        {
        }
        
        // Constructor grande que usa como parámetros la cola de personajes y
        // los tamaños deseados
        public Matrix(MatrixCharacter[] queueIntr, int xValue, int yValue)
        {
            // Primero creamos la matriz con el tamaño parametrizado
            this.numberOfCreated = 0;
            this.matrix = new MatrixCharacter[xValue, yValue];
            this.queue = queueIntr;


            // Después metemos a Neo con una ubicación aleatoria dentro
            // de las dimensiones de la matriz
            int xNeo = AuxiliarMethods.generateRandom(0, xValue - 1);
            int yNeo = AuxiliarMethods.generateRandom(0, yValue - 1);
            matrix[xNeo, yNeo] = new Neo();
            casillaNeo = new Casilla(xNeo, yNeo);


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
            casillaSmith = new Casilla(xSmith, ySmith);


            // Una vez ubicados Neo y Smith, rellenamos con personajes con la cola
            // que ya existe como atributo. Cada vez que un personaje es extraído de
            // la cola de personajes disponibles e insertado en la matrix, se aumenta
            // en 1 la cantidad (atributo) de personajes que han entrado y se iguala
            // a null la posición que el personaje ocupaba en la cola, haciendo que se
            // reduzca el número de personajes que quedan disponibles.
            int positionQueue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==null)
                    {
                        positionQueue = AuxiliarMethods.generateRandom(0, queue.Length-1);

                        // Se elige el personaje de la cola de manera aleatoria; si el número
                        // que se usará para la posición aleatoria se corresponde con una posición
                        // nula, se vuelve a generar otro número.
                        while (queue[positionQueue] == null)
                        {
                            positionQueue = AuxiliarMethods.generateRandom(0, queue.Length-1);
                        }

                        matrix[i, j] = queue[positionQueue];
                        this.numberOfCreated++;
                        queue[positionQueue] = null;

                    }
                }
                Console.WriteLine("");
            }

            // E imprimimos la matrix para ver cómo queda tras construitla
            print();
        }


        // Métodos
        /**
         * Método para imprimir por pantalla el estado en el que se encuentra la 
         * matriz de personajes. Imprime una N en donde esté Neo, S en donde esté
         * Smith, C en donde haya personajes genéricos y X en donde haya habido una muerte.
         */
        public void print()
        {
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] is Neo)
                    {
                        Console.Write("| N |  ");
                    } else if (matrix[i, j] is Smith)
                    {
                        Console.Write("| S |  ");
                    } else if (matrix[i, j] is MatrixCharacter)
                    {
                        Console.Write("| C |  ");
                    } else if (matrix[i, j] == null)
                    {
                        Console.Write("| X |  ");
                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }

            Console.WriteLine("Neo is in (" + getCasillaNeo().getX() + "," + getCasillaNeo().getY() + ")");
            Console.WriteLine("Smith is in (" + getCasillaSmith().getX() + "," + getCasillaSmith().getY() + ")");
            Console.WriteLine("Number of characters that have entered the Matrix: "+numberOfCreated);
            Console.WriteLine("Number of characters pending in the queue: "+(queue.Length - this.numberOfCreated));
        }



        /**
         * Método que devuelve la casilla en la que se encuentra Neo
         */
        public Casilla getCasillaNeo()
        {
            return this.casillaNeo;
        }

        /**
         * Método que devuelve la casilla en la que se encuentra Smith
         */
        public Casilla getCasillaSmith()
        {
            return this.casillaSmith;
        }


        /**
         * Método que implementa la funcionalidad de los personajes.
         * Revisa toda la matriz en busca de objetos que sean personajes,
         * pero que no sean Neo ni Smith. 
         * 
         * Si su probabilidad de muerte (independiente de la edad) es 
         * menor que 70, se suma 10.
         * 
         * Si su probabilidad de muerte es mayor o igual que 70, el personaje
         * muere; la casilla se iguala a null, se extrae otro personaje de
         * la cola, se inserta en esa misma posición de la matriz, la
         * posición que el personaje ocupaba en la cola se iguala a null
         * (se reduce el número de personajes disponibles) y se aumenta
         * el número de personajes que han entrado en la matrix.
         */

        public void charactersTurn()
        {
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] is MatrixCharacter &&
                        matrix[i, j] is not Neo &&
                        matrix[i, j] is not Smith)
                    {
                        int probDeath = matrix[i, j].getPercDeath();
                        if (probDeath < 70)
                        {
                            matrix[i, j].setPercDeath();
                        } else
                        {
                            matrix[i, j] = null;

                            int positionQueue = AuxiliarMethods.generateRandom(0, queue.Length - 1);

                            while (queue[positionQueue] == null)
                            {
                                positionQueue = AuxiliarMethods.generateRandom(0, queue.Length - 1);
                            }

                            matrix[i, j] = this.queue[positionQueue];
                            queue[positionQueue] = null;
                            numberOfCreated++;
                        }
                    }
                }
            }
        }


        public void getRoute(Casilla casillaSmith)
        {
            int xReach = casillaSmith.getX() + this.casillaNeo.getX();
            int yReach = casillaSmith.getY() + this.casillaNeo.getY();

            if ((xReach%2==0 && yReach % 2 == 0) || (xReach % 2 != 0 && yReach % 2 != 0))
            {
                int xShortest = Math.Abs(casillaSmith.getX() - this.casillaNeo.getX());
                int yShortest = Math.Abs(casillaSmith.getY() - this.casillaNeo.getY());
                int numOfMovs = (int) Math.Max(xShortest, yShortest);

                Casilla casillaRevisada;
                Casilla casillaOptima;

                // Reviso la adyacencia de las posiciones de Smith, verificando que esté
                // todo dentro de los límites de la matrix ¡¡Y!! que sean casillas válidas,
                // es decir, casillas diagonales a su posición dentro de lo disponible en
                // la adyacencia, puesto que solamente puede moverse a esas casillas
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (casillaSmith.getX()+i >= 0 && 
                            casillaSmith.getX()+i < matrix.GetLength(0) &&
                            casillaSmith.getY()+j >= 0 &&
                            casillaSmith.getY()+j < matrix.GetLength(1))
                        {
                            
                            matrix[casillaSmith.getX() + i, casillaSmith.getY() + j] = null;
                            //casillaRevisada = new Casilla(casillaSmith.getX()+i , casillaSmith.getY()+j);
                            //int xOptimal = Math.Abs((casillaSmith.getX()+i) - (this.casillaNeo.getX()));
                            //int yOptimal = Math.Abs((casillaSmith.getY()+j) - (this.casillaNeo.getY()));
                            //int numMovsOptimal = (int)Math.Max(xOptimal, yOptimal);

                            //if (numMovsOptimal < numOfMovs)
                            //{
                            //    casillaOptima = casillaRevisada;
                            //}



                        }
                    }
                }
            }
        }
    }
}
