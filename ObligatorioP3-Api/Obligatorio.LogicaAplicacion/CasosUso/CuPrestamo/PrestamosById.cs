using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using static Obligatorio.LogicaNegocio.VO.VOPrestamo.VOEstadoPrestamo;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuPrestamo
{
    public class PrestamosById(IRepositorioPrestamo _repo) : ICUGetById<PrestamoListadoDTO>
    {
        public PrestamoListadoDTO Execute(int id)
        {
            var o = _repo.GetById(id);

            if (o == null) throw new NotFoundException($"Préstamo con id {id} no encontrado");

            return new PrestamoListadoDTO(
                o.Id,
                o.Socio.Id,
                o.Socio.Nombre.Value,
                o.Telescopio.Marca.Value,
                o.Montura.Marca.Value,
                o.Camara?.Marca.Value ?? "",
                o.Ocular?.Marca.Value ?? "",
                o.FchInicio.Value,
                o.FchFin.Value,
                o.Estado.Value,
                o.Estado.Value != VOEstadoPrestamoEnum.Devuelto.ToString(),
                o.Coord.Id,
                o.Coord.Nombre.Value
            );
        }
    }
}
