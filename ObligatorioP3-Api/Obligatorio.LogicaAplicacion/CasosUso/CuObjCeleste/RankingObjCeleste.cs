using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

public class RankingObjCeleste : ICUGetAll<RankinObjCelesteDTO>
{
    private readonly IRepositorioObservacion _repoObs;

    public RankingObjCeleste(IRepositorioObservacion repoObs)
    {
        _repoObs = repoObs;
    }

    public IEnumerable<RankinObjCelesteDTO> Ejecutar()
    {
        return _repoObs.GetAll()
            .GroupBy(o => o.ObjCeleste)
            .Select(g => new RankinObjCelesteDTO(
                g.Key.Nombre.Value,
                g.Key.Tipo.Value.ToString(),
                g.Count()
            ))
            .OrderByDescending(r => r.Cantidad)
            .ToList();
    }
}