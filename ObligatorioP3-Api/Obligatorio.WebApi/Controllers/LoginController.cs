using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.Exepciones.User;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController(IJwtGenerator<Usuario> _jwtGenerator,
                                 ICULogin<LoginUsuarioDTO> _login,
                                 ICUAlta<AltaUsuarioDTO> _altaUsuario,
                                 ICUGetAll<AltaUsuarioDTO> _listarUsuarios
                                 ) : ControllerBase
    {


        [HttpPost]
        public IActionResult Login([FromBody] LoginUsuarioDTO dto)
        {
            try
            {
                Usuario? usuario = _login.Ejecutar(dto);

                if (usuario == null)
                {
                    return Unauthorized(new Error(401, "Credenciales incorrectas."));
                }
                var token = _jwtGenerator.GenerateToken(usuario);

                var retorno = new UsuarioLogueadoDTO(
                    usuario.Id,
                    usuario.Nombre.Value,
                    usuario.UserName.Value,
                    usuario.Rol.Value,
                    token
                );

                return Ok(retorno);
            }
            catch (UsuarioInvalidException ex)
            {
                return BadRequest(new Error(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

        [HttpGet("usuarios")]
        [Authorize]
        public IActionResult GetUsuarios()
        {
            try
            {
                var usuarios = _listarUsuarios.Ejecutar();
                if (usuarios == null || !usuarios.Any())
                {
                    return NoContent();
                }
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return StatusCode(500, new Error(500, "Error interno del servidor"));
            }
        }

        [HttpPost("usuarios")]
        [Authorize]
        public IActionResult CreateUsuario([FromBody] AltaUsuarioDTO dto)
        {
            try
            {
                _altaUsuario.Ejecutar(dto);
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
    }
}