using OtroEjemploSinBD.Domain;
using OtroEjemploSinBD.View;
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

namespace OtroEjemploSinBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PagData page;
        public void start()
        {
            page.txtName.Text = "";
            page.txtColor.Text = "";
            page.txtWeight.Text = "";

            page.dgvVeggies.UnselectAll();

            page.btnNew.IsEnabled = false;
            page.btnDel.IsEnabled = false;
        }

        public MainWindow()
        {
            InitializeComponent();
            page = new PagData();
            FrameVeggies.Content = page;

            start();

            Veggies v = new Veggies();
            page.dgvVeggies.ItemsSource = v.getL();
        }

        private void btnRep_Click(object sender, RoutedEventArgs e)
        {
            Veggies v = new Veggies((List<Veggies>)page.dgvVeggies.ItemsSource);

            PagReport pagReport = new PagReport(v.getD());
            FrameVeggies.Content = pagReport;
        }
    }
}
