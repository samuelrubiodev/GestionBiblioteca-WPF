public class Usuario
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Contrasena { get; set; }
    public string Telefono { get; set; }
    public string Rol { get; set; }

    public Usuario()
    {

    }

    public Usuario(string nombre, string apellido, string email, string contrasena, string telefono, string rol)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Contrasena = contrasena;
        this.Telefono = telefono;
        this.Rol = rol;
    }

    public Usuario(int id, string nombre, string apellido, string email, string contrasena, string telefono, string rol)
    {
        this.ID = id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Contrasena = contrasena;
        this.Telefono = telefono;
        this.Rol = rol;
    }

    public override string ToString()
    {
        return Nombre;
    }
}