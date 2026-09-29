namespace Obligatorio.LogicaAplicacion.Dtos.Usuario
{
    public record UsuarioLogueadoDTO
    (
        int Id,
        string Nombre,
        string UserName,
        string Rol,
        string Token
    );
}
