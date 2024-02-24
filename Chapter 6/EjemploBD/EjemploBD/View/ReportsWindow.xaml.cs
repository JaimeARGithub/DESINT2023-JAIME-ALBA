using EjemploBD.Domain;
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

namespace EjemploBD.View
{
    /// <summary>
    /// Lógica de interacción para ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void CR_Loaded(object sender, RoutedEventArgs e)
        {
            Lesbians l = new Lesbians();
            DataTable data = l.getD();

            CrystalReport1 cr1 = new CrystalReport1();

            cr1.Database.Tables["LESBIAN_DATA"].SetDataSource(data);

            CR.ViewerCore.ReportSource = cr1;
        }
    }
}
