using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComunidadVecinos.Persistence.Manages
{
    /// <summary>
    /// Clase de persistencia que permite la interacción entre la base
    /// de datos y el objeto Propietario, haciendo posible manipular
    /// los datos relativos a esta entidad en la BBDD sin acceder
    /// directamente a la misma.
    /// </summary>
    public class PropietarioManage
    {
        /// <summary>
        /// Método que emplea una instancia del DBBroker para establecer
        /// conexión con la base de datos e insertar en la misma el objeto
        /// Propietario que se esté pasando por parámetro, introduciendo en
        /// las columnas de la tabla los atributos del objeto.
        /// </summary>
        /// <param name="p">Propietario a insertar.</param>
        public void insertOwner(Propietario p)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            dbBroker.modificar("INSERT INTO OWNERS (DNI, NAME, SURNAMES, RESIDENCE_ADDRESS, LOCALITY, POSTAL_CODE, PROVINCE) VALUES ('" + p.dni + "','" + p.nombre + "','" + p.apellidos + "','" + p.direcResidencia + "','" + p.localidad + "'," + p.codPostal + ",'" + p.provincia + "')");
        }

        /// <summary>
        /// Método que ejecuta una consulta a la base de datos para hallar
        /// información sobre los propietarios, y tras obtenerla, crear y 
        /// devolver una Data Table cuyo contenido será la información 
        /// encontrada sobre los propietarios.
        /// 
        /// Dado que la consulta select solamente solicita información sobre
        /// el DNI, el nombre y los apellidos, éstos serán los datos contenidos
        /// en la Data Table que se devolverá.
        /// 
        /// La creación de la Data Table en base a los datos obtenidos de la
        /// consulta procede igual que en casos anteriores.
        /// </summary>
        /// <returns>Data Table con información sobre los propietarios.</returns>
        public DataTable getDatosPropietarios()
        {
            // hacemos la select de la info almacenada en la base de datos y la almacenamos en una lista de objetos
            List<Object> col = DBBroker.obtenerAgente().leer("select DNI, NAME, SURNAMES from owners");

            // creamos una data table, dos columnas con sus nombres y las añadimos a la data table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("DNI");
            DataColumn c2 = new DataColumn("NAME");
            DataColumn c3 = new DataColumn("SURNAMES");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            // se crea una fila, iniciada como null
            DataRow row = null;

            // se recorre la lista de objetos resultante de la consulta
            foreach (List<Object> aux in col)
            {
                // para cada fila de la consulta, se crea una nueva fila con los datos que
                // contiene la consulta inicial y se van añadiendo a la data table
                row = dt.NewRow();
                row[0] = aux[0];
                row[1] = aux[1];
                row[2] = aux[2];

                dt.Rows.Add(row);
            }

            return dt;
        }

        public void pruebill2a()
        {
            List<Object> col = DBBroker.obtenerAgente().leer("SELECT COUNT(DISTINCT A.NAME) FROM OWNERS AS A");

            foreach (List<Object> aux in col)
            {
                MessageBox.Show("There is a total of " + aux[0].ToString() +" unique names in the database.");
            }
        }

        public void pruebilla()
        {
            // Según la lógica de creación, en primer lugar se crea la lista de pisos,
            // y tras ella, una lista de propietarios con tantos elementos como elementos
            // tenga la lista de pisos
            // Pueden aparecer nombres repetidos, con lo cual el número de NOMBRES ÚNICOS
            // deberá ser MENOR O IGUAL que el número de pisos total creado
            // Y el número total de propietarios, IGUAL al número de pisos

            // Consulta para el número total de pisos
            List<Object> cons1 = DBBroker.obtenerAgente().leer("SELECT COUNT(*) FROM APARTMENTS");
            int numPisos=0;
            foreach(List<Object> aux in cons1)
            {
                numPisos = Int32.Parse(aux[0].ToString());
            }

            // Consulta para el número total de propietarios
            List<Object> cons2 = DBBroker.obtenerAgente().leer("SELECT COUNT(*) FROM OWNERS");
            int numPropietarios=0;
            foreach (List<Object> aux in cons2)
            {
                numPropietarios = Int32.Parse(aux[0].ToString());
            }

            if (numPisos == numPropietarios)
            {
                MessageBox.Show("El número de pisos ("+numPisos.ToString()+") coincide con el de propietarios ("+numPropietarios.ToString()+"). Prueba correcta.");
            } else
            {
                MessageBox.Show("El número de pisos NO coincide con el de propietarios. Prueba fallida.");
            }


            // Consulta para el número total de nombres únicos
            List<Object> cons3 = DBBroker.obtenerAgente().leer("SELECT COUNT(DISTINCT A.NAME) FROM OWNERS AS A");
            int numNomUniq = 0;
            foreach(List<Object> aux in cons3)
            {
                numNomUniq = Int32.Parse(aux[0].ToString());
            }

            if (numNomUniq <= numPisos)
            {
                MessageBox.Show("El número de nombres únicos ("+numNomUniq.ToString()+") es menor o igual que el número de pisos ("+numPisos.ToString()+"). Prueba correcta.");
            } else
            {
                MessageBox.Show("El número de nombres únicos NO es menor o igual que el número de pisos. Prueba fallida.");
            }
        }
    }
}
