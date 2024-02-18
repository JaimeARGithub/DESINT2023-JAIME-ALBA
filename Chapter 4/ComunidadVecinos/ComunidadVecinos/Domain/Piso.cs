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
    /// Clase pisos. Será aquella que se empleará para transportar los datos
    /// de los pisos que se introducirán en la base de datos, interactuando
    /// con la clase de persistencia PisoManage.
    /// </summary>
    public class Piso
    {
        public static int autoID = 0;
        public int Id { get; set; }
        public int idComunidad { get; set; }
        public string idProp1 { get; set; }
        public string idProp2 { get; set; }
        public int numPortal { get; set; }
        public int numEscalera { get; set; }
        public int numPlanta { get; set; }
        public string puerta { get; set; }
        public int numTrastero { get; set; }
        public int numPlaza { get; set; }
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
        /// Crea una instancia de la clase <see cref="Piso"/.
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
