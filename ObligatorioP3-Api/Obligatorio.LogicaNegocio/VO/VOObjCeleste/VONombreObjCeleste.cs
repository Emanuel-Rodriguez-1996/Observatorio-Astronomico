using Obligatorio.LogicaNegocio.Exepciones.ObjCeleste;

namespace Obligatorio.LogicaNegocio.VO.ObjCeleste
{
    public record VONombreObjCeleste : VOString
    {
        public VONombreObjCeleste(string value) : base(value)
        {
        }
        public enum VONombreObjCelesteEnum
        {
            Luna,
            Júpiter,
            GalaxiaM42,
            Polaris
        }
        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            throw new ObjCelesteInvalidException();
        }
    }

}
