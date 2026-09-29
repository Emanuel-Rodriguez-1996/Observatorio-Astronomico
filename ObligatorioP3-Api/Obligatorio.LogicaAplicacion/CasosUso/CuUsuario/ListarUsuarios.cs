using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso
{
    public class ListarUsuarios : ICUGetAll<AltaUsuarioDTO>
    {
        private IRepositorioUsuario _repo;

        public ListarUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repo = repositorioUsuario;
        }

        public IEnumerable<AltaUsuarioDTO> Ejecutar()
        {
            return _repo.GetAll()
        .OfType<Usuario>()
        .Select(t => UsuarioMapper.ToDto(t));
        }
    }
}