using OtroEjemploConBD.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtroEjemploConBD.Persistence.Manages
{
    public class VeggiesManage
    {
        public List<Veggies> listVeggies { get; set; }


        public VeggiesManage()
        {
            this.listVeggies = new List<Veggies>();
        }

        public void readAllVeggies()
        {
            List<Object> data = DBBroker.obtenerAgente().leer("select * from VEGGIES");

            foreach(List<Object> aux in data)
            {
                Veggies v = new Veggies();
                v.Id = Int32.Parse(aux[0].ToString());
                v.Name = aux[1].ToString();
                v.Color = aux[2].ToString();
                v.Weight = Int32.Parse(aux[3].ToString());

                listVeggies.Add(v);
            }
        }

        public void deleteVeggie(Veggies v)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM VEGGIES WHERE ID=" + v.Id);
        }

        public void insertVeggie(Veggies v)
        {
            DBBroker.obtenerAgente().modificar("INSERT INTO VEGGIES(NAME, COLOR, WEIGHT) VALUES('"+v.Name+"', '"+v.Color+"', "+v.Weight+")");
        }

        /// <summary>
        /// Método que selecciona de la base de datos la ID máxima existente y se la asigna al Veggie enviado por parámetro.
        /// </summary>
        /// <param name="v">El veggie cuya ID se asigna a la máxima existente en la base de datos.</param>
        public void selectMaxID(Veggies v)
        {
            List<Object> data = DBBroker.obtenerAgente().leer("SELECT MAX(ID) FROM VEGGIES");

            foreach (List<Object> aux in data)
            {
                v.Id = Int32.Parse(aux[0].ToString());
            }
        }

        /// <summary>
        /// Método que envía por parámetro un objeto Veggie y actualiza sus campos en la base de datos.
        /// </summary>
        /// <param name="v">El Veggie a actualizar..</param>
        public void updateVeggie(Veggies v)
        {
            DBBroker.obtenerAgente().modificar("UPDATE VEGGIES SET NAME='"+v.Name+"', COLOR='"+v.Color+"', WEIGHT="+v.Weight+" WHERE ID=" + v.Id);
        }

        public DataTable getData()
        {
            List<Object> data = DBBroker.obtenerAgente().leer("SELECT MIN(WEIGHT), MAX(WEIGHT), AVG(WEIGHT) FROM VEGGIES");

            DataTable dt = new DataTable();

            DataColumn c1 = new DataColumn("MIN_WEIGHT");
            DataColumn c2 = new DataColumn("MAX_WEIGHT");
            DataColumn c3 = new DataColumn("AVERAGE_WEIGHT");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            DataRow row = null;

            foreach(List<Object> aux in data)
            {
                row = dt.NewRow();

                row[0] = Int32.Parse(aux[0].ToString());
                row[1] = Int32.Parse(aux[1].ToString());
                row[2] = Double.Parse(aux[2].ToString());

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
