using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ClasesBase;

namespace ClasesBase
{
    public class TrabajarUsuario
    {
        public ObservableCollection<Usuario> TraerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            string cadenaSQL = "SELECT * FROM Usuario";

            using (SqlConnection connection = cnn)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cadenaSQL, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario(
                            Convert.ToString(reader["UserName"]),
                            Convert.ToString(reader["Password"]),
                           Convert.ToString(reader["Apellido"]),
                            Convert.ToString(reader["Nombre"]),
                            Convert.ToString(reader["Rol"])
                        );

                        listaUsuario.Add(usuario);
                    }
                }
            }

            return listaUsuario;
           }

        public static List<Usuario> ListarUsuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);
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
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

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
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

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
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

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

    }
    
}
