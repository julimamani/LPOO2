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
        public ABMcliente()
        {
            InitializeComponent();
        }
        private void GuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de Cliente y asignar los valores ingresados
            Cliente cliente = new Cliente
            {
                ClienteDNI = int.Parse(txtDNI.Text),
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text
            };

            // Muestra un cuadro de diálogo de confirmación antes de guardar
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de guardar?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Guarda los datos (puedes implementar esta parte según tus necesidades)
                // En este ejemplo, solo mostramos un MessageBox después de la confirmación
                MessageBox.Show("Cliente guardado con éxito.");
                MessageBox.Show("DNI del Cliente: " + cliente.ClienteDNI + "\nApellido del Cliente: " + cliente.Apellido + "\nNombre del Cliente: " + cliente.Nombre + "\nTeléfono del Cliente: " + cliente.Telefono);
            }
        }
    }
}
