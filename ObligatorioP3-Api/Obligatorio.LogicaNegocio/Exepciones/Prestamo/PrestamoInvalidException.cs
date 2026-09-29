namespace Obligatorio.LogicaNegocio.Exepciones.Prestamo
{
    public class PrestamoInvalidException : LogicaNegocioException
    {
        public PrestamoInvalidException()
        {
        }
        public PrestamoInvalidException(string message) : base(message)
        {
        }
    }
}
