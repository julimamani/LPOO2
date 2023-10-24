
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ClasesBase
{
    public class trabajarUsuario
    {
        public static string validate_login(string szUsername, string szPassword)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "SELECT rol FROM Usuario " +
                                         "WHERE username = @user COLLATE SQL_Latin1_General_CP1_CS_AS " +
                                         "AND password = @pass COLLATE SQL_Latin1_General_CP1_CS_AS";
                        cmd.Parameters.AddWithValue("@user", szUsername);
                        cmd.Parameters.AddWithValue("@pass", szPassword);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                    }
                }

                return string.Empty; // Autenticación fallida
            }
            catch (SqlException ex)
            {
                string errorMessage = "Error al validar el usuario: " + ex.Message;
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
