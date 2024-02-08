using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class Piso
    {
        public static int autoID = 0;
        public int Id { get; set; }
        public int idComunidad { get; set; }
        public string idProp1 { get; set; }
        public string idProp2 { get; set; }
        public int numPortal { get; set; }
        public int numEscalera { get; set; }
        public int numPlanta { get; set; }
        public string puerta { get; set; }
        public int numTrastero { get; set; }
        public int numPlaza { get; set; }
        public PisoManage pm { get; set; }


        public Piso()
        {
            this.pm = new PisoManage();
        }

        public Piso(int idComunidad,  int numPortal, int numEscalera, int numPlanta, string puerta)
        {
            this.Id = autoID++;
            this.idComunidad = idComunidad;
            this.numPortal = numPortal;
            this.numEscalera = numEscalera;
            this.numPlanta = numPlanta;
            this.puerta = puerta;
            this.pm = new PisoManage();
        }

        public void Insert()
        {
            pm.insertPiso(this);
        }


        public DataTable getP()
        {
            return pm.getReportPisos();
        }

        public DataTable getMH1()
        {
            return pm.getReportMinihito1();
        }
    }
}
