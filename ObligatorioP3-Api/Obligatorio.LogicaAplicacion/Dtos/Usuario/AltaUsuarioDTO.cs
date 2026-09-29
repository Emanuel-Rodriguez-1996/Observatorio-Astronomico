namespace Obligatorio.LogicaAplicacion.Dtos.Usuario
{
    public record AltaUsuarioDTO(
     int? Id,
     string Nombre,
     string? Direccion,
     int? Telefono,
     string Email,
     string UserName,
     string Password,
     string Rol
 );
}