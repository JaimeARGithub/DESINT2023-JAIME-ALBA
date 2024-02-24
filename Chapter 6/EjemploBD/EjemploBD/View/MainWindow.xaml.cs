using EjemploBD.Domain;
using EjemploBD.View;
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

namespace EjemploBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Lesbians yara = new Lesbians();

            dgvLesbians.ItemsSource = yara.getBolleras();
            start();
        }

        public void start()
        {
            txtName.Text = "";
            txtBodyCount.Text = "";

            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;

            dgvLesbians.UnselectAll();
        }

        private void dgvLesbians_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvLesbians.SelectedItems.Count > 0)
            {
                Lesbians l = (Lesbians)dgvLesbians.SelectedItem;
                txtName.Text = l.Name;
                txtBodyCount.Text = l.Bodycount.ToString();

                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgvLesbians.SelectedItems.Count > 0) //modificar
            {
                try
                {
                    Lesbians l = (Lesbians)dgvLesbians.SelectedItem; 
                    l.Name = txtName.Text;
                    l.Bodycount = Int32.Parse(txtBodyCount.Text);

                    l.updateL();

                    dgvLesbians.Items.Refresh();


                } catch (Exception E)
                {
                    MessageBox.Show("Asigne datos correctos para la modificación.");
                }
            } else // insertar
            {
                try
                {
                    Lesbians yara = new Lesbians((txtName.Text), (Int32.Parse(txtBodyCount.Text)));
                    yara.insertL();
                    yara.lastID();

                    ((List<Lesbians>)dgvLesbians.ItemsSource).Add(yara);
                    dgvLesbians.Items.Refresh();
                } catch (Exception E)
                {
                    MessageBox.Show("Asigne datos correctos para la inserción.");
                }
            }

            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Lesbians l = (Lesbians)dgvLesbians.SelectedItem;
            l.deleteL();
            ((List<Lesbians>)dgvLesbians.ItemsSource).Remove(l);

            dgvLesbians.Items.Refresh();

            start();
        }

        private void btnRep_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow rw = new ReportsWindow();
            rw.Show();
        }
    }
}
