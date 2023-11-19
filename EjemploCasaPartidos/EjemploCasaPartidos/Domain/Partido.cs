using EjemploCasaPartidos.Persistence.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploCasaPartidos.Domain
{
    class Partido
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string presidente { get; set; }
        public int numVotos { get; set; }
        public GestorPartidos gp {  get; set; }


        public Partido ()
        {
            this.gp = new GestorPartidos ();
        }

        public Partido (int id)
        {
            this.Id = id;
            this.gp = new GestorPartidos();
        }

        public Partido (string nom, string pres, int numVot)
        {
            this.nombre = nom;
            this.presidente = pres;
            this.numVotos = numVot;
            this.gp = new GestorPartidos();
        }

        public void readP()
        {
            gp.readPartido();
        }

        public List<Partido> getLista()
        {
            return gp.listaPartidos;
        }

        public void insertar()
        {
            gp.insertPartido(this);
        }

        public void last()
        {
            gp.lastId(this);
        }

        public void delete()
        {
            gp.deletePartido(this);
        }

        public void update()
        {
            gp.updatePartido(this);
        }
    }

}
