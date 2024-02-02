using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using ExampleMVCnoDatabase.Domain;
using ExampleMVCnoDatabase.Persistence;

namespace ExampleMVCnoDatabase.Persistence.Manages
{
    internal class PeopleManage
    {
        public DataTable table { get; set; }
        public List<People> listPeople { get; set; }

        public PeopleManage()
        {
            table=new DataTable();
            listPeople=new List<People>();
        }

        public void readPeople()
        {
            People p = null;
            List<Object> lpeople;
            lpeople = DBBroker.obtenerAgente().leer("select * from People order by idPeople");
            foreach (List<Object> aux in lpeople)
            {
                p = new People(Int32.Parse(aux[0].ToString()));
                p.name = aux[1].ToString();
                p.age = Int32.Parse(aux[2].ToString());
                this.listPeople.Add(p);
            }


            /*listPeople.Add(new People("Neil",42));
            listPeople.Add(new People("Jimi", 20));
            listPeople.Add(new People("Valverde", 19));*/
        }

        public void insertPeople(People p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("insert into People(name, age) values('" + p.name + "'," + p.age + ")");
            dBBroker.modificar("insert into People(name, age) values('" + p.name + "'," + p.age + ")");
        }

        public void lastId(People p)
        {
            List<Object> lpeople;
            lpeople = DBBroker.obtenerAgente().leer("select MAX(idPeople) from People");
            foreach (List<Object> aux in lpeople)
            {
                p.Id = Convert.ToInt32(aux[0]);
            }
        }

        public void deletePeople(People p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("delete from People where idPeople=" + p.Id);
            dBBroker.modificar("delete from People where idPeople=" + p.Id);
        }

        public void updatePeople(People p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("update People set name='" + p.name + "', age=" + p.age + " where idPeople=" + p.Id);
            dBBroker.modificar("update People set name='"+p.name+"', age="+p.age+" where idPeople="+p.Id);
        }



        // Para los Crystal Reports
        public DataTable getPeople()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("select * from People order by idpeople");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("name");
            DataColumn c2 = new DataColumn("age");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);

            // se crea una fila, iniciada como null
            DataRow row = null;

            // se recorre la lista de objetos resultante de la consulta
            foreach(List<Object> aux in col)
            {
                // para cada fila de la consulta, se crea una nueva fila con los datos que
                // contiene la consulta inicial y se van añadiendo a la data table
                row = dt.NewRow();
                row[0] = aux[0];
                row[1] = aux[1];
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
