using MiniHito2.Domain;
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

namespace MiniHito1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void start()
        {
            txtAcronym.Text = "";
            txtName.Text = "";
            txtPresident.Text = "";

            btnNew.IsEnabled = false;
            btnDel.IsEnabled = false;

            txtPoblacion.Text = "";
            txtAbstenciones.Text = "";
            txtNulos.Text = "";

            dgvParties.UnselectAll();
        }
        
        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        private void dgvParties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgvParties.SelectedItems.Count>0)
            {
                btnNew.IsEnabled = true;
                btnDel.IsEnabled=true;

                Party p = (Party)dgvParties.SelectedItems[0];
                txtAcronym.Text = p.acronym;
                txtName.Text = p.name;
                txtPresident.Text= p.president;
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!btnNew.IsEnabled)
            {
                if (MessageBox.Show("Do you desire to add this party to the list?", "Confirmation", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    Party party = new Party();
                    party.readP();
                    dgvParties.ItemsSource = party.getListParties();

                    try
                    {
                        ((List<Party>)dgvParties.ItemsSource).Add(new Party(txtAcronym.Text, txtName.Text, txtPresident.Text));
                        dgvParties.Items.Refresh();


                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("System error.");
                    }
                }
            } else
            {
                if (dgvParties.SelectedItems.Count>0)
                {
                    Party p = (Party)dgvParties.SelectedItems[0];
                    p.acronym = txtAcronym.Text;
                    p.name = txtName.Text;
                    p.president = txtPresident.Text;

                    dgvParties.Items.Refresh();
                }
            }
            start();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you REALLY desire to delete this party?", "Confirmation", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                Party p = (Party) dgvParties.SelectedItems[0];
                List<Party> listado = (List<Party>)dgvParties.ItemsSource;

                listado.Remove(p);

                dgvParties.Items.Refresh();
                dgvParties.ItemsSource = listado;
                start();
            }
        }




        int numPartidos = 10;
        int escañosMadrid = 37;
        int poblacion;
        int abstenciones;
        int nulos;
        int votosValidos;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            poblacion=Int32.Parse(txtPoblacion.Text);
            abstenciones=Int32.Parse(txtAbstenciones.Text);
            nulos = Int32.Parse(txtNulos.Text);

            votosValidos = poblacion - abstenciones - nulos;
        }

        private void btnSimular_Click(object sender, RoutedEventArgs e)
        {
            double[] porcentajes = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25 };

            int[] votosSinDividir = new int[porcentajes.Length];
            for (int i=0; i<votosSinDividir.Length; i++)
            {
                votosSinDividir[i] = (int)((porcentajes[i] * votosValidos) / 100);
            }

            int blank = votosValidos;
            for (int i=0; i<votosSinDividir.Length; i++)
            {
                blank = blank - votosSinDividir[i];
            }


            for (int i = 0; i < porcentajes.Length; i++)
            {
                if (porcentajes[i] < 3)
                {
                    porcentajes[i] = 0;
                }
            }


            int[,] votos = new int[numPartidos, escañosMadrid];
            for (int i = 0; i < numPartidos; i++)
            {
                votos[i, 0] = (int)((porcentajes[i] * votosValidos) / 100); 
            }



            int min = (3 * votosValidos) / 100;
            for (int i = 0; i < numPartidos; i++)
            {
                if (votos[i, 0] < min)
                {
                    votos[i, 0] = 0;
                }
            }



            for (int i = 0; i < votos.GetLength(0); i++)
            {
                for (int j = 1; j < votos.GetLength(1); j++)
                {
                    votos[i, j] = votos[i, 0] / (j + 1);
                }
            }


            int[] partidos = new int[numPartidos];

            int partidoMayor = 0;
            for (int i = 0; i < escañosMadrid; i++)
            {
                partidoMayor = encontrarMayor(votos);
                partidos[partidoMayor]++;
            }

            PartyVotes p1 = new PartyVotes("Party1", votosSinDividir[0], partidos[0]);
            PartyVotes p2 = new PartyVotes("Party2", votosSinDividir[1], partidos[1]);
            PartyVotes p3 = new PartyVotes("Party3", votosSinDividir[2], partidos[2]);
            PartyVotes p4 = new PartyVotes("Party4", votosSinDividir[3], partidos[3]);
            PartyVotes p5 = new PartyVotes("Party5", votosSinDividir[4], partidos[4]);
            PartyVotes p6 = new PartyVotes("Party6", votosSinDividir[5], partidos[5]);
            PartyVotes p7 = new PartyVotes("Party7", votosSinDividir[6], partidos[6]);
            PartyVotes p8 = new PartyVotes("Party8", votosSinDividir[7], partidos[7]);
            PartyVotes p9 = new PartyVotes("Party9", votosSinDividir[8], partidos[8]);
            PartyVotes p10 = new PartyVotes("Party10", votosSinDividir[9], partidos[9]);
            PartyVotes pB = new PartyVotes("Blank ballots", blank, 0);

            List<PartyVotes> listaVotos = new List<PartyVotes>();
            listaVotos.Add(p1);
            listaVotos.Add(p2);
            listaVotos.Add(p3);
            listaVotos.Add(p4);
            listaVotos.Add(p5);
            listaVotos.Add(p6);
            listaVotos.Add(p7);
            listaVotos.Add(p8);
            listaVotos.Add(p9);
            listaVotos.Add(p10);
            listaVotos.Add(pB);

            dgvSeats.ItemsSource = listaVotos;
        }


        public int encontrarMayor(int[,] m)
        {
            int mayor = m[0, 0];
            int fila = 0;
            int col = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 1; j < m.GetLength(1); j++)
                {
                    if (m[i, j] > mayor)
                    {
                        mayor = m[i, j];
                        fila = i;
                        col = j;
                    }
                }
            }

            m[fila, col] = 0;
            return fila;

        }
    }
}
