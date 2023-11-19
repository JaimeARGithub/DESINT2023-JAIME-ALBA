using ShoppingList.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            //para usar punto en los dobles

            Compra c = new Compra();
            c.readC();
            dgvLista.ItemsSource = c.getListCompra();

            btnNew.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled) //añade
            {
                if (txtBoxAmount.Text == "" && txtBoxPrice.Text == "" && txtBoxProduct.Text == "")
                {
                    MessageBox.Show("Por favor, rellene los campos.");
                }
                else
                {
                    try
                    {
                        Compra c = new Compra(Int32.Parse(txtBoxAmount.Text), txtBoxProduct.Text, Math.Round(Double.Parse(txtBoxPrice.Text), 2));
                        c.insert();
                        c.last();

                        ((List<Compra>)dgvLista.ItemsSource).Add(c);
                        dgvLista.Items.Refresh();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Valor numérico erróneo");
                    }
                }
            } else
            {
                if (MessageBox.Show("Do you want to modify this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (dgvLista.SelectedItems.Count > 0)
                    {

                        try
                        {
                            Compra c = (Compra)dgvLista.SelectedItems[0]; // Si selecciono varios, sólo me pone el primero; puedo poner SelectedItem
                            c.Product = txtBoxProduct.Text;
                            c.Amount = Int32.Parse(txtBoxAmount.Text);
                            c.Price = Math.Round(Double.Parse(txtBoxPrice.Text),2);
                            dgvLista.Items.Refresh();
                            c.update();
                        }
                        catch (Exception E)
                        {
                            MessageBox.Show("Valor numérico erróneo");
                        }

                    }

                }
            }
            start();
            
        }

        private void dgvLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvLista.SelectedItems.Count > 0)
            {
                btnNew.IsEnabled = true;
                btnDelete.IsEnabled = true;
                Compra c = (Compra)dgvLista.SelectedItems[0]; // Si selecciono varios, sólo me pone el primero
                txtBoxAmount.Text = c.Amount.ToString();
                txtBoxPrice.Text = c.Price.ToString();
                txtBoxProduct.Text = c.Product;

                btnSave.Content = "Modify";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Compra c = (Compra)dgvLista.SelectedItems[0];

                c.delete();
                List<Compra> list = (List<Compra>)dgvLista.ItemsSource;
                list.Remove(c);

                dgvLista.Items.Refresh();
                dgvLista.ItemsSource = list;
                start();
            }
        }

        private void start()
        {
            txtBoxAmount.Text = "";
            txtBoxPrice.Text = "";
            txtBoxProduct.Text = "";
            btnNew.IsEnabled = false;
            btnDelete.IsEnabled = false;

            dgvLista.UnselectAll();
            btnSave.Content = "Save";
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }
    }
}
