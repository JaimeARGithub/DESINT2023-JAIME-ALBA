using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunidadVecinos.Persistence;
using System.Data;

namespace ComunidadVecinos.Domain
{
    /// <summary>
    /// Clase propietario. Será aquella que se empleará para transportar los datos
    /// de los propietarios que se introducirán en la base de datos, interactuando
    /// con la clase de persistencia PropietarioManage.
    /// </summary>
    public class Propietario
    {
        public string dni {  get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direcResidencia { get; set; }
        public string localidad {  get; set; }
        public int codPostal { get; set; }
        public string provincia { get; set; }

        public PropietarioManage pm { get; set; }


        private static readonly List<string> listaNombres = new List<string>
{
    "Mérida", "Alfredo", "Carlos", "Rodrigo", "Laureano", "Laura", "José María", "Mariví",
    "Joel", "Jaime", "Silvia", "Patricia", "Marta", "Diana", "Paula", "Javier", "Raquel", "Gonzalo",
    "Stacy", "Rosa", "Luis", "Raúl"
};

        private static readonly List<string> listaApellidos = new List<string>
{
    "López", "Gómez", "Sánchez", "Alba", "Toledo", "Córdoba", "Navajas", "León",
    "Vellón", "Valverde", "Serrano", "Bacho", "España", "Luque", "Maldonado",
    "Lavigne", "Blanco", "Rubio", "Ruiz", "Aparicio", "Rouse", "Estrada", "Malpartida",
    "Cafetero", "Menor", "Alarcón", "Laguna", "Ayuga", "Zapata", "Ochovo", "Gil-Ortega"
};

        private static readonly List<string> listaLocalidades = new List<string>
{
    "Madrid", "Barcelona", "Valencia", "Sevilla", "Zaragoza", "Ciudad Real", "Móstoles", "Piedrabuena",
    "Málaga", "Murcia", "Palma", "Valladolid", "Santander", "Villarrobledo", "Santa Cruz de Mudela", "Baix del Llobregat",
    "Almendralejo", "Lepe", "Alcantarilla", "Villarrubia de los Ojos", "Fuente el Fresno", "Puerto Lápice", "Arenas de San Juan",
    "Malagón", "Fuenlabrada", "Benalmádena", "Pontevedra", "Carballo", "Lugo", "Sanxenxo", "Las Labores"
};

        private static readonly List<string> listaProvincias = new List<string>
{
    "Álava", "Albacete", "Alicante", "Almería", "Asturias",
    "Ávila", "Badajoz", "Barcelona", "Burgos", "Cáceres",
    "Cádiz", "Cantabria", "Castellón", "Ciudad Real", "Córdoba",
    "Cuenca", "Gerona", "Granada", "Guadalajara", "Guipúzcoa",
    "Huelva", "Huesca", "Islas Balears", "Jaén", "La Coruña",
    "La Rioja", "Las Palmas", "León", "Lérida", "Lugo",
    "Madrid", "Málaga", "Murcia", "Navarra", "Orense",
    "Palencia", "Pontevedra", "Salamanca", "Santa Cruz de Tenerife", "Segovia",
    "Sevilla", "Soria", "Tarragona", "Teruel", "Toledo",
    "Valencia", "Valladolid", "Vizcaya", "Zamora", "Zaragoza"
};

        /// <summary>
        /// Crea una instancia de la clase <see cref="Propietario"/>.
        /// Crea una instancia vacía sin datos; únicamente tiene disponible
        /// el manage.
        /// </summary>
        public Propietario()
        {
            this.pm = new PropietarioManage();
        }

        /// <summary>
        /// Crea una instancia de la clase <see cref="Propietario"/>.
        /// Crea una instancia con los datos pasados por parámetro.
        /// El único dato pasado por parámetro es el DNI; el resto
        /// de atributos del objeto se obtienen de manera aleatoria.
        /// </summary>
        /// <param name="dniP">String que contiene el DNI que identificará al propietario.</param>
        public Propietario(string dniP)
        {
            this.dni = dniP;
            this.pm = new PropietarioManage();
            generarPropietarioAleatorio();
        }

        /// <summary>
        /// Método que, al ser invocado por un objeto de la clase Propietario,
        /// asignará a todos sus atributos valores aleatorios empleando un método
        /// de obtención aleatoria y listas de datos estáticas contenidas en el
        /// interior de la clase.
        /// </summary>
        public void generarPropietarioAleatorio()
        {
            // Generar valores aleatorios para las otras propiedades 
            Random random = new Random();
            this.nombre = ObtenerElementoAleatorio(listaNombres);
            this.apellidos = ObtenerElementoAleatorio(listaApellidos);
            this.direcResidencia = ObtenerElementoAleatorio(listaLocalidades) + ", " + RandomNumber.random_Number(1, 100);
            this.localidad = ObtenerElementoAleatorio(listaLocalidades);
            this.provincia = ObtenerElementoAleatorio(listaProvincias);
            this.codPostal = RandomNumber.random_Number(1000, 9999);
        }

        /// <summary>
        /// Método que recibe por parámetro una lista de Strings y
        /// selecciona y devuelve una String aleatoria de entre las
        /// contenidas en la lista.
        /// </summary>
        /// <param name="lista">Lista de Strings de la que se obtendrá la String aleatoria.</param>
        /// <returns>La String aleatoria seleccionada.</returns>
        private string ObtenerElementoAleatorio(List<string> lista)
        {
            Random random = new Random();
            int indice = RandomNumber.random_Number(0, lista.Count);
            return lista[indice];
        }

        /// <summary>
        /// Método que llama al método insert del manage,
        /// pasándose a sí mismo por parámetro.
        /// </summary>
        public void Insertar()
        {
            pm.insertOwner(this);
        }

        /// <summary>
        /// Método que llama al método del manage que devuelve la
        /// Data Table que contiene la información sobre los
        /// propietarios, devolviendo dicha Data Table.
        /// </summary>
        /// <returns>Data Table que contiene información sobre los propietarios.</returns>
        public DataTable getD()
        {
            return pm.getDatosPropietarios();
        }
    }
}


