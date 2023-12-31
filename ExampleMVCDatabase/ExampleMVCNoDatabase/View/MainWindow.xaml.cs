﻿using ExampleMVCnoDatabase.Domain;
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
            people.readP();
            dgvPeople.ItemsSource = people.getListPeople();
            // De entrada, nuevo está habilitado para meter registros si quiero
            // Borrar sólo se habilita si selecciono un registro para borrarlo
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
            //MessageBox.Show("Selección cambiada");
            // dgvPeople es un array de objetos que tengo guardados.
            // dgvPeople.SelectedItems[0] me va a devolver el primero
            // de los elementos de ese array, y para poder utilizar los
            // métodos de la clase People tengo que hacerle un casting

            // El nombre de la textbox a la que le quiero ajustar el texto
            // junto con la propiedad .Text me va a permitir ajustarle el
            // texto que contiene.
            if (dgvPeople.SelectedItems.Count>0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled = true;
                People p = (People)dgvPeople.SelectedItems[0]; // Si selecciono varios, sólo me pone el primero
                txtName.Text = p.name;
                txtAge.Text = p.age.ToString();
            }
            
        }


        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            // Al darle a NEW, los campos se quedan en blanco, el botón de
            // borrar se deshabilita y se quita la selección
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            // NUNCA BORRAR NADA SIN ANTES PEDIR CONFIRMACIÓN
            if (MessageBox.Show("Do you want to remove this person?","Confirmation",MessageBoxButton.YesNo)==MessageBoxResult.Yes) {
                // El objeto que quiero borrar.
                People p = (People)dgvPeople.SelectedItems[0];

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
            // Vamos a pedir confirmación
            // Si el botón de NEW está deshabilitado, es porque le hemos pinchado; vamos a añadir
            // Si el botón de NEW está habilitado, modificamos
            if (!btnNew.IsEnabled) // añadir
            {
                if (MessageBox.Show("Do you want to add this person?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        People p = new People(txtName.Text, Int32.Parse(txtAge.Text));
                        p.insert();
                        p.last();
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
                        People p = (People)dgvPeople.SelectedItems[0]; // Si selecciono varios, sólo me pone el primero; puedo poner SelectedItem
                        p.name=txtName.Text;
                        p.age = Int32.Parse(txtAge.Text);
                        dgvPeople.Items.Refresh();
                        p.update();
                        


                        // Ejemplo con index:
                        // List<People> listado = (List<People>) dgvPeople.ItemsSource;
                        // listado[dgvPeople.SelectedIndex].name = txtName.Text;
                        // listado[dgvPeople.SelectedIndex].age = int.Parse(txtAge.Text);
                        // dgvPeople.Items.Refresh();
                    }

                }
            }
            start();



            /* Mi  versión:
            if (dgvPeople.SelectedItems.Count > 0)
            {
                btnDel.IsEnabled = true;
                People p = (People)dgvPeople.SelectedItems[0]; // Si selecciono varios, sólo me pone el primero
                p.name = txtName.Text;
                p.age = Int32.Parse(txtAge.Text);

                dgvPeople.Items.Refresh();
            } else
            {
                List<People> lista = (List<People>)dgvPeople.ItemsSource;
                lista.Add(new People(txtName.Text, Int32.Parse(txtAge.Text)));

                dgvPeople.Items.Refresh();
                dgvPeople.ItemsSource = lista;
            }  
            */
        }
    }
}