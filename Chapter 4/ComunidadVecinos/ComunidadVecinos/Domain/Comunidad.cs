using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    internal class Comunidad
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set;}
        public string fechaCreac { get; set; }
        public double metrosCuadrados { get; set; }
        public bool hayPiscina { get; set; }
        public int numPortales { get; set; }
        public ComunidadManage cm { get; set; }


        public Comunidad()
        {
            cm = new ComunidadManage();
        }

        public Comunidad(int id)
        {
            this.Id = id;
            cm = new ComunidadManage();
        }

        public Comunidad(string nombre, string direccion, string fechaCreac, double metrosCuadrados, bool hayPiscina, int numPortales)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.fechaCreac = fechaCreac;
            this.metrosCuadrados = metrosCuadrados;
            this.hayPiscina = hayPiscina;
            this.numPortales = numPortales;
            cm = new ComunidadManage();
        }
    }


}
