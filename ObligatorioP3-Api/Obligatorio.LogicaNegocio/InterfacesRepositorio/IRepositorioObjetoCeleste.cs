using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioObjCeleste : IRepositorioAdd<ObjCeleste>,
                                              IRepositorioGetAll<ObjCeleste>,
                                              IRepositorioGetById<ObjCeleste>
    {
    }
}
