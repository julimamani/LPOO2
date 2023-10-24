﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarTiposVehiculo
    {
        public DataTable TraerTiposVehiculo()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Select * From TipoVehiculo", cn))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }

     public static void insertarTipoVehiculo(TipoVehiculo tipoVehiculo)
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
                cmd.CommandText = "INSERT INTO TipoVehiculo (Descripcion, Tarifa, TVCodigo) VALUES (@descripcion, @tarifa, @tvcodigo)";
                cmd.Parameters.AddWithValue("@descripcion", tipoVehiculo.Descripcion);
                cmd.Parameters.AddWithValue("@tarifa", tipoVehiculo.Tarifa);
                cmd.Parameters.AddWithValue("@tvcodigo", tipoVehiculo.TVCodigo);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserción exitosa");
            }
        }
    }
    catch (SqlException ex)
    {
        string errorMessage = "Error al agregar el tipo de vehículo: " + ex.Message;
        throw new Exception(errorMessage);
    }
    catch (Exception ex)
    {
        string errorMessage = "Se produjo un error. Por favor, contacta al administrador. " + ex.Message;
        throw new Exception(errorMessage);
    }
}

      public static void EliminarTipoVehiculo(string codigoTipoVehiculo)
{
    try
    {
        // Asegúrate de que la conexión se abre sin errores.
        using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
        {
            cnn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM TipoVehiculo WHERE TVCodigo = @codigoTipoVehiculo";
                cmd.Parameters.AddWithValue("@codigoTipoVehiculo", codigoTipoVehiculo);

                cmd.ExecuteNonQuery();
            }
        }
    }
    catch (SqlException ex)
    {
        // Captura cualquier excepción y muestra un mensaje de error.
        string errorMessage = "Error al eliminar el tipo de vehículo: " + ex.Message;
        throw new Exception(errorMessage);
    }
    catch (Exception ex)
    {
        // Captura cualquier excepción y muestra un mensaje de error.
        string errorMessage = "Se produjo un error. Por favor, contacta al administrador. " + ex.Message;
        throw new Exception(errorMessage);
    }
}

    }

    }

