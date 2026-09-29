using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.Exepciones.User;

namespace Obligatorio.LogicaNegocio.VO.VOUsuarios
{
    public record VOPhone: VOInt
    {
        public VOPhone (int value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(int value, string errorMsg)
        {
            return new UsuarioInvalidException(errorMsg);
        }

        protected override bool Validar(int value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                return false;
            }

            errorMsg = string.Empty;
            return true;
        }
    }
}
