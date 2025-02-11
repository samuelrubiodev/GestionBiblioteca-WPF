using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contrsena { get; set; }
        public string telefono { get; set; }
        public string rol { get; set; }

        public Usuario(int id, string nombre, string apellido, string email, string contrasena, string telefono, string rol)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.contrsena = contrasena;
            this.telefono = telefono;
            this.rol = rol;
        }
    }
}
