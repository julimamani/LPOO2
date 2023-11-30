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
using System.Windows.Controls.Primitives;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FrmABMVehiculo.xaml
    /// </summary>
    public partial class FrmEstacionamiento : UserControl
    {
        ToolTip tooltip = new ToolTip();
        public ObservableCollection<Sector> sectores { get; set; }
        public FrmEstacionamiento()
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
                MessageBoxResult result = MessageBox.Show("Sector Ocupado. ¿Deseas registrar la salida?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Playa playa = new Playa(botonActual.Content.ToString());
                    FrameSectores.Content = playa;
                }
            }
            else if ((botonActual.Background as SolidColorBrush).Color == Colors.Green)
            {
                MessageBoxResult result = MessageBox.Show("Sector Disponible. ¿Deseas registrar la entrada?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Playa playa = new Playa(botonActual.Content.ToString());
                    FrameSectores.Content = playa;
                }
            }
            
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void cuadro_MouseEnter(object sender, MouseEventArgs e)
        {
            Button botonActual = (Button)sender;
            string identificadorSector = botonActual.Content.ToString();
            Sector sector = TrabajarPlaya.TraerSectorPorIdentificador(identificadorSector);
            if ((botonActual.Background as SolidColorBrush).Color == Colors.Red)
            {
                Ticket ticket = TrabajarPlaya.TraerTicketSector(sector.sectorCodigo);
                TimeSpan diferencia = (sector.fechaHoraUltima > DateTime.Now) ? sector.fechaHoraUltima - DateTime.Now : DateTime.Now - sector.fechaHoraUltima;
                string contenido = "TIEMPO OCUPADO " + "\r\n" + "Horas: " + diferencia.Hours + ", Minutos: " + diferencia.Minutes + ", Segundos: " + diferencia.Seconds + "\r\n" +
                    "Tipo Vehiculo: "+ TrabajarTiposVehiculo.obtenerVehiculo(ticket.TVCodigo.ToString()).Descripcion +"\r\n" +
                    "Total: "+ ticket.Total;
                mostrarToolTip(contenido, botonActual);
           
            }
            else if ((botonActual.Background as SolidColorBrush).Color == Colors.Green)
            {
                TimeSpan diferencia = (sector.fechaHoraUltima > DateTime.Now) ? sector.fechaHoraUltima - DateTime.Now : DateTime.Now - sector.fechaHoraUltima;
                string contenido = "TIEMPO LIBRE " + "\r\n" + "Horas: " + diferencia.Hours + ", Minutos: " + diferencia.Minutes + ", Segundos: " + diferencia.Seconds;
                mostrarToolTip(contenido, botonActual);
            }
            else
            {
                mostrarToolTip("Sector No Disponible", botonActual);
            }
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
                boton.MouseEnter += new MouseEventHandler(cuadro_MouseEnter);
                boton.Click += new RoutedEventHandler(cuadro_Click);
               
                
                wrap.Children.Add(boton);
                if (i == 4 || i == 25 || i == 42)
                {
                    boton.Background = Brushes.Gray;
                }
                else if (sectores[i].habilitado == true)
                {
                    boton.Background = Brushes.Green;
                }
                else {
                    boton.Background = Brushes.Red;
                }
            }

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

        private void mostrarToolTip(string contenido, Button boton)
        {

            tooltip.Content = contenido;

            // Asignar el ToolTip al botón
            boton.ToolTip = tooltip;
            tooltip.FontSize = 16;

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#7be9f6"), 0.0));
            gradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#f083da"), 1.0));

            tooltip.Background = gradientBrush;
        }
    }
    
}
