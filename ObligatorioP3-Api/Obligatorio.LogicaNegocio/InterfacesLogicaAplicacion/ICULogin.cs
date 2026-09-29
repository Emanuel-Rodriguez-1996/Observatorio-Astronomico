using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;

namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICULogin<T>
    {
        Usuario Ejecutar(T obj);
    }
}
