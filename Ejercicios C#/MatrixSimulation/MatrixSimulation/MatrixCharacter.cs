using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSimulation
{
    public class MatrixCharacter
    {
        // Clase interna Location
        public class Location
        {
            public int latitude;
            public int longitude;
            public String cityOfBirth;

            public Location (String city)
            {
                Random generador = new Random();
                this.latitude = generador.Next(0,51); // El 51 no se incluye
                this.longitude = generador.Next(0, 51);
                this.cityOfBirth = city;
            }

        }
        
        // Atributos
        protected String name;
        protected int age;
        protected int percDeath;
        protected Location location;

        
        // Constructor
        public MatrixCharacter(String nameInt, int ageInt, int percDeathInt, String locationInt)
        {
            this.name= nameInt;
            this.age= ageInt;
            this.percDeath= percDeathInt;
            this.location = new Location(locationInt);
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
    }
}
