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
        public Neo():base("Neo", 37, 0, "Capital City") {
            isTheOne = true; // Sé que Neo es un hombre indeciso, pero
                             // he optado por ser optimista y asumir que
                             // se crea partiendo de que cree ser el Elegido
        }


        // Métodos
        public bool getIsTheOne()
        {
            return this.isTheOne;
        }

        public void setIsTheOne()
        {
            int num = AuxiliarMethods.generateRandom(0,1);

            if (num==0)
            {
                this.isTheOne = false;
            } else
            {
                this.isTheOne = true;
            }
        }
    }
}
