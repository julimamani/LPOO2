﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarPlaya
    {
        public static ObservableCollection<TipoVehiculo> TraerTipos()
        {
            ObservableCollection<TipoVehiculo> vehiculos = new ObservableCollection<TipoVehiculo>();
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);

            string cadenaSQL = "SELECT * FROM TipoVehiculo";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoVehiculo tipoVehiculo = new TipoVehiculo
                        {
                            Descripcion = Convert.ToString(reader["Descripcion"]),
                            Tarifa = Convert.ToString(reader["Tarifa"]),
                            TVCodigo = Convert.ToString(reader["TVCodigo"]),
                        };

                        vehiculos.Add(tipoVehiculo);
                    }
                }
            }

            return vehiculos;
        }

        public static ObservableCollection<Sector> TraerSectoresPorZona(int zonaCodigo) {
            ObservableCollection<Sector> sectores = new ObservableCollection<Sector>();
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();
            //string cadenaSQL = "SELECT * FROM Sector WHERE ZonaCodigo = @Codigo";
            cmd.CommandText = "SELECT * FROM Sector WHERE ZonaCodigo = @Codigo";
            cmd.CommandType = CommandType.Text; // Usamos una consulta SQL directa
            cmd.Connection = cnn;

            SqlParameter param = new SqlParameter("@Codigo", SqlDbType.Int);
            param.Value = zonaCodigo;
            cmd.Parameters.Add(param);

            using (SqlConnection connection = cnn)
            {
                cnn.Open();

                //using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                //{
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Sector sector = new Sector
                        {
                            descripcion = Convert.ToString(reader["Descripcion"]),
                            habilitado = Convert.ToBoolean(reader["Habilitado"]),
                            identificador = Convert.ToString(reader["Identificador"]),
                            zonaCodigo = Convert.ToInt32(reader["ZonaCodigo"]),
                            sectorCodigo = Convert.ToInt32(reader["SectorCodigo"]),
                        };

                        sectores.Add(sector);
                    }
                //}
            }

            cnn.Close();

            return sectores;
        }

        public static Sector TraerSectorPorIdentificador(string id)
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();

            // Consulta SQL para seleccionar un cliente por DNI
            cmd.CommandText = "SELECT * FROM Sector WHERE Identificador = @ID";
            cmd.CommandType = CommandType.Text; // Usamos una consulta SQL directa
            cmd.Connection = cn;

            // Agregar el parámetro para el DNI del cliente
            SqlParameter param = new SqlParameter("@ID", SqlDbType.VarChar);
            param.Value = id;
            cmd.Parameters.Add(param);

            cn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Sector oSector = null;

            if (reader.Read())
            {
                oSector = new Sector();
                oSector.descripcion = (string)reader["Descripcion"];
                oSector.habilitado = (bool)reader["Habilitado"];
                oSector.identificador = (string)reader["Identificador"];
                oSector.sectorCodigo = (int)reader["SectorCodigo"];
                oSector.zonaCodigo = (int)reader["ZonaCodigo"];
            }

            cn.Close();

            return oSector;
        }

        public static void insertTicket(Ticket ticket) {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Ticket (ClienteDNI, Duracion, FechaHoraEnt, FechaHoraSal, Patente, SectorCodigo, Tarifa, TicketNro, Total, TVCodigo) VALUES (@dni, @duracion, @fechaent, @fechasal, @patente, @sector, @tarifa, @ticket, @total, @tvcodigo)";
                        cmd.Parameters.AddWithValue("@dni", ticket.ClienteDNI);
                        cmd.Parameters.AddWithValue("@duracion", ticket.Duracion);
                        cmd.Parameters.AddWithValue("@fechaent", ticket.FechaHoraEnt);
                        cmd.Parameters.AddWithValue("@fechasal", ticket.FechaHoraSal);
                        cmd.Parameters.AddWithValue("@patente", ticket.Patente);
                        cmd.Parameters.AddWithValue("@sector", ticket.SectorCodigo);
                        cmd.Parameters.AddWithValue("@tarifa", ticket.Tarifa);
                        cmd.Parameters.AddWithValue("@ticket", ticket.TicketNro);
                        cmd.Parameters.AddWithValue("@total", ticket.Total);
                        cmd.Parameters.AddWithValue("@tvcodigo", ticket.TVCodigo);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserción exitosa de ticket");
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "Error al agregar ticket: " + ex.Message;
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