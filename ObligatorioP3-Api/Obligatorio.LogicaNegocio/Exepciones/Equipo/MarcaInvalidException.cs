namespace Obligatorio.LogicaNegocio.Exepciones.Equipo
{
    public class MarcaInvalidException : EquipoInvalidExeption
    {
        public MarcaInvalidException()
        {
        }
        public MarcaInvalidException(string message) : base(message)
        {
        }
    }
}
