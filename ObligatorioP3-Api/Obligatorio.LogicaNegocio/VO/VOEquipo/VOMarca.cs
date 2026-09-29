using Obligatorio.LogicaNegocio.Exepciones.Equipo;

namespace Obligatorio.LogicaNegocio.VO.Equipo
{
    public record VOMarca : VOString
    {
        public VOMarca(string value) : base(value)
        {

        }
       

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new MarcaInvalidException(errorMsg);
        }

        protected override bool Validar(string value, out string errorMsg)
        {
            if (!base.Validar(value, out errorMsg))
            {
                errorMsg = "La marca no puede estar vacia.";
                return false;
            }
            
            return true;
        }
    }
}
