using OtroEjemploSinBD.Domain;
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

namespace OtroEjemploSinBD.View
{
    /// <summary>
    /// Lógica de interacción para PagReport.xaml
    /// </summary>
    public partial class PagReport : Page
    {
        DataTable dt {  get; set; }
        public PagReport(DataTable data)
        {
            InitializeComponent();
            this.dt = data;
        }

        private void CrystalReport_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable data = this.dt;
            CrystalReport1 cr1 = new CrystalReport1();

            cr1.Database.Tables["VEGGIES"].SetDataSource(data);
            CrystalReport.ViewerCore.ReportSource = cr1;
        }
    }
}
