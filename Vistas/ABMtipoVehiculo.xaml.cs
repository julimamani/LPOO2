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
        public ABMtipoVehiculo()
        {
            InitializeComponent();
        }
         private void GuardarTipoVehiculo_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de TipoVehiculo y asignar los valores ingresados
            TipoVehiculo tipoVehiculo = new TipoVehiculo
            {
                TVCodigo = int.Parse(txtCodigo.Text),
                Descripcion = txtDescripcion.Text,
                Tarifa = decimal.Parse(txtTarifa.Text)
            };

            // Muestra un cuadro de diálogo de confirmación antes de guardar
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de guardar?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Guarda los datos (puedes implementar esta parte según tus necesidades)
                // En este ejemplo, solo mostramos un MessageBox después de la confirmación
                MessageBox.Show("Tipo de vehículo guardado con éxito.");
                MessageBox.Show("Código del Vehículo: " + tipoVehiculo.TVCodigo + "\nDescripción del Vehículo: " + tipoVehiculo.Descripcion + "\nTarifa del Vehículo: " + tipoVehiculo.Tarifa);
            }
           
        }
    }
}
