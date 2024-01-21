using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    public class PisoManage
    {
        public void insertPiso(Piso p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO APARTMENTS (ID, COMMUNITY_ID, DNI_OWNER_1, DNI_OWNER_2, DOORWAY, STAIR, FLOOR, DOOR, STORAGE_ROOM, PARKING_SPOT) VALUES (" + p.Id + "," + p.idComunidad + ",'" + p.idProp1 + "','" + p.idProp2 + "'," + p.numPortal + ",'" + p.numEscalera + "'," + p.numPlanta + ",'" + p.puerta + "'," + p.numTrastero + "," + p.numPlaza + ")");
        }
    }
}
