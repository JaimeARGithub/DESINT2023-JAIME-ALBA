using Newtonsoft.Json;
using SquidCompanyJson.Domain;
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

namespace SquidCompanyJson
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Employee employee = new Employee();

            try
            {
                employee.readE();
            }
            catch (JsonException je)
            {
                Console.WriteLine("Error al deserializar el JSON.");
            }


            dgvEmployee.ItemsSource = employee.getList();
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
        }

        private void start()
        {
            txtNIF.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtAge.Text = "";
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;

            dgvEmployee.UnselectAll();
        }

        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvEmployee.SelectedItems.Count > 0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
                Employee em = (Employee)dgvEmployee.SelectedItems[0];
                txtNIF.Text = em.nif;
                txtName.Text = em.name;
                txtSurname.Text = em.surname;
                txtAge.Text = em.age.ToString();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this employee?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Employee em = (Employee)dgvEmployee.SelectedItems[0];
                em.readE();

                em.delete();
                List<Employee> list = (List<Employee>)dgvEmployee.ItemsSource;
                list.Remove(em);

                dgvEmployee.Items.Refresh();
                dgvEmployee.ItemsSource = list;
                start();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("Do you want to add this employee?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Employee em = new Employee(txtNIF.Text, txtName.Text, txtSurname.Text, Int32.Parse(txtAge.Text));
                        em.readE();

                        em.insert();
                        ((List<Employee>)dgvEmployee.ItemsSource).Add(em);
                        dgvEmployee.Items.Refresh();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Excepción.");
                    }

                }
            }
            else // modificar
            {
                if (MessageBox.Show("Do you want to modify this employee?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (dgvEmployee.SelectedItems.Count > 0)
                    {
                        Employee em = (Employee)dgvEmployee.SelectedItems[0];
                        em.readE();

                        em.nif = txtNIF.Text;
                        em.name = txtName.Text;
                        em.surname = txtSurname.Text;
                        em.age = Int32.Parse(txtAge.Text);
                        dgvEmployee.Items.Refresh();
                        em.update();
                    }

                }
            }
            start();
        }
    }
}
