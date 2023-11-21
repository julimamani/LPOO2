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
using System.Windows.Markup;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for PreviewTicket.xaml
    /// </summary>
    public partial class PreviewTicket : Window
    {
        public PreviewTicket(Ticket ticket, string cliente, string tipo)
        {
            InitializeComponent();
            FixedDocument documento = GenerarDocumento(ticket,cliente, tipo);
            DocumentViewer.Document = documento;
        }

        private FixedDocument GenerarDocumento(Ticket ticket, string cliente, string tipo)
        {
            // Crear un nuevo documento fijo
            FixedDocument fixedDocument = new FixedDocument();

            // Crear una nueva página
            PageContent pageContent = new PageContent();
            fixedDocument.Pages.Add(pageContent);

            // Crear un nuevo contenedor fijo para la página
            FixedPage fixedPage = new FixedPage();
            pageContent.Child = fixedPage;

            // Crear un lienzo (Canvas) para agregar elementos
            Canvas canvas = new Canvas();
            fixedPage.Children.Add(canvas);


            Image imagen = new Image();
            imagen.Source = new BitmapImage(new Uri("Imagenes/logo.png", UriKind.Relative)); // Reemplaza con la ruta de tu imagen
            imagen.Width = 60; // Ajusta el ancho de la imagen según sea necesario
            imagen.Height = 60;

            Canvas.SetTop(imagen, 10);
            Canvas.SetLeft(imagen, 10);

            TextBlock titulo = new TextBlock();
            titulo.Text = "PLAYA DE ESTACIONAMIENTO";
            titulo.FontSize = 16;
            // Agregar un TextBlock con el formato especificado
            TextBlock texto = new TextBlock();
            texto.Text =
               "Balcarce 200                   CUIT: 30-123424-6 \r\n" +
               "S.S de Jujuy                   IIBB: 999         \r\n" +
               "#################################################\r\n" + 
               "Ticket #: " + ticket.TicketNro + "\r\n" +
               "Cliente: "+ cliente +"\r\n" +
               "Patente: "+ ticket.Patente + "\r\n" +
               "Ingreso: " + ticket.FechaHoraEnt.ToString("dd/MM/yyyy HHmm") + "\r\n" +
               "Tipo Vehículo: "+ tipo + "\r\n" +
               "Tarifa: " + ticket.Tarifa + "\r\n" +
               "##################################################\r\n" +
               "Usuario: Operador";

            // Establecer la posición del TextBlock
            Canvas.SetTop(texto, 50);
            Canvas.SetLeft(texto, 50);
            fixedPage.Children.Add(imagen);
            fixedPage.Children.Add(titulo);
            // Agregar el TextBlock al lienzo
            canvas.Children.Add(texto);

            return fixedDocument;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)
                DocumentViewer.Document).DocumentPaginator, "Impresión Documento Fijo");
                this.Close();
            } 
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
