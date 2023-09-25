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
            for (int i=0; i<6; i++)
            {
                
                for (int j=0; j<i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < 11-(2*i); j++)
                {
                    Console.Write("#");
                }


                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    
        public static void k(int height)
        {
            for (int i=0; i<height; i++)
            {
                for (int j=0; j<height-1-i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < ((i+1)*2)-1; j++)
                {
                    Console.Write("#");
                }


                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void l(int height)
        {
            for (int i=0; i<((int)height/2)+1; i++)
            {
                for (int j=0; j<((int)height/2)-i; j++)
                {
                    Console.Write(" ");
                }
                
                for (int j=0; j<((i+1)*2)-1; j++)
                {
                    Console.Write("#");
                }

                Console.WriteLine(" ");
            }

            for (int i=((int)height/2)+1; i<height; i++)
            {
                for (int j=0; j<(i-(int)height/2); j++)
                {
                    Console.Write(" ");
                }

                for (int j=0; j<(height-i)+((height-i)-1); j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    
        public static void m()
        {
            for (int i=0; i<8; i++)
            {
                for (int j=0; j<=i; j++)
                {
                    Console.Write(j+1);
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static void n()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (j <= i - 1)
                    {
                       Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(j + 1 - i);
                    }


                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    }
}
