namespace Obligatorio.LogicaNegocio.Exepciones.User
{
    public class UserNameInvalidException : UsuarioInvalidException
    {
        public UserNameInvalidException() { }

        public UserNameInvalidException(string message) : base(message) { }
    }
}
