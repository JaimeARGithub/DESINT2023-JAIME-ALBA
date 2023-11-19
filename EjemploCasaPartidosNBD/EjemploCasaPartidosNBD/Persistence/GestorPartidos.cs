using EjemploCasaPartidosNBD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploCasaPartidosNBD.Persistence
{
    internal class GestorPartidos
    {
        public List<Partido> listaPartidos;

        public GestorPartidos()
        {
            this.listaPartidos = new List<Partido>();
        }

        public void readPartidos()
        {
            listaPartidos.Add(new Partido("PSOE", "PerroSanche", 67));
            listaPartidos.Add(new Partido("PP", "Feoo", 2));
            listaPartidos.Add(new Partido("Sumar", "La pava esa", 3));
        }
    }
}
