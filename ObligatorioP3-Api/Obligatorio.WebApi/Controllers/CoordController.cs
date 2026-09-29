using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoordController(ICUAlta<AltaPrestamoDTO> _altaPrestamo,
                                ICUGetAll<PrestamoListadoDTO> _listarPrestamos,
                                ICUGetById<PrestamoListadoDTO> _prestamoById,
                                ICUUpdate<DevolverPrestamoDTO> _updatePrestamo,
                                ICUGetTById<AuditoriaPrestamoDTO> _listarAuditoria) : ControllerBase
    {

        [HttpPost("prestamos")]
        public IActionResult AltaPrestamo(AltaPrestamoDTO dto)
        {
            try
            {
                _altaPrestamo.Ejecutar(dto);
                return Ok();
            }
            catch (LogicaNegocioException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("prestamos")]
        public IActionResult GetPrestamos()
        {
            try
            {
                return Ok(_listarPrestamos.Ejecutar());
            }
            catch (Exception e)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }

        }
        [HttpGet("prestamos/{id}")]
        public IActionResult GetPrestamoById([FromRoute] int id)
        {
            try
            {
                var filtro = _prestamoById.Execute(id);
                return Ok(filtro);
            }
            catch (NotFoundException e)
            {
                return NotFound(new Error(404, e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("auditorias/{prestamoId}")]
        public IActionResult GetAuditoriaByPrestamo([FromRoute] int prestamoId)
        {
            try
            {
                var filtro = _listarAuditoria.Ejecutar(prestamoId) ?? new List<AuditoriaPrestamoDTO>();
                return Ok(filtro);
            }
            catch (NotFoundException e)
            {
                return NotFound(new Error(404, e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpPut("prestamos/{id}")]
        public IActionResult DevolverPrestamo([FromRoute] int id, [FromBody] DevolverPrestamoDTO dto)
        {
            try
            {
                _updatePrestamo.Execute(id, dto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new Error(404, e.Message));
            }
            catch (LogicaNegocioException e)
            {
                return BadRequest(new Error(400, e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
    }
}
