using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.Equipo;
using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;


namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController(ICUAlta<AltaTelescopioDTO> _altaTelescopio,
                                 ICUAlta<AltaCamaraDTO> _altaCamaras,
                                 ICUAlta<AltaMonturaDTO> _altaMontura,
                                 ICUAlta<AltaOcularDTO> _altaOcular,
                                 ICUGetAll<AltaTelescopioDTO> _listarTelescopios,
                                 ICUGetAll<AltaCamaraDTO> _listarCamaras,
                                 ICUGetAll<AltaMonturaDTO> _listarMonturas,
                                 ICUGetAll<AltaOcularDTO> _listarOculares,
                                 ICUGetTById<SocioListadoDTO> _SocioXTelescopio,
                                 ICUUpdate<AltaCamaraDTO> _updateCamara,
                                 ICUUpdate<AltaTelescopioDTO> _updateTelescopio,
                                 ICUUpdate<AltaOcularDTO> _updateOcular,
                                 ICUUpdate<AltaMonturaDTO> _updateMontura,
                                 ICUGetEquipoById _equipoById,
                                 ICUDelete<int> _deleteEquipo) : ControllerBase
    {
        //EQUIPOS
        [HttpGet("telescopios/{id}/socios")]
        public IActionResult GetSociosPorTelescopio(int id)
        {
            try
            {
                var socios = _SocioXTelescopio.Ejecutar(id);
                return Ok(socios);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpPost("telescopios")]
        public IActionResult CreateTelescopio([FromBody] AltaTelescopioDTO dto)
        {
            try
            {
                _altaTelescopio.Ejecutar(dto);
                return Ok(dto);
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
        [HttpPost("camaras")]
        public IActionResult CreateCamara([FromBody] AltaCamaraDTO dto)
        {
            try
            {
                _altaCamaras.Ejecutar(dto);
                return Ok(dto);
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
        [HttpPost("monturas")]
        public IActionResult CreateMontura([FromBody] AltaMonturaDTO dto)
        {
            try
            {
                _altaMontura.Ejecutar(dto);
                return Ok(dto);
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

        [HttpPost("oculares")]
        public IActionResult CreateOcular([FromBody] AltaOcularDTO dto)
        {
            try
            {
                _altaOcular.Ejecutar(dto);
                return Ok(dto);
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

        [HttpPut("telescopios/{id}")]
        public IActionResult UpdateTelescopio([FromRoute] int id, [FromBody] AltaTelescopioDTO dto)
        {
            if (id < 0)
            {
                return BadRequest(new Error(400, "El ID no es valido"));
            }
            try
            {
                _updateTelescopio.Execute(id, dto);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

        [HttpPut("camaras/{id}")]
        public IActionResult UpdateCamara([FromRoute] int id, [FromBody] AltaCamaraDTO dto)
        {
            try
            {
                _updateCamara.Execute(id, dto);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

        [HttpPut("monturas/{id}")]
        public IActionResult UpdateMontura([FromRoute] int id, [FromBody] AltaMonturaDTO dto)
        {
            try
            {
                _updateMontura.Execute(id, dto);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

        [HttpPut("oculares/{id}")]
        public IActionResult UpdateOcular([FromRoute] int id, [FromBody] AltaOcularDTO dto)
        {
            try
            {
                _updateOcular.Execute(id, dto);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("telescopios")]
        public IActionResult GetTelescopios()
        {
            try
            {
                var telescopios = _listarTelescopios.Ejecutar();

                if (telescopios == null || !telescopios.Any())
                {
                    return Ok(new List<AltaTelescopioDTO>());
                }

                return Ok(telescopios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("camaras")]
        public IActionResult GetCamaras()
        {
            try
            {
                var camaras = _listarCamaras.Ejecutar();

                if (camaras == null || !camaras.Any())
                {
                    return Ok(new List<AltaCamaraDTO>());
                }

                return Ok(camaras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("monturas")]
        public IActionResult GetMonturas()
        {
            try
            {
                var monturas = _listarMonturas.Ejecutar();

                if (monturas == null || !monturas.Any())
                {
                    return Ok(new List<AltaMonturaDTO>());
                }

                return Ok(monturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("oculares")]
        public IActionResult GetOculares()
        {
            try
            {
                var oculares = _listarOculares.Ejecutar();

                if (oculares == null || !oculares.Any())
                {
                    return Ok(new List<AltaOcularDTO>());
                }
                return Ok(oculares);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpGet("equipos/{id}")]
        public IActionResult GetEquipoById(int id)
        {
            try
            {
                var equipo = _equipoById.Ejecutar(id);

                return Ok(equipo);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }
        [HttpDelete("equipos/{id}")]
        public IActionResult DeleteEquipo([FromRoute] int id)
        {
            try
            {
                _deleteEquipo.Execute(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Error(404, ex.Message));
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

    }
}