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
            cr1.Database.Tables["Apartments"].SetDataSource(dt);

            // llamo al crystal report con el nombre de la variable que le haya asignado
            // y le asigno como datos el crystal report que me he creado
            Crv1.ViewerCore.ReportSource = cr1;
        }
    }
}
