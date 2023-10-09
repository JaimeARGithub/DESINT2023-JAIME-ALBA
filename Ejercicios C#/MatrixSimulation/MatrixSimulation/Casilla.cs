using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSimulation
{
    public class Casilla
    {
        // Atributos
        private int x;
        private int y;

        // Constructor
        public Casilla(int xIntr, int yIntr)
        {
            this.x = xIntr;
            this.y = yIntr;
        }

        // Métodos
        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }
    }
}
