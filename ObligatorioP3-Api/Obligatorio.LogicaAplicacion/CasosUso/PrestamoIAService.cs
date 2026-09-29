using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso
{
    public class PrestamoIAService : ICUGetById<PrestamoIADTO>
    {
            private readonly IRepositorioPrestamo _repo;

            public PrestamoIAService(IRepositorioPrestamo repo)
            {
                _repo = repo;
            }

        public PrestamoIADTO Execute(int id)
        {
            var p = _repo.GetById(id);

            if (p == null)
                return null;

            return new PrestamoIADTO(
                p.Telescopio.Apertura.Value,
                p.Telescopio.DistanciaFocal.Value,
                p.Telescopio.RelacionFocal.Value,

                p.Camara?.TipoSensor?.Value,
                p.Camara?.Resolucion?.Value,
                p.Camara?.Pixel?.Value,

                p.Ocular?.Angulo?.Value,
                p.Ocular?.Diametro?.Value
            );
        }
    }
}

