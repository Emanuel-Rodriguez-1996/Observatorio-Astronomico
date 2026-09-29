using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuPrestamo
{

    public class ListAudiById : ICUGetTById<AuditoriaPrestamoDTO>
    {
        private readonly IRepositorioPrestamo _repo;

        public ListAudiById(
            IRepositorioPrestamo repo)
        {
            _repo = repo;
        }

        public IEnumerable<AuditoriaPrestamoDTO> Ejecutar(int id)
        {
            return _repo.GetAuditoriaByPrestamo(id)
                 .Select(a => new AuditoriaPrestamoDTO(
                     a.Id,
                     a.PrestamoId.Value,
                     a.Fecha.Value,
                     a.CoordinadorId.Value,
                     a.CoordinadorNombre.Value,
                     a.Accion.Value
                 ))
                 .ToList();
        }
    }
}