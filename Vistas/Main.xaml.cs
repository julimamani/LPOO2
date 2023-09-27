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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
{
    public MainWindow(string rol)
    {
        InitializeComponent();

        if (rol == "Admin")
        {
            // Habilitar funciones de gestión de Sectores , Tipos de Vehículo , gestión de Clientes y gestión de Estacionamiento
            btnGestionSectores.IsEnabled = true;
            btnGestionTiposVehiculo.IsEnabled = true;
            btnGestionClientes.IsEnabled = true;
            btnGestionEstacionamiento.IsEnabled = true;
        }
        else if (rol == "Operador")
        {
            // Habilitar funciones de gestión de Clientes y Gestión de Estacionamiento
            btnGestionClientes.IsEnabled = true;
            btnGestionEstacionamiento.IsEnabled = true;
        }
    }
}
}