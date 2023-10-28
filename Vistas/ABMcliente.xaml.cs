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
    public partial class ABMcliente : Page
    {
        Cliente cliente = new Cliente();

        public ABMcliente()
        {
            InitializeComponent();
            this.DataContext = new Cliente();
        }

        private void LimpiarForm_Click(object sender, RoutedEventArgs e)
        {
            LimpiarForm();
        }
        

        private void LimpiarForm()
        {
            txtDNI.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void GuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Cargar los datos del cliente desde los campos de texto u otros controles
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            // Asigna otros campos si es necesario

            // Luego, verifica si hay errores en la instancia del cliente
            string nombreError = cliente["Nombre"];
            string apellidoError = cliente["Apellido"];
            string telefonoError = cliente["Telefono"];

            if (string.IsNullOrEmpty(nombreError) && string.IsNullOrEmpty(apellidoError) && string.IsNullOrEmpty(telefonoError))
            {
                // Los datos son válidos, continúa con el proceso de guardado
                try
                {
                    TrabajarClientes.InsertarCliente(cliente);
                    MessageBox.Show("Cliente guardado con éxito.");
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el cliente: " + ex.Message);
                }
            }
            else
            {
                // Muestra mensajes de error o realiza acciones según corresponda
                MessageBox.Show("Por favor, complete todos los campos correctamente antes de guardar.");
            }
        }
        private void EliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Solicitar confirmación al usuario antes de eliminar el cliente
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el Cliente seleccionado?", "Eliminar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            // Obtener el DNI ingresado por el usuario
            string dni = txtDNI.Text;

            if (!string.IsNullOrEmpty(dni))
            {
                try
                {
                    // Verifica el valor de txtDNI.Text antes de llamar al método EliminarCliente.
                    int dniCliente = int.Parse(dni);

                    // Llama al método de ClasesBase para eliminar el cliente de la base de datos
                    TrabajarClientes.EliminarCliente(dniCliente);

                    // Muestra un mensaje de éxito
                    MessageBox.Show("Cliente eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Limpia los campos (reemplaza esto con tu función para limpiar los campos)
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de error en caso de excepción
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI válido para eliminar el cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        private void ModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (form_Completo() && controlDatos())
            {
                CargarDatos();

                try
                {
                    // Llama al método de ClasesBase para actualizar el cliente en la base de datos
                    TrabajarClientes.ActualizarCliente(cliente);
                    MessageBox.Show("Cliente modificado con éxito.");
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de modificar.");
            }
        }

        private bool form_Completo()
        {
            MessageBoxResult Result;

            Result = MessageBox.Show("¿Quiere guardar los datos?", "Confirmación ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return Result == MessageBoxResult.Yes;
        }

        private void CargarDatos()
        {
            cliente.ClienteDNI = int.Parse(txtDNI.Text);
            cliente.Apellido = txtApellido.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
        }

        private bool controlDatos()
        {
            return !string.IsNullOrEmpty(txtDNI.Text) &&
                   !string.IsNullOrEmpty(txtApellido.Text) &&
                   !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtTelefono.Text);
        }

        private void txtDNI_LostFocus(object sender, RoutedEventArgs e)
        {
            // Obten el valor del DNI ingresado por el usuario
            int dni;
            if (int.TryParse(txtDNI.Text, out dni))
            {
                // Llama al método TraerClientePorDNI de ClasesBase para buscar el cliente en la base de datos
                Cliente cliente = TrabajarClientes.TraerClientePorDNI(dni);

                if (cliente != null)
                {
                    // Si se encuentra un cliente, carga automáticamente los campos de apellido, nombre y teléfono
                    txtApellido.Text = cliente.Apellido;
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono;
                }
                else
                {
                    // Si el cliente no se encontró, puedes borrar los campos o mostrar un mensaje de error.
                    txtApellido.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                }
            }
        }

    }
}