using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo.Camara
{
    public record VOPixel : VODecimal
    {
        public VOPixel(decimal value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new EquipoInvalidExeption();
        }
    }
}
