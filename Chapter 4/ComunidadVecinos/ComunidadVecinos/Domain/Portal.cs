using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    internal class Portal
    {
        public int numEscaleras { get; set; }
        public int numPlantas { get; set; }
        public int numPuertas { get; set; }


        public Portal(int numEscaleras, int numPlantas, int numPuertas)
        {
            this.numEscaleras = numEscaleras;
            this.numPlantas = numPlantas;
            this.numPuertas = numPuertas;
        }
    }
}
