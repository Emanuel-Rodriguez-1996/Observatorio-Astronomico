namespace Obligatorio.LogicaNegocio.Exepciones.Equipo
{
    public class EquipoInvalidExeption : LogicaNegocioException
    {
        public EquipoInvalidExeption()
        {
        }

        public EquipoInvalidExeption(string? message) : base(message)
        {
        }
    }

}
