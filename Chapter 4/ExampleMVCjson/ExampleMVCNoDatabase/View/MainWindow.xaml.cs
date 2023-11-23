using ExampleMVCnoDatabase.Domain;
using Newtonsoft.Json;
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

namespace ExampleMVCnoDatabase
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            People people = new People();
            
            try
            {
                people.readP();
            } catch (JsonException je)
            {
                Console.WriteLine("Error al deserializar el JSON.");
            }


            dgvPeople.ItemsSource = people.getListPeople();
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;
        }

        private void start()
        {
            txtName.Text = "";
            txtAge.Text = "";
            btnDel.IsEnabled = false;
            btnNew.IsEnabled = false;

            dgvPeople.UnselectAll();
        }

        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPeople.SelectedItems.Count>0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
                People p = (People)dgvPeople.SelectedItems[0];
                txtName.Text = p.name;
                txtAge.Text = p.age.ToString();
            }
            
        }


        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this person?","Confirmation",MessageBoxButton.YesNo)==MessageBoxResult.Yes) {
                People p = (People)dgvPeople.SelectedItems[0];
                p.readP();

                p.delete();
                List<People> list = (List<People>)dgvPeople.ItemsSource;
                list.Remove(p);

                dgvPeople.Items.Refresh();
                dgvPeople.ItemsSource = list;
                start();
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("Do you want to add this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        People p = new People(txtName.Text, Int32.Parse(txtAge.Text));
                        p.readP();
                        
                        p.insert();
                        ((List<People>)dgvPeople.ItemsSource).Add(p);
                        dgvPeople.Items.Refresh();
                    } catch (Exception E)
                    {
                        MessageBox.Show("No metas texto en la edad, mongolo");
                    }

                }
            } else // modificar
            {
                if (MessageBox.Show("Do you want to modify this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (dgvPeople.SelectedItems.Count > 0)
                    {
                        People p = (People)dgvPeople.SelectedItems[0];
                        p.readP();
                        
                        p.name=txtName.Text;
                        p.age = Int32.Parse(txtAge.Text);
                        dgvPeople.Items.Refresh();
                        p.update();
                    }

                }
            }
            start();
        }
    }
}