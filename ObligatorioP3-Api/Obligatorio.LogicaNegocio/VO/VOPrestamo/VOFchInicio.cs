namespace Obligatorio.LogicaNegocio.VO.Prestamo
{
    public record VOFchInicio
    {
        public DateTime Value { get; private set; }
        public VOFchInicio(DateTime value)
        {
            Value = value;
        }
    }
}
