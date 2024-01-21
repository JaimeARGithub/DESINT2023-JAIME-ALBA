﻿using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class Comunidad
    {
        public static int autoID = 0;
        public int Id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set;}
        public string fechaCreac { get; set; }
        public int metrosCuadrados { get; set; }
        public Boolean hayPiscina { get; set; }
        public int numPortales { get; set; }
        public List<Piso> listaPisos {  get; set; }
        public ComunidadManage cm { get; set; }


        public Comunidad(string nombre, string direccion, string fechaCreac, int metrosCuadrados, Boolean hayPiscina, int numPortales)
        {
            this.Id = autoID++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.fechaCreac = fechaCreac;
            this.metrosCuadrados = metrosCuadrados;
            this.hayPiscina = hayPiscina;
            this.numPortales = numPortales;
            this.listaPisos = new List<Piso>();
            cm = new ComunidadManage();
        }
    }


}
