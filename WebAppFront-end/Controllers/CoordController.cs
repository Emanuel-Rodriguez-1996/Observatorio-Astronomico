using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Http;
using WebAppFront_end.Models.Dtos.Equipo;
using WebAppFront_end.Models.Dtos.Prestamo;
using WebAppFront_end.Models.Dtos.Usuario;
using WebAppFront_end.Models.VM;

namespace Obligatorio.AppWeb.Controllers
{
    public class CoordController : Controller
    {
        private readonly AuxiliarClienteHttp _auxHttp;
        string token => HttpContext.Session.GetString("token");
        int idCord => HttpContext.Session.GetInt32("userId").Value;

        public CoordController(AuxiliarClienteHttp auxHttp)
        {
            _auxHttp = auxHttp;
        }

        private void CargarCombos(VMPrestamo vm)
        {
            vm.listUsuarios =
                _auxHttp.EnviarYDeserializar<List<AltaUsuarioDTO>>("api/login/usuarios", "GET", token: token).Where(u => u.Rol == "Socio")
                .ToList() ?? new List<AltaUsuarioDTO>();

            vm.listTelescopios =
                _auxHttp.EnviarYDeserializar<List<AltaTelescopioDTO>>(
                    "api/admin/telescopios",
                    "GET", token: token
                ) ?? new List<AltaTelescopioDTO>();

            vm.listMonturas =
                _auxHttp.EnviarYDeserializar<List<AltaMonturaDTO>>(
                    "api/admin/monturas",
                    "GET", token: token
                ) ?? new List<AltaMonturaDTO>();

            vm.listCamaras =
                _auxHttp.EnviarYDeserializar<List<AltaCamaraDTO>>(
                    "api/admin/camaras",
                    "GET", token: token
                ) ?? new List<AltaCamaraDTO>();

            vm.listOculares =
                _auxHttp.EnviarYDeserializar<List<AltaOcularDTO>>(
                    "api/admin/oculares",
                    "GET", token: token
                ) ?? new List<AltaOcularDTO>();
        }
        public IActionResult AltaPrestamo()
        {
            var vm = new VMPrestamo();
            ViewBag.Token = "Bearer " + HttpContext.Session.GetString("token");
            CargarCombos(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult AltaPrestamo([FromForm] VMPrestamo vm)
        {
            ViewBag.Token = "Bearer " + HttpContext.Session.GetString("token");

            if (!ModelState.IsValid)
            {
                CargarCombos(vm);
                return View(vm);
            }
            try
            {
                var dto = new AltaPrestamoDTO(
                    vm.Id,
                    vm.Socio.Value,
                    vm.Telescopio.Value,
                    vm.Montura.Value,
                    vm.Camara,
                    vm.Ocular,
                    vm.FchInicio.Value,
                    vm.FchFin.Value,
                    "En_Prestamo",
                    idCord
                );

                var response = _auxHttp.EnviarSolicitud("api/coord/prestamos", "POST", token: token, body: dto);

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                CargarCombos(vm);
                return View(vm);
            }
        }
        [HttpGet]
        public IActionResult DevolverPrestamo(int id)
        {
            try
            {
                var dto = new DevolverPrestamoDTO(id, idCord);

                _auxHttp.EnviarSolicitud($"api/coord/prestamos/{id}", "PUT", token: token, body: dto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado al procesar la devolución: " + ex.Message;
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
