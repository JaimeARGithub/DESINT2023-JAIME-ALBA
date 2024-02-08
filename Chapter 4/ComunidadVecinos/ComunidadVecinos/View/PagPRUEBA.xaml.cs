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
    /// Lógica de interacción para PagPRUEBA.xaml
    /// </summary>
    public partial class PagPRUEBA : Page
    {
        public PagPRUEBA()
        {
            InitializeComponent();
        }

        private void CrvPRUEBA_Loaded(object sender, RoutedEventArgs e)
        {
            // declaro objeto people
            Propietario prop = new Propietario();

            // recupero su data table
            DataTable dt = prop.getD();

            // inicializo un nuevo crystal report
            CrystalReportPRUEBA crPrueba = new CrystalReportPRUEBA();

            // al crystal report le asigno como tabla
            // (CON UN NOMBRE QUE COINCIDA EXACTO CON EL ANTERIOR QUE ME HE CREADO)
            // la data table que me acabo de recuperar
            crPrueba.Database.Tables["OWNERS"].SetDataSource(dt);

            // llamo al crystal report con el nombre de la variable que le haya asignado
            // y le asigno como datos el crystal report que me he creado
            CrvPRUEBA.ViewerCore.ReportSource = crPrueba;
        }
    }
}
