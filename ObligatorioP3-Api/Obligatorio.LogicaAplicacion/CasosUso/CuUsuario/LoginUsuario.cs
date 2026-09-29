using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.Exepciones.User;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuUsuario
{
    public class LoginUsuario : ICULogin<LoginUsuarioDTO>
    {
        private IRepositorioUsuario _repo;

        public LoginUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public Usuario Ejecutar(LoginUsuarioDTO dto)
        {
            var usuarios = _repo.GetAll();

            foreach (var u in usuarios)
            {
                if (u.UserName.Value == dto.UserName && u.Password.Value == dto.Password)
                {
                    return u;
                }
            }
            throw new UsuarioInvalidException("Usuario y/o contraseña incorrectos");
        }
    }
}