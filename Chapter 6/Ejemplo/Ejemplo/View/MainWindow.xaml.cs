using Ejemplo.Domain;
using Ejemplo.View;
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

namespace Ejemplo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Players p = new Players();
            dgvPlayers.ItemsSource = p.readP();

            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;
        }

        private void dgvPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPlayers.SelectedItems.Count > 0)
            {
                Players p = (Players)dgvPlayers.SelectedItem;
                txtDni.Text = p.DNI;
                txtName.Text = p.Name;
                txtSur.Text = p.Surnames;
                txtPos.Text = p.Position;
                txtAge.Text = p.Age.ToString();

                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtDni.Text = "";
            txtName.Text = "";
            txtSur.Text = "";
            txtPos.Text = "";
            txtAge.Text = "";
            dgvPlayers.UnselectAll();

            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Players p = (Players)dgvPlayers.SelectedItems[0];
                ((List<Players>)dgvPlayers.ItemsSource).Remove(p);
                dgvPlayers.Items.Refresh();

                txtDni.Text = "";
                txtName.Text = "";
                txtSur.Text = "";
                txtPos.Text = "";
                txtAge.Text = "";

                btnNew.IsEnabled = false;
                btnDel.IsEnabled = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgvPlayers.SelectedItems.Count > 0) // modificar
            {
                try
                {
                    Players p = (Players)dgvPlayers.SelectedItems[0];
                    p.DNI = txtDni.Text;
                    p.Name = txtName.Text;
                    p.Surnames = txtSur.Text;
                    p.Position = txtPos.Text;
                    p.Age = Int32.Parse(txtAge.Text);

                } catch (Exception E)
                {
                    MessageBox.Show("Insert correct data.");
                }
            } else // añadir
            {
                try
                {
                    Players p = new Players(txtDni.Text, txtName.Text, txtSur.Text, txtPos.Text, Int32.Parse(txtAge.Text));

                    ((List<Players>)dgvPlayers.ItemsSource).Add(p);

                }
                catch (Exception E)
                {
                    MessageBox.Show("Insert correct data.");
                }
            }

            dgvPlayers.Items.Refresh();

            txtDni.Text = "";
            txtName.Text = "";
            txtSur.Text = "";
            txtPos.Text = "";
            txtAge.Text = "";
            dgvPlayers.UnselectAll();

            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;
        }

        private void btnRep_Click(object sender, RoutedEventArgs e)
        {
            Players pData = new Players((List<Players>)dgvPlayers.ItemsSource);


            VentanaReports vr = new VentanaReports(pData.getD());
            vr.Show();
        }

        private void btnWbt_Click(object sender, RoutedEventArgs e)
        {
            Players pTest = new Players((List<Players>)dgvPlayers.ItemsSource);
            pTest.getWBT();
        }
    }
}
