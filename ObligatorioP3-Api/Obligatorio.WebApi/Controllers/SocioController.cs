using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SocioController(ICUAlta<AltaObservacionDTO> _altaObservacion,
                                 ICUGetAll<PrestamoListadoDTO> _listarPrestamos,
                                 ICUGetAll<ObjCelesteListadoDTO> _listarObjCelestes,
                                 ICUGetAll<RankinObjCelesteDTO> _rankingObjetos) : ControllerBase
    {

        [HttpGet("objetos-celestes")]
        public IActionResult GetObjetosCelestes()
        {
            try
            {
                return Ok(_listarObjCelestes.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpPost("observaciones")]
        public IActionResult AltaObservacion([FromBody] AltaObservacionDTO dto)
        {
            try
            {
                _altaObservacion.Ejecutar(dto);
                return Ok(dto);
            }
            catch (LogicaNegocioException e)
            {
                return BadRequest(new { e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

        [HttpGet("ranking-objetos")]
        public IActionResult GetRankingObjetos()
        {
            try
            {
                return Ok(_rankingObjetos.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
    }
}
