using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;


namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioObservacion : IRepositorioObservacion
    {
        private ObservatorioContext _context;

        public RepositorioObservacion(ObservatorioContext context)
        {
            _context = context;
        }

        public void Add(Observacion obj)
        {
            _context.Observaciones.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Observacion> GetAll()
        {
            //throw new NotImplementedException();
            return _context.Observaciones
            .Include(o => o.Prestamo)
            .Include(o => o.ObjCeleste)
            .ToList();
        }

        public Observacion GetById(int id)
        {
            //hrow new NotImplementedException();
            return _context.Observaciones
            .Include(o => o.Prestamo)
            .Include(o => o.ObjCeleste)
            .FirstOrDefault(o => o.Id == id);
        }
    }
}