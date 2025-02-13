using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Prestamo
    {
        private int Id { get; set; }
        private Libro libro { get; set; }
        private Usuario usuario { get; set; }
        private DateTime fecha_prestamo { get; set; }
        private DateTime fecha_devolucion { get; set; }

        public Prestamo()
        {

        }

        public Prestamo(int id, Libro, Libro, Usuario usuario, DateTime fecha_prestamo, DateTime fecha_devolucion)
        {
            this.Id = id;
            this.libro = libro;
            this.usuario = usuario;
            this.fecha_prestamo = fecha_prestamo;
            this.fecha_devolucion = fecha_devolucion;
        }

        public Prestamo(Libro, Libro, Usuario usuario, DateTime fecha_prestamo, DateTime fecha_devolucion)
        {
            this.libro = libro;
            this.usuario = usuario;
            this.fecha_prestamo = fecha_prestamo;
            this.fecha_devolucion = fecha_devolucion;
        }

    }
}
