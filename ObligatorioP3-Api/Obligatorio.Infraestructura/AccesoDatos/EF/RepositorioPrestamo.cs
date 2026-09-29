using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioPrestamo : IRepositorioPrestamo
    {
        private ObservatorioContext _contexto;
        public RepositorioPrestamo(ObservatorioContext contexto)
        {
            _contexto = contexto;
        }
        public void Add(Prestamo obj)
        {

            _contexto.Prestamos.Add(obj);
            _contexto.SaveChanges();
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _contexto.Prestamos
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .Include(p => p.Socio)
                .Include(p => p.Coord)
                .ToList();
        }

        public Prestamo GetById(int id)
        {
            return _contexto.Prestamos
               .Include(p => p.Telescopio)
               .Include(p => p.Montura)
               .Include(p => p.Camara)
               .Include(p => p.Ocular)
               .Include(p => p.Socio)
               .Include(p => p.Coord)
               .FirstOrDefault(p => p.Id == id);
        }

        public void Update(int id, Prestamo obj)
        {
            _contexto.Prestamos.Update(obj);
            _contexto.SaveChanges();
        }

        public void Add(AuditoriaPrestamo obj)
        {
            _contexto.AuditoriaPrestamos.Add(obj);
            _contexto.SaveChanges();
        }

        public IEnumerable<AuditoriaPrestamo> GetAllAuditorias()
        {
            return _contexto.AuditoriaPrestamos
                .AsNoTracking()//fijarme si puedo sacar
                .ToList();
        }

        public IEnumerable<AuditoriaPrestamo> GetAuditoriaByPrestamo(int prestamoId)
        {
            return _contexto.AuditoriaPrestamos
                .AsNoTracking()
                .Where(a => a.PrestamoId.Value == prestamoId)
                .ToList();
        }
    }
}
