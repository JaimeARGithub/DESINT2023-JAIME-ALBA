using ComunidadVecinos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunidadVecinos.Persistence;

namespace ComunidadVecinos.Domain
{
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



        public Propietario(string dniP)
        {
            this.dni = dniP;
            this.pm = new PropietarioManage();
            generarPropietarioAleatorio();
        }


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

        private string ObtenerElementoAleatorio(List<string> lista)
        {
            Random random = new Random();
            int indice = RandomNumber.random_Number(0, lista.Count);
            return lista[indice];
        }

        public void Insertar()
        {
            pm.insertOwner(this);
        }
    }
}


