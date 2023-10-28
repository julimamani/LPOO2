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
            txtCodigo.Text = string.Empty;
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
            string codigoTipoVehiculo = txtCodigo.Text;

            if (string.IsNullOrEmpty(codigoTipoVehiculo))
            {
                MessageBox.Show("Ingresa un código de tipo de vehículo válido.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (form_Completo() && controlDatos())
            {
                TipoVehiculo tipoVehiculo = new TipoVehiculo();
                tipoVehiculo.TVCodigo = txtCodigo.Text;
                tipoVehiculo.Descripcion = txtDescripcion.Text;
                tipoVehiculo.Tarifa = txtTarifa.Text;

                try
                {
                    TrabajarTiposVehiculo.ActualizarTipoVehiculo(tipoVehiculo);
                    MessageBox.Show("Tipo de vehículo modificado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarForm();

                    // Si deseas navegar a la página de lista de tipos de vehículos, debes hacerlo aquí.
                    // Si estás utilizando un Frame o similar para la navegación entre páginas, 
                    // puedes usar un código como el siguiente:

                    // Frame frame = new Frame();
                    // frame.Navigate(new TiposVehiculos());
                    // Window.Current.Content = frame;

                    // O si estás trabajando con ventanas, puedes abrir la ventana de TiposVehiculos
                    // como lo haces en btnVerTiposVehiculos_Click.
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
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el Tipo de Vehículo seleccionado?", "Eliminar Tipo de Vehículo", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            try
            {
                // Verifica el valor de txtCodigo.Text antes de llamar al método EliminarTipoVehiculo.
                string codigoTipoVehiculo = txtCodigo.Text;

                // Llama al método EliminarTipoVehiculo
                TrabajarTiposVehiculo.EliminarTipoVehiculo(codigoTipoVehiculo);

                // Muestra un mensaje de éxito
                MessageBox.Show("Tipo de vehículo eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                // Limpia los campos (reemplaza esto con tu función para limpiar los campos)
                limpiarForm();
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
            TiposVehiculos listadoTiposVehiculos = new TiposVehiculos();
            listadoTiposVehiculos.Show();
        }
    }
}
