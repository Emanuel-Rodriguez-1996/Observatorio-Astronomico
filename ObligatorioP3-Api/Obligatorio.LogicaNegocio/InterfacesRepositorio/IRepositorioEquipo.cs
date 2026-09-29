using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEquipo : IRepositorioGetAll<Equipo>,
                                          IRepositorioGetById<Equipo>,
                                          IRepositorioDelete<Equipo>,
                                          IRepositorioUpdate<Equipo>,
                                          IRepositorioAdd<Equipo>

    {
    }
}
