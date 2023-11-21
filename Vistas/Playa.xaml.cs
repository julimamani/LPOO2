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
using System.Collections.ObjectModel;
using System.Xml;
using System.Windows.Markup;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Playa.xaml
    /// </summary>
    public partial class Playa : Page
    {
        public Sector sector;
        public ObservableCollection<Cliente> ClientesDni { get; set; }
        public ObservableCollection<TipoVehiculo> Vehiculos { get; set; }
        public Playa(string identificador)
        {
            InitializeComponent();
            CargarDatosXml();
            DataContext = this;
            sector = TrabajarPlaya.TraerSectorPorIdentificador(identificador);
            txtSector.Text = sector.identificador;
            ClientesDni = TrabajarClientes.TraerClientes();
            Vehiculos = TrabajarPlaya.TraerTipos();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.ClienteDNI = ((Cliente)cmbClientes.SelectedItem).ClienteDNI;
            string cliente = ((Cliente)cmbClientes.SelectedItem).Nombre + " "+((Cliente)cmbClientes.SelectedItem).Apellido;
            ticket.Patente = txtPatente.Text;
            ticket.SectorCodigo = sector.sectorCodigo;
            ticket.TVCodigo = int.Parse(((TipoVehiculo)cmbVehiculos.SelectedItem).TVCodigo);
            string tipoVehiculo = ((TipoVehiculo)cmbVehiculos.SelectedItem).Descripcion;
            string formatoTicket = string.Format("{0:D6}", sector.sectorCodigo);
            ticket.TicketNro = formatoTicket;
            DateTime fechaActual = DateTime.Now;
            ticket.FechaHoraEnt = fechaActual;
            ticket.Tarifa = Decimal.Parse(txtTarifa.Text);
            ticket.Duracion = Double.Parse(cmbTiempos.SelectedValue.ToString());
            ticket.Total = Decimal.Parse(txtTotal.Text);
            ticket.FechaHoraSal = fechaActual.AddMinutes(ticket.Duracion);
            TrabajarPlaya.insertTicket(ticket);
            PreviewTicket prevTicket = new PreviewTicket(ticket, cliente, tipoVehiculo);
            prevTicket.Show();
            Content = new FrmABMVehiculo();
            
           // limpiarForm();
            
        
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            limpiarForm();
            Content = new FrmABMVehiculo();
        }

        private void LimpiarForm_Click(object sender, RoutedEventArgs e)
        {
            limpiarForm();
        }

        private void CargarDatosXml()
        {
            // Crear un objeto XmlDocument para cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("./../../Tiempos.xml"); // Asegúrate de que el archivo XML esté en la misma ubicación que tu aplicación

            // Obtener los nodos de "Tiempo" del archivo XML
            XmlNodeList tiempoNodes = xmlDoc.SelectNodes("/Tiempos/Tiempo");

            // Recorrer los nodos y agregar los valores al ComboBox
            foreach (XmlNode tiempoNode in tiempoNodes)
            {
                cmbTiempos.Items.Add(tiempoNode.InnerText);
            }
        }

        private void cmbVehiculos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVehiculos.SelectedItem != null)
            txtTarifa.Text = ((TipoVehiculo)cmbVehiculos.SelectedItem).Tarifa;
            if (cmbTiempos.SelectedValue != null)
                txtTotal.Text = (int.Parse(txtTarifa.Text) * int.Parse(cmbTiempos.SelectedValue.ToString())).ToString();
        }

        private void cmbTiempos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtTarifa.Text != "")
                txtTotal.Text = (int.Parse(txtTarifa.Text) * int.Parse(cmbTiempos.SelectedValue.ToString())).ToString();
        }

        public void limpiarForm() {
            cmbClientes.SelectedValue = "";
            txtPatente.Text = "";
            cmbVehiculos.SelectedValue = "";
            txtTarifa.Text = "";
            cmbTiempos.SelectedValue = "";
            txtTotal.Text = "";
        }
    
    }
}
