using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    public class ComunidadManage
    {
        public void insertCommunity(Comunidad c)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO COMMUNITIES (ID, NAME, ADDRESS, DATE_OF_CREATION, SURFACE, SWIMMING_POOL, NUMBER_OF_DOORWAYS) VALUES (" + c.Id + ",'" + c.nombre + "','" + c.direccion + "','" + c.fechaCreac + "'," + c.metrosCuadrados + "," + c.hayPiscina + ", " + c.numPortales +")");
        }
    }
}
