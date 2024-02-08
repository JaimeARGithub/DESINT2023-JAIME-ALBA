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
    /// Lógica de interacción para Pag2Minihito.xaml
    /// </summary>
    public partial class Pag2Minihito : Page
    {
        public Pag2Minihito()
        {
            InitializeComponent();
        }

        private void CrMini2_Loaded(object sender, RoutedEventArgs e)
        {
            // declaro objeto people
            Comunidad c = new Comunidad();

            // recupero su data table
            DataTable dt = c.getMH2();

            // inicializo un nuevo crystal report
            CrystalReport2Minihito crmh2 = new CrystalReport2Minihito();

            // al crystal report le asigno como tabla
            // (CON UN NOMBRE QUE COINCIDA EXACTO CON EL ANTERIOR QUE ME HE CREADO)
            // la data table que me acabo de recuperar
            crmh2.Database.Tables["DEPENDENCIES"].SetDataSource(dt);

            // llamo al crystal report con el nombre de la variable que le haya asignado
            // y le asigno como datos el crystal report que me he creado
            CrMini2.ViewerCore.ReportSource = crmh2;
        }
    }
}
