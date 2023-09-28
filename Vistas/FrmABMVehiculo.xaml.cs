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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FrmABMVehiculo.xaml
    /// </summary>
    public partial class FrmABMVehiculo : Window
    {
        public FrmABMVehiculo()
        {
            InitializeComponent();
        }

        private void Button_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void cuadro_Click(object sender, RoutedEventArgs e)
        {
            Button botonActual = (Button)sender;

            if ((botonActual.Background as SolidColorBrush).Color == Colors.Red)
                MessageBox.Show("Sector Ocupado. Registrar Salida");
            else if ((botonActual.Background as SolidColorBrush).Color == Colors.Green)
                MessageBox.Show("Sector Disponible. Registrar Entrada");
            else
                MessageBox.Show("Sector deshabilitado");
        }

        private void btn_Vehiculo_Click(object sender, RoutedEventArgs e)
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
                boton.Content = "E: " + i;
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
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
