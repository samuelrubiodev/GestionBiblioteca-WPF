using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Libro
    {
        private int id { get; set; }
        private string titulo { get; set; }
        private string autor { get; set; }
        private DateTime anio_publicacion { get; set; }
        private string genero { get; set; }
        private string isbn { get; set; }

        public Libro()
        {
        }
        public Libro(int id, string titulo, string autor, DateTime anio_publicacion, string genero, string isbn)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.anio_publicacion = anio_publicacion;
            this.genero = genero;
            this.isbn = isbn;
        }
    }
}
