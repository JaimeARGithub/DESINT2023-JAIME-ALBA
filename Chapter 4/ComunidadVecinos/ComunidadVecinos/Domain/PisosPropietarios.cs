using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    /// <summary>
    /// Clase PisosPropietarios. Será aquella que se empleará para transportar los datos
    /// de los PisosPropietarios que se introducirán en la base de datos, interactuando
    /// con la clase de persistencia PisosPropietariosManage.
    /// Es la clase que transporta datos hacia la tabla intermedia, resultante de la relación
    /// N:M, que recoge cada posible relación entre cada propietario y su/s piso.
    /// </summary>
    public class PisosPropietarios
    {
        /// <summary>
        /// AutoID que se empleará para la clase PisosPropietarios. Es estático.
        /// Se asignará al ID del objeto y después autoincrementará cada vez que se invoque
        /// al constructor que lo utiliza.
        /// </summary>
        public static int autoID = 0;

        /// <summary>
        /// Atributo, obtención y asignación del mismo empleado para la ID asociada a cada
        /// objeto de la clase PisosPropietarios.
        /// </summary>
        /// <value>
        /// Entero identificador de cada objeto de la clase PisosPropietarios.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ID del piso de cada objeto PisosPropietarios.
        /// </summary>
        /// <value>
        /// Entero identificador del ID del piso del objeto PisosPropietarios.
        /// </value>
        public int idPiso { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ID del propietario de cada objeto PisosPropietarios.
        /// </summary>
        /// <value>
        /// String identificador del ID del propietario del objeto PisosPropietarios.
        /// </value>
        public string idProp { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el PisosPropietariosManage (clase de persistencia) de cada objeto PisosPropietarios.
        /// </summary>
        /// <value>
        /// PisosPropietariosManage (clase de persistencia para interacción con base de datos) de cada objeto PisosPropietarios.
        /// </value>
        public PisosPropietariosManage ppm { get; set; }

        /// <summary>
        /// Crea una instancia de la clase <see cref="PisosPropietarios"/>.
        /// Crea una instancia con los datos pasados por parámetro.
        /// </summary>
        /// <param name="idPiso">Entero con el que se identifica al piso asociado al registro.</param>
        /// <param name="idPropietario">Entero con el que se identifica al propietario asociado al registro.</param>
        public PisosPropietarios(int idPiso, string idPropietario)
        {
            this.Id = autoID++;
            this.idPiso = idPiso;
            this.idProp = idPropietario;
            this.ppm = new PisosPropietariosManage();
        }

        /// <summary>
        /// Método que llama al método insert del manage,
        /// pasándose a sí mismo por parámetro.
        /// </summary>
        public void Insert()
        {
            ppm.insertPisoProp(this);
        }
    }
}
