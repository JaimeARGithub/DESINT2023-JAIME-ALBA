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
    /// Lógica de interacción para Pag1Minihito.xaml
    /// </summary>
    public partial class Pag1Minihito : Page
    {
        public Pag1Minihito()
        {
            InitializeComponent();
        }

        private void CrMini1_Loaded(object sender, RoutedEventArgs e)
        {
            // declaro objeto people
            Piso p = new Piso();

            // recupero su data table
            DataTable dt = p.getMH1();

            // inicializo un nuevo crystal report
            CrystalReport1Minihito crmh1 = new CrystalReport1Minihito();

            // al crystal report le asigno como tabla
            // (CON UN NOMBRE QUE COINCIDA EXACTO CON EL ANTERIOR QUE ME HE CREADO)
            // la data table que me acabo de recuperar
            crmh1.Database.Tables["NEIGHBORHOOD"].SetDataSource(dt);

            // llamo al crystal report con el nombre de la variable que le haya asignado
            // y le asigno como datos el crystal report que me he creado
            CrMini1.ViewerCore.ReportSource = crmh1;
        }
    }
}
