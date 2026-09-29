using Obligatorio.LogicaAplicacion.Dtos.Equipo;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipo
{
    public class AltaEquipo : ICUAlta<AltaCamaraDTO>,
                              ICUAlta<AltaTelescopioDTO>,
                              ICUAlta<AltaOcularDTO>,
                              ICUAlta<AltaMonturaDTO>
    {
        private IRepositorioEquipo _repo;
        public AltaEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }
        public void Ejecutar(AltaCamaraDTO dto)
        {
            var camara = EquipoMapper.ToEntity(dto);
            _repo.Add(camara);
        }

        public void Ejecutar(AltaTelescopioDTO dto)
        {
            var telescopio = EquipoMapper.ToEntity(dto);
            _repo.Add(telescopio);
        }

        public void Ejecutar(AltaOcularDTO dto)
        {
            var ocular = EquipoMapper.ToEntity(dto);
            _repo.Add(ocular);
        }

        public void Ejecutar(AltaMonturaDTO dto)
        {
            var montura = EquipoMapper.ToEntity(dto);
            _repo.Add(montura);
        }
    }
}
