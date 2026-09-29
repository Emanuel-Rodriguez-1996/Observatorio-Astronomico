using Obligatorio.WebApi.ModelIA.DTO;

namespace Obligatorio.LogicaAplicacion.Dtos
{
    public record AnalizarObservacion
    {
        public TelescopioIADTO Telescopio { get; set; }
        public CamaraIADTO? Camara { get; set; }
        public OcularIADTO? Ocular { get; set; }
        public ObjCelesteIADTO Objeto { get; set; }

    }
}
