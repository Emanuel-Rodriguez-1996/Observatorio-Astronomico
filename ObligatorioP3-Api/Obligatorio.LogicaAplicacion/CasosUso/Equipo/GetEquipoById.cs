using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.Exepciones.Equipo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipo
{
    public class GetEquipoById : ICUGetEquipoById
    {
        private readonly IRepositorioEquipo _repo;

        public GetEquipoById(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public object Ejecutar(int id)
        {
            var e = _repo.GetById(id);

            if (e == null)
                throw new EquipoInvalidExeption("Equipo no encontrado");

            return e switch
            {
                Telescopio t => EquipoMapper.ToDto(t),
                Camara c => EquipoMapper.ToDto(c),
                Montura m => EquipoMapper.ToDto(m),
                Ocular o => EquipoMapper.ToDto(o),
                _ => throw new EquipoInvalidExeption("Tipo desconocido")
            };
        }

    }
}
