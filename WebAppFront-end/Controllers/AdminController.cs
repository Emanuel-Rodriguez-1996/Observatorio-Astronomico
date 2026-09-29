using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Http;
using WebAppFront_end.Filter;
using WebAppFront_end.Models.Dtos.Equipo;
using WebAppFront_end.Models.Dtos.Prestamo;
using WebAppFront_end.Models.Dtos.Usuario;
using WebAppFront_end.Models.VM;
using WebAppFront_end.Models.VM.Equipo;


namespace WebAppFront_end.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuxiliarClienteHttp _auxHttp;
        private string Token => HttpContext.Session.GetString("token");

        public AdminController(AuxiliarClienteHttp aux)
        {
            _auxHttp = aux;
        }

        [Logueado]
        public IActionResult Index()
        {
            var vm = new VMIndex
            {
                Usuarios = _auxHttp.EnviarYDeserializar<List<AltaUsuarioDTO>>("api/login/usuarios", "GET", token: Token) ?? new List<AltaUsuarioDTO>(),
                Telescopios = _auxHttp.EnviarYDeserializar<List<AltaTelescopioDTO>>("api/admin/telescopios", "GET", token: Token) ?? new List<AltaTelescopioDTO>(),
                Camaras = _auxHttp.EnviarYDeserializar<List<AltaCamaraDTO>>("api/admin/camaras", "GET", token: Token) ?? new List<AltaCamaraDTO>(),
                Monturas = _auxHttp.EnviarYDeserializar<List<AltaMonturaDTO>>("api/admin/monturas", "GET", token: Token) ?? new List<AltaMonturaDTO>(),
                Oculares = _auxHttp.EnviarYDeserializar<List<AltaOcularDTO>>("api/admin/oculares", "GET", token: Token) ?? new List<AltaOcularDTO>(),
                Prestamos = _auxHttp.EnviarYDeserializar<List<PrestamoListadoDTO>>("api/coord/prestamos", "GET", token: Token) ?? new List<PrestamoListadoDTO>()
            };
            return View(vm);
        }
        public IActionResult SocioXTelescopio(int id)
        {
            try
            {
                var socios = _auxHttp.EnviarYDeserializar<List<SocioListadoDTO>>($"api/admin/telescopios/{id}/socios", "GET", token: Token) ?? new List<SocioListadoDTO>();
                return View(socios);
            }
            catch (Exception e)
            {
                ViewBag.Error = "No se pudieron cargar los socios: " + e.Message;
                return View(new List<SocioListadoDTO>());
            }
        }

        [Admin]
        public IActionResult VerPrestamos(int? coordId)
        {
            try
            {
                var coordinadores = _auxHttp.EnviarYDeserializar<List<AltaUsuarioDTO>>("api/login/usuarios", "GET", token: Token).
                    Where(u => u.Rol == "Coordinador").ToList() ?? new List<AltaUsuarioDTO>();

                var prestamos = _auxHttp.EnviarYDeserializar<List<PrestamoListadoDTO>>("api/coord/prestamos", "GET", token: Token
                ) ?? new List<PrestamoListadoDTO>();

                if (coordId.HasValue)
                {
                    prestamos = prestamos
                        .Where(p => p.CoordId == coordId.Value)
                        .ToList();
                }

                ViewBag.Coordinadores = coordinadores;
                ViewBag.CoordSeleccionado = coordId;

                return View(prestamos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<PrestamoListadoDTO>());
            }
        }
        [Admin]
        public IActionResult VerPrestamoByAudiId(int? id)
        {
            try
            {
                var prestamo = _auxHttp.EnviarYDeserializar<PrestamoListadoDTO>($"api/coord/prestamos/{id}", "GET", token: Token);
                return View(prestamo);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<PrestamoListadoDTO>());
            }
        }
        [Admin]
        public IActionResult VerAuditoria(int prestamoId)
        {
            try
            {
                if (prestamoId <= 0)
                {
                    ViewBag.Error = "Id de préstamo inválido.";
                    return View(new List<AuditoriaPrestamoDTO>());
                }
                var auditorias = _auxHttp.EnviarYDeserializar<List<AuditoriaPrestamoDTO>>($"api/coord/auditorias/{prestamoId}", "GET", token: Token) ?? new List<AuditoriaPrestamoDTO>();

                return View(auditorias);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(new List<AuditoriaPrestamoDTO>());
            }
        }
        [Admin]
        public IActionResult AltaUsu()
        {
            return View();
        }
        [HttpPost]
        [Admin]
        public IActionResult AltaUsu([FromForm] VMUsuario vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var dto = new AltaUsuarioDTO(
                 vm.Id,
                 vm.Nombre,
                 vm.Direccion,
                 vm.Telefono,
                 vm.Email,
                 vm.UserName,
                 vm.Password,
                 "Socio"
             );
            _auxHttp.EnviarYDeserializar<AltaUsuarioDTO>("api/login/usuarios", "POST", dto, token: Token);
            return RedirectToAction("Index");
        }
        [Admin]
        public IActionResult AltaTelescopio()
        {
            return View();
        }
        [HttpPost]
        [Admin]
        public IActionResult AltaTelescopio([FromForm] VMTelescopio vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                var dto = new AltaTelescopioDTO(
                    vm.Id,
                    vm.Marca,
                    vm.Modelo,
                    vm.Cantidad.Value,
                    vm.Apertura.Value,
                    vm.RelacionFocal.Value,
                    vm.DistanciaFocal.Value,
                    vm.Peso.Value
                );
                _auxHttp.EnviarYDeserializar<AltaTelescopioDTO>("api/admin/telescopios", "POST", dto, token: Token);

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(vm);
            }
            return RedirectToAction("Index");
        }
        [Admin]
        public IActionResult AltaMontura()
        {
            return View();
        }
        [HttpPost]
        [Admin]
        public IActionResult AltaMontura([FromForm] VMMontura vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var dto = new AltaMonturaDTO(
                vm.Id,
                vm.Marca,
                vm.Modelo,
                vm.Cantidad.Value,
                vm.TipoMontura,
                vm.CargaSoportada.Value,
                vm.EsComputarizado
            );
            _auxHttp.EnviarYDeserializar<AltaMonturaDTO>("api/admin/monturas", "POST", dto, token: Token);
            return RedirectToAction("Index");
        }
        [Admin]
        public IActionResult AltaOcular()
        {
            return View();
        }
        [HttpPost]
        [Admin]
        public IActionResult AltaOcular([FromForm] VMOcular vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var dto = new AltaOcularDTO(
                vm.Id,
                vm.Marca,
                vm.Modelo,
                vm.Cantidad.Value,
                vm.Angulo.Value,
                vm.Diametro.Value
            );
            _auxHttp.EnviarYDeserializar<AltaOcularDTO>("api/admin/oculares", "POST", dto, token: Token);
            return RedirectToAction("Index");
        }

        [Admin]
        public IActionResult AltaCamara()
        {
            return View();
        }
        [HttpPost]
        [Admin]
        public IActionResult AltaCamara([FromForm] VMCamara vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var dto = new AltaCamaraDTO(
                vm.Id,
                vm.Marca,
                vm.Modelo,
                vm.Cantidad.Value,
                vm.Pixel.Value,
                vm.Resolucion.Value,
                vm.TipoSensor
            );

            _auxHttp.EnviarYDeserializar<AltaCamaraDTO>("api/admin/camaras", "POST", dto, token: Token);
            return RedirectToAction("Index");
        }

        [Admin]
        public IActionResult EditCamara(int id)
        {
            var vm = new VMCamara
            {
                Id = id
            };
            return View(vm);
        }

        [HttpPost]
        [Admin]
        public IActionResult EditCamara(int id, [FromForm] VMCamara vm)
        {
            try
            {
                var dto = new AltaCamaraDTO(
                    id,
                    vm.Marca,
                    vm.Modelo,
                    vm.Cantidad.Value,
                    vm.Pixel.Value,
                    vm.Resolucion.Value,
                    vm.TipoSensor
                );

                _auxHttp.EnviarSolicitud($"api/admin/camaras/{id}", "PUT", dto, token: Token);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
        }

        [Admin]
        public IActionResult EditTelescopio(int id)
        {
            var vm = new VMTelescopio
            {
                Id = id
            };
            return View(vm);
        }

        [HttpPost]
        [Admin]
        public IActionResult EditTelescopio(int id, [FromForm] VMTelescopio vm)
        {
            try
            {
                var dto = new AltaTelescopioDTO(
                    id,
                    vm.Marca,
                    vm.Modelo,
                    vm.Cantidad.Value,
                    vm.Apertura.Value,
                    vm.RelacionFocal.Value,
                    vm.DistanciaFocal.Value,
                    vm.Peso.Value
                );

                _auxHttp.EnviarSolicitud($"api/admin/telescopios/{id}", "PUT", dto, token: Token);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
        }

        [Admin]
        public IActionResult EditOcular(int id)
        {

            var vm = new VMOcular
            {
                Id = id
            };
            return View(vm);
        }

        [HttpPost]
        [Admin]
        public IActionResult EditOcular(int id, [FromForm] VMOcular vm)
        {
            try
            {
                var dto = new AltaOcularDTO(
                    id,
                    vm.Marca,
                    vm.Modelo,
                    vm.Cantidad.Value,
                    vm.Angulo.Value,
                    vm.Diametro.Value
                );
                string token = HttpContext.Session.GetString("token");
                _auxHttp.EnviarSolicitud($"api/admin/oculares/{id}", "PUT", dto, token: Token);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
        }

        [Admin]
        public IActionResult EditMontura(int id)
        {
            var vm = new VMMontura
            {
                Id = id
            };
            return View(vm);
        }

        [HttpPost]
        [Admin]
        public IActionResult EditMontura(int id, [FromForm] VMMontura vm)
        {
            try
            {
                var dto = new AltaMonturaDTO(
                    id,
                    vm.Marca,
                    vm.Modelo,
                    vm.Cantidad.Value,
                    vm.TipoMontura,
                    vm.CargaSoportada.Value,
                    vm.EsComputarizado
                );

                _auxHttp.EnviarSolicitud($"api/admin/monturas/{id}", "PUT", dto, token: Token);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
        }
        [Admin]
        public IActionResult Delete(int id)
        {
            try
            {
                var equipo = _auxHttp.EnviarYDeserializar<AltaCamaraDTO>($"api/admin/equipos/{id}", "GET", token: Token);
                if (equipo == null)
                    return NotFound();
                return View(equipo);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        [Admin]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _auxHttp.EnviarSolicitud($"api/admin/equipos/{id}", "DELETE", token: Token);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}