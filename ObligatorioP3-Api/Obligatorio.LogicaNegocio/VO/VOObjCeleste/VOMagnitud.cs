using Obligatorio.LogicaNegocio.Exepciones.ObjCeleste;

namespace Obligatorio.LogicaNegocio.VO.ObjCeleste
{
    public record VOMagnitud : VODecimal
    {
        public decimal Value { get; private set; }

        public VOMagnitud(decimal value) : base(value)
        {
            Value = value;
        }

        protected override Exception CreateInvalidValueException(decimal value, string errorMsg)
        {
            throw new ObjCelesteInvalidException();
        }
    }
}
