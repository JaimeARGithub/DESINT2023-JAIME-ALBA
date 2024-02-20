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
        /// <summary>
        /// AutoID que se empleará para la clase Comunidad. Es estático.
        /// Se asignará al ID del objeto y después autoincrementará cada vez que se invoque
        /// al constructor que lo utiliza.
        /// </summary>
        public static int autoID = 0;

        /// <summary>
        /// Atributo, obtención y asignación del mismo empleado para la ID asociada a cada
        /// objeto de la clase Comunidad.
        /// </summary>
        /// <value>
        /// Entero identificador de cada objeto de la clase Comunidad.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el nombre de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// String nombre del objeto Comunidad.
        /// </value>
        public string nombre { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para la dirección de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// String dirección del objeto Comunidad.
        /// </value>
        public string direccion { get; set;}

        /// <summary>
        /// Atributo, obtención y asignación para la fecha de creación de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// String fecha de creación del objeto Comunidad.
        /// </value>
        public string fechaCreac { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para los metros cuadrados (superficie) de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// Entero metros cuadrados del objeto Comunidad.
        /// </value>
        public int metrosCuadrados { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay piscina] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay piscina]; si no, <c>booleano false</c>.
        /// </value>
        public bool hayPiscina { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de portales de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// Entero número de portales del objeto Comunidad.
        /// </value>
        public int numPortales { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para la lista de pisos de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// Lista de objetos Piso asociados al objeto Comunidad.
        /// </value>
        public List<Piso> listaPisos {  get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ComunidadManage (clase de persistencia) de cada objeto Comunidad.
        /// </summary>
        /// <value>
        /// ComunidadManage (clase de persistencia para interacción con base de datos) de cada objeto Comunidad.
        /// </value>
        public ComunidadManage cm { get; set; }

        // Nuevas variables: dependencias

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay portero] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay portero]; si no, <c>false</c>.
        /// </value>
        public bool hayPortero { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay duchas comunitarias] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay duchas comunitarias]; si no, <c>booleano false</c>.
        /// </value>
        public bool hayDucha { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay zona de juego] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay zona de juego]; si no, <c>booleano false</c>.
        /// </value>
        public bool hayJuego { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay zona de ejercicio] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay zona de ejercicio]; si no, <c>booleano false</c>.
        /// </value>
        public bool hayEjercicio { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay sala social] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> if [hay sala social]; si no, <c>booleano false</c>.
        /// </value>
        public bool haySala { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay pista de tenis] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay pista de tenis]; si no, <c>booleano false</c>.
        /// </value>
        public bool hayTenis { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para ver si [hay pista de padel] o no en cada objeto Comunidad.
        /// </summary>
        /// <value>
        ///   <c>Booleano true</c> si [hay pista de padel]; si no, <c>booleano false</c>.
        /// </value>
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
