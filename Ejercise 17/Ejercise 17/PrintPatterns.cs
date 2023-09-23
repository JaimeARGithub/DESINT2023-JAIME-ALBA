using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercise_17
{
    public class PrintPatterns
    {
        public static void a()
        {
            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    if (j<=i)
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void b()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i <= j)
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void c()
        {
            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    if (j<=i-1)
                    {
                        Console.Write(" ");
                    } else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void d()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j <= 8 - i -2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }



        public static void e()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i==0 || i==6 || j==0 || j==6)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void f()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i==0 || i==6 || i==j)
                    {
                        Console.Write("#");
                    } else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void g()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0 || i == 6 || j==6-i)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    
        public static void h()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0 || i == 6 || i==j || j == 6 - i)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void i()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0 || i == 6 || i == j || j == 6 - i || j == 0 || j == 6)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    
        public static void j()
        {
            for (int i=0; i<12; i++)
            {
                for (int j=0; j<6; j++)
                {
                    if (j<i)
                    {
                        Console.Write(" ");
                    } else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
