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
    /// Interaction logic for TiposVehiculos.xaml
    /// </summary>
    public partial class TiposVehiculos : UserControl
    {
        TrabajarTiposVehiculo trabajarVehiculo = new TrabajarTiposVehiculo();
        public TiposVehiculos()
        {
            InitializeComponent();
        }

        private void abrirAbmVehiculo(object sender, RoutedEventArgs e)
        {
            ABMtipoVehiculo pageVehiculo = new ABMtipoVehiculo();
            FrameVehiculos.Content = pageVehiculo;
            pageVehiculo.btnModificar.IsEnabled = false;
            pageVehiculo.btnModificar.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void FrameVehiculos_Loaded(object sender, RoutedEventArgs e)
        {
            GridDatos.ItemsSource = trabajarVehiculo.TraerTiposVehiculo().DefaultView;
        }

        private void modificar_click(object sender, RoutedEventArgs e)
        {
            int codigo = (int)((Button)sender).CommandParameter;
            
            try
            {
                
                TipoVehiculo vehiculo = TrabajarTiposVehiculo.obtenerVehiculo(codigo.ToString());
                if (vehiculo != null)
                {
                    ABMtipoVehiculo pageVehiculo = new ABMtipoVehiculo();
                    FrameVehiculos.Content = pageVehiculo;
                    pageVehiculo.txtTitle.Text = "Modificar Tipo de Vehiculo";
                    pageVehiculo.txtCodigo.Text = vehiculo.TVCodigo;
                    pageVehiculo.txtCodigo.IsEnabled = false;
                    pageVehiculo.txtDescripcion.Text = vehiculo.Descripcion;
                    pageVehiculo.txtTarifa.Text = vehiculo.Tarifa;
                    pageVehiculo.btnGuardar.IsEnabled = false;
                    pageVehiculo.btnGuardar.Background = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    // Show an error message if the type of vehicle doesn't exist
                    MessageBox.Show("El código de tipo de vehículo no existe en la base de datos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el tipo de vehículo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void eliminar_click(object sender, RoutedEventArgs e)
        {
            int codigo = (int)((Button)sender).CommandParameter;

            try
            {
                // Verifica si el código existe en la base de datos antes de intentar eliminar
                TrabajarTiposVehiculo trabajarTiposVehiculo = new TrabajarTiposVehiculo();
                if (trabajarTiposVehiculo.TipoVehiculoExisteEnBaseDeDatos(codigo.ToString()))
                {
                    // Llama al método EliminarTipoVehiculo para eliminar el tipo de vehículo
                    TrabajarTiposVehiculo.EliminarTipoVehiculo(codigo.ToString());
                    MessageBox.Show("Tipo de vehículo eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    GridDatos.ItemsSource = trabajarVehiculo.TraerTiposVehiculo().DefaultView;
                }
                else
                {
                    // Muestra un mensaje de error si el código no existe en la base de datos
                    MessageBox.Show("El código de tipo de vehículo no existe en la base de datos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error en caso de excepción
                MessageBox.Show("Error al eliminar el tipo de vehículo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

  
    }
}
