using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComunidadVecinos.Persistence.Manages
{
    /// <summary>
    /// Clase de persistencia que permite la interacción entre la base
    /// de datos y el objeto Comunidad, haciendo posible manipular
    /// los datos relativos a esta entidad en la BBDD sin acceder
    /// directamente a la misma.
    /// </summary>
    public class ComunidadManage
    {

        public DataTable table { get; set; }

        /// <summary>
        /// Método que emplea una instancia del DBBroker para establecer
        /// conexión con la base de datos e insertar en la misma el objeto
        /// Comunidad que se esté pasando por parámetro, introduciendo en
        /// las columnas de la tabla los atributos del objeto.
        /// </summary>
        /// <param name="c">Comunidad a insertar.</param>
        public void insertCommunity(Comunidad c)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO COMMUNITIES (ID, NAME, ADDRESS, DATE_OF_CREATION, SURFACE, SWIMMING_POOL, NUMBER_OF_DOORWAYS, GATEKEEPER_APARTMENT, SHOWERS_AND_TOILETS, PLAY_AREA, EXERCISE_AREA, SOCIAL_ROOM, TENNIS_COURT, PADEL_COURT) VALUES (" + c.Id + ",'" + c.nombre + "','" + c.direccion + "','" + c.fechaCreac + "'," + c.metrosCuadrados + "," + c.hayPiscina + ", " + c.numPortales + ", " + c.hayPortero + ", " + c.hayDucha + ", " + c.hayJuego + ", " + c.hayEjercicio + ", " + c.haySala + ", " + c.hayTenis + ", " + c.hayPadel + ")");
        }

        /// <summary>
        /// Método que ejecuta una consulta a la base de datos para hallar
        /// información sobre las dependencias de la en teoría única comunidad
        /// existente, y tras obtenerla, crear y devolver una Data Table cuyo
        /// contenido varía en función de la información encontrada sobre las
        /// dependencias de la comunidad.
        /// 
        /// El objeto obtenido con la sentencia select es col; se compone como una
        /// lista de objetos al tratarse de una consulta que puede devolver varias
        /// filas (cada fila es un objeto), y cada fila a su vez se compone como una
        /// lista de objetos al poseer cada fila varias columnas (cada columna es
        /// un objeto), con lo que, si col es una lista de objetos (filas), cada uno
        /// de estos objetos es también una lista de objetos (columnas).
        /// </summary>
        /// <returns>Data Table con información sobre las dependencias de la comunidad.</returns>
        public DataTable getReportMinihito2()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("SELECT GATEKEEPER_APARTMENT, SHOWERS_AND_TOILETS, PLAY_AREA, EXERCISE_AREA, SOCIAL_ROOM, TENNIS_COURT, PADEL_COURT from communities");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("DATA");

            dt.Columns.Add(c1);

            // se crea una fila, iniciada como null
            DataRow row = null;


            foreach(List<Object> aux in col)
            {
                if (Int32.Parse(aux[0].ToString())==1)
                {
                    row = dt.NewRow();
                    row[0] = "GATEKEEPER_APARTMENT";
                    dt.Rows.Add(row);
                }

                if (Int32.Parse(aux[1].ToString()) == 1)
                {
                    row = dt.NewRow();
                    row[0] = "SHOWERS_AND_TOILETS";
                    dt.Rows.Add(row);
                }

                if (Int32.Parse(aux[2].ToString()) == 1)
                {
                    row = dt.NewRow();
                    row[0] = "PLAY_AREA";
                    dt.Rows.Add(row);
                }

                if (Int32.Parse(aux[3].ToString()) == 1)
                {
                    row = dt.NewRow();
                    row[0] = "EXERCISE_AREA";
                    dt.Rows.Add(row);
                }

                if (Int32.Parse(aux[4].ToString()) == 1)
                {
                    row = dt.NewRow();
                    row[0] = "SOCIAL_ROOM";
                    dt.Rows.Add(row);
                }

                if (Int32.Parse(aux[5].ToString()) == 1)
                {
                    row = dt.NewRow();
                    row[0] = "TENNIS_COURT";
                    dt.Rows.Add(row);
                }

                if (Int32.Parse(aux[6].ToString()) == 1)
                {
                    row = dt.NewRow();
                    row[0] = "PADEL_COURT";
                    dt.Rows.Add(row);
                }
            }


            return dt;
        }
    }
}
