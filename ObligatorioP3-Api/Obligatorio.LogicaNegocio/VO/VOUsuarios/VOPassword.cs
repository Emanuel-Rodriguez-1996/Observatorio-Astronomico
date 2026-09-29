using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.Exepciones.User;
using System.Text.RegularExpressions;

namespace Obligatorio.LogicaNegocio.VO.VOUsuarios
{
    public record VOPassword : VOString
    {
        public VOPassword(string value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new PasswordInvalidException(errorMsg);
        }
        protected override bool Validar(string value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                return false;
            }

            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$");

            if (!regex.IsMatch(value))
            {
                errorMsg = "La contraseña debe contener minimo 8 caracteres, incluyendo mayúsculas, minúsculas, números y un carácter especial.";
                return false;
            }

            errorMsg = string.Empty;
            return true;
        }
    }
}
