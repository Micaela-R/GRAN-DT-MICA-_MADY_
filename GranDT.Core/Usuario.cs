namespace GranDT.Core;

public class Usuario
{
    public Usuario(string email, string nombre, string apellido, DateTime nacimiento, int idUsuario = 0)
    {
        IdUsuario = idUsuario;
        Email = email;
        Nombre = nombre;
        Apellido = apellido;
        Nacimiento = nacimiento;
    }

    public int IdUsuario { get; set; }
    public string Email { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateTime Nacimiento { get; set; }

}
