namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface IJwtGenerator<T>
    {
        string GenerateToken(T usuario);
    }
}
