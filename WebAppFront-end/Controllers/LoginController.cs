using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Http;
using WebAppFront_end.Models.Dtos.Usuario;

namespace WebAppFront_end.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuxiliarClienteHttp _auxHttp;
        //string token = null;

        public LoginController(AuxiliarClienteHttp aux)
        {
            _auxHttp = aux;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                var respuesta = _auxHttp.EnviarYDeserializar<UsuarioLogueadoDTO>("api/login", "POST", dto);

                // 4. Guardamos todo en la Sesión del Frontend
                HttpContext.Session.SetString("token", respuesta.Token);
                HttpContext.Session.SetInt32("userId", respuesta.Id);
                HttpContext.Session.SetString("rol", respuesta.Rol);
                HttpContext.Session.SetString("Nombre", respuesta.Nombre);

                // 5. Redirección según el Rol obtenido del Token
                if (respuesta.Rol == "Socio")
                {
                    return RedirectToAction("IndexSocio", "Socio");
                }

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(dto);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}