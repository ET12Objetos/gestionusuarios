namespace Dominio;

public class Rol
{
    public int IdRol { get; set; }
    public required string Nombre { get; set; }
    public List<Usuario> Usuarios { get; } = new List<Usuario>();
}
