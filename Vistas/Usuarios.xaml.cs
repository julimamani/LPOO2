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
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void FrameUsuarios_Loaded(object sender, RoutedEventArgs e)
        {
            GridDatos.ItemsSource = trabajarUsuario.obtenerUsuariosAsc().DefaultView;
        }

        private void abrirAbmUsuario(object sender, RoutedEventArgs e)
        {
            ABMUsuario abm = new ABMUsuario();
            FrameUsuarios.Content = abm;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string usernameBuscado = txtBuscar.Text;
            GridDatos.ItemsSource = trabajarUsuario.obtenerUsuariosPorUsername(usernameBuscado).DefaultView;
        }

        private void VistaPreviaImprimir(object sender, RoutedEventArgs e)
        {
            VistaPreviaImpr abm = new VistaPreviaImpr();
            FrameUsuarios.Content = abm;
        }
    }
}
