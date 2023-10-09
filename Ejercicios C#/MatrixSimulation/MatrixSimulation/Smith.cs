using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSimulation
{
    public class Smith : MatrixCharacter
    {
        // Atributos
        int abilityInfect;
        // Las constantes son estáticas por naturaleza
        const int MAX_ABILITY_INFECT = 5;


        // Constructor
        public Smith():base("Smith", 157, 0, "The Matrix")
        {
            this.abilityInfect = AuxiliarMethods.generateRandom(1,MAX_ABILITY_INFECT);
        }


        // Métodos
        public int getAbilityInfect() 
        { 
            return this.abilityInfect; 
        }

        public void setAbilityInfect()
        {
            this.abilityInfect = AuxiliarMethods.generateRandom(1, MAX_ABILITY_INFECT);
        }

        // FALTA IMPLEMENTARLO
        public List<Casilla> getShortestRoute (Casilla casillaNeo, Casilla casillaSmith)
        {
            List<Casilla> shortestRoute = new List<Casilla>();

            return shortestRoute;
        }
    }
}
