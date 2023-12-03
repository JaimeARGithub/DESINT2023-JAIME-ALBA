using MiniHito3Json.Domain;
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

namespace MiniHito3Json
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


        int numPartidos = 10;
        int escañosMadrid = 37;
        int poblacion;
        int abstenciones;
        int nulos;
        int votosValidos;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            poblacion = Int32.Parse(txtPoblacion.Text);
            abstenciones = Int32.Parse(txtAbstenciones.Text);
            nulos = Int32.Parse(txtNulos.Text);

            votosValidos = poblacion - abstenciones - nulos;
            start();
        }


        private void btnSimular_Click(object sender, RoutedEventArgs e)
        {
            double[] porcentajes = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25 };

            int[] votosSinDividir = new int[porcentajes.Length];
            for (int i = 0; i < votosSinDividir.Length; i++)
            {
                votosSinDividir[i] = (int)((porcentajes[i] * votosValidos) / 100);
            }

            int blank = votosValidos;
            for (int i = 0; i < votosSinDividir.Length; i++)
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


            List<Party> listaVotos = new List<Party>();

            Party p1 = new Party("Party1", votosSinDividir[0], partidos[0]);
            p1.readP();
            p1.insert();
            listaVotos.Add(p1);

            Party p2 = new Party("Party2", votosSinDividir[1], partidos[1]);
            p2.readP();
            p2.insert();
            listaVotos.Add(p2);

            Party p3 = new Party("Party3", votosSinDividir[2], partidos[2]);
            p3.readP();
            p3.insert();
            listaVotos.Add(p3);

            Party p4 = new Party("Party4", votosSinDividir[3], partidos[3]);
            p4.readP();
            p4.insert();
            listaVotos.Add(p4);

            Party p5 = new Party("Party5", votosSinDividir[4], partidos[4]);
            p5.readP();
            p5.insert();
            listaVotos.Add(p5);

            Party p6 = new Party("Party6", votosSinDividir[5], partidos[5]);
            p6.readP();
            p6.insert();
            listaVotos.Add(p6);

            Party p7 = new Party("Party7", votosSinDividir[6], partidos[6]);
            p7.readP();
            p7.insert();
            listaVotos.Add(p7);

            Party p8 = new Party("Party8", votosSinDividir[7], partidos[7]);
            p8.readP();
            p8.insert();
            listaVotos.Add(p8);

            Party p9 = new Party("Party9", votosSinDividir[8], partidos[8]);
            p9.readP();
            p9.insert();
            listaVotos.Add(p9);

            Party p10 = new Party("Party10", votosSinDividir[9], partidos[9]);
            p10.readP();
            p10.insert();
            listaVotos.Add(p10);

            Party pB = new Party("Blank ballots", blank, 0);
            pB.readP();
            pB.insert();
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
