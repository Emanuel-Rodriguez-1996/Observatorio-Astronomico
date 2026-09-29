using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Exepciones.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.LogicaNegocio.VO.VOPrestamo;
using Obligatorio.LogicaNegocio.VO.VOPrestamo.VOAuditoria;
using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuPrestamo
{
    public class DevolverPrestamo : ICUUpdate<DevolverPrestamoDTO>
    {
        private IRepositorioPrestamo _repo;
        private IRepositorioUsuario _repoUsu;

        public DevolverPrestamo(IRepositorioPrestamo repo, IRepositorioUsuario repoUsu)
        {
            _repo = repo;
            _repoUsu = repoUsu;
        }

        public void Execute(int id, DevolverPrestamoDTO dto)
        {
            // ToDo agrgar excepcion NotFouund y manejarla en el controller con 404
            var prestamo = _repo.GetById(id);
            if (prestamo == null)
                throw new PrestamoInvalidException("Préstamo no encontrado.");

            var coord = _repoUsu.GetById(dto.CoordId);
            if (coord == null)
                throw new PrestamoInvalidException("Coordinador del préstamo no encontrado.");

            prestamo.Devolver();

            AuditoriaPrestamo auditoria = new AuditoriaPrestamo(
                    new VOId(prestamo.Id),
                    new VOFchAuditoriaP(DateTime.Now),
                    new VOId(coord.Id),
                    new VOName(coord.Nombre.Value),
                    new VOEstadoPrestamo(prestamo.Estado.Value)
                );

            _repo.Update(id, prestamo);
            _repo.Add(auditoria);

        }
    }
}
