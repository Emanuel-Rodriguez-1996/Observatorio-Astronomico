using Obligatorio.LogicaNegocio.Exepciones.User;

namespace Obligatorio.LogicaNegocio.VO.VOUsuarios
{
    public record VOUserName : VOString
    {
        public VOUserName(string value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new UserNameInvalidException(errorMsg);
        }

        protected override bool Validar(string value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                errorMsg = "El nombre de usuario no puede estar vacio.";
                return false;
            }

            errorMsg = string.Empty;
            return true;
        }
    }
}
