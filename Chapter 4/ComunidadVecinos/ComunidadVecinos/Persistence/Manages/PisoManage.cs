using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    /// <summary>
    /// Clase de persistencia que permite la interacción entre la base
    /// de datos y el objeto Piso, haciendo posible manipular
    /// los datos relativos a esta entidad en la BBDD sin acceder
    /// directamente a la misma.
    /// </summary>
    public class PisoManage
    {
        public DataTable table { get; set; }

        /// <summary>
        /// Método que emplea una instancia del DBBroker para establecer
        /// conexión con la base de datos e insertar en la misma el objeto
        /// Piso que se esté pasando por parámetro, introduciendo en
        /// las columnas de la tabla los atributos del objeto.
        /// </summary>
        /// <param name="p">Piso a insertar.</param>
        public void insertPiso(Piso p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO APARTMENTS (ID, COMMUNITY_ID, DNI_OWNER_1, DNI_OWNER_2, DOORWAY, STAIR, FLOOR, DOOR, STORAGE_ROOM, PARKING_SPOT) VALUES (" + p.Id + "," + p.idComunidad + ",'" + p.idProp1 + "','" + p.idProp2 + "'," + p.numPortal + ",'" + p.numEscalera + "'," + p.numPlanta + ",'" + p.puerta + "'," + p.numTrastero + "," + p.numPlaza + ")");
        }

        /// <summary>
        /// Método empleado como ejemplo de generación de Crystal Reports
        /// en clase.
        /// 
        /// Método que ejecuta una consulta a la base de datos para hallar
        /// información sobre los pisos (id, portal, trastero, plaza de 
        /// parking, propietario uno y propietario dos), y tras obtenerla,
        /// crear y devolver una Data Table que contiene la información
        /// resultante de la consulta.
        /// 
        /// En primer lugar se ejecuta la consulta y se obtiene de la misma
        /// el objeto que contiene el resultado, col. Tras ello, se crea una
        /// Data Table como nueva y se le añaden seis columnas, correspondientes
        /// al número de columnas que existe en la información obtenida de la
        /// consulta a BBDD.
        /// 
        /// Tras ello, se recorre col; col se establece como lista de objetos,
        /// siendo cada objeto una fila de la consulta, pero cada uno de estos
        /// objetos (filas) se establece como otra lista de objetos, siendo cada
        /// objeto una columna de la fila de la consulta.
        /// 
        /// Se recorre col iterando por cada objeto (que es lista de objetos),
        /// se crea una fila por cada iteración y a cada columna de esta fila
        /// creada se le asigna el valor que tenga la columna de la fila de col
        /// que se esté recorriendo. Al acabar cada iteración, a la Data Table
        /// se le añade la fila creada.
        /// 
        /// Al acabar de iterar, se devuelve la Data Table.
        /// </summary>
        /// <returns>Data Table con información sobre los pisos.</returns>
        public DataTable getReportPisos()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("select ID, DOORWAY, STORAGE_ROOM, PARKING_SPOT, DNI_OWNER_1, DNI_OWNER_2 from apartments");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("ID");
            DataColumn c2 = new DataColumn("DOORWAY");
            DataColumn c3 = new DataColumn("STORAGE_ROOM");
            DataColumn c4 = new DataColumn("PARKING_SPOT");
            DataColumn c5 = new DataColumn("DNI_OWNER_1");
            DataColumn c6 = new DataColumn("DNI_OWNER_2");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);

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
                row[3] = aux[3];
                row[4] = aux[4];
                row[5] = aux[5];

                dt.Rows.Add(row);
            }

            return dt;
        }



        /// <summary>
        /// Método que ejecuta una consulta a la base de datos para hallar
        /// información sobre los pisos (de cada uno se extrae el portal,
        /// la escalera, la planta, la letra y el número de propietarios),
        /// y tras obtenerla, crear y devolver una Data Table que contiene 
        /// la información resultante de la consulta.
        /// 
        /// La consulta establecida en la sentencia select cruza las tablas
        /// Pisos y PisosPropietarios.
        /// 
        /// La obtención de información de la consulta y creación de la
        /// Data Table en base a la misma procede igual que en ocasiones
        /// anteriores.
        /// </summary>
        /// <returns>Data Table con información sobre los pisos.</returns>
        public DataTable getReportMinihito1()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("SELECT a.DOORWAY, a.STAIR, a.FLOOR, a.DOOR, count(b.ID) AS NUMBER_OF_OWNERS FROM apartments AS a JOIN apartments_owners AS b ON a.ID=b.APARTMENTS_ID group by a.DOORWAY, a.STAIR, a.FLOOR, a.DOOR");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("DOORWAY");
            DataColumn c2 = new DataColumn("STAIR");
            DataColumn c3 = new DataColumn("FLOOR");
            DataColumn c4 = new DataColumn("DOOR");
            DataColumn c5 = new DataColumn("NUMBER_OF_OWNERS");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);

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
                row[3] = aux[3];
                row[4] = aux[4];

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
