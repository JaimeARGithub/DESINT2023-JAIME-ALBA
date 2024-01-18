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

        int numStairs;
        int numFloors;
        int numDoors;

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
            FrameCommunity.UpdateLayout();
            // Acciones a ejecutar si se está en la última página
            if (cont == 0)
            {
                
                try
                {
                    // Se guardan los valores de las variables asignadas a la comunidad
                    name = paginaCom.txtName.Text.ToString();
                    address = paginaCom.txtAddress.Text.ToString();
                    surface = Double.Parse(paginaCom.txtSurface.Text.ToString());
                    numDoorways = Int32.Parse(paginaCom.txtNumDoor.Text.ToString());
                    creationDate = paginaCom.calCalendar.SelectedDate.Value.ToString("dd/MM/yyyy");

                    // Se incrementa el contador, que se empleará para determinar qué página
                    // mostrar y a qué objeto Portal acceder
                    cont++;

                    paginaPort = new PagPortal();
                    FrameCommunity.Content = paginaPort;
                    btnPrev.Visibility = Visibility.Visible;
                    paginaPort.labelPortal.Content = $"Portal {cont} de {numDoorways}";


                } catch (Exception E)
                {
                    MessageBox.Show("Error en la creación. Por favor, introduzca datos correctos.");
                }

            // Acciones a ejecutar si ya se ha pasado por todos los portales
            } else if (cont == numDoorways)
            {
                cont++;
                
                FrameCommunity.Content = paginaCom;
                paginaPort.labelPortal.Content = $"PÁGINA FINAL";
                btnNext.Content = $"FINISH";

                
            } else if (cont > numDoorways)
            // Acciones a ejecutar si se presiona FINISH
            {
                Environment.Exit(0);
            } else
            // Acciones a ejecutar si se está en la página de un portal
            {
                cont++;

                paginaPort.labelPortal.Content = $"Portal {cont} de {numDoorways}";

                try
                {

                }
                catch (Exception E)
                {
                    MessageBox.Show("Error en la creación. Por favor, introduzca datos correctos.");
                }

            }


            
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            cont--;
            // Acciones a realizar si, tras la pulsación de previous, se vuelve a la pantalla inicial
            if (cont == 0)
            {
                FrameCommunity.Content = paginaCom;
                btnPrev.Visibility = Visibility.Hidden;

            } 
            // Acciones a ejecutar si, tras la pulsación de previous, se vuelve de la página final a la de un portal
            else if (cont == numDoorways)
            {
                FrameCommunity.Content = paginaPort;
                paginaPort.labelPortal.Content = $"Portal {cont} de {numDoorways}";
                btnNext.Content = $"NEXT";
            } 
            // Acciones a ejecutar en el movimiento entre portales, de uno hacia otro, atrás
            else
            {
                paginaPort.labelPortal.Content = $"Portal {cont} de {numDoorways}";

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
