using EjemploCasaPartidos.Domain;
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

namespace EjemploCasaPartidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Partido inic = new Partido();
            inic.readP();
            Console.WriteLine($"Número de partidos en la lista después de readP: {inic.getLista()?.Count}");

            dgvPartidos.ItemsSource = inic.getLista();

            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
        }

        private void start()
        {
            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;
            txtNombre.Text = "";
            txtPresidente.Text = "";
            txtNumVotos.Text = "";
            dgvPartidos.UnselectAll();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("¿Deseas añadir este partido?", "Confirmation", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    Partido p = new Partido(txtNombre.Text, txtPresidente.Text, Int32.Parse(txtNumVotos.Text));
                    p.insertar();
                    p.last();
                    ((List<Partido>)dgvPartidos.ItemsSource).Add(p);
                    dgvPartidos.Items.Refresh();
                }

            } else
            {
                if (MessageBox.Show("¿Deseas actualizar este partido?", "Confirmation", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    Partido p = (Partido)dgvPartidos.SelectedItems[0];
                    p.nombre = txtNombre.Text;
                    p.presidente = txtPresidente.Text;
                    p.numVotos = Int32.Parse(txtNumVotos.Text);

                    dgvPartidos.Items.Refresh();
                    p.update();
                }
            }

            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Quieres borrar este partido?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Partido p = (Partido)dgvPartidos.SelectedItems[0];
                p.delete();
                ((List<Partido>)dgvPartidos.ItemsSource).Remove(p);
                dgvPartidos.Items.Refresh();

                start();
            }
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
                txtNumVotos.Text = (p.numVotos).ToString();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }
    }
}
