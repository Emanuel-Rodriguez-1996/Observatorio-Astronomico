namespace Obligatorio.LogicaNegocio.VO.Equipo.Telescopio
{
    public record VODistanciaFocal : VODecimal
    {
        public VODistanciaFocal(decimal value) : base(value)
        {

        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
