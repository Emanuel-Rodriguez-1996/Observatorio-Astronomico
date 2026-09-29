using Obligatorio.LogicaAplicacion.Dtos.Equipo;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.Exepciones.Equipo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;


namespace Obligatorio.LogicaAplicacion.CasosUso.Equipo
{
    public class UpdateEquipo : ICUUpdate<AltaCamaraDTO>,
                                ICUUpdate<AltaTelescopioDTO>,
                                ICUUpdate<AltaOcularDTO>,
                                ICUUpdate<AltaMonturaDTO>
    {
        private IRepositorioEquipo _repo;
        public UpdateEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public void Execute(int id, AltaCamaraDTO dto)
        {
            var existente = _repo.GetById(id) as Camara;

            if (existente == null)
                throw new EquipoInvalidExeption("La cámara no existe");

            EquipoMapper.UpdateEntity(dto, existente);

            _repo.Update(id, existente);
        }
        public void Execute(int id, AltaTelescopioDTO dto)
        {
            var existente = _repo.GetById(id) as Telescopio;

            if (existente == null)
                throw new EquipoInvalidExeption("El telescopio no existe");

            EquipoMapper.UpdateEntity(dto, existente);

            _repo.Update(id, existente);
        }

        public void Execute(int id, AltaMonturaDTO dto)
        {
            var existente = _repo.GetById(id) as Montura;

            if (existente == null)
                throw new EquipoInvalidExeption("La montura no existe");

            EquipoMapper.UpdateEntity(dto, existente);

            _repo.Update(id, existente);
        }

        public void Execute(int id, AltaOcularDTO dto)
        {
            var existente = _repo.GetById(id) as Ocular;

            if (existente == null)
                throw new EquipoInvalidExeption("El ocular no existe");

            EquipoMapper.UpdateEntity(dto, existente);

            _repo.Update(id, existente);
        }
    }
}