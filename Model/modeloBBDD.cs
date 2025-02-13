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

        public void insertarLibros(Libro libro)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el libro: " + libro.titulo);
            }
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


    }
}
