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
    /// Interaction logic for VistaPreviaImpr.xaml
    /// </summary>
    
    public partial class VistaPreviaImpr : UserControl
    {
        public void iniciar(){
            InitializeComponent();
        }

        public List<ClasesBase.Usuario> listUsuario { get; set; }
        public VistaPreviaImpr()
        {
            InitializeComponent();
            dgUsers.AutoGeneratingColumn += dataGridListUsuarios_AutoGeneratingColumn;
            listUsuario = ClasesBase.trabajarUsuario.ListarUsuarios();
            cargarDatos();
        }


        private void cargarDatos()
        {
            dgUsers.ItemsSource = listUsuario;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)ImprUsuarios).DocumentPaginator, "Impresión desde Vista Previa");
            }
            this.Visibility = Visibility.Collapsed;
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
