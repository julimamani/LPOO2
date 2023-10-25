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
    /// Interaction logic for ABMcliente.xaml
    /// </summary>
    public partial class ABMcliente : Page
    {
        Cliente cliente = new Cliente();

        public ABMcliente()
        {
            InitializeComponent();
        }

        private bool form_Completo()
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
            cliente.ClienteDNI = int.Parse(txtDNI.Text);
            cliente.Apellido = txtApellido.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
        }

        private bool controlDatos()
        {
            if (txtDNI.Text == "" || txtApellido.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "")
                return false;
            else
                return true;
        }
        private void LimpiarForm_Click(object sender, RoutedEventArgs e)
        {
            limpiarForm();
        }

        private void limpiarForm()
        {
            txtDNI.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;

        }


        private void GuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (form_Completo() == true)
            {
                if (controlDatos() == true)
                {
                    cargarDatos();
                    //MessageBox.Show("Nombre guardado: " + cliente.Cli_Nombre);
                    string resultado = "DNI del Cliente: " + cliente.ClienteDNI + "\n" +
                                       "Apellido del Cliente: " + cliente.Apellido + "\n" +
                                       "Nombre del Cliente: " + cliente.Nombre + "\n" +
                                       "Teléfono del Cliente: " + cliente.Telefono;


                    // Guarda los datos (puedes implementar esta parte según tus necesidades)
                    // En este ejemplo, solo mostramos un MessageBox después de la confirmación
                    MessageBox.Show("Cliente guardado con éxito.");
                    MessageBox.Show("DNI del Cliente: " + cliente.ClienteDNI + "\nApellido del Cliente: " + cliente.Apellido + "\nNombre del Cliente: " + cliente.Nombre + "\nTeléfono del Cliente: " + cliente.Telefono);
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
