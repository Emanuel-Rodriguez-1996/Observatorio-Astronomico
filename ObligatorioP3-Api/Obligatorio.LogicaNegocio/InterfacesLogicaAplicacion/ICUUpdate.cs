namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUUpdate<T>
    {
        void Execute(int id, T Obj);
    }
}
