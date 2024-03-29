﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComunidadVecinos.Domain
{
    /// <summary>
    /// Clase portal. No tiene relación con la base de datos, pero se emplea durante
    /// la creación de una comunidad para ir portal por portal recopilando datos para,
    /// al final del proceso, generar una serie de pisos que rellenen todos los posibles
    /// datos indicados para un portal (generando pisos para cada letra de una planta, para
    /// cada planta de una escalera y para cada escalera del portal).
    /// 
    /// No interactúa con una clase de persistencia propia, pero sí dispone de una lista
    /// de objetos piso que se rellena al invocar su método principal y que luego es
    /// proporcionada a la lista de pisos de la totalidad de la comunidad.
    /// </summary>
    public class Portal
    {
        /// <summary>
        /// AutoID que se empleará para la clase Portal. Es estático.
        /// Se asignará al ID del objeto y después autoincrementará cada vez que se invoque
        /// al constructor que lo utiliza.
        /// </summary>
        public static int autoID = 0;

        /// <summary>
        /// Atributo, obtención y asignación del mismo empleado para la ID asociada a cada
        /// objeto de la clase Portal.
        /// </summary>
        /// <value>
        /// Entero identificador de cada objeto de la clase Portal.
        /// </value>
        public int Idportal { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el ID de la comunidad de cada objeto Portal.
        /// </summary>
        /// <value>
        /// Entero ID de la comunidad del objeto Portal.
        /// </value>
        public int idComunidad {  get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de escaleras de cada objeto Portal.
        /// </summary>
        /// <value>
        /// Entero número de escaleras del objeto Portal.
        /// </value>
        public int numEscaleras { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de plantas de cada objeto Portal.
        /// </summary>
        /// <value>
        /// Entero número de plantas del objeto Portal.
        /// </value>
        public int numPlantas { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para el número de puertas de cada objeto Portal.
        /// </summary>
        /// <value>
        /// Entero número de puertas del objeto Portal.
        /// </value>
        public int numPuertas { get; set; }

        /// <summary>
        /// Atributo, obtención y asignación para la lista de pisos de cada objeto Portal.
        /// </summary>
        /// <value>
        /// Lista de objetos Piso asociados al objeto Portal.
        /// </value>
        public List<Piso> listaPisos { get; set; }

        /// <summary>
        /// Crea una instancia de la clase <see cref="Portal"/>.
        /// Crea una instancia con los datos pasados por parámetro.
        /// </summary>
        /// <param name="idCom">Entero que identifica a la comunidad para la que se está creando el portal.</param>
        /// <param name="numEscaleras">Entero que indica el número de escaleras que tendrá el portal.</param>
        /// <param name="numPlantas">Entero que indica el número de plantas que tendrá el portal.</param>
        /// <param name="numPuertas">Entero que indica el número de puertas que tendrá el portal.</param>
        public Portal(int idCom, int numEscaleras, int numPlantas, int numPuertas)
        {
            this.Idportal = autoID++;
            this.idComunidad = idCom;
            this.numEscaleras = numEscaleras;
            this.numPlantas = numPlantas;
            this.numPuertas = numPuertas;
            listaPisos = new List<Piso>();
        }

        /// <summary>
        /// Método que genera los pisos con la información obtenida sobre el portal.
        /// En primer lugar, itera por el número de escaleras indicado. Dentro de
        /// cada bucle escalera, itera por el número de plantas indicado. Dentro
        /// de cada bucle planta, itera por el número de puertas indicado. Dentro
        /// de cada iteración del bucle puertas creará un objeto piso con los
        /// siguientes datos: ID de la comunidad, ID del portal, escalera asociada,
        /// planta asociada y puerta/letra asociada.
        /// </summary>
        public void generarPisos()
        {
            for (int esc=0; esc<=numEscaleras; esc++)
            {
                for (int pla=0; pla<=numPlantas; pla++)
                {
                    for (int let=1; let<=numPuertas; let++)
                    {
                        listaPisos.Add(new Piso(idComunidad, Idportal, esc, pla, Convert.ToChar('A' + let - 1).ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// Método que muestra por pantalla una MessageBox que contiene los
        /// datos del portal creado; número de escaleras, número de plantas
        /// y número de puertas.
        /// </summary>
        public void toString()
        {
            MessageBox.Show($"Number of stairs: {numEscaleras}. Number of floors: {numPlantas}. Number of doors: {numPuertas}");
        }
    }
}
