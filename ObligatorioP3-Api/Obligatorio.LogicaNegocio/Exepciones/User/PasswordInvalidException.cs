namespace Obligatorio.LogicaNegocio.Exepciones.User
{
    public class PasswordInvalidException : UsuarioInvalidException
    {
        public PasswordInvalidException() { }

        public PasswordInvalidException(string message) : base(message) { }
    }
}
