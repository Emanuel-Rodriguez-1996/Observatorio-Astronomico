using Obligatorio.LogicaAplicacion.Dtos.Equipo;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipo
{
    public class ListarEquipos : ICUGetAll<AltaTelescopioDTO>,
                                    ICUGetAll<AltaCamaraDTO>,
                                    ICUGetAll<AltaMonturaDTO>,
                                    ICUGetAll<AltaOcularDTO>
    {
        private IRepositorioEquipo _repo;
        public ListarEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<AltaTelescopioDTO> Ejecutar()
        {
            return _repo.GetAll()
                .OfType<Telescopio>()
                .Select(t => EquipoMapper.ToDto(t));
        }

        IEnumerable<AltaCamaraDTO> ICUGetAll<AltaCamaraDTO>.Ejecutar()
        {
            return _repo.GetAll()
                .OfType<Camara>()
                .Select(c => EquipoMapper.ToDto(c));
        }

        IEnumerable<AltaMonturaDTO> ICUGetAll<AltaMonturaDTO>.Ejecutar()
        {
            return _repo.GetAll()
                .OfType<Montura>()
                .Select(m => EquipoMapper.ToDto(m));
        }

        IEnumerable<AltaOcularDTO> ICUGetAll<AltaOcularDTO>.Ejecutar()
        {
            return _repo.GetAll()
                .OfType<Ocular>()
                .Select(o => EquipoMapper.ToDto(o));
        }
    }
}
