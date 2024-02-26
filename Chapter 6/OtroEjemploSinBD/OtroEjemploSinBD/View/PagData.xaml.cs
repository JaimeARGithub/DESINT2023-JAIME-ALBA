using OtroEjemploSinBD.Domain;
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

namespace OtroEjemploSinBD.View
{
    /// <summary>
    /// Lógica de interacción para PagData.xaml
    /// </summary>
    public partial class PagData : Page
    {
        public void start()
        {
            txtName.Text = "";
            txtColor.Text = "";
            txtWeight.Text = "";

            dgvVeggies.UnselectAll();

            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;
        }

        public PagData()
        {
            InitializeComponent();
        }

        private void dgvVeggies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvVeggies.SelectedItems.Count > 0)
            {
                Veggies v = (Veggies)dgvVeggies.SelectedItem;
                
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;

                txtName.Text = v.Name;
                txtColor.Text = v.Color;
                txtWeight.Text = v.Weight.ToString();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgvVeggies.SelectedItems.Count == 0) // insertar
            {

                try
                {
                    Veggies v = new Veggies(txtName.Text, txtColor.Text, Int32.Parse(txtWeight.Text));
                    ((List<Veggies>)dgvVeggies.ItemsSource).Add(v);
                    dgvVeggies.Items.Refresh();

                } catch (Exception E)
                {
                    MessageBox.Show("Fallo durante la inserción.");
                }

            } else // modificar
            {

                try
                {
                    Veggies v = (Veggies)dgvVeggies.SelectedItem;
                    v.Name = txtName.Text;
                    v.Color = txtColor.Text;
                    v.Weight = Int32.Parse(txtWeight.Text);
                    dgvVeggies.Items.Refresh();
                }
                catch (Exception E)
                {
                    MessageBox.Show("Fallo durante la modificación.");
                }

            }

            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Quieres borrar este VEGETAL?", "Confirmation", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Veggies v = (Veggies)dgvVeggies.SelectedItem;
                ((List<Veggies>)dgvVeggies.ItemsSource).Remove(v);

                dgvVeggies.Items.Refresh();
                start();
            }
        }
    }
}
