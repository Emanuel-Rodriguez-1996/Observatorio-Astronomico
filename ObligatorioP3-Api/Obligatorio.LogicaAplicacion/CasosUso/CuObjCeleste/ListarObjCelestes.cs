using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuObjCeleste
{
    public class ListarObjCelestes : ICUGetAll<ObjCelesteListadoDTO>
    {
        private IRepositorioObjCeleste _repo;

        public ListarObjCelestes(IRepositorioObjCeleste repo)
        {
            _repo = repo;
        }

        public IEnumerable<ObjCelesteListadoDTO> Ejecutar()
        {
            return _repo.GetAll()
                .Select(o => new ObjCelesteListadoDTO(
                    o.Id,
                    o.Nombre.Value,
                    o.Tipo.ToString(),
                    o.Magnitud.Value
                ));
        }
    }
}

