using Obligatorio.LogicaAplicacion.Dtos;
using Obligatorio.WebApi.ModelIA.DTO;

namespace Obligatorio.WebApi.ModelIA
{
    public interface IGeminiService
    {
        Task<ResultadoIADTO> EvaluarAsync(AnalizarObservacion dto);
    }
}
