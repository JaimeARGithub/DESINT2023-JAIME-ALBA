using EjemploCasaPartidosNBD.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploCasaPartidosNBD.Domain
{
    internal class Partido
    {
        public string nombre {  get; set; }
        public string presidente { get; set; }
        public int numVotos { get; set; }
        public GestorPartidos gp {  get; set; }

        public Partido() 
        {
            this.gp = new GestorPartidos();
        }

        public Partido(string nom, string pres, int numV)
        {
            this.nombre = nom;
            this.presidente = pres;
            this.numVotos = numV;
            this.gp = new GestorPartidos();
        }

        public void readP()
        {
            gp.readPartidos();
        }

        public List<Partido> getLista()
        {
            return gp.listaPartidos;
        }
    }
}
