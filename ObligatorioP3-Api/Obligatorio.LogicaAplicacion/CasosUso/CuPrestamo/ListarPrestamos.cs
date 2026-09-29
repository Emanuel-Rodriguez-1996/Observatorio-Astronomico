using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using static Obligatorio.LogicaNegocio.VO.VOPrestamo.VOEstadoPrestamo;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuPrestamo
{
    public class ListarPrestamos : ICUGetAll<PrestamoListadoDTO>
    {
        private IRepositorioPrestamo _repo;

        public ListarPrestamos(IRepositorioPrestamo repo)
        {
            _repo = repo;
        }

        public IEnumerable<PrestamoListadoDTO> Ejecutar()
        {
            return _repo.GetAll().Select(p =>
                new PrestamoListadoDTO(
                    p.Id,
                    p.Socio.Id,
                    p.Socio.Nombre.Value,
                    p.Telescopio.Marca.Value,
                    p.Montura.Marca.Value,
                    p.Camara?.Marca.Value ?? "",
                    p.Ocular?.Marca.Value ?? "",
                    p.FchInicio.Value,
                    p.FchFin.Value,
                    p.Estado.GetTString(),
                    p.Estado.Value != VOEstadoPrestamoEnum.Devuelto.ToString(),
                    p.Coord.Id,
                    p.Coord.Nombre.Value
                )
            );
        }
    }
}
