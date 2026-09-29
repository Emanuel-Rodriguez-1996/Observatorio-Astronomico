namespace Obligatorio.LogicaNegocio.VO.Equipo.Montura
{
    public record VOComputarizado
    {
        public bool Value { get; private set; }
        public VOComputarizado(bool value)
        {
            Value = value;
        }
    }
}
