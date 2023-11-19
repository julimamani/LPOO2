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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListaUsuarios.xaml
    /// </summary>
    public partial class VistaPreviaImpr : Window
    {
       
        public List<ClasesBase.Usuario> listUsuario { get; set; }
        public VistaPreviaImpr(){
            dataGridListUsuarios.AutoGeneratingColumn += dataGridListUsuarios_AutoGeneratingColumn;
            listUsuario = ClasesBase.TrabajarUsuario.ListarUsuarios();
            cargarDatos();
        }

       
        private void cargarDatos() {
            dataGridListUsuarios.ItemsSource = listUsuario;
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)DocPrueba).DocumentPaginator, "Impresión desde Vista Previa");
            }
        }
        private void dataGridListUsuarios_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // Cambiar el tamaño de las columnas como desees
            if (e.PropertyName == "Nombre")
            {
                e.Column.Width = 150; // Cambia 150 al valor que desees
            }
            // Puedes agregar más condiciones para otras columnas si es necesario
        }
    }
}
