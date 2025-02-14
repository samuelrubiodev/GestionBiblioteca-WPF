using BaseDatos.ConexionBD;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Biblioteca.Model
{
    public class modeloBBDD
    {
        private MySqlConnection conexionBD;

        private string _bbddConectada;

        public string BBDDConectada
        {
            get { return _bbddConectada; }
            set
            {
                _bbddConectada = value;
            }
        }

        public modeloBBDD()
        {

        }

        private MySqlConnection abrirConexionBBDD()
        {
            try
            {
                ConexionBD instanciaConexion = ConexionBD.Instance;
                conexionBD = instanciaConexion.getConection();
                if (conexionBD.State == System.Data.ConnectionState.Closed)
                {
                    conexionBD.Open();
                }

                BBDDConectada = conexionBD.Database;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la BBDD Basket: " + ex.Message);
            }
            return conexionBD;
        }

        public List<Libro> consultarLibros()
        {
            List<Libro> listadoLibros = new List<Libro>();
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde consultarLibros");
                    return listadoLibros;
                }
            }
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM libros", conexionBD);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                listadoLibros.Add(new Libro(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetString(4),
                    reader.GetString(5)
                    ));
            }
            reader.Close();
            return listadoLibros;
        }

        public int insertarLibros(Libro libro)
        {
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde insertarLibros");
                }
            }
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO libros (titulo, autor, anio_publicacion, genero, isbn) VALUES (@titulo, @autor, @anio_publicacion, @genero, @isbn)", conexionBD);
                mySqlCommand.Parameters.AddWithValue("@titulo", libro.titulo);
                mySqlCommand.Parameters.AddWithValue("@autor", libro.autor);
                mySqlCommand.Parameters.AddWithValue("@anio_publicacion", libro.anio_publicacion);
                mySqlCommand.Parameters.AddWithValue("@genero", libro.genero);
                mySqlCommand.Parameters.AddWithValue("@isbn", libro.isbn);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Libro insertado: " + libro.titulo);
                return (int) mySqlCommand.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el libro, cod error: " + ex);
                return -1;
            }
        }

        public void eliminarLibro(Libro libro)
        {
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde eliminarLibro");
                }
            }
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM libros WHERE id = @id", conexionBD);
                mySqlCommand.Parameters.AddWithValue("@id", libro.id);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Libro eliminado correctamente", "Éxito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el libro: {ex.Message}",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int insertarPrestamo(Prestamo prestamo)
        {
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde insertarPrestamo");
                }
            }

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO prestamos (libro_id, usuario_id, fecha_prestamo, fecha_devolucion) VALUES (@libro_id, @usuario_id, @fecha_prestamo, @fecha_devolucion)", conexionBD);
                mySqlCommand.Parameters.AddWithValue("@libro_id", prestamo.Libro.id);
                mySqlCommand.Parameters.AddWithValue("@usuario_id", prestamo.Usuario.ID);
                mySqlCommand.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaPrestamo);
                mySqlCommand.Parameters.AddWithValue("@fecha_devolucion", prestamo.FechaDevolucion);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();
                
                MessageBox.Show("Prestamo insertado correctamente", "Éxito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                return (int) mySqlCommand.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el prestamo: {ex.Message}",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }

        public void eliminarPrestamo(Prestamo prestamo)
        {
            
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde eliminarPrestamo");
                }
            }

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM prestamos WHERE id = @id", conexionBD);
                mySqlCommand.Parameters.AddWithValue("@id", prestamo.ID);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Prestamo eliminado correctamente", "Éxito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el prestamo: {ex.Message}",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<Prestamo> consultarPrestamos()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde consultarPrestamos");
                    return prestamos;
                }
            }
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT p.*,l.*,u.* FROM prestamos p, libros l, usuarios u" +
                " WHERE p.libro_id = l.id AND p.usuario_id = u.id", conexionBD);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var libro = new Libro(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader.GetString(reader.GetOrdinal("titulo")),
                    reader.GetString(reader.GetOrdinal("autor")),
                    reader.GetInt32(reader.GetOrdinal("anio_publicacion")),
                    reader.GetString(reader.GetOrdinal("genero")),
                    reader.GetString(reader.GetOrdinal("isbn"))
                    );

                var usuario = new Usuario(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader.GetString(reader.GetOrdinal("nombre")),
                    reader.GetString(reader.GetOrdinal("apellido")),
                    reader.GetString(reader.GetOrdinal("email")),
                    reader.GetString(reader.GetOrdinal("contrasena")),
                    reader.GetString(reader.GetOrdinal("telefono")),
                    reader.GetString(reader.GetOrdinal("rol"))
                    );

                prestamos.Add(new Prestamo(
                    reader.GetInt32(0),
                    libro,
                    usuario,
                    reader.GetDateTime(3),
                    reader.GetDateTime(4)));
            }
            reader.Close();
            return prestamos;
        }

        public List<Usuario> consultarUsuarios()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde consultarUsuarios");
                    return listadoUsuarios;
                }
            }

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM usuarios", conexionBD);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                listadoUsuarios.Add(new Usuario(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6)));
            }
            reader.Close();
            return listadoUsuarios;
        }

        public int insertarUsuario(Usuario usuario)
        {
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde insertarUsuario");
                    return -1;
                }
            }

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO usuarios (nombre, apellido, email, contrasena, telefono, rol) VALUES (@nombre, @apellido, @email, @contrasena, @telefono, @rol)", conexionBD);
                mySqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                mySqlCommand.Parameters.AddWithValue("@apellido", usuario.Apellido);
                mySqlCommand.Parameters.AddWithValue("@email", usuario.Email);
                mySqlCommand.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                mySqlCommand.Parameters.AddWithValue("@telefono", usuario.Telefono);
                mySqlCommand.Parameters.AddWithValue("@rol", usuario.Rol);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Usuario insertado correctamente", "Éxito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                return (int) mySqlCommand.LastInsertedId;
            } catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el usuario: {ex.Message}",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }

        public void eliminarUsuario(Usuario usuario)
        {
            if (conexionBD == null)
            {
                abrirConexionBBDD();
                if (conexionBD == null)
                {
                    MessageBox.Show("No hay conexión a la BBDD desde insertarUsuario");
                }
            }
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM usuarios WHERE id = @id", conexionBD);
                mySqlCommand.Parameters.AddWithValue("@id", usuario.ID);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Usuario eliminado correctamente", "Éxito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
