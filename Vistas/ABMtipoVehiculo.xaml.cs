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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;
using System.Data.SqlClient;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMtipoVehiculo.xaml
    /// </summary>
    public partial class ABMtipoVehiculo : Page
    {
        public ABMtipoVehiculo()
        {
            InitializeComponent();
        }

        private Boolean form_Completo()
        {
            MessageBoxResult Result;

            Result = MessageBox.Show("¿Quiere guardar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
                return true;
            else
                return false;
        }


        private bool controlDatos()
        {
            if (txtCodigo.Text == "" || txtDescripcion.Text == "" || txtTarifa.Text == "")
                return false;
            else
                return true;
        }

        private void limpiarForm()
        {
            txtCodigo.Text = txtCodigo.Text;
            txtDescripcion.Text = string.Empty;
            txtTarifa.Text = string.Empty;

        }

        private void GuardarTipoVehiculo_Click(object sender, RoutedEventArgs e)
        {
            if (form_Completo())
            {
                if (controlDatos())
                {
                    TipoVehiculo tipoVehiculo = new TipoVehiculo();
                    tipoVehiculo.TVCodigo = txtCodigo.Text;
                    tipoVehiculo.Descripcion = txtDescripcion.Text;
                    tipoVehiculo.Tarifa = txtTarifa.Text;

                    try
                    {
                        // Intenta insertar el tipo de vehículo
                        TrabajarTiposVehiculo.insertarTipoVehiculo(tipoVehiculo);
                        limpiarForm();
                        MessageBox.Show("Tipo de vehículo guardado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        // Maneja la excepción lanzada por el método insertarTipoVehiculo
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("TODOS LOS CAMPOS DEBEN ESTAR CARGADOS Y LA TARIFA DEBE SER UN NÚMERO VÁLIDO", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("TODOS LOS CAMPOS DEBEN ESTAR CARGADOS", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void ModificarTipoVehiculo_Click(object sender, RoutedEventArgs e)
        {
            /*string codigoTipoVehiculo = txtCodigo.Text;

            if (string.IsNullOrEmpty(codigoTipoVehiculo))
            {
                MessageBox.Show("Ingresa un código de tipo de vehículo válido.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }*/

            if (form_Completo() && controlDatos())
            {
                try
                {
                    TrabajarTiposVehiculo trabajarTiposVehiculo = new TrabajarTiposVehiculo();
                    
                        // The type of vehicle exists, so proceed with the modification
                        TipoVehiculo tipoVehiculo = new TipoVehiculo();
                        tipoVehiculo.TVCodigo = txtCodigo.Text;
                        tipoVehiculo.Descripcion = txtDescripcion.Text;
                        tipoVehiculo.Tarifa = txtTarifa.Text;

                        TrabajarTiposVehiculo.ActualizarTipoVehiculo(tipoVehiculo);
                        MessageBox.Show("Tipo de vehículo modificado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        limpiarForm();
                        Content = new TiposVehiculos();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el tipo de vehículo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifica que todos los campos estén completos y que la tarifa sea un número válido.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EliminarTipoVehiculo_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el código del tipo de vehículo desde txtCodigo.Text
            string codigoTipoVehiculo = txtCodigo.Text;

            // Verifica si el campo está vacío
            if (string.IsNullOrEmpty(codigoTipoVehiculo))
            {
                MessageBox.Show("El campo del código está vacío. Ingresa un código válido.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Verifica si el código existe en la base de datos antes de intentar eliminar
                TrabajarTiposVehiculo trabajarTiposVehiculo = new TrabajarTiposVehiculo();
                if (trabajarTiposVehiculo.TipoVehiculoExisteEnBaseDeDatos(codigoTipoVehiculo))
                {
                    // Llama al método EliminarTipoVehiculo para eliminar el tipo de vehículo
                    TrabajarTiposVehiculo.EliminarTipoVehiculo(codigoTipoVehiculo);
                    MessageBox.Show("Tipo de vehículo eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);


                    // Limpia los campos (reemplaza esto con tu función para limpiar los campos)
                    limpiarForm();
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

        private void LimpiarForm_Click(object sender, RoutedEventArgs e)
        {
            limpiarForm();
        }

        private void btnVerTiposVehiculos_Click(object sender, RoutedEventArgs e)
        {
            //TiposVehiculos listadoTiposVehiculos = new TiposVehiculos();
            //listadoTiposVehiculos.Show();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Content = new TiposVehiculos();
        }
    }
}
