﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Usuario admin;
        private Usuario operador;
        private Main main;
        public Login()
        {
            InitializeComponent();
            inicializarUsuarios();
        }

        public void inicializarUsuarios(){
            admin = new Usuario( "admin", "admin","perez", "pepe", "1");
            operador = new Usuario("operador", "operador", "cordova", "luis", "2");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (textUser.Text == admin.UserName && passBox.Password == admin.Password)
            {
                MessageBox.Show("Usuario o contraseña correcta", "INFO", MessageBoxButton.OK);
                main = new Main("Admin");
                main.Show();
                this.Hide();
            }
            else if (textUser.Text == operador.UserName && passBox.Password == operador.Password) {
                main = new Main("Operador");
                main.Show();
                this.Close();
            }else {
                MessageBox.Show("Usuario o contraseña incorrecta", "ERROR", MessageBoxButton.OK);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
