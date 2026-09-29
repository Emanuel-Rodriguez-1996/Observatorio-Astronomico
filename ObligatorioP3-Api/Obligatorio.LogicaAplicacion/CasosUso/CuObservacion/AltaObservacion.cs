using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.LogicaNegocio.VO.VOObservacion;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuObservacion
{
    public class AltaObservacion(IRepositorioObservacion _repoObservacion,
                                 IRepositorioPrestamo _repoPrestamo,
                                 IRepositorioObjCeleste _repoObjCeleste) : ICUAlta<AltaObservacionDTO>
    {
        public void Ejecutar(AltaObservacionDTO dto)
        {
            Prestamo prestamo = _repoPrestamo.GetById(dto.PrestamoId);
            ObjCeleste objeto = _repoObjCeleste.GetById(dto.ObjCelesteId);
            VOFechaObs fchObs = new VOFechaObs(dto.FechaObservacion);
            Observacion observacion = new Observacion(
                dto.Id,
                prestamo,
                objeto,
                fchObs
            );
            _repoObservacion.Add(observacion);
        }
    }
}