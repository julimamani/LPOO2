
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// variable Objeto estatica que guarda los datos de login de usuario
        /// </summary>
        public static Usuario usuario = new Usuario();
         public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();
           SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);

            string cadenaSQL = "SELECT * FROM Usuario";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            UserName = Convert.ToString(reader["UserName"]),
                            Password = Convert.ToString(reader["Password"]),
                            Apellido = Convert.ToString(reader["Apellido"]),
                            Nombre = Convert.ToString(reader["Nombre"]),
                            Rol = Convert.ToString(reader["Rol"])
                        };

                        listaUsuario.Add(usuario);
                    }
                }
            }

            return listaUsuario;

            //listaUsuario.Add(new Usuario("Kami", "1273", "Administrador","Calderon","Emilio"));
            //listaUsuario.Add(new Usuario("Primm", "1423", "Operador","Casasola","Yaz"));
            //listaUsuario.Add(new Usuario("ZApit", "1253", "Administrador","Ferril","Fabian"));
            //listaUsuario.Add(new Usuario("Astrox", "1263", "Operador","Brama","Soledad"));

        }

        public static List<Usuario> ListarUsuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            List<Usuario> usuarios = new List<Usuario>();

            string cadenaSQL = "SELECT * FROM Usuario";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            UserName = Convert.ToString(reader["UserName"]),
                            Password = Convert.ToString(reader["Password"]),
                            Apellido = Convert.ToString(reader["Apellido"]),
                            Nombre = Convert.ToString(reader["Nombre"]),
                            Rol = Convert.ToString(reader["Rol"])
                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }


        public static void AgregarUsuario(Usuario nuevoUsuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);


            string cadenaSQL = "INSERT INTO Usuario (UserName, Password, Apellido, Nombre, Rol) " +
                           "VALUES (@UserName, @Password, @Apellido, @Nombre, @Rol)";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    command.Parameters.AddWithValue("@UserName", nuevoUsuario.UserName);
                    command.Parameters.AddWithValue("@Password", nuevoUsuario.Password);
                    command.Parameters.AddWithValue("@Apellido", nuevoUsuario.Apellido);
                    command.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                    command.Parameters.AddWithValue("@Rol", nuevoUsuario.Rol);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarUsuario(Usuario usuarioModificado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);

            string cadenaSQL = "UPDATE Usuario " +
                           "SET Password = @Password, Apellido = @Apellido, Nombre = @Nombre, Rol = @Rol " +
                           "WHERE UserName = @UserName";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    command.Parameters.AddWithValue("@Password", usuarioModificado.Password);
                    command.Parameters.AddWithValue("@Apellido", usuarioModificado.Apellido);
                    command.Parameters.AddWithValue("@Nombre", usuarioModificado.Nombre);
                    command.Parameters.AddWithValue("@Rol", usuarioModificado.Rol);
                    command.Parameters.AddWithValue("@UserName", usuarioModificado.UserName);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarUsuario(string userName)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);


            string cadenaSQL = "DELETE FROM Usuario WHERE UserName = @UserName";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable obtenerUsuariosAsc()
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand("Select Nombre, Apellido, UserName, rol from Usuario ORDER BY UserName ASC", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public static DataTable obtenerUsuariosPorUsername(string username)
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnectionString);
            string query = @"
            DECLARE @filtroUsername NVARCHAR(50);
            SET @filtroUsername = @username + '%';

            SELECT Nombre, Apellido, UserName, rol 
            FROM Usuario
            WHERE UserName LIKE @filtroUsername
            ORDER BY username ASC;";


            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}

    
