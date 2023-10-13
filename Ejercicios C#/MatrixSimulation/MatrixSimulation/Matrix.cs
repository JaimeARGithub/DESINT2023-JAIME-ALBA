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

            // E imprimimos la matrix para ver cómo queda tras construirla
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
                        Console.Write(" N ");
                    } else if (matrix[i, j] is Smith)
                    {
                        Console.Write(" S ");
                    } else if (matrix[i, j] is MatrixCharacter)
                    {
                        Console.Write(" C ");
                    } else if (matrix[i, j] == null)
                    {
                        Console.Write(" X ");
                    }
                }
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

                            if (queue.Length - this.numberOfCreated > 0)
                            {
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
        }


        /**
         * Método que busca la ruta más corta de Smith hacia Neo. Localiza la ruta,
         * y a lo largo de ella va asesinando a personajes, cuya cantidad dependerá
         * de la capacidad de infectar con que haya aparecido ese turno.
         */
        public void getRoute(Casilla casillaSmith, int capacidadInfeccion)
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

                int xCoordenadaDivisible;
                int yCoordenadaDivisible;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        xCoordenadaDivisible = casillaSmith.getX() + i + this.casillaNeo.getX();
                        yCoordenadaDivisible = casillaSmith.getY() + j + this.casillaNeo.getY();

                        if (casillaSmith.getX()+i >= 0 && 
                            casillaSmith.getX()+i < matrix.GetLength(0) &&
                            casillaSmith.getY()+j >= 0 &&
                            casillaSmith.getY()+j < matrix.GetLength(1) &&
                            (matrix[casillaSmith.getX() + i, casillaSmith.getY() + j] is not Smith) &&
                            (  (xCoordenadaDivisible%2==0 && yCoordenadaDivisible%2==0)  ||  (xCoordenadaDivisible % 2 != 0 && yCoordenadaDivisible % 2 != 0)  ))
                        {
                            
                            casillaRevisada = new Casilla(casillaSmith.getX()+i , casillaSmith.getY()+j);
                            int xOptimal = Math.Abs((casillaSmith.getX()+i) - (this.casillaNeo.getX()));
                            int yOptimal = Math.Abs((casillaSmith.getY()+j) - (this.casillaNeo.getY()));
                            int numMovsOptimal = (int)Math.Max(xOptimal, yOptimal);

                            // Si el número de movimientos que hay desde la casilla que se ha revisado
                            // hasta Neo es menor que el que anteriormente se calculó, esa casilla
                            // es aceptada como válida y la variable que indica la distancia hasta
                            // Neo se reasigna, evitando de esa manera que puedan tomarse como válidas
                            // varias casillas que ofrezcan hacia Neo una distancia igual entre sí,
                            // pero menor a la existente desde la casilla en la que se encuentra Smith.

                            // En el propio acto de encontrar una casilla eficiente se mata al personaje
                            // presente en ésta, y la capacidad de infectar de Smith se reduce en 1.

                            // Encontrada una casilla óptima, se hace una llamada recursiva al método
                            // pasando como parámetros la casilla óptima encontrada y la capacidad de
                            // infectar de Smith reducida en 1.

                            
                            if (numMovsOptimal < numOfMovs)
                            {
                                numOfMovs = numMovsOptimal;
                                casillaOptima = casillaRevisada;
                                int capInf = capacidadInfeccion;
                                if (capInf>0 && 
                                    (matrix[casillaOptima.getX(), casillaOptima.getY()] is not Neo) &&

                                    // DETALLE IMPORTANTE: en el camino desde Smith hasta Neo, es posible
                                    // que encuentre casillas con personajes ya muertos; a la hora de
                                    // asesinar personajes en la ruta más corta hasta Neo, estas casillas
                                    // son bestialmente ignoradas, de manera que únicamente continuará
                                    // matando en aquellas casillas en las que haya personajes vivos
                                    // disponibles.
                                    // Tras morir estos personajes, las casillas permanecen a nulo a menos
                                    // que Neo inserte personajes nuevos; no se reponen con el paso del
                                    // tiempo, al contrario que el caso de aquellos personajes que mueren
                                    // de manera natural, por el atributo de la probabilidad de muerte.
                                    (matrix[casillaOptima.getX(), casillaOptima.getY()] != null))
                                {
                                    matrix[casillaOptima.getX(), casillaOptima.getY()] = null;
                                    capInf = capInf - 1;
                                }

                                if (numOfMovs>1)
                                {
                                    getRoute(casillaOptima,capInf);
                                }
                            }



                        }
                    }
                }
            }
        }

        /**
         * Método que aglutina lo que hará Smith siempre que sea su turno. Se
         * generará una capacidad de infectar aleatoria entre 1 y su máximo
         * asignado, se buscará la ruta óptima desde él hasta Neo y se matará
         * al número de personajes que haya aparecido en la capacidad de infección.
         */
        public void smithTurn()
        {
            Smith smithInfectar = (Smith)(matrix[casillaSmith.getX(),casillaSmith.getY()]);
            smithInfectar.setAbilityInfect();
            int capInfectar = smithInfectar.getAbilityInfect();
            Console.WriteLine("Smith's ability to infect is "+ capInfectar);
            getRoute(casillaSmith,capInfectar);
        }


        /**
         * Método para asesinar a toda la matrix y ver si Neo 
         * revive a los de su alrededor. No se usa en el programa
         * final. Borrarlo si me acuerdo.
         */
        public void matar()
        {
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] is MatrixCharacter &&
                        matrix[i, j] is not Neo &&
                        matrix[i, j] is not Smith)
                    {
                        matrix[i, j] = null;
                    }
                }
            }
        }


        /**
         * Método que aglutina lo que hará Neo siempre que sea su turno. 
         * 
         * En primer lugar, decide con una probabilidad del 50% si es el elegido 
         * o no; si resulta serlo, inspecciona las casillas de la adyacencia, y 
         * aquellas que encuentre nulas (con personajes muertos) las rellenará 
         * extrayendo personajes de la cola e insertándolos en dichas casillas.
         * 
         * En segundo lugar, cambiará su posición. Genera dos números aleatorios
         * que utiliza como coordenadas para revisar una posición de la matriz, e
         * intercambia posiciones, independientemente de qué la esté ocupando.
         */
        public void neoTurn()
        {
            Neo neo = new Neo();
            neo.setIsTheOne();
            if (neo.getIsTheOne() && (queue.Length - this.numberOfCreated > 0))
            {
                Console.WriteLine("Neo is the Chosen One!");
                int positionQueue;
                for (int i=-1; i<=1; i++)
                {
                    for (int j=-1; j<=1; j++)
                    {
                        if ((casillaNeo.getX()+i >= 0) &&
                            (casillaNeo.getX()+i < matrix.GetLength(0)) &&
                            (casillaNeo.getY()+j >= 0) &&
                            (casillaNeo.getY()+j < matrix.GetLength(1)) &&
                            (matrix[casillaNeo.getX() + i, casillaNeo.getY() + j] is null))
                        {


                            // En el hipotético caso de que queden personajes disponibles en la cola,
                            // se elige el personaje de la cola de manera aleatoria; si el número
                            // que se usará para la posición aleatoria se corresponde con una posición
                            // nula, se vuelve a generar otro número.
                            // Los personajes elegidos de la cola de personajes disponibles son insertados
                            // en Matrix, en la adyacencia de Neo.
                                positionQueue = AuxiliarMethods.generateRandom(0, queue.Length - 1);

                                while (queue[positionQueue] == null)
                                {
                                    positionQueue = AuxiliarMethods.generateRandom(0, queue.Length - 1);
                                }

                                matrix[casillaNeo.getX() + i, casillaNeo.getY() + j] = this.queue[positionQueue];
                                this.numberOfCreated++;
                                queue[positionQueue] = null;
                            

                        }
                    }
                }
            } else
            {
                Console.WriteLine("Neo is not the Chosen One. Sorry :(");
            }


            int xNewPosition = AuxiliarMethods.generateRandom(0, matrix.GetLength(0) - 1);
            int yNewPosition = AuxiliarMethods.generateRandom(0, matrix.GetLength(1) - 1);

            if (matrix[xNewPosition,yNewPosition] is Smith)
            {
                // Para el caso de la casilla generada coincida con aquella en la que
                // se encuentre Smith
                matrix[casillaNeo.getX(), casillaNeo.getY()] = new Smith();
                casillaSmith = new Casilla(casillaNeo.getX(), casillaNeo.getY());
                
                matrix[xNewPosition, yNewPosition] = new Neo();
                casillaNeo = new Casilla(xNewPosition, yNewPosition);

            } else
            {
                // Para el caso de la casilla generada sea una en la que haya un
                // personaje genérico, ya sea vivo o muerto
                matrix[casillaNeo.getX(), casillaNeo.getY()] = matrix[xNewPosition, yNewPosition];

                matrix[xNewPosition, yNewPosition] = new Neo();
                casillaNeo = new Casilla(xNewPosition, yNewPosition);
            }



        }


        /**
         * Método que pone en marcha el funcionamiento de toda la matriz.
         * 
         * Cada segundo se produce el turno de los personajes genéricos.
         * Cada dos segundos se produce el turno del agente Smith.
         * Cada cinco segundos se produce el turno de Neo.
         * 
         * La simulación termina, según los términos especificados en clase,
         * cuando han pasado 20 segundos o cuando la cola de personajes
         * está vacía (los 200 ya han entrado en Matrix).
         */
        public void funcionar()
        {
            int max_time = 20;
            int time = 1;

            do
            {
                print();
                if (time % 1 == 0)
                {
                    charactersTurn();
                }
                if (time % 2 == 0) 
                { 
                    smithTurn(); 
                }
                if (time % 5 == 0)
                {
                    neoTurn();
                }
                Thread.Sleep(1000);
                time += 1;

            } while (time <= max_time && numberOfCreated < queue.Length);
            print();
            Console.WriteLine("Tiempo en Matrix terminado.");
        }
    }
}
