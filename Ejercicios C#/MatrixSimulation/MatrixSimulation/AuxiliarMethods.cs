using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSimulation
{
    public class AuxiliarMethods
    {
        public static int generateRandom (int minVal, int maxVal)
        {
            Random generador = new Random();
            int numAleatorio = generador.Next(minVal, (maxVal+1));
            return numAleatorio;
        }
    }
}
