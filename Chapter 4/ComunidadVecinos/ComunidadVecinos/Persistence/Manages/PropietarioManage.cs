using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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


        public DataTable getDatosPropietarios()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("select DNI, NAME, SURNAMES from owners");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("DNI");
            DataColumn c2 = new DataColumn("NAME");
            DataColumn c3 = new DataColumn("SURNAMES");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            // se crea una fila, iniciada como null
            DataRow row = null;

            // se recorre la lista de objetos resultante de la consulta
            foreach (List<Object> aux in col)
            {
                // para cada fila de la consulta, se crea una nueva fila con los datos que
                // contiene la consulta inicial y se van añadiendo a la data table
                row = dt.NewRow();
                row[0] = aux[0];
                row[1] = aux[1];
                row[2] = aux[2];

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
