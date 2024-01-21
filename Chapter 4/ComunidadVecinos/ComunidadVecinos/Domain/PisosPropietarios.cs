using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class PisosPropietarios
    {
        public static int autoID = 0;
        public int Id { get; set; }
        public int idPiso { get; set; }
        public string idProp { get; set; }
        public PisosPropietariosManage ppm { get; set; }


        public PisosPropietarios(int idPiso, string idPropietario)
        {
            this.Id = autoID++;
            this.idPiso = idPiso;
            this.idProp = idPropietario;
            this.ppm = new PisosPropietariosManage();
        }

        public void Insert()
        {
            ppm.insertPisoProp(this);
        }
    }
}
