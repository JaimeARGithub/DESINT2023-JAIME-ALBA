using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos
{
    /// <summary>
    /// Clase de apoyo empleada a lo largo de todo el código para obtener números aleatorios.
    /// </summary>
    class RandomNumber
    {
        private static readonly Random r = new Random();
        private static readonly object syncLock = new object();
        /**
       * Method that extracts of Sample its amount and increases the number of valid samples
       **/
        /// <summary>
        /// Método estático que genera y devuelve un número aleatorio,
        /// dentro de unos límites inferior y superior.
        /// </summary>
        /// <param name="min">Límite inferior.</param>
        /// <param name="max">Límite superior.</param>
        /// <returns>El número aleatorio generado.</returns>
        public static int random_Number(int min, int max)
        {

            lock (syncLock)
            {
                return r.Next(min, max);
            }
        }

    }
}
