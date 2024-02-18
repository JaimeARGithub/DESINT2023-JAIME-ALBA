using ComunidadVecinos.Persistence.Manages;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    /// <summary>
    /// Clase comunidad. Será aquella que se empleará para transportar los datos
    /// de las comunidades que se introducirán en la base de datos, interactuando
    /// con la clase de persistencia ComunidadManage.
    /// </summary>
    public class Comunidad
    {
        public static int autoID = 0;
        public int Id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set;}
        public string fechaCreac { get; set; }
        public int metrosCuadrados { get; set; }
        public bool hayPiscina { get; set; }
        public int numPortales { get; set; }
        public List<Piso> listaPisos {  get; set; }
        public ComunidadManage cm { get; set; }

        // Nuevas variables: dependencias
        public bool hayPortero { get; set; }
        public bool hayDucha { get; set; }
        public bool hayJuego { get; set; }
        public bool hayEjercicio { get; set; }
        public bool haySala { get; set; }
        public bool hayTenis { get; set; }
        public bool hayPadel {  get; set; }


        /// <summary>
        /// Crea una instancia de la clase <see cref="Comunidad"/>.
        /// Crea una instancia vacía sin datos; únicamente tiene disponible
        /// el manage.
        /// </summary>
        public Comunidad()
        {
            cm = new ComunidadManage();
        }

        /// <summary>
        /// Crea una instancia de la clase <see cref="Comunidad"/>.
        /// Crea una instancia con los datos pasados por parámetro.
        /// </summary>
        /// <param name="nombre">String con el nombre de la comunidad.</param>
        /// <param name="direccion">String con la dirección de la comunidad.</param>
        /// <param name="fechaCreac">String con la fecha de creación de la comunidad.</param>
        /// <param name="metrosCuadrados">String con la superficie en metros cuadrados de la comunidad.</param>
        /// <param name="hayPiscina">Valor booleano que indica la existencia o no de piscina en la comunidad.</param>
        /// <param name="numPortales">Entero que indica el número de portales de la comunidad.</param>
        public Comunidad(string nombre, string direccion, string fechaCreac, int metrosCuadrados, bool hayPiscina, int numPortales)
        {
            this.Id = autoID++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.fechaCreac = fechaCreac;
            this.metrosCuadrados = metrosCuadrados;
            this.hayPiscina = hayPiscina;
            this.numPortales = numPortales;
            this.listaPisos = new List<Piso>();
            cm = new ComunidadManage();
        }

        /// <summary>
        /// Método que llama al método insert del manage,
        /// pasándose a sí mismo por parámetro.
        /// </summary>
        public void Insert()
        {
            cm.insertCommunity(this);
        }

        /// <summary>
        /// Método que llama al método del manage que devuelve la
        /// Data Table que contiene los datos solicitados para el
        /// minihito sobre Crystal Reports, ejercicio 2, devolviendo
        /// dicha Data Table.
        /// </summary>
        /// <returns>Data Table que contiene los datos solicitados
        /// para el ejercicio 2 del minihito sobre Crystal Reports.</returns>
        public DataTable getMH2()
        {
            return cm.getReportMinihito2();
        }
    }


}
