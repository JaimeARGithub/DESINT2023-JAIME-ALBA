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
        public static int autoID = 0;
        public int Id { get; set; }
        public int idPiso { get; set; }
        public string idProp { get; set; }
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
