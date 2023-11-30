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
using System.Data;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Ventas.xaml
    /// </summary>
    public partial class Ventas : UserControl
    {
            DataTable dtVentas;
            string total;

            public Ventas()
            {
                InitializeComponent();
                CargarDatosDeVentas();
            }
            private void CargarDatosDeVentas()
            {
                DataTable dtVentas = TrabajarPlaya.TraerTicketsVendidos();
                dgVentas.ItemsSource = dtVentas.DefaultView;

                object resultado = dtVentas.Compute("SUM(Total)", ""); // Modificada la columna de sumatoria
                string total = resultado != DBNull.Value ? Convert.ToString(resultado) : "0";
                txtTotal.Text = total;
            }

            private void btnBuscar_Click(object sender, RoutedEventArgs e)
            {
                {
                    if (datePickerFechaEntrada.SelectedDate == null && datePickerFechaSalida.SelectedDate == null)
                    {
                        dtVentas = TrabajarPlaya.TraerTicketsVendidos();
                        dgVentas.ItemsSource = dtVentas.DefaultView;

                        object resultado = dtVentas.Compute("SUM(Total)", "");
                        if (resultado != DBNull.Value)
                        {
                            total = Convert.ToString(resultado);
                            txtTotal.Text = total;
                        }
                        else
                        {
                            total = "0";
                            txtTotal.Text = total;
                        }
                    }
                    else if (datePickerFechaEntrada.SelectedDate == null || datePickerFechaSalida.SelectedDate == null)
                    {
                        MessageBox.Show("Ingrese un rango de fechas", "Error");
                    }
                    else if (datePickerFechaEntrada.SelectedDate > datePickerFechaSalida.SelectedDate)
                    {
                        MessageBox.Show("Ingrese un rango de fechas posible", "Error");
                    }
                    else
                    {
                        dtVentas = TrabajarPlaya.TraerTicketsVendidosPorFecha(datePickerFechaEntrada.SelectedDate.Value, datePickerFechaSalida.SelectedDate.Value);
                        dgVentas.ItemsSource = dtVentas.DefaultView;

                        object resultado = dtVentas.Compute("SUM(Total)", "");
                        if (resultado != DBNull.Value)
                        {
                            total = Convert.ToString(resultado);
                            txtTotal.Text = total;
                        }
                        else
                        {
                            total = "0";
                            txtTotal.Text = total;
                        }
                    }
                }
            }

            private void btnImprimir_Click(object sender, RoutedEventArgs e)
            {
                if (TieneDatos(dtVentas))
                {
                    VistaPreviaVentas vistaPreviaVentasWindow = new VistaPreviaVentas (dtVentas, total);
                    vistaPreviaVentasWindow.Show();

                }
                else
                {
                    MessageBox.Show("No hay datos para imprimir", "Error");
                }

            }

            static bool TieneDatos(DataTable dataTable)
            {
                // Verificar si hay al menos una fila en el DataTable
                return (dataTable != null && dataTable.Rows.Count > 0);
            }
        }
    
}
