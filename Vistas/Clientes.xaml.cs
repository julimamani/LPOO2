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
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        TrabajarClientes trabajarClientes = new TrabajarClientes();
        public Clientes()
        {
            InitializeComponent();
        }

        private void abrirAbmCliente(object sender, RoutedEventArgs e)
        {
            ABMcliente clienteAbm = new ABMcliente();
            FrameClientes.Content = clienteAbm;
            clienteAbm.btnModificar.IsEnabled = false;
            clienteAbm.btnModificar.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void modificar_click(object sender, RoutedEventArgs e)
        {
            int dni = (int)((Button)sender).CommandParameter;

            Cliente cliente = TrabajarClientes.TraerClientePorDNI(dni);
            //cliente.Validar = false;
            if (cliente != null)
            {
                
                ABMcliente abm = new ABMcliente();
                FrameClientes.Content = abm;
                abm.btnGuardar.IsEnabled = false;
                abm.btnGuardar.Background = new SolidColorBrush(Colors.Transparent);
                abm.txtDNI.Text = cliente.ClienteDNI.ToString();
                abm.txtApellido.Text = cliente.Apellido;
                abm.txtNombre.Text = cliente.Nombre;
                abm.txtTelefono.Text = cliente.Telefono;
                //cliente.Validar = true;
 
            }
        }

        private void eliminar_click(object sender, RoutedEventArgs e)
        {
            int dni = (int)((Button)sender).CommandParameter;
            // Solicitar confirmación al usuario antes de eliminar el cliente
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el Cliente seleccionado?", "Eliminar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;
                try
                {

                    // Llama al método de ClasesBase para eliminar el cliente de la base de datos
                    TrabajarClientes.EliminarCliente(dni);
                    GridDatos.ItemsSource = trabajarClientes.ObtenerClientes().DefaultView;
                    // Muestra un mensaje de éxito
                    MessageBox.Show("Cliente eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Limpia los campos (reemplaza esto con tu función para limpiar los campos)
                    //LimpiarForm();
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de error en caso de excepción
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
         
        }

        private void FrameClientes_Loaded(object sender, RoutedEventArgs e)
        {
            GridDatos.ItemsSource = trabajarClientes.ObtenerClientes().DefaultView;
        }
    }
}
