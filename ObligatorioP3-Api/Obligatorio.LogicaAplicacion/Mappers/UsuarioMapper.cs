using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaAplicacion.Mappers
{
    public class UsuarioMapper
    {
        // DTO → ENTIDAD
        public static UserSocio ToEntitySocio(AltaUsuarioDTO dto)
        {
            return new UserSocio(
                  dto.Nombre != null ? new VOName(dto.Nombre) : null,
                  dto.Direccion != null ? new VOAddress(dto.Direccion) : null,
                  dto.Telefono.HasValue ? new VOPhone(dto.Telefono.Value) : null,
                  new VOEmail(dto.Email),
                  new VOUserName(dto.UserName),
                  new VOPassword(dto.Password),
                  new VORol("Socio")
            );
        }

        // ENTIDAD → DTO
        public static AltaUsuarioDTO ToDto(Usuario u)
        {
            return new AltaUsuarioDTO(
                u.Id,
                u.Nombre?.Value,
                u.Direccion?.Value,
                u.Telefono?.Value,
                u.Email.Value,
                u.UserName.Value,
                u.Password.Value,
                u.Rol?.Value
            );
        }
    }
}