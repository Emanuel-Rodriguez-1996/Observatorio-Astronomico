using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso
{
    public class AltaUsuario : ICUAlta<AltaUsuarioDTO>
    {
        private readonly IRepositorioUsuario _repo;

        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repo = repositorioUsuario;
        }

        public void Ejecutar(AltaUsuarioDTO dto)
        {
            var usuario = UsuarioMapper.ToEntitySocio(dto);

            _repo.Add(usuario);
        }
    }
}