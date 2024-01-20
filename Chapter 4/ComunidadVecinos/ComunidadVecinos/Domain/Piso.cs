using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    internal class Piso
    {
        public int Id { get; set; }
        public int idComunidad { get; set; }
        public int idProp1 { get; set; }
        public int idProp2 { get; set; }
        public int numPortal { get; set; }
        public int numEscalera { get; set; }
        public int numPlanta { get; set; }
        public string puerta { get; set; }
        public int numTrastero { get; set; }
        public int numPlaza { get; set; }
        public PisoManage pm { get; set; }


        public Piso()
        {
            pm = new PisoManage();
        }

        public Piso(int id)
        {
            this.Id = id;
            pm = new PisoManage();
        }

        public Piso(int idComunidad, int idProp1, int idProp2, int numPortal, int numEscalera, int numPlanta, string puerta, int numTrastero, int numPlaza)
        {
            this.idComunidad = idComunidad;
            this.idProp1 = idProp1;
            this.idProp2 = idProp2;
            this.numPortal = numPortal;
            this.numEscalera = numEscalera;
            this.numPlanta = numPlanta;
            this.puerta = puerta;
            this.numTrastero = numTrastero;
            this.numPlaza = numPlaza;
            this.pm = new PisoManage();
        }
    }
}
