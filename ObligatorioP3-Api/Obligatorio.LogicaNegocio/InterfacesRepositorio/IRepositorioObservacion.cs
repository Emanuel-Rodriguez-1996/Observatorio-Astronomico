using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioObservacion : IRepositorioAdd<Observacion>,
                                               IRepositorioGetAll<Observacion>
    {
    }
}