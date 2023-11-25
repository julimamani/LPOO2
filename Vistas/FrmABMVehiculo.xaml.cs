using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FrmABMVehiculo.xaml
    /// </summary>
    public partial class FrmABMVehiculo : UserControl
    {
        public ObservableCollection<Sector> sectores { get; set; }
        public FrmABMVehiculo()
        {
            InitializeComponent();
            //generarSectores();
        }

        private void Button_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void cuadro_Click(object sender, RoutedEventArgs e)
        {
            Button botonActual = (Button)sender;

            if ((botonActual.Background as SolidColorBrush).Color == Colors.Red)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida");
                Playa playa = new Playa(botonActual.Content.ToString());
                FrameSectores.Content = playa;
            }
            else if ((botonActual.Background as SolidColorBrush).Color == Colors.Green)
            {

                MessageBox.Show("Sector Disponible. Registrar Entrada");
                Playa playa = new Playa(botonActual.Content.ToString());
                FrameSectores.Content = playa;
            }
            else
                MessageBox.Show("Sector deshabilitado");
        }

       /** private void btn_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            var wrap = new WrapPanel();

            //var scroll = new ScrollViewer();
            //wrap.Children.Add(scroll);
            
            for (int i = 1; i < 11; i++)
            {               
                var boton = new Button();

                boton.Height = 60;
                boton.Width = 100;
                boton.FontWeight = FontWeights.Bold;
                boton.FontFamily = new System.Windows.Media.FontFamily("Book Antiqua");
                boton.FontSize = 20;
                boton.Margin = new Thickness(20, 20, 20, 10);
                boton.Name = "btn_" + i;
                boton.Content = "E:" + i;
                boton.Click += new RoutedEventHandler(cuadro_Click);
                
                wrap.Children.Add(boton);

                if (i == 7)
                {
                    boton.Background = Brushes.Red;
                }
                else if (i == 4)
                {
                    boton.Background = Brushes.Gray;
                }
                else
                {
                    boton.Background = Brushes.Green;
                }
            }
          
            //cnvMesas.Children.Add(wrap);
            grdMesas.Children.Add(wrap);
            wrap.Height = 500;
            wrap.Width = 560;
            wrap.Orientation = Orientation.Horizontal;
            wrap.Orientation = Orientation.Vertical;
            wrap.HorizontalAlignment = HorizontalAlignment.Center;
            wrap.Margin = new Thickness(10, 0,-250,10);
        }**/

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        public void generarSectores() {
            var wrap = new WrapPanel();

            //var scroll = new ScrollViewer();
            //wrap.Children.Add(scroll);

            for (int i = 0; i < sectores.Count; i++)
            {
                var boton = new Button();

                boton.Height = 60;
                boton.Width = 100;
                boton.FontWeight = FontWeights.Bold;
                boton.FontFamily = new System.Windows.Media.FontFamily("Book Antiqua");
                boton.FontSize = 20;
                boton.Margin = new Thickness(20, 20, 20, 10);
                boton.Name = "btn_" + i;
                boton.Content = sectores[i].identificador;
                boton.Click += new RoutedEventHandler(cuadro_Click);
                wrap.Children.Add(boton);

                /*if (i == 7)
                {
                    boton.Background = Brushes.Red;
                }
                else if (i == 4)
                {
                    boton.Background = Brushes.Gray;
                }
                else
                {
                    boton.Background = Brushes.Green;
                }*/
                if (sectores[i].habilitado == true)
                {
                    boton.Background = Brushes.Green;
                }
                else {
                    boton.Background = Brushes.Red;
                }
            }

            //cnvMesas.Children.Add(wrap);
            grdMesas.Children.Add(wrap);
            wrap.Height = 500;
            wrap.Width = 560;
            wrap.Orientation = Orientation.Horizontal;
            wrap.Orientation = Orientation.Vertical;
            wrap.HorizontalAlignment = HorizontalAlignment.Center;
            wrap.Margin = new Thickness(10, 0, -250, 10);
        }

        private void zona1_click(object sender, RoutedEventArgs e)
        {
            int zonaCodigo = 1;
            sectores = TrabajarPlaya.TraerSectoresPorZona(zonaCodigo);
            generarSectores();
        }

        private void zona2_click(object sender, RoutedEventArgs e)
        {
            int zonaCodigo = 2;
            sectores = TrabajarPlaya.TraerSectoresPorZona(zonaCodigo);
            generarSectores();
        }

        private void zona3_click(object sender, RoutedEventArgs e)
        {
            int zonaCodigo = 3;
            sectores = TrabajarPlaya.TraerSectoresPorZona(zonaCodigo);
            generarSectores();
        }
    }
    
}
