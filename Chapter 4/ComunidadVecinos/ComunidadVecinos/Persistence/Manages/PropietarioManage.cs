using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    public class PropietarioManage
    {
        public void insertOwner(Propietario p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO OWNERS (DNI, NAME, SURNAMES, RESIDENCE_ADDRESS, LOCALITY, POSTAL_CODE, PROVINCE) VALUES ('" + p.dni + "','" + p.nombre + "','" + p.apellidos + "','" + p.direcResidencia + "','" + p.localidad + "'," + p.codPostal + ",'" + p.provincia + "')");
        }
    }
}
