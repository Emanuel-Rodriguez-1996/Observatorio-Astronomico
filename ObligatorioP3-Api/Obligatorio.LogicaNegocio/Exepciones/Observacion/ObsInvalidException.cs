namespace Obligatorio.LogicaNegocio.Exepciones.Observacion
{
    public class ObsInvalidException : LogicaNegocioException
    {
        public ObsInvalidException() { }

        public ObsInvalidException(string message) : base(message) { }
    }
}
