using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo.Montura
{
    public record VOCargaMontura : VODecimal
    {
        public VOCargaMontura(decimal value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new EquipoInvalidExeption();
        }
    }
}
