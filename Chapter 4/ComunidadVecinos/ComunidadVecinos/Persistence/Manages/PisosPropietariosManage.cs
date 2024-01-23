using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    public class PisosPropietariosManage
    {
        public void insertPisoProp(PisosPropietarios p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO APARTMENTS_OWNERS (APARTMENTS_ID, OWNERS_DNI, ID) VALUES (" + p.idPiso + ",'" + p.idProp + "'," + p.Id + ")");
        }
    }
}
