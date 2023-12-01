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
using System.Collections.ObjectModel;
using ClasesBase;
namespace Vistas
{
     public partial class ABMUsuario : Page
    {
        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuario;

        public ABMUsuario()
        {
            InitializeComponent();
            actualizar_lista();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuario = odp.Data as ObservableCollection<Usuario>;

            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
        }

        private void actualizar_lista()
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuario = odp.Data as ObservableCollection<Usuario>;

            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast)
            {
                Vista.MoveCurrentToFirst();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        // ABM
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            trabajarUsuario.EliminarUsuario(txtUsername.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cmbRol.SelectedIndex = 0;
            btnModificar.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnEliminar.IsEnabled = false;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            trabajarUsuario.AgregarUsuario(obtenerUsuario());
            MessageBox.Show("Usuario agregado");
            actualizar_lista();
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = txbApellido.Text;
            txtNombre.Text = txbNombre.Text;
            txtUsername.Text = txbUsuario.Text;
            txtPassword.Text = txbPassword.Text;

            if (txbRol.Text == "Admin")
                cmbRol.SelectedIndex = 0;
            else
                cmbRol.SelectedIndex = 1;

            btnModificar.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnEliminar.IsEnabled = true;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            trabajarUsuario.ModificarUsuario(obtenerUsuario());
            MessageBox.Show("Usuario modificado");
        }

        private Usuario obtenerUsuario()
        {
            Usuario user = new Usuario();

            user.Apellido = txtApellido.Text;
            user.Nombre = txtNombre.Text;
            user.Password = txtPassword.Text;
            user.UserName = txtUsername.Text;

            if (cmbRol.SelectedIndex == 0)
                user.Rol = "admin";
            else
                user.Rol = "operador";

            return user;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(null);
        }
    }
}


