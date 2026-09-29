using Obligatorio.LogicaNegocio.Exepciones.Prestamo;

namespace Obligatorio.LogicaNegocio.VO.VOPrestamo
{
    public record VOEstadoPrestamo : VOString
    {
        public VOEstadoPrestamo(string value) : base(value)
        {

        }

        public enum VOEstadoPrestamoEnum
        {
            En_Prestamo,
            Devuelto,
            Atrasado
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            throw new PrestamoInvalidException(errorMsg);
        }
    }
}
