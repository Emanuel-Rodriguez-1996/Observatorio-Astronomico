using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipo
{
    public class DeleteEquipo : ICUDelete<int>
    {
        private IRepositorioEquipo _repo;


        public DeleteEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            var equipo = _repo.GetById(id);

            if (equipo == null)
                throw new NotFoundException("No existe el equipo con id: " + id);

            _repo.Delete(equipo);
        }
    }
}

