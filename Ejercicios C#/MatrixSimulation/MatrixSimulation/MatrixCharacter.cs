using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSimulation
{
    public class MatrixCharacter : IMethods
    {
        // Clase interna Location
        public class Location
        {
            public int latitude;
            public int longitude;
            public String cityOfBirth;

            public Location (String city)
            {
                this.latitude = AuxiliarMethods.generateRandom(-90, 90);
                this.longitude = AuxiliarMethods.generateRandom(-180, 180);
                this.cityOfBirth = city;
            }

        }
        
        // Atributos
        protected String name;
        protected int age;
        protected int percDeath;
        protected Location location;

        
        // Constructor
        public MatrixCharacter(String nameIntr, int ageIntr, int percDeathIntr, String cityIntr)
        {
            this.name= nameIntr;
            this.age= ageIntr; // Las edades variarán en un rango de 0 (recién nacido) a 80 años.
            this.percDeath= percDeathIntr; // Las probabilidades de muerte variarán en un rango del 0% al 90%.
            // Al cada turno sumarse un 10% de probabilidades de morir, no tendría sentido la existencia de 
            // personajes con más de un 100% de probabilidades de morir.
            this.location = new Location(cityIntr);
        }


        // Métodos
        public int getPercDeath()
        {
            return this.percDeath;
        }

        public void setPercDeath()
        {
            this.percDeath = this.percDeath + 10;
        }


        // Implementación de los métodos de la interfaz
        public void generate() { }

        public void prompt() { }

        public String print()
        {
            String infoCharacter = new string("Name: "+this.name+". Age: "+this.age+". Percentage of death: "+this.percDeath+". City of birth: "+this.location.cityOfBirth+".");
            return infoCharacter;
        }
    }
}
