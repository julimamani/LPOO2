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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMtipoVehiculo.xaml
    /// </summary>
    public partial class ABMtipoVehiculo : Page
    {

        TipoVehiculo tipoVehiculo = new TipoVehiculo();

        public ABMtipoVehiculo()
        {
            InitializeComponent();
        }

        private Boolean form_Completo()
        {
            MessageBoxResult Result;

            Result = MessageBox.Show("¿Quiere guardar los datos?", "Confirmación ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
                return true;
            else
                return false;
        }

        private void cargarDatos()
        {
            tipoVehiculo.TVCodigo = txtCodigo.Text;
            tipoVehiculo.Descripcion = txtDescripcion.Text;
            tipoVehiculo.Tarifa = txtTarifa.Text;
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

            if (form_Completo() == true)
            {
                if (controlDatos() == true)
                {
                    cargarDatos();
                    //MessageBox.Show("Nombre guardado: " + cliente.Cli_Nombre);
                    string resultado = "Código del Vehículo: " + tipoVehiculo.TVCodigo + "\n" +
                                       "Descripción del Vehículo: " + tipoVehiculo.Descripcion + "\n" +
                                       "Tarifa del Vehículo: " + tipoVehiculo.Tarifa + "\n";


                     // Guarda los datos (puedes implementar esta parte según tus necesidades)
                        // En este ejemplo, solo mostramos un MessageBox después de la confirmación
                     MessageBox.Show("Tipo de vehículo guardado con éxito.");
                    MessageBox.Show("Código del Vehículo: " + tipoVehiculo.TVCodigo + "\nDescripción del Vehículo: " + tipoVehiculo.Descripcion + "\nTarifa del Vehículo: " + tipoVehiculo.Tarifa);
                    MessageBox.Show(resultado, "Datos: ", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarForm();
                }
                else
                {
                    MessageBox.Show("TODOS LOS CAMPOS DEBEN ESTAR CARGADOS", "Aviso", MessageBoxButton.OK);
                }
            }
        }
    }
}
