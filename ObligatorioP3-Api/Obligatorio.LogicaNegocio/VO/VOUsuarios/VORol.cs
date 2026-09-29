using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.Exepciones.User;

namespace Obligatorio.LogicaNegocio.VO.VOUsuarios
{
    public record VORol : VOString
    {
        public VORol(string value) : base(value)
        {

        }
   
        protected override bool Validar(string value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                return false;
            }
            if (value != "Administrador" && value != "Coordinador" && value != "Socio") 
            {
                errorMsg = "Rol Invalido";
                return false;
            }
            errorMsg = string.Empty;
            return true;
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new RolInvalidException(errorMsg);
        }
    }
}
