using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    /// <summary>
    /// Clase piso. Será aquella que se empleará para transportar los datos
    /// de los pisos que se introducirán en la base de datos, interactuando
    /// con la clase de persistencia PisoManage.
    /// </summary>
    public class Piso
    {
        /// <summary>
        /// AutoID que se empleará para la clase Piso. Es estático.
        /// Se asignará al ID del objeto y después autoincrementará cada vez que se invoque
        /// al constructor que lo utiliza.
        /// </summary>
        public static int autoID = 0;

        /// <summary>
        /// Atributo, obtención y asignación del mismo empleado para la ID asociada a cada
        /// objeto de la clase Piso.
        /// </summary>
        /// <value>
        /// Entero identificador de cada objeto de la clase Piso.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ID de la comunidad de cada objeto Piso.
        /// </summary>
        /// <value>
        /// Entero identificador de la comunidad del objeto Piso.
        /// </value>
        public int idComunidad { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ID del propietario 1 de cada objeto Piso.
        /// </summary>
        /// <value>
        /// String ID del propietario 1 del objeto Piso.
        /// </value>
        public string idProp1 { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ID del propietario 2 de cada objeto Piso.
        /// </summary>
        /// <value>
        /// String ID del propietario 2 del objeto Piso.
        /// </value>
        public string idProp2 { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de portal de cada objeto Piso.
        /// </summary>
        /// <value>
        /// Entero número de portal del objeto Piso.
        /// </value>
        public int numPortal { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de escalera de cada objeto Piso.
        /// </summary>
        /// <value>
        /// Entero número de escalera del objeto Piso.
        /// </value>
        public int numEscalera { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de planta de cada objeto Piso.
        /// </summary>
        /// <value>
        /// Entero número de planta del objeto Piso.
        /// </value>
        public int numPlanta { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para la letra de la puerta de cada objeto Piso.
        /// </summary>
        /// <value>
        /// String letra de la puerta del objeto Piso.
        /// </value>
        public string puerta { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de trastero de cada objeto Piso.
        /// </summary>
        /// <value>
        /// Entero número de trastero del objeto Piso.
        /// </value>
        public int numTrastero { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de plaza de garaje de cada objeto Piso.
        /// </summary>
        /// <value>
        /// Entero número de plaza de garaje del objeto Piso.
        /// </value>
        public int numPlaza { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el PisoManage (clase de persistencia) de cada objeto Piso.
        /// </summary>
        /// <value>
        /// PisoManage (clase de persistencia para interacción con base de datos) de cada objeto Piso.
        /// </value>
        public PisoManage pm { get; set; }

        /// <summary>
        /// Crea una instancia de la clase <see cref="Piso"/>.
        /// Crea una instancia vacía sin datos; únicamente tiene disponible
        /// el manage.
        /// </summary>
        public Piso()
        {
            this.pm = new PisoManage();
        }

        /// <summary>
        /// Crea una instancia de la clase <see cref="Piso"/>.
        /// Crea una instancia con los datos pasados por parámetro.
        /// </summary>
        /// <param name="idComunidad">Entero con el identificador de la comunidad asociada al piso.</param>
        /// <param name="numPortal">Entero con el número de portal asociado al piso.</param>
        /// <param name="numEscalera">Entero con el número de escalera asociada al piso.</param>
        /// <param name="numPlanta">Entero con el número de planta asociada al piso.</param>
        /// <param name="puerta">String que contiene la letra/puerta asociada al piso.</param>
        public Piso(int idComunidad,  int numPortal, int numEscalera, int numPlanta, string puerta)
        {
            this.Id = autoID++;
            this.idComunidad = idComunidad;
            this.numPortal = numPortal;
            this.numEscalera = numEscalera;
            this.numPlanta = numPlanta;
            this.puerta = puerta;
            this.pm = new PisoManage();
        }

        /// <summary>
        /// Método que llama al método insert del manage,
        /// pasándose a sí mismo por parámetro.
        /// </summary>
        public void Insert()
        {
            pm.insertPiso(this);
        }

        /// <summary>
        /// Método que llama al método del manage que devuelve la
        /// Data Table que contiene los datos solicitados para el
        /// primer ejemplo sobre Crystal Reports visto en clase,
        /// devolviendo dicha Data Table.
        /// </summary>
        /// <returns>Data Table que contiene los datos solicitados
        /// para el primer ejemplo sobre Crystal Reports visto en clase.</returns>
        public DataTable getP()
        {
            return pm.getReportPisos();
        }

        /// <summary>
        /// Método que llama al método del manage que devuelve la
        /// Data Table que contiene los datos solicitados para el
        /// minihito sobre Crystal Reports, ejercicio 1, devolviendo
        /// dicha Data Table.
        /// </summary>
        /// <returns>Data Table que contiene los datos solicitados
        /// para el ejercicio 1 del minihito sobre Crystal Reports.</returns>
        public DataTable getMH1()
        {
            return pm.getReportMinihito1();
        }
    }
}
