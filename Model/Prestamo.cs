using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Prestamo
    {
        public int ID { get; set; }
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public Prestamo()
        {

        }

        public Prestamo(int id, Libro libro,  Usuario usuario, DateTime fecha_prestamo, DateTime fecha_devolucion)
        {
            this.ID = id;
            this.Libro = libro;
            this.Usuario = usuario;
            this.FechaPrestamo = fecha_prestamo;
            this.FechaDevolucion = fecha_devolucion;
        }

        public Prestamo(Libro libro, Usuario usuario, DateTime fecha_prestamo, DateTime fecha_devolucion)
        {
            this.Libro = libro;
            this.Usuario = usuario;
            this.FechaPrestamo = fecha_prestamo;
            this.FechaDevolucion = fecha_devolucion;
        }

        public override string ToString()
        {
            return ID.ToString();
        }

    }
}
