using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos;
using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.WebApi.ModelIA;
using Obligatorio.WebApi.ModelIA.DTO;

namespace Obligatorio.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAController(ICUGetById<PrestamoIADTO> _getPrestamo,
                              ICUGetById<ObjCelesteListadoDTO> _getObjCeleste,
                              IGeminiService _geminiService) : ControllerBase
    {
        [HttpPost("evaluar")]
        public async Task<IActionResult> Evaluar([FromBody] EvaluarObservacionDTO dto)
        {
            var prestamo = _getPrestamo.Execute(dto.PrestamoId);
            var objeto = _getObjCeleste.Execute(dto.ObjCelesteId);

            if (prestamo == null)
                return NotFound("Préstamo no encontrado");

            if (objeto == null)
                return NotFound("Objeto celeste no encontrado");

            var analisis = new AnalizarObservacion
            {
                Telescopio = new TelescopioIADTO(
                    prestamo.AperturaMm,
                    prestamo.DistanciaFocalMm,
                    prestamo.RelacionFocal
                ),

                Camara = prestamo.Sensor != null
                    ? new CamaraIADTO(
                        prestamo.Sensor,
                        prestamo.ResolucionPx,
                        prestamo.PixelSizeUm
                    )
                    : null,

                Ocular = prestamo.CampoAparenteGrados.HasValue
                    ? new OcularIADTO(
                        prestamo.OcularFocalMm,
                        prestamo.CampoAparenteGrados
                    )
                    : null,

                Objeto = new ObjCelesteIADTO(
                    objeto.Nombre,
                    objeto.Tipo
                )
            };

            var resultado = await _geminiService.EvaluarAsync(analisis);

            return Ok(resultado);
        }
    }
}