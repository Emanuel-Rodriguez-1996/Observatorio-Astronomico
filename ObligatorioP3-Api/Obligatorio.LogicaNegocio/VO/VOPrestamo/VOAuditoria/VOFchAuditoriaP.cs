namespace Obligatorio.LogicaNegocio.VO.VOPrestamo.VOAuditoria
{
    public record VOFchAuditoriaP
    {
        public DateTime Value { get; init; }
        public VOFchAuditoriaP(DateTime value)
        {
            Value = value;
        }
    }
}
