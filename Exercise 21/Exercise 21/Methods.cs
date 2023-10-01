using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_21
{
    public class Methods
    {
        public static bool isPerfect(int number)
        {
            bool isPerfect = false;
            int acc = 0;

            for (int i=1; i<=(int)(number/2); i++)
            {
                if (number%i == 0)
                {
                    acc = acc + i;
                }
            }

            if (acc == number)
            {
                isPerfect = true;
            }

            return isPerfect;
        }


        public static bool isDeficient(int number)
        {
            bool isDeficient = false;
            int acc = 0;

            for (int i = 1; i <= (int)(number / 2); i++)
            {
                if (number % i == 0)
                {
                    acc = acc + i;
                }
            }

            if (acc < number)
            {
                isDeficient = true;
            }

            return isDeficient;
        }
    }
}
