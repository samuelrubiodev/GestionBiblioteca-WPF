using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Libro
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public int anio_publicacion { get; set; }
        public string genero { get; set; }
        public string isbn { get; set; }

        public Libro()
        {
        }

        public Libro(string titulo, string autor, int anio_publicacion, string genero, string isbn)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio_publicacion = anio_publicacion;
            this.genero = genero;
            this.isbn = isbn;
        }
        public Libro(int id, string titulo, string autor, int anio_publicacion, string genero, string isbn)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.anio_publicacion = anio_publicacion;
            this.genero = genero;
            this.isbn = isbn;
        }

        public override string ToString()
        {
            return titulo;
        }
    }
}
