namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetTById<T>
    {
        IEnumerable<T> Ejecutar(int id);

    }
}
