namespace Obligatorio.LogicaNegocio.Exepciones.Equipo
{
    public class ModeloInvalidException : EquipoInvalidExeption
    {
        public ModeloInvalidException()
        {
        }
        public ModeloInvalidException(string message) : base(message)
        {
        }
    }
}
