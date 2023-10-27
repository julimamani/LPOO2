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
using System.Xml;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for EstadoSector.xaml
    /// </summary>
    public partial class EstadoSector : Window
    {
        public EstadoSector()
        {
            InitializeComponent();
            CargarDatosXml();
            EstablecerDataContext();
        }
        private void EstablecerDataContext()
        {
            // Crear una instancia de la clase de datos
            DatosDeSector datos = new DatosDeSector();

            // Cargar datos desde XML o configurar la propiedad Tiempo aquí
            CargarDatosXml(datos); // Implementa la lógica para cargar datos XML en la instancia 'datos'

            // Establecer la instancia de datos como el DataContext de la ventana
            this.DataContext = datos;
        }

        private void CargarDatosXml(DatosDeSector datos)
        {
            throw new NotImplementedException();
        }
        private void CargarDatosXml()
    {
        // Crear un objeto XmlDocument para cargar el archivo XML
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Tiempos.xml"); // Asegúrate de que el archivo XML esté en la misma ubicación que tu aplicación

        // Obtener los nodos de "Tiempo" del archivo XML
        XmlNodeList tiempoNodes = xmlDoc.SelectNodes("/Tiempos/Tiempo");

        // Recorrer los nodos y agregar los valores al ComboBox
        foreach (XmlNode tiempoNode in tiempoNodes)
        {
            cmbTiempos.Items.Add(tiempoNode.InnerText);
        }
    }
}
}