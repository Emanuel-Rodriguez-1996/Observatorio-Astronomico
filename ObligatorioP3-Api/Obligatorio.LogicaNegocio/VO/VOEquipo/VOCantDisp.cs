using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo
{
    public record VOCantDisp : VOInt
    {
        public VOCantDisp(int value) : base(value)
        {
        }

        protected override Exception CreateInvalidValueException(int value, string errorMsg)
        {
            return new CantDispInvalidException(errorMsg);
        }

        protected override bool Validar(int value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                errorMsg = "La cantidad disponible no puede ser negativa.";
                return false;
            }

            return true;
        }
    }
}
