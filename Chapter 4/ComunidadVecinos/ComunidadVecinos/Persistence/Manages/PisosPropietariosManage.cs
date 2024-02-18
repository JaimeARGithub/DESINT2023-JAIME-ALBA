using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    /// <summary>
    /// Clase de persistencia que permite la interacción entre la base
    /// de datos y el objeto PisosPropietarios, haciendo posible manipular
    /// los datos relativos a esta entidad en la BBDD sin acceder
    /// directamente a la misma.
    /// </summary>
    public class PisosPropietariosManage
    {
        /// <summary>
        /// Método que emplea una instancia del DBBroker para establecer
        /// conexión con la base de datos e insertar en la misma el objeto
        /// PisosPropietarios que se esté pasando por parámetro, 
        /// introduciendo en las columnas de la tabla los atributos del objeto.
        /// </summary>
        /// <param name="p">PisosPropietarios a insertar.</param>
        public void insertPisoProp(PisosPropietarios p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO APARTMENTS_OWNERS (APARTMENTS_ID, OWNERS_DNI, ID) VALUES (" + p.idPiso + ",'" + p.idProp + "'," + p.Id + ")");
        }
    }
}
