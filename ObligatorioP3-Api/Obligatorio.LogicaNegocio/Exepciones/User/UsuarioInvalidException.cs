
namespace Obligatorio.LogicaNegocio.Exepciones.User
{
    public class UsuarioInvalidException : LogicaNegocioException
    {
        public UsuarioInvalidException() { }

        public UsuarioInvalidException(string message) : base(message) { }
       
    }
}
