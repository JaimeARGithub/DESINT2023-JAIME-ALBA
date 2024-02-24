using Ejemplo.Domain;
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
using System.Windows.Shapes;

namespace Ejemplo.View
{
    /// <summary>
    /// Lógica de interacción para VentanaReports.xaml
    /// </summary>
    public partial class VentanaReports : Window
    {
        public DataTable data { get; set; }

        public VentanaReports(DataTable data)
        {
            InitializeComponent();
            this.data = data;
        }

        /// <summary>
        /// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Crv1_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = this.data;

            CrystalReport1 cr = new CrystalReport1();

            cr.Database.Tables["DATA"].SetDataSource(dt);

            Crv1.ViewerCore.ReportSource = cr;
        }
    }
}
