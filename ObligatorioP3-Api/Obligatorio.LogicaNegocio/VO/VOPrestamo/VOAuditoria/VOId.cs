
using Obligatorio.LogicaNegocio.Exepciones.Prestamo;

namespace Obligatorio.LogicaNegocio.VO.VOPrestamo.VOAuditoria
{
    public record VOId : VOInt
    {
        public VOId(int value) : base(value)
        {
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
        protected override Exception CreateInvalidValueException(int value, string errorMsg)
        {
            return new PrestamoInvalidException(errorMsg);
        }

    }
}
