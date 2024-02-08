using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Persistence.Manages
{
    public class ComunidadManage
    {

        public DataTable table { get; set; }

        public void insertCommunity(Comunidad c)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO COMMUNITIES (ID, NAME, ADDRESS, DATE_OF_CREATION, SURFACE, SWIMMING_POOL, NUMBER_OF_DOORWAYS, GATEKEEPER_APARTMENT, SHOWERS_AND_TOILETS, PLAY_AREA, EXERCISE_AREA, SOCIAL_ROOM, TENNIS_COURT, PADEL_COURT) VALUES (" + c.Id + ",'" + c.nombre + "','" + c.direccion + "','" + c.fechaCreac + "'," + c.metrosCuadrados + "," + c.hayPiscina + ", " + c.numPortales + ", " + c.hayPortero + ", " + c.hayDucha + ", " + c.hayJuego + ", " + c.hayEjercicio + ", " + c.haySala + ", " + c.hayTenis + ", " + c.hayPadel + ")");
        }


        public DataTable getReportMinihito2()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("SELECT GATEKEEPER_APARTMENT, SHOWERS_AND_TOILETS, PLAY_AREA, EXERCISE_AREA, SOCIAL_ROOM, TENNIS_COURT, PADEL_COURT FROM communities");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("DATA");

            dt.Columns.Add(c1);

            // se crea una fila, iniciada como null
            DataRow row = null;


            if ((bool) col[0]==true)
            {
                row = dt.NewRow();
                row[0] = "GATEKEEPER_APARTMENT";
                dt.Rows.Add(row);
            }


            if ((bool)col[1] == true)
            {
                row = dt.NewRow();
                row[0] = "SHOWERS_AND_TOILETS";
                dt.Rows.Add(row);
            }

            if ((bool)col[2] == true)
            {
                row = dt.NewRow();
                row[0] = "PLAY_AREA";
                dt.Rows.Add(row);
            }

            if ((bool)col[3] == true)
            {
                row = dt.NewRow();
                row[0] = "EXERCISE_AREA";
                dt.Rows.Add(row);
            }

            if ((bool)col[4] == true)
            {
                row = dt.NewRow();
                row[0] = "SOCIAL_ROOM";
                dt.Rows.Add(row);
            }

            if ((bool)col[5] == true)
            {
                row = dt.NewRow();
                row[0] = "TENNIS_COURT";
                dt.Rows.Add(row);
            }

            if ((bool)col[6] == true)
            {
                row = dt.NewRow();
                row[0] = "PADEL_COURT";
                dt.Rows.Add(row);
            }


            return dt;
        }
    }
}
