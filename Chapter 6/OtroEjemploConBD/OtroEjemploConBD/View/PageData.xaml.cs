using OtroEjemploConBD.Domain;
using OtroEjemploConBD.Persistence;
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

namespace OtroEjemploConBD.View
{
    /// <summary>
    /// Lógica de interacción para PageData.xaml
    /// </summary>
    public partial class PageData : Page
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

        public PageData()
        {
            InitializeComponent();

            start();

            Veggies v = new Veggies();
            v.readV();
            dgvVeggies.ItemsSource = v.getV();
        }

        private void dgvVeggies_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgvVeggies.SelectedItems.Count > 0)
            {
                Veggies v = (Veggies)dgvVeggies.SelectedItem;

                txtName.Text = v.Name;
                txtColor.Text = v.Color;
                txtWeight.Text = v.Weight.ToString();

                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure about deleting this veggie?", "ARE YOU SURE?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Veggies v = (Veggies)dgvVeggies.SelectedItem;

                v.deleteV();
                ((List<Veggies>)dgvVeggies.ItemsSource).Remove(v);

                dgvVeggies.Items.Refresh();

                start();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgvVeggies.SelectedItems.Count > 0) // modificar
            {
                try
                {
                    Veggies v = (Veggies)dgvVeggies.SelectedItem;

                    v.Name = txtName.Text;
                    v.Color = txtColor.Text;
                    v.Weight = Int32.Parse(txtWeight.Text);

                    v.updateV();

                    dgvVeggies.Items.Refresh();

                } catch (Exception E)
                {
                    MessageBox.Show("Failure during insertion.");
                }
            } else // insertar
            {
                try
                {
                    Veggies v = new Veggies(txtName.Text, txtColor.Text, Int32.Parse(txtWeight.Text));

                    v.insertV();
                    v.lastId();

                    ((List<Veggies>)dgvVeggies.ItemsSource).Add(v);
                } catch (Exception E)
                {
                    MessageBox.Show("Failure during insertion.");
                }
            }

            dgvVeggies.Items.Refresh();
            start();
        }

        
    }
}
