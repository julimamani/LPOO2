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
        public ObservableCollection<Ticket> Tickets { get; set; }
        public ObservableCollection<TipoVehiculo> Vehiculos { get; set; }
        public Ticket ticketObtenido;
        public Playa(string identificador)
        {
            InitializeComponent();
            CargarDatosXml();
            DataContext = this;
            sector = TrabajarPlaya.TraerSectorPorIdentificador(identificador);
            txtSector.Text = sector.identificador;
            Vehiculos = TrabajarPlaya.TraerTipos();
            if (sector.habilitado)
            {
                stkTicket.Visibility = Visibility.Collapsed;
                stkFechEnt.Visibility = Visibility.Collapsed;
                stkFechSal.Visibility = Visibility.Collapsed;
                ClientesDni = TrabajarClientes.TraerClientes();
                txtEntrada.Visibility = Visibility.Collapsed;
                txtSalida.Visibility = Visibility.Collapsed;
                cmbTickets.Visibility = Visibility.Collapsed;
                stkCliente.Visibility = Visibility.Collapsed;
                stkTiempo.Visibility = Visibility.Collapsed;
            }
            else {
                txtTitle.Text = "Registro Salida";
                Tickets = TrabajarPlaya.TraerTickets();
                cmbClientes.IsEnabled = false;
                txtPatente.IsEnabled = false;
                stkDni.Visibility = Visibility.Collapsed;
                cmbClientes.Visibility = Visibility.Collapsed;
                stkDuracion.Visibility = Visibility.Collapsed;
                cmbTiempos.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (sector.habilitado)
            {
                registrarEntrada();
            }
            else {
                registrarSalida();
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            limpiarForm();
            Content = new FrmEstacionamiento();
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
            if (!sector.habilitado) txtTotal.Text = (int.Parse(txtTarifa.Text) * int.Parse(txtDuracion.Text)).ToString();
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

        private void cmbTickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTickets.SelectedItem != null) {
                ticketObtenido = ((Ticket)cmbTickets.SelectedItem);
                txtCliente.Text = ticketObtenido.ClienteDNI.ToString();
                txtPatente.Text = ticketObtenido.Patente;
                txtEntrada.Text = ticketObtenido.FechaHoraEnt.ToString("dd/MM/yyyy HH:mm");
                txtSalida.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                TimeSpan diff = DateTime.Now.Subtract(ticketObtenido.FechaHoraEnt);
                double diffMin = diff.TotalMinutes;
                txtDuracion.Text = diffMin.ToString("F0");
            }
        }

        private void registrarEntrada() {
            Ticket ticket = new Ticket();
            ticket.ClienteDNI = ((Cliente)cmbClientes.SelectedItem).ClienteDNI;
            string cliente = ((Cliente)cmbClientes.SelectedItem).Nombre + " " + ((Cliente)cmbClientes.SelectedItem).Apellido;
            ticket.Patente = txtPatente.Text;
            ticket.SectorCodigo = sector.sectorCodigo;
            ticket.TVCodigo = int.Parse(((TipoVehiculo)cmbVehiculos.SelectedItem).TVCodigo);
            string tipoVehiculo = ((TipoVehiculo)cmbVehiculos.SelectedItem).Descripcion;
            Random rnd = new Random();
            string formatoTicket = string.Format("{0:D6}", rnd.Next(100, 199 + 1) + sector.sectorCodigo);
            ticket.TicketNro = formatoTicket;
            DateTime fechaActual = DateTime.Now;
            ticket.FechaHoraEnt = fechaActual;
            ticket.Tarifa = Decimal.Parse(txtTarifa.Text);
            ticket.Duracion = Double.Parse(cmbTiempos.SelectedValue.ToString());
            ticket.Total = Decimal.Parse(txtTotal.Text);
            ticket.FechaHoraSal = fechaActual.AddMinutes(ticket.Duracion);
            
            TrabajarPlaya.insertTicket(ticket);

            PreviewTicket prevTicket = new PreviewTicket(ticket, cliente, tipoVehiculo, sector.habilitado);
            prevTicket.Show();
            Content = new FrmEstacionamiento();
            sector.habilitado = false;
            sector.fechaHoraUltima = DateTime.Now;
            TrabajarPlaya.desahibilitarSector(sector);
        
        }

        private void registrarSalida()
        {
            Ticket ticket = new Ticket();
            ticket.ClienteDNI = ticketObtenido.ClienteDNI;
            ticket.Duracion = Convert.ToDouble(txtDuracion.Text);
            ticket.FechaHoraEnt = ticketObtenido.FechaHoraEnt;
            ticket.FechaHoraSal = DateTime.Now;
            ticket.Patente = txtPatente.Text;
            ticket.SectorCodigo = ticketObtenido.SectorCodigo;
            ticket.Tarifa = Decimal.Parse(txtTarifa.Text);
            ticket.Total = Decimal.Parse(txtTotal.Text);
            ticket.TVCodigo = int.Parse(((TipoVehiculo)cmbVehiculos.SelectedItem).TVCodigo);
            Random rnd = new Random();
            string formatoTicket = string.Format("{0:D6}", rnd.Next(100, 199 + 1) + sector.sectorCodigo);
            ticket.TicketNro = formatoTicket;
            TrabajarPlaya.insertTicket(ticket);
            Cliente clienteObtenido = TrabajarClientes.TraerClientePorDNI(ticket.ClienteDNI);
            string cliente = clienteObtenido.Nombre + ", " + clienteObtenido.Apellido;
            string tipoVehiculo = ((TipoVehiculo)cmbVehiculos.SelectedItem).Descripcion;
            PreviewTicket prevTicket = new PreviewTicket(ticket, cliente, tipoVehiculo, sector.habilitado);
            prevTicket.Show();
            Content = new FrmEstacionamiento();
            sector.habilitado = true;
            sector.fechaHoraUltima = DateTime.Now;
            TrabajarPlaya.desahibilitarSector(sector);
        }
    
    }
}
