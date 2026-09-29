using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorioAdd<Usuario>,
                                           IRepositorioGetAll<Usuario>,
                                           IRepositorioGetById<Usuario>

                                            
    {
        
    }
}
