using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo
{
    public record VOModelo : VOString
    {
        public VOModelo(string value) : base(value)
        {
        
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new ModeloInvalidException(errorMsg);
        }

        protected override bool Validar(string value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                errorMsg = "El modelo no puede estar vacio.";
                return false;
            }
            
            return true;
        }
    }
}
