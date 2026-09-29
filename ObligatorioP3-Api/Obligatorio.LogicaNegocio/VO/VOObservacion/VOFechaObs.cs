namespace Obligatorio.LogicaNegocio.VO.VOObservacion
{
    public record VOFechaObs
    {
        public DateTime Value { get; private set; }
        public VOFechaObs(DateTime value)
        {
            Value = value;
        }

    }
}
