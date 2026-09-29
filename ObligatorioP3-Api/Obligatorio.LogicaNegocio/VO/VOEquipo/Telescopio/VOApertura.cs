namespace Obligatorio.LogicaNegocio.VO.Equipo.Telescopio
{
    public record VOApertura : VODecimal
    {
        public VOApertura(decimal value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
