namespace Obligatorio.LogicaNegocio.VO.Equipo.Telescopio
{
    public record VORelacionFocal : VODecimal
    {
        public VORelacionFocal(decimal value) : base(value)
        {

        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
