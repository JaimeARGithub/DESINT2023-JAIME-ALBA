using OtroEjemploConBD.View;
using System;
using System.Collections.Generic;
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

namespace OtroEjemploConBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PageData page;
        public MainWindow()
        {
            InitializeComponent();
            page = new PageData();
            FrameVeggies.Content = page;
        }

        private void btnRep_Click(object sender, RoutedEventArgs e)
        {
            PageReport pageData = new PageReport();
            FrameVeggies.Content = pageData;
        }
    }
}
