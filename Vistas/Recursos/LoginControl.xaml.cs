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

namespace Vistas.Recursos
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
      //  private Main main;

        public LoginControl()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = textUser.Text;
            string password = passBox.Password;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                string roleName = ValidateLogin(userName, password);

                if (!string.IsNullOrEmpty(roleName))
                {
                    MessageBox.Show("Usuario y contraseña correctos", "INFO", MessageBoxButton.OK);
                    mostrarPrincipal(roleName);

                    //main = new Main(roleName);
                    //main.Show();
                    // Asegúrate de que se muestre la ventana Main
                    Window.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta", "ERROR", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Faltan llenar campos", "Fallo de autenticación", MessageBoxButton.OK);
            }
        }

        private string ValidateLogin(string userName, string password)
        {
            try
            {
                return trabajarUsuario.validate_login(userName, password);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al validar el usuario: " + ex.Message, "Error de autenticación", MessageBoxButton.OK);
                return string.Empty; // Devuelve una cadena vacía para indicar un error en la autenticación
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error. Por favor, contacta al administrador. " + ex.Message, "Error de autenticación", MessageBoxButton.OK);
                return string.Empty; // Devuelve una cadena vacía para indicar un error en la autenticación
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result;
            Result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
        private void mostrarPrincipal(string role)
        {
            Bienvenido bienvenido = new Bienvenido(role);
            bienvenido.Show();
        }
    }
}
