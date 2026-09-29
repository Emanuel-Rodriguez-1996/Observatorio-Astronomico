using Obligatorio.LogicaNegocio.Exepciones.User;

namespace Obligatorio.LogicaNegocio.VO.VOUsuarios
{
    public record VOAddress : VOString
    {
        public VOAddress(string value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new UsuarioInvalidException(errorMsg);
        }

        protected override bool Validar(string value, out string errorMsg)
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
