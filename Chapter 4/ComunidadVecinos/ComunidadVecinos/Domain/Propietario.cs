using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    internal class Propietario
    {
        public int Id { get; set; }
        public string dni {  get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direcResidencia { get; set; }
        public string localidad {  get; set; }
        public int codPostal { get; set; }
        public string provincia { get; set; }
        public PropietarioManage pm { get; set; }


        public Propietario()
        {
            pm = new PropietarioManage();
        }


        public Propietario(int id)
        {
            this.Id = id;
            pm = new PropietarioManage();
        }

        public Propietario(string dni, string nombre, string apellidos, string direcResidencia, string localidad, int codPostal, string provincia)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direcResidencia = direcResidencia;
            this.localidad = localidad;
            this.codPostal = codPostal;
            this.provincia = provincia;
            this.pm = new PropietarioManage();
        }
    }
}
