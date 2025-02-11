using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    class Prestamo
    {
        private int Id { get; set; }
        private Libro libro { get; set; }
        private Usuario usuario { get; set; }
        private DateTime fecha_prestamo { get; set; }
        private DateTime fecha_devolucion { get; set; }
    }
}
