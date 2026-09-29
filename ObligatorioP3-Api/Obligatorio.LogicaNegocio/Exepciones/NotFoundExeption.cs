namespace Obligatorio.LogicaNegocio.Exepciones
{
    public class NotFoundException : LogicaNegocioException
    {
        public NotFoundException() { }

        public NotFoundException(string? message) : base(message)
        {
        }

    }
}
