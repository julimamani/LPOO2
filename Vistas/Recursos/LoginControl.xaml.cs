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
namespace Vistas.Recursos
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        private Usuario admin;
        private Usuario operador;
        private Main main;

        public LoginControl()
        {
            InitializeComponent();
            inicializarUsuarios();
        }

        public void inicializarUsuarios()
        {
            admin = new Usuario("admin", "admin", "perez", "pepe", "1");
            operador = new Usuario("operador", "operador", "cordova", "luis", "2");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textUser.Text == admin.UserName && passBox.Password == admin.Password)
            {
                MessageBox.Show("Usuario y contraseña correctos", "INFO", MessageBoxButton.OK);
                main = new Main("Admin");
                main.Show();
                // Asegúrate de que se muestre la ventana Main
                Window.GetWindow(this).Close();
            }
            else if (textUser.Text == operador.UserName && passBox.Password == operador.Password)
            {
                MessageBox.Show("Usuario y contraseña correctos", "INFO", MessageBoxButton.OK);
                main = new Main("Operador");
                main.Show();
                // Cierra la ventana de login
                Window.GetWindow(this).Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "ERROR", MessageBoxButton.OK);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result;
            Result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
