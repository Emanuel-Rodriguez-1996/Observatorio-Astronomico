using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Http;
using WebAppFront_end.Models.Dtos.Observacion;
using WebAppFront_end.Models.Dtos.Prestamo;
using WebAppFront_end.Models.VM;

namespace WebAppFront_end.Controllers
{
    public class SocioController : Controller
    {
        private readonly AuxiliarClienteHttp _auxHttp;
        string token => HttpContext.Session.GetString("token");

        public SocioController(AuxiliarClienteHttp auxHttp)
        {
            _auxHttp = auxHttp;
        }
        private void CargarCombos()
        {
            int socioId = HttpContext.Session.GetInt32("userId").Value;

            ViewBag.Prestamos = _auxHttp.EnviarYDeserializar<List<PrestamoListadoDTO>>("api/coord/prestamos", "GET", token: token
            )?.Where(p => p.SocioId == socioId).ToList() ?? new List<PrestamoListadoDTO>();

            ViewBag.ObjetosCelestes = _auxHttp.EnviarYDeserializar<List<ObjCelesteListadoDTO>>("api/socio/objetos-celestes", "GET", token: token) ?? new List<ObjCelesteListadoDTO>();
        }
        public IActionResult IndexSocio()
        {
            var prestamos = _auxHttp.EnviarYDeserializar<List<PrestamoListadoDTO>>("api/coord/prestamos", "GET", token: token) ?? new List<PrestamoListadoDTO>();
            var ranking = _auxHttp.EnviarYDeserializar<List<RankinObjCelesteDTO>>("api/socio/ranking-objetos", "GET", token: token) ?? new List<RankinObjCelesteDTO>();

            VMIndex vm = new VMIndex()
            {
                Prestamos = prestamos,
                RankingObjCelestes = ranking
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult FiltrarPrestamos(int mes, int anio)
        {
            var ranking = _auxHttp.EnviarYDeserializar<List<RankinObjCelesteDTO>>("api/socio/ranking-objetos", "GET", token: token) ?? new List<RankinObjCelesteDTO>();
            var prestamosTotales = _auxHttp.EnviarYDeserializar<List<PrestamoListadoDTO>>("api/coord/prestamos", "GET", token: token) ?? new List<PrestamoListadoDTO>();

            var prestamosFiltrados = prestamosTotales.Where(p => p.FchInicio.Month == mes && p.FchInicio.Year == anio).ToList();

            VMIndex vm = new VMIndex()
            {
                RankingObjCelestes = ranking,
                Prestamos = prestamosFiltrados
            };

            return View("IndexSocio", vm);
        }
        public IActionResult AltaObservacion(int id)
        {
            CargarCombos();
            VMObservacion vm = new VMObservacion();
            vm.PrestamoId = id;
            return View(vm);
        }
        [HttpPost]
        public IActionResult AltaObservacion([FromForm] VMObservacion vm)
        {
            if (!ModelState.IsValid)
            {
                CargarCombos();
                return View(vm);
            }

            try
            {

                var dto = new AltaObservacionDTO(
                    vm.Id,
                    vm.PrestamoId,
                    vm.ObjCelesteId.Value,
                    vm.FechaObservacion.Value
                );

                _auxHttp.EnviarYDeserializar<AltaObservacionDTO>(
                    "api/socio/observaciones",
                    "POST",
                    dto,
                    token: token
                );

                return RedirectToAction("IndexSocio");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                CargarCombos();
                return View(vm);
            }
        }
        [HttpPost]
        public IActionResult EvaluarObservacion([FromForm] VMObservacion vm)
        {
            if (!ModelState.IsValid)
            {
                CargarCombos();
                return View("AltaObservacion", vm);
            }

            try
            {
                var dto = new EvaluarObservacionDTO(
                    vm.PrestamoId,
                    vm.ObjCelesteId.Value
                );

                var resultado =
                    _auxHttp.EnviarYDeserializar<ResultadoIADTO>(
                        "api/IA/evaluar",
                        "POST",
                        dto,
                        token: token);

                ViewBag.ResultadoIA = resultado;

                CargarCombos();
                return View("AltaObservacion", vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                CargarCombos();
                return View("AltaObservacion", vm);
            }
        }
    }
}