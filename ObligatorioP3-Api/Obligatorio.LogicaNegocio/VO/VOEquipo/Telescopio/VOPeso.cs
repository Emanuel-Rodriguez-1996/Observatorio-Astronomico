namespace Obligatorio.LogicaNegocio.VO.Equipo.Telescopio
{
    public record VOPeso : VODecimal
    {
        public VOPeso(decimal value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
