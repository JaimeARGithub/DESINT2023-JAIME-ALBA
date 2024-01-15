using ComunidadVecinos.Domain;
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

namespace ComunidadVecinos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PagComunidad paginaCom;
        PagPortal paginaPort;
        int cont;

        string name;
        string address;
        double surface;
        int numDoorways;
        bool isSwimPool;
        string creationDate;

        public MainWindow()
        {
            InitializeComponent();
            cont = 0;

            paginaCom = new PagComunidad();
            FrameCommunity.Content = paginaCom;

            btnPrev.Visibility = Visibility.Hidden;
            FrameCommunity.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (cont == 0)
            {
                
                try
                {
                    name = paginaCom.txtName.Text.ToString();
                    address = paginaCom.txtAddress.Text.ToString();
                    surface = Double.Parse(paginaCom.txtSurface.Text.ToString());
                    numDoorways = Int32.Parse(paginaCom.txtNumDoor.Text.ToString());
                    creationDate = paginaCom.calCalendar.SelectedDate.Value.ToString("dd/MM/yyyy");

                    cont++;

                    paginaPort = new PagPortal();
                    FrameCommunity.Content = paginaPort;
                    btnPrev.Visibility = Visibility.Visible;

                } catch (Exception E)
                {
                    MessageBox.Show("Error en la creación. Por favor, introduzca datos correctos.");
                }

            } else
            {
                
            }


            
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            cont--;

            if (cont == 0)
            {
                FrameCommunity.Content = paginaCom;
                btnPrev.Visibility = Visibility.Hidden;

            } else
            {

            }
        }

        private void btnYes_Checked(object sender, RoutedEventArgs e)
        {
            isSwimPool = true;
            paginaCom.btnNo.IsChecked = false;
        }

        private void btnNo_Checked(object sender, RoutedEventArgs e)
        {
            isSwimPool = false;
            paginaCom.btnNo.IsChecked = false;
        }
    }
}
