namespace Dominio;

public class Usuario
{
    public int IdUsuario { get; set; }
    public required string Nombre { get; set; }
    public required string NombreUsuario { get; set; }
    public required string Contraseña { get; set; }
    public required string Email { get; set; }
    List<Rol> Roles { get; set; } = new List<Rol>();
}
