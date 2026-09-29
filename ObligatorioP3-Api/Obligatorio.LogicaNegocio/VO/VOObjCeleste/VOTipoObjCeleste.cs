using Obligatorio.LogicaNegocio.Exepciones.ObjCeleste;

namespace Obligatorio.LogicaNegocio.VO.ObjCeleste
{
    public record VOTipoObjCeleste : VOString
    {
        public VOTipoObjCeleste(string value) : base(value)
        {

        }

        public enum VOTipoObjCelesteEnum
        {
            Planeta,
            Galaxia,
            Nebulosa,
            Estrella
        }

        protected override Exception CreateInvalidValueException(string value, string errorMsg)
        {
            return new ObjCelesteInvalidException($"Los tipos validos son Planeta, Galaxia, Nebulosa, Estrella");
        }
    }
}
