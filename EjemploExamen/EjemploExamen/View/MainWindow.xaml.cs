using EjemploExamen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EjemploExamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Product p = new Product();
            p.readP();
            dgvProducts.ItemsSource = p.getLista();
            start();
        }

        public void start()
        {
            txtAmount.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            btnDel.IsEnabled = false;
            dgvProducts.UnselectAll();

            ListTab.IsSelected = true;
        }

        private void dgvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvProducts.SelectedItems.Count > 0)
            {
                btnDel.IsEnabled = true;
                ProductsTab.IsSelected = true;
                txtAmount.Text = ((Product)dgvProducts.SelectedItems[0]).amount.ToString();
                txtProductName.Text = ((Product)dgvProducts.SelectedItems[0]).product_name;
                txtPrice.Text = ((Product)dgvProducts.SelectedItems[0]).price.ToString();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
            ProductsTab.IsSelected = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure about deleting this product?", "Confirmation", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
            {
                Product p = (Product)dgvProducts.SelectedItems[0];

                p.delete();
                ((List<Product>)dgvProducts.ItemsSource).Remove(p);
                dgvProducts.Items.Refresh();

                start();
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!btnDel.IsEnabled)
            {
                if (MessageBox.Show("Are you sure about adding this product?", "Confirmation", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
                {
                    try
                    {
                        Product p = new Product();
                        p.amount = Int32.Parse(txtAmount.Text);
                        p.product_name = txtProductName.Text;
                        p.price = Math.Round(Double.Parse(txtPrice.Text), 2, MidpointRounding.AwayFromZero);

                        p.insert();
                        p.last();


                        ((List<Product>)dgvProducts.ItemsSource).Add(p);
                        dgvProducts.Items.Refresh();

                    } catch (Exception E)
                    {
                        MessageBox.Show(E.ToString());
                    }
                }
            } else
            {
                if (MessageBox.Show("Are you sure about modifyng this product?", "Confirmation", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
                {
                    try
                    {
                        Product p = (Product)dgvProducts.SelectedItems[0];
                        p.amount = Int32.Parse(txtAmount.Text);
                        p.product_name = txtProductName.Text;
                        p.price = Math.Round(Double.Parse(txtPrice.Text), 2, MidpointRounding.AwayFromZero);

                        p.update();

                        dgvProducts.Items.Refresh();
                    } catch (Exception E)
                    {
                        MessageBox.Show(E.ToString());
                    }
                }
            }
            
            start();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (((List<Product>)dgvProducts.ItemsSource).Count > 0)
            {
                double acc = 0;

                foreach (Product p in ((List<Product>)dgvProducts.ItemsSource))
                {
                    acc = acc + Math.Round((p.amount * p.price), 2, MidpointRounding.AwayFromZero);
                }

                MessageBox.Show("The total price for the shopping list will be "+(acc).ToString()+"€");

            } else
            {
                MessageBox.Show("EMPTY LIST");
            }
        }
    }
}
