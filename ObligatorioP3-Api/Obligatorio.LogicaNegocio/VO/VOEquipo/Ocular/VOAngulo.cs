using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo.Ocular
{
    public record VOAngulo : VODecimal
    {
        public VOAngulo(decimal value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new EquipoInvalidExeption();
        }
    }
}
