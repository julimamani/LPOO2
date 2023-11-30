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
using System.Data;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for VistaPreviaVentas.xaml
    /// </summary>
    public partial class VistaPreviaVentas : Window
    {
       DataTable dtVentas;
        string totalVentas;

        public VistaPreviaVentas(DataTable ventas, string total)
        {
            InitializeComponent();
            dtVentas = ventas;
            totalVentas = total;
            CargarDatosDeVentas();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)DocVentas).DocumentPaginator, "Impresión Documento Dinámico");
            }
        }

        private void CargarDatosDeVentas()
        {
            dgVentas.ItemsSource = dtVentas.DefaultView;
            totalDeVentas.Text = totalVentas;
        }
    }
    
}
