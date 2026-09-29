namespace Obligatorio.LogicaNegocio.VO.Prestamo
{
    public record VOFchFin
    {
        public DateTime Value { get; private set; }
        public VOFchFin(DateTime value)
        {
            Value = value;
        }
    }
}
