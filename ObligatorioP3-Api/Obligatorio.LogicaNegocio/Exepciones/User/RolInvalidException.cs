namespace Obligatorio.LogicaNegocio.Exepciones.User
{
    public class RolInvalidException : UsuarioInvalidException
    {
        public RolInvalidException() { }

        public RolInvalidException(string message) : base(message) { }
    }
}
