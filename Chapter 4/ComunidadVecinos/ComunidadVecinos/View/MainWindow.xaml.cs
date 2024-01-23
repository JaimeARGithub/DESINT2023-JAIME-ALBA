﻿using ComunidadVecinos.Domain;
using ComunidadVecinos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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

namespace ComunidadVecinos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PagComunidad paginaCom;
        PagPortal paginaPort;
        PagDependencias paginaDep;
        int cont;

        Comunidad comu;
        string name;
        string address;
        int surface;
        int numDoorways=0;
        bool isSwimPool;
        string creationDate;

        Portal[] portales;
        int numStairs;
        int numFloors;
        int numDoors;

        // Nueva adición: variables para las dependencias
        bool isGatekeeper;
        bool isShower;
        bool isPlay;
        bool isExercise;
        bool isRoom;
        bool isTennis;
        bool isPadel;

        public MainWindow()
        {
            InitializeComponent();
            cont = 0;

            paginaCom = new PagComunidad();
            FrameCommunity.Content = paginaCom;
            btnPrev.Visibility = Visibility.Hidden;
            FrameCommunity.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // PÁGINA DE CREACIÓN DE COMUNIDAD
            // PRIMERO SE RECOGEN LAS VARIABLES PARA USARLAS Y CREAR LA COMUNIDAD
            // TRAS ESO SE REGENERA LA INTERFAZ Y SE MUESTRA LA DE CREAR PORTALES
            if (cont == 0)
            {
                
                try
                {
                    // Si el número de portales escrito el distinto que el valor
                    // que hay almacenado, el array de portales se crea nuevo
                    if (numDoorways != Int32.Parse(paginaCom.txtNumDoor.Text.ToString()))
                    {
                        // El array de portales se crea con el nº de huecos indicado
                        // Si ha cambiado el número de doorways, se crea nuevo.
                        numDoorways = Int32.Parse(paginaCom.txtNumDoor.Text.ToString());
                        portales = new Portal[numDoorways];
                        MessageBox.Show("New doorways have been created.");
                    }

                    
                    // Se guardan los valores de las variables asignadas a la comunidad
                    name = paginaCom.txtName.Text.ToString();
                    address = paginaCom.txtAddress.Text.ToString();
                    surface = Int32.Parse(paginaCom.txtSurface.Text.ToString());
                    creationDate = paginaCom.calCalendar.SelectedDate.Value.ToString("dd/MM/yyyy");


                    
                    // Solamente se puede seguir si los portales y la superficie son mayores que cero
                    if (numDoorways <= 0 || surface <=0 || (paginaCom.btnYes.IsChecked==false && paginaCom.btnNo.IsChecked == false))
                    {
                        MessageBox.Show("The number of doorways and the surface must be greater than 0. Also, you must select yes or no swimming pool.");
                    } else
                    {
                        // Se crea el objeto comunidad con los datos introducidos
                        
                        if (paginaCom.btnYes.IsChecked==true)
                        {
                            isSwimPool = true;

                        } else
                        {
                            isSwimPool = false;
                        }

                        comu = new Comunidad(name, address, creationDate, surface, isSwimPool, numDoorways);



                        // Se incrementa el contador, que se empleará para gestionar el
                        // avance y retroceso en el proceso de creación
                        cont++;


                        // SE UBICA COMO INTERFAZ LA DE CREAR PORTALES
                        paginaPort = new PagPortal();
                        FrameCommunity.Content = paginaPort;
                        btnPrev.Visibility = Visibility.Visible;
                        paginaPort.labelPortal.Content = $"Doorway nº {cont} of {numDoorways}";


                        // Si estamos volviendo a portales tras haber estado ya en
                        // ellos y ya había datos, los datos se rellenan solos
                        if (portales[cont - 1] != null)
                        {
                            MessageBox.Show($"Returning to temporarily saved data for doorway nº {cont}.");
                            paginaPort.txtStair.Text = portales[cont - 1].numEscaleras.ToString();
                            paginaPort.txtFloor.Text = portales[cont - 1].numPlantas.ToString();
                            paginaPort.txtDoor.Text = portales[cont - 1].numPuertas.ToString();
                        }
                        
                    }


                } catch (Exception E)
                {
                    MessageBox.Show("Failure during creation. Please, enter correct data for the condominium.");
                }

            // PÁGINA FINAL, APARECE TRAS TODOS LOS PORTALES
            // LA DE LAS DEPENDENCIAS
            } else if (cont == numDoorways)
            {
                // En el paso a la página final, se guarda el último piso
                try
                {
                    // Se recogen los datos de un portal y se crea 
                    numStairs = Int32.Parse(paginaPort.txtStair.Text.ToString());
                    numFloors = Int32.Parse(paginaPort.txtFloor.Text.ToString());
                    numDoors = Int32.Parse(paginaPort.txtDoor.Text.ToString());
                    portales[cont - 1] = new Portal(comu.Id, numStairs, numFloors, numDoors);


                    // No se puede seguir a menos que escaleras y plantan no sean negativos
                    // y haya al menos una puerta
                    if (numDoors <= 0 || numStairs < 0 || numFloors < 0)
                    {
                        MessageBox.Show("At least, there must be a door in every doorway. Also, stairs and floors must be, at least, zero.");
                        paginaPort.txtStair.Text = "";
                        paginaPort.txtFloor.Text = "";
                        paginaPort.txtDoor.Text = "";
                    }
                    else
                    {
                        MessageBox.Show($"Data for doorway nº {cont} correctly saved.");
                        portales[cont - 1].toString();
                    }

                }
                catch (Exception E)
                {
                    MessageBox.Show("Failure during creation. Please, enter correct data for the doorway.");
                    paginaPort.txtStair.Text = "";
                    paginaPort.txtFloor.Text = "";
                    paginaPort.txtDoor.Text = "";
                }



                cont++;

                paginaDep = new PagDependencias();
                FrameCommunity.Content = paginaDep;
                paginaPort.labelPortal.Content = $"LAST PAGE";
                btnNext.Content = $"FINISH";

                
            } else if (cont > numDoorways)
            // ¡¡¡¡CUANDO SE LE DA A FINISH!!!!
            {
                if ((paginaDep.btnYesGatekeeper.IsChecked == false && paginaDep.btnNoGatekeeper.IsChecked == false) ||
                    (paginaDep.btnYesShower.IsChecked == false && paginaDep.btnNoShower.IsChecked == false)  ||
                    (paginaDep.btnYesPlay.IsChecked == false && paginaDep.btnNoPlay.IsChecked == false)  ||
                    (paginaDep.btnYesExercise.IsChecked == false && paginaDep.btnNoExercise.IsChecked == false) ||
                    (paginaDep.btnYesRoom.IsChecked == false && paginaDep.btnNoRoom.IsChecked == false) ||
                    (paginaDep.btnYesTennis.IsChecked == false && paginaDep.btnNoTennis.IsChecked == false) ||
                    (paginaDep.btnYesPadel.IsChecked == false && paginaDep.btnNoPadel.IsChecked == false) )
                {
                    MessageBox.Show("Please, select correct values for the dependencies of the condominium.");
                } else
                {
                    // Asignamos todas las variables de las dependencias
                    if (paginaDep.btnYesGatekeeper.IsChecked == true)
                    {
                        isGatekeeper = true;

                    }
                    else
                    {
                        isGatekeeper = false;
                    }


                    if (paginaDep.btnYesShower.IsChecked == true)
                    {
                        isShower = true;

                    }
                    else
                    {
                        isShower = false;
                    }


                    if (paginaDep.btnYesPlay.IsChecked == true)
                    {
                        isPlay = true;

                    }
                    else
                    {
                        isPlay = false;
                    }


                    if (paginaDep.btnYesExercise.IsChecked == true)
                    {
                        isExercise = true;

                    }
                    else
                    {
                        isExercise = false;
                    }


                    if (paginaDep.btnYesRoom.IsChecked == true)
                    {
                        isRoom = true;

                    }
                    else
                    {
                        isRoom = false;
                    }


                    if (paginaDep.btnYesTennis.IsChecked == true)
                    {
                        isTennis = true;

                    }
                    else
                    {
                        isTennis = false;
                    }


                    if (paginaDep.btnYesPadel.IsChecked == true)
                    {
                        isPadel = true;

                    }
                    else
                    {
                        isPadel = false;
                    }




                    // Se generan todos los pisos y las listas de ellos son añadidas a la lista de
                    // pisos de que dispone la comunidad
                    for (int i = 0; i < portales.Length; i++)
                    {
                        portales[i].generarPisos();

                        comu.listaPisos.AddRange(portales[i].listaPisos);
                    }


                    // Generamos los propietarios de manera aleatoria
                    List<Propietario> listaPropietarios = new List<Propietario>();

                    for (int i = 0; i < comu.listaPisos.Count; i++)
                    {
                        listaPropietarios.Add(new Propietario(DniGenerator.GenerarDNIUnico()));
                    }


                    // Recorremos la lista de pisos para asignar un propietario 1, uno o ninguno propietario 2,
                    // un trastero y una plaza de garaje
                    // Determinaremos si hay o no segundo propietario, y el propietario, con un nº aleatorio de
                    // sí/no y un nº aleatorio para la posición
                    Random random = new Random();
                    int haySegundoProp;
                    int posSegundoProp;
                    List<PisosPropietarios> listaPisosPropietarios = new List<PisosPropietarios>();
                    List<int> plazasParking = GenerateAndShuffleList(comu.listaPisos.Count);
                    List<int> trasteros = GenerateAndShuffleList(comu.listaPisos.Count);

                    for (int i = 0; i < comu.listaPisos.Count; i++)
                    {
                        comu.listaPisos[i].idProp1 = listaPropietarios[i].dni;
                        listaPisosPropietarios.Add(new PisosPropietarios(comu.listaPisos[i].Id, comu.listaPisos[i].idProp1));

                        haySegundoProp = random.Next(0, 2);
                        if (haySegundoProp == 1)
                        {
                            posSegundoProp = random.Next(0, listaPropietarios.Count);
                            while (posSegundoProp == i)
                            {
                                posSegundoProp = random.Next(0, listaPropietarios.Count);
                            }
                            comu.listaPisos[i].idProp2 = listaPropietarios[posSegundoProp].dni;
                            listaPisosPropietarios.Add(new PisosPropietarios(comu.listaPisos[i].Id, comu.listaPisos[i].idProp2));
                        }

                        comu.listaPisos[i].numPlaza = plazasParking[i];
                        comu.listaPisos[i].numTrastero = trasteros[i];
                    }


                    if (isGatekeeper)
                    {
                        Propietario portero = new Propietario("P0R73R0");
                        listaPropietarios.Add(portero);

                        Piso pisoPortero = new Piso(comu.Id, 0, 0, -1, "Z");
                        pisoPortero.idProp1 = portero.dni;
                        pisoPortero.numTrastero = -1;
                        pisoPortero.numPlaza = -1;
                        comu.listaPisos.Add(pisoPortero);

                        listaPisosPropietarios.Add(new PisosPropietarios(pisoPortero.Id, pisoPortero.idProp1));
                    }


                    // Antes de realizar los inserts, nuevas asignaciones
                    // Para la comunidad, dependencias. Si hay portero, nuevo piso para él.
                    comu.hayPortero = isGatekeeper;
                    comu.hayDucha = isShower;
                    comu.hayJuego = isPlay;
                    comu.hayEjercicio = isExercise;
                    comu.haySala = isRoom;
                    comu.hayTenis = isTennis;
                    comu.hayPadel = isPadel;




                    // Tras generarse todos los pisos, se imprimen en la segunda pestaña
                    Imprimir(comu, OutputTextBox);

                    comu.Insert();
                    foreach (Propietario p in listaPropietarios)
                    {
                        p.Insertar();
                    }
                    foreach (Piso p in comu.listaPisos)
                    {
                        p.Insert();
                    }
                    foreach (PisosPropietarios p in listaPisosPropietarios)
                    {
                        p.Insert();
                    }
                }

                


            } else

            // CREACIÓN DE UN PORTAL
            {
                try
                {
                    // Se recogen los datos de un portal y se crea 
                    numStairs = Int32.Parse(paginaPort.txtStair.Text.ToString());
                    numFloors = Int32.Parse(paginaPort.txtFloor.Text.ToString());
                    numDoors = Int32.Parse(paginaPort.txtDoor.Text.ToString());
                    portales[cont - 1] = new Portal(comu.Id, numStairs, numFloors, numDoors);


                    // No se puede seguir a menos que escaleras y plantan no sean negativos
                    // y haya al menos una puerta
                    if (numDoors <= 0 || numStairs<0 || numFloors<0)
                    {
                        MessageBox.Show("At least, there must be a door in every doorway. Also, stairs and floors must be, at least, zero.");
                        paginaPort.txtStair.Text = "";
                        paginaPort.txtFloor.Text = "";
                        paginaPort.txtDoor.Text = "";
                    } else
                    {
                        MessageBox.Show($"Data for doorway nº {cont} correctly saved.");
                        portales[cont - 1].toString();

                        // Se vacían los campos de texto
                        paginaPort.txtStair.Text = "";
                        paginaPort.txtFloor.Text = "";
                        paginaPort.txtDoor.Text = "";

                        // Si en el elemento siguiente del array de portales hay datos,
                        // rellenamos los campos con ellos
                        if (portales[cont] != null)
                        {
                            MessageBox.Show($"Returning to temporarily saved data for doorway nº {cont + 1}.");
                            paginaPort.txtStair.Text = portales[cont].numEscaleras.ToString();
                            paginaPort.txtFloor.Text = portales[cont].numPlantas.ToString();
                            paginaPort.txtDoor.Text = portales[cont].numPuertas.ToString();
                        }

                        // Y nos movemos de página y etiqueta
                        cont++;
                        paginaPort.labelPortal.Content = $"Doorway nº {cont} of {numDoorways}";
                    }

                }
                catch (Exception E)
                {
                    MessageBox.Show("Failure during creation. Please, enter correct data for the doorway.");
                    paginaPort.txtStair.Text = "";
                    paginaPort.txtFloor.Text = "";
                    paginaPort.txtDoor.Text = "";
                }
            }


            
        }

        // Método que genera, desordena y devuelve una lista de números que
        // abarca del 1 al número que se pase por parámetro
        public List<int> GenerateAndShuffleList(int x)
        {
            List<int> result = new List<int>();

            // Generar lista ordenada 
            for (int i = 1; i <= x; i++)
            {
                result.Add(i);
            }

            // Desordenar la lista utilizando el método Fisher-Yates 
            int n = result.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = RandomNumber.random_Number(0, i + 1);
                int temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }

            return result;
        }

        // Imprimir troncho de texto
        public static void Imprimir(Comunidad comunidad, TextBox outputTextBox)
        {
            outputTextBox.AppendText($"Datos de la Comunidad: {comunidad.nombre}\n"); outputTextBox.AppendText($"Comunidad ID: {comunidad.Id}\n");
            outputTextBox.AppendText($"Dirección: {comunidad.direccion}\n"); outputTextBox.AppendText($"Fecha: {comunidad.fechaCreac}\n");
            outputTextBox.AppendText($"Metros Cuadrados: {comunidad.metrosCuadrados}\n"); outputTextBox.AppendText($"Piscina: {(comunidad.hayPiscina ? "Sí" : "No")}\n");
            outputTextBox.AppendText("\nPisos:\n");
            foreach (Piso piso in comunidad.listaPisos)
            {
                outputTextBox.AppendText($"Piso ID: {piso.Id}\n"); outputTextBox.AppendText($"Portal: {piso.numPortal}\n");
                outputTextBox.AppendText($"Escaleras: {piso.numEscalera}\n"); outputTextBox.AppendText($"Plantas: {piso.numPlanta}\n");
                outputTextBox.AppendText($"Letras: {piso.puerta}\n"); outputTextBox.AppendText($"Número de Trastero: {piso.numTrastero}\n");
                outputTextBox.AppendText($"Número de Parking: {piso.numPlaza}\n");
                outputTextBox.AppendText($"Propietario 1: {piso.idProp1}\n");
                outputTextBox.AppendText($"Propietario 2: {piso.idProp2}\n");
                outputTextBox.AppendText("\n------------------------\n");
            }
        }






        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            cont--;
            // RETORNO A LA PANTALLA INICIAL
            if (cont == 0)
            {
                // Si se habían rellenado los tres campos del portal, se guardan los datos
                if (paginaPort.txtStair.Text.ToString() != "" && paginaPort.txtFloor.Text.ToString() != "" && paginaPort.txtDoor.Text.ToString() != "")
                {
                    try
                    {
                        numStairs = Int32.Parse(paginaPort.txtStair.Text.ToString());
                        numFloors = Int32.Parse(paginaPort.txtFloor.Text.ToString());
                        numDoors = Int32.Parse(paginaPort.txtDoor.Text.ToString());
                        portales[cont] = new Portal(comu.Id, numStairs, numFloors, numDoors);
                        MessageBox.Show($"Data of doorway number {cont + 1} temporarily saved.");
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Please, enter valid data if you want to save it for later.");
                    }
                }

                FrameCommunity.Content = paginaCom;
                btnPrev.Visibility = Visibility.Hidden;


            } 
            // VUELTA DE PÁGINA FINAL A PORTAL
            else if (cont == numDoorways)
            {
                FrameCommunity.Content = paginaPort;
                paginaPort.labelPortal.Content = $"Doorway nº {cont} of {numDoorways}";
                btnNext.Content = $"NEXT";


                paginaPort.txtStair.Text = portales[cont - 1].numEscaleras.ToString();
                paginaPort.txtFloor.Text = portales[cont - 1].numPlantas.ToString();
                paginaPort.txtDoor.Text = portales[cont - 1].numPuertas.ToString();

            } 
            // VUELTA ATRÁS DE UN PORTAL A OTRO
            else
            {
                // Si se habían rellenado los tres campos del portal, se guardan los datos
                if (paginaPort.txtStair.Text.ToString()!="" && paginaPort.txtFloor.Text.ToString()!="" && paginaPort.txtDoor.Text.ToString()!="")
                {
                    try
                    {
                        numStairs = Int32.Parse(paginaPort.txtStair.Text.ToString());
                        numFloors = Int32.Parse(paginaPort.txtFloor.Text.ToString());
                        numDoors = Int32.Parse(paginaPort.txtDoor.Text.ToString());
                        portales[cont] = new Portal(comu.Id, numStairs, numFloors, numDoors);
                        MessageBox.Show($"Data of doorway number {cont + 1} temporarily saved.");
                    } catch (Exception E)
                    {
                        MessageBox.Show("Please, enter valid data if you want to save it for later.");
                    }
                }


                paginaPort.labelPortal.Content = $"Doorway nº {cont} of {numDoorways}";


                paginaPort.txtStair.Text = portales[cont - 1].numEscaleras.ToString();
                paginaPort.txtFloor.Text = portales[cont - 1].numPlantas.ToString();
                paginaPort.txtDoor.Text = portales[cont - 1].numPuertas.ToString();

            }
        }

        private void btnYes_Checked(object sender, RoutedEventArgs e)
        {
            paginaCom.btnNo.IsChecked = false;
        }

        private void btnNo_Checked(object sender, RoutedEventArgs e)
        {
            paginaCom.btnNo.IsChecked = false;
        }




        private void btnYesGatekeeper_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoGatekeeper.IsChecked = false;
        }

        private void btnNoGatekeeper_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesGatekeeper.IsChecked = false;
        }

        private void btnYesShower_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoShower.IsChecked = false;
        }

        private void btnNoShower_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesShower.IsChecked = false;
        }

        private void btnYesPlay_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoPlay.IsChecked = false;
        }

        private void btnNoPlay_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesPlay.IsChecked = false;
        }

        private void btnYesExercise_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoExercise.IsChecked = false;
        }

        private void btnNoExercise_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesExercise.IsChecked = false;
        }

        private void btnYesRoom_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoRoom.IsChecked = false;
        }

        private void btnNoRoom_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesRoom.IsChecked = false;
        }

        private void btnYesTennis_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoTennis.IsChecked = false;
        }

        private void btnNoTennis_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesTennis.IsChecked = false;
        }

        private void btnYesPadel_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnNoPadel.IsChecked = false;
        }

        private void btnNoPadel_Checked(object sender, RoutedEventArgs e)
        {
            paginaDep.btnYesPadel.IsChecked = false;
        }




    }


    // Clase para la generación de DNIs aleatorios
    internal class DniGenerator
    {
        private static List<string> dnisGenerados = new List<string>();
        private static Random random = new Random();

        public static string GenerarDNIUnico()
        {
            string nuevoDNI;

            do
            {
                nuevoDNI = GenerarDNI();
            } while (dnisGenerados.Contains(nuevoDNI));

            dnisGenerados.Add(nuevoDNI);
            return nuevoDNI;
        }

        private static string GenerarDNI()
        {
            int numero = random.Next(10000000, 99999999);
            int indice = numero % 23;

            // Array de letras posibles para un DNI en España 
            char[] letrasDNI = "TRWAGMYFPDXBNJZSQVHLCKE".ToCharArray();

            return numero.ToString("D8") + letrasDNI[indice];
        }
    }
}