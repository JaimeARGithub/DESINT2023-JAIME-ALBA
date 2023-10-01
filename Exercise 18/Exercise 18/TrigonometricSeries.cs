using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_18
{
    public class TrigonometricSeries
    {
        
        public static double sin(double num)
        {
            double radians = num * Math.PI / 180;
            
            double sin = 0;
            int iterator = 1;
            int numTerms = 10;

            for (int i=1; i<=numTerms; i++)
            {
                if (i % 2 != 0)
                {
                    sin = sin + (Math.Pow(radians, iterator))  /  (factorial(iterator));

                } else
                {
                    sin = sin - (Math.Pow(radians, iterator)) / (factorial(iterator));

                }
                iterator = iterator + 2;

            }

            return sin;

        }



        public static double cos(double num)
        {
            double radians = num * Math.PI / 180;
            double cos = 1;
            int iterator = 2;
            int numTerms = 10;

            for (int i=1; i<numTerms; i++)
            {
                if (i % 2 != 0)
                {
                    cos = cos = cos - (Math.Pow(radians, iterator)) / (factorial(iterator));

                } else
                {
                    cos = cos = cos + (Math.Pow(radians, iterator)) / (factorial(iterator));

                }
                iterator = iterator + 2;

            }
            

            return cos;
        }




        
        public static int factorial(int number)
        {
            int fact = 1;

            for (int i=1; i<=number; i++)
            {
                fact = fact * i;
            }

            return fact;
        }
    }
}
