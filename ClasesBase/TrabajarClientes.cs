using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    class TrabajarClientes
    {
        public static ObservableCollection<Cliente> TraerClientes() {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListarClientes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;

            DataTable oTablaClientes = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(oTablaClientes);

            var oListaClientes = new ObservableCollection<Cliente>();

            foreach (DataRow fila in oTablaClientes.Rows)
            {
                Cliente oCliente = new Cliente();

                oCliente.ClienteDNI = (int)fila["Dni"];
                oCliente.Nombre = (string)fila["Nombre"];
                oCliente.Apellido = (string)fila["Apellido"];
                oCliente.Telefono = (string)fila["Telefono"];

                oListaClientes.Add(oCliente);

            }
            return oListaClientes;
        }
    }
}
