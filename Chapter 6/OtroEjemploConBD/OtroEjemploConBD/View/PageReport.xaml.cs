using OtroEjemploConBD.Domain;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OtroEjemploConBD.View
{
    /// <summary>
    /// Lógica de interacción para PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        public PageReport()
        {
            InitializeComponent();
        }

        private void CRV1_Loaded(object sender, RoutedEventArgs e)
        {
            Veggies v = new Veggies();
            DataTable dt = v.getD();

            CrystalReport1 cr = new CrystalReport1();

            cr.Database.Tables["VEGGIE_DATA"].SetDataSource(dt);

            CRV1.ViewerCore.ReportSource = cr;
        }
    }
}
