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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        public Main(string rol)
        {
            InitializeComponent();
            MessageBox.Show(" Rol: " + rol, "INFO", MessageBoxButton.OK);
            string roleName = rol.Trim();
            if (roleName == "admin")
            {
                // Habilitar funciones de gestión de Sectores , Tipos de Vehículo , gestión de Clientes y gestión de Estacionamiento
                btnGestionSectores.IsEnabled = true;
               btnGestionTiposVehiculo.IsEnabled = true;
                btnGestionClientes.IsEnabled = true;
                btnGestionEstacionamiento.IsEnabled = true;
            }
            else if (roleName == "operador")
            {
                // Habilitar funciones de gestión de Clientes y Gestión de Estacionamiento
                btnGestionClientes.IsEnabled = true;
                btnGestionEstacionamiento.IsEnabled = true;
            }

            
        }

        private void btnGestionSectores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGestionTiposVehiculo_Click(object sender, RoutedEventArgs e)
        {
           // Principal.Content = new ABMtipoVehiculo();
            DataContext = new TiposVehiculos();

        }

        private void btnGestionClientes_Click(object sender, RoutedEventArgs e)
        {
            //Principal.Content = new ABMcliente();
            DataContext = new Clientes();
        }

        private void btnGestionEstacionamiento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void TBShow(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;
        }

        private void PreviewMouseLeftDownBG(object sender, MouseButtonEventArgs e)
        {
            BtnShowHide.IsChecked = false;
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
        private void btnGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {

            ABMUsuario USUARIO = new ABMUsuario();

        }

    }
}