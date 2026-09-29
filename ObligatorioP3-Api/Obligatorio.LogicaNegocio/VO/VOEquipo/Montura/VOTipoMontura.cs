using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo.Montura
{
    public record VOTipoMontura : VOString
    {
        public VOTipoMontura(string value) : base(value)
        {

        }
        public enum VOTipoMonturaEnum
        {
            Ecuatorial,
            AltAzimutal,
            Hibrida
        }
        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new EquipoInvalidExeption($"Tipo de montura inválido: {value}");
        }
    }
}
