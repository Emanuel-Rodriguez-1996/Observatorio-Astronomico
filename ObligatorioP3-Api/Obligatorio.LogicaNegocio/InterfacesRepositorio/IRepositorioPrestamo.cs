using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPrestamo : IRepositorioAdd<Prestamo>,
                                            IRepositorioAdd<AuditoriaPrestamo>,
                                            IRepositorioGetAll<Prestamo>,
                                            IRepositorioGetById<Prestamo>,
                                            IRepositorioUpdate<Prestamo>
    {
        IEnumerable<AuditoriaPrestamo> GetAllAuditorias();
        IEnumerable<AuditoriaPrestamo> GetAuditoriaByPrestamo(int prestamoId);
    }
}