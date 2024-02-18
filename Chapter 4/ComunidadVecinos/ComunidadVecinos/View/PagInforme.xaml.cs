using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComunidadVecinos.View
{
    /// <summary>
    /// Lógica de interacción para PagInforme.xaml
    /// </summary>
    public partial class PagInforme : Page
    {
        public PagInforme()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método que realiza la carga del Crystal Report.
        /// 
        /// En primer lugar, crea una instancia vacía del objeto cuyo manage
        /// nos permitirá obtener la DataTable necesaria para el Crystal Report.
        /// 
        /// Tras ello, invoca el método de obtención de la DataTable y guarda los
        /// datos obtenidos en un objeto.
        /// 
        /// Después, crea una instancia del objeto Crystal Report que hayamos designado
        /// para contener los datos obtenidos de la Data Table, debiendo coincidir
        /// la estructura de columnas del Crystal Report y de la Data Table.
        /// 
        /// Acto seguido, al objeto Crystal Report creado se le indica que usará las
        /// tablas que seleccionemos y que se hallarán en el DataSet previamente creado,
        /// y que la fuente de los datos que usará es la Data Table antes recogida.
        /// 
        /// Para finalizar, el objeto Crystal Report (ya con los datos asignados) se
        /// asigna como núcleo de vista a un elemento de interfaz Crystal Report que
        /// hayamos establecido.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">Instancia de <see cref="RoutedEventArgs"/> que contiene los datos del evento.</param>
        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            // declaro objeto piso
            Piso piso = new Piso();

            // recupero su data table
            DataTable dt = piso.getP();

            // inicializo un nuevo crystal report
            CrystalReport1 cr1 = new CrystalReport1();

            // al crystal report le asigno como tabla
            // (CON UN NOMBRE QUE COINCIDA EXACTO CON EL ANTERIOR QUE ME HE CREADO)
            // la data table que me acabo de recuperar
            cr1.Database.Tables["APARTMENTS"].SetDataSource(dt);

            // llamo al crystal report con el nombre de la variable que le haya asignado
            // y le asigno como datos el crystal report que me he creado
            Crv1.ViewerCore.ReportSource = cr1;
        }
    }
}
