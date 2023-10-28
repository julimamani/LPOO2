using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarClientes
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
        public static Cliente TraerClientePorDNI(int clienteDNI)
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();

            // Consulta SQL para seleccionar un cliente por DNI
            cmd.CommandText = "SELECT * FROM Cliente WHERE ClienteDNI = @DNI";
            cmd.CommandType = CommandType.Text; // Usamos una consulta SQL directa
            cmd.Connection = cn;

            // Agregar el parámetro para el DNI del cliente
            SqlParameter param = new SqlParameter("@DNI", SqlDbType.Int);
            param.Value = clienteDNI;
            cmd.Parameters.Add(param);

            cn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Cliente oCliente = null;

            if (reader.Read())
            {
                oCliente = new Cliente();
                oCliente.ClienteDNI = (int)reader["clienteDNI"];
                oCliente.Nombre = (string)reader["Nombre"];
                oCliente.Apellido = (string)reader["Apellido"];
                oCliente.Telefono = (string)reader["Telefono"];
            }

            cn.Close();

            return oCliente;
        }

        public static void InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Cliente (ClienteDNI, Apellido, Nombre, Telefono) VALUES (@dni, @apellido, @nombre, @telefono)";
                        cmd.Parameters.AddWithValue("@dni", cliente.ClienteDNI);
                        cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserción exitosa de cliente");
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "Error al agregar el cliente: " + ex.Message;
                throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "Se produjo un error. Por favor, contacta al administrador. " + ex.Message;
                throw new Exception(errorMessage);
            }
        }

        public static void EliminarCliente(int dni)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM Cliente WHERE ClienteDNI = @dni";
                        cmd.Parameters.AddWithValue("@dni", dni);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Eliminación exitosa de cliente");
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "Error al eliminar el cliente: " + ex.Message;
                throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "Se produjo un error. Por favor, contacta al administrador. " + ex.Message;
                throw new Exception(errorMessage);
            }

        }

        public static void ActualizarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Cliente SET Apellido = @apellido, Nombre = @nombre, Telefono = @telefono WHERE ClienteDNI = @dni";
                        cmd.Parameters.AddWithValue("@dni", cliente.ClienteDNI);
                        cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Modificación exitosa de cliente");
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "Error al actualizar el cliente: " + ex.Message;
                throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "Se produjo un error. Por favor, contacta al administrador. " + ex.Message;
                throw new Exception(errorMessage);
            }
        }

    }
}
