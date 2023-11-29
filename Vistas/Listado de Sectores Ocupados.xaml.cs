using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Printing;
using System.Drawing.Printing;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;
using System.IO;
using ClasesBase;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for Listado_de_Sectores_Ocupados.xaml
    /// </summary>
    public partial class Listado_de_Sectores_Ocupados : Window
    {
        public Listado_de_Sectores_Ocupados()
        {
            InitializeComponent();

            List<SectorOcupado> sectoresOcupados = ObtenerDatosSectoresOcupados();
            dataGrid.ItemsSource = sectoresOcupados;
        }

        public List<SectorOcupado> ObtenerDatosSectoresOcupados()
        {
            // Aquí deberías obtener los datos reales de tu aplicación
            // Esta es solo una simulación
            return new List<SectorOcupado>
            {
                new SectorOcupado { Zona = "Zona1", Sector = "A", FechaHoraEntrada = DateTime.Now, ApellidoNombreCliente = "Cliente1", TipoVehiculo = "Auto", Patente = "123ABC", TiempoTranscurrido = TimeSpan.FromHours(1) },
                new SectorOcupado { Zona = "Zona2", Sector = "B", FechaHoraEntrada = DateTime.Now.AddHours(-2), ApellidoNombreCliente = "Cliente2", TipoVehiculo = "Camión", Patente = "456DEF", TiempoTranscurrido = TimeSpan.FromHours(2) }
            };
        }

        private void ImprimirButton_Click(object sender, RoutedEventArgs e)
        {
            // Crear un documento XPS
            using (XpsDocument doc = new XpsDocument("ListadoSectoresOcupados.xps", FileAccess.Write))
            {
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

                // Crear una representación visual de la grilla
                DataGrid dataGridToPrint = new DataGrid
                {
                    ItemsSource = dataGrid.ItemsSource
                };

                // Escribir el contenido de la grilla en el documento XPS
                writer.Write(dataGridToPrint);
            }

            // Imprimir el documento XPS
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(dataGrid, "Listado de Sectores Ocupados");
            }
        }
    }
}

