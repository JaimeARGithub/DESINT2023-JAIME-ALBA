using EjemploCasaPartidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EjemploCasaPartidos.Persistence.Gestores
{
    class GestorPartidos
    {
        public List<Partido> listaPartidos {  get; set; }


        public GestorPartidos()
        {
            this.listaPartidos = new List<Partido>();
        }


        public void readPartido()
        {
            Partido p = null;
            List<Object> lpartido;
            lpartido = DBBroker.obtenerAgente().leer("select * from partidos order by idPartido");


            foreach (List<Object> aux in lpartido)
            {
                p = new Partido(Int32.Parse(aux[0].ToString()));
                p.nombre = aux[1].ToString();
                p.presidente = aux[2].ToString();
                p.numVotos = Int32.Parse(aux[3].ToString());

                this.listaPartidos.Add(p);
            }
        }

        public void insertPartido(Partido p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("insert into partidos(Nombre, Presidente, NumVotos) values('" + p.nombre + "','" + p.presidente + "'," + p.numVotos + ")");
            dBBroker.modificar("insert into partidos(Nombre, Presidente, NumVotos) values('" + p.nombre + "','" + p.presidente + "'," + p.numVotos + ")");
        }

        public void lastId(Partido p)
        {
            List<Object> lpartido;
            lpartido = DBBroker.obtenerAgente().leer("select MAX(idPartido) from partidos");
            foreach (List<Object> aux in lpartido)
            {
                p.Id = Convert.ToInt32(aux[0]);
            }
        }

        public void deletePartido(Partido p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("delete from partidos where idPartido=" + p.Id);
            dBBroker.modificar("delete from partidos where idPartido=" + p.Id);
        }

        public void updatePartido(Partido p)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            MessageBox.Show("update partidos set Nombre='" + p.nombre + "', Presidente='" + p.presidente + "', NumVotos=" + p.numVotos + " where idPartido=" + p.Id);
            dBBroker.modificar("update partidos set Nombre='"+p.nombre+"', Presidente='"+p.presidente+"', NumVotos="+p.numVotos+" where idPartido="+p.Id);
        }
    }
}
