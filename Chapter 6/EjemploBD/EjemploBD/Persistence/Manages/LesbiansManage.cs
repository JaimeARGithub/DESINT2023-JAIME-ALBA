using EjemploBD.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EjemploBD.Persistence.Manages
{
    public class LesbiansManage
    {
        public List<Lesbians> listLesbians {  get; set; }


        public LesbiansManage()
        {
            listLesbians = new List<Lesbians>();
        }

        public void getAllLesbians()
        {
            List<Object> list = DBBroker.obtenerAgente().leer("select * from LESBIANS");

            foreach (List<Object> l in list)
            {
                Lesbians lesbian = new Lesbians(Int32.Parse(l[0].ToString()));
                lesbian.Name = l[1].ToString();
                lesbian.Bodycount = Int32.Parse(l[2].ToString());

                this.listLesbians.Add(lesbian);
            }
        }

        public void insertLesbian(Lesbians l)
        {
            DBBroker.obtenerAgente().modificar("INSERT INTO LESBIANS(NAME, BODYCOUNT) VALUES('"+l.Name+"', "+l.Bodycount+")");
        }

        public void lastId(Lesbians l)
        {
            List<Object> data = DBBroker.obtenerAgente().leer("select max(ID) from LESBIANS");
            foreach(List<Object> aux in data)
            {
                l.Id = Int32.Parse(aux[0].ToString());
            }
        }

        public void updateLesbian(Lesbians l)
        {
            DBBroker.obtenerAgente().modificar("update LESBIANS set NAME='"+l.Name+"', BODYCOUNT="+l.Bodycount+" WHERE ID="+l.Id);
        }

        /// <summary>
        /// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        /// </summary>
        /// <param name="l">The l.</param>
        public void deleteLesbian(Lesbians l)
        {
            DBBroker.obtenerAgente().modificar("delete from LESBIANS where ID="+l.Id);
        }


        /// <summary>
        /// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        /// </summary>
        /// <returns></returns>
        public DataTable getData()
        {
            List<Object> data = DBBroker.obtenerAgente().leer("select * from LESBIANS");

            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("ID");
            DataColumn c2 = new DataColumn("NAME");
            DataColumn c3 = new DataColumn("BODYCOUNT");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            DataRow row = null;
            foreach(List<Object> aux in data)
            {
                row = dt.NewRow();

                row[0] = Int32.Parse(aux[0].ToString());
                row[1] = aux[1].ToString();
                row[2] = Int32.Parse(aux[2].ToString());

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
