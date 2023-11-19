using EjemploCasaPartidosNBD.Domain;
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

namespace EjemploCasaPartidosNBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Partido partido = new Partido();
            partido.readP();
            dgvPartidos.ItemsSource = partido.getLista();

            start();
        }

        public void start()
        {
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
            txtNombre.Text = "";
            txtPresidente.Text = "";
            txtNumVotos.Text = "";
            dgvPartidos.UnselectAll();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void dgvPartidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPartidos.SelectedItems.Count > 0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;

                Partido p = (Partido)dgvPartidos.SelectedItems[0];
                txtNombre.Text = p.nombre;
                txtPresidente.Text = p.presidente;
                txtNumVotos.Text = p.numVotos.ToString();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Seguro?", "Confirmation", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
            {
                Partido p = (Partido)dgvPartidos.SelectedItems[0];
                ((List<Partido>)dgvPartidos.ItemsSource).Remove(p);
                dgvPartidos.Items.Refresh();

                start();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("¿Seguro de insertar este partido?", "Confirmation", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
                {
                    try
                    {
                        Partido p = new Partido();
                        p.nombre = txtNombre.Text;
                        p.presidente = txtPresidente.Text;
                        p.numVotos = Int32.Parse(txtNumVotos.Text);

                        ((List<Partido>)dgvPartidos.ItemsSource).Add(p);
                        dgvPartidos.Items.Refresh();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Ha ocurrido un problema. Introducción de datos incorrecta.");
                    }
                }
            } else
            {
                if (MessageBox.Show("¿Seguro de modificar este partido?", "Confirmation", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
                {
                    try
                    {
                        Partido p = (Partido)dgvPartidos.SelectedItems[0];
                        p.nombre = txtNombre.Text;
                        p.presidente = txtPresidente.Text;
                        p.numVotos = Int32.Parse(txtNumVotos.Text);

                        dgvPartidos.Items.Refresh();
                    } catch (Exception E)
                    {
                        MessageBox.Show("Ha ocurrido un problema. Introducción de datos incorrecta.");
                    }
                }
            }

            start();
        }
    }
}
