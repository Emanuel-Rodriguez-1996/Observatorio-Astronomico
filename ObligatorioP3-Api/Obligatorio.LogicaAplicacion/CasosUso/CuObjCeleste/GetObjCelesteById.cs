using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuObjCeleste;

public class GetObjCelesteById : ICUGetById<ObjCelesteListadoDTO>
{
    private readonly IRepositorioObjCeleste _repo;

    public GetObjCelesteById(IRepositorioObjCeleste repo)
    {
        _repo = repo;
    }

    public ObjCelesteListadoDTO Execute(int id)
    {
        var o = _repo.GetById(id);

        if (o == null) return null;

        return new ObjCelesteListadoDTO(
            o.Id,
            o.Nombre.Value,
            o.Tipo.ToString(),
            o.Magnitud.Value
        );
    }
}