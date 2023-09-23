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


        public static double[,] addition(double[,] elem1, double[,] elem2)
        {
            double[,] result = null;

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
                result = new double[elem1.GetLength(0), elem1.GetLength(1)];


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

        public static int[,] substraction(int[,] elem1, int[,] elem2)
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
                        result[i, j] = elem1[i, j] - elem2[i, j];
                    }
                }
            }

            return result;

        }

        public static double[,] substraction(double[,] elem1, double[,] elem2)
        {
            double[,] result = null;

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
                result = new double[elem1.GetLength(0), elem1.GetLength(1)];


                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = elem1[i, j] - elem2[i, j];
                    }
                }
            }

            return result;

        }
    
        public static int[,] multiplication(int[,] elem1, int[,] elem2)
        {
            int[,] result = null;

            if (elem1.GetLength(1)!=elem2.GetLength(0))
            {
                Console.WriteLine("Operation is not possible; the number of columns in matrix 1 must equal the number of rows in matrix 2.");
            } else
            {
                result = new int[elem1.GetLength(0),elem2.GetLength(1)];

                for (int i=0; i<result.GetLength(0); i++)
                {
                    for (int j=0; j<result.GetLength(1); j++)
                    {

                        result[i, j] = 0;
                        for (int z=0; z<elem1.GetLength(1); z++)
                        {
                            result[i, j] = result[i, j] + (elem1[i,z] * elem2[z,j] );
                        }

                    }
                }
            }

            return result;
        }

        public static double[,] multiplication(double[,] elem1, double[,] elem2)
        {
            double[,] result = null;

            if (elem1.GetLength(1) != elem2.GetLength(0))
            {
                Console.WriteLine("Operation is not possible; the number of columns in matrix 1 must equal the number of rows in matrix 2.");
            }
            else
            {
                result = new double[elem1.GetLength(0), elem2.GetLength(1)];

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {

                        result[i, j] = 0;
                        for (int z = 0; z < elem1.GetLength(1); z++)
                        {
                            result[i, j] = result[i, j] + (elem1[i, z] * elem2[z, j]);
                        }

                    }
                }
            }

            return result;
        }
    }
}
