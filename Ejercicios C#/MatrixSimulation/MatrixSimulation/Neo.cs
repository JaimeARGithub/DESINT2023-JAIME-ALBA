using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MatrixSimulation
{
    public class Neo : MatrixCharacter
    {
        // Atributos
        bool isTheOne;

        
        // Constructor
        public Neo(String nameInt, int ageInt, int percDeathInt, String locationInt):base(nameInt, ageInt, percDeathInt, locationInt) {
            isTheOne = true;
        }


        // Métodos
        public bool getIsTheOne()
        {
            return this.isTheOne;
        }

        public void setIsTheOne()
        {
            Random generador = new Random();
            int num = generador.Next(0, 2);

            if (num==0)
            {
                this.isTheOne = false;
            } else
            {
                this.isTheOne = false;
            }
        }
    }
}
