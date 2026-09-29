
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.Exepciones;
using Obligatorio.LogicaNegocio.Exepciones.Equipo;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private ObservatorioContext _context;
        public RepositorioEquipo(ObservatorioContext context)
        {
            _context = context;
        }
        public void Add(Equipo obj)
        {
            if (obj == null)
                throw new EquipoInvalidExeption("El equipo no puede ser nulo");

            _context.Equipos.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Equipo obj)
        {
            if (obj == null)
                throw new LogicaNegocioException("El equipo no puede ser nulo");

            // Comprobar si existe algún préstamo que referencie este equipo
            /*var hasPrestamo = _context.Prestamos.Any(p =>
                Microsoft.EntityFrameworkCore.EF.Property<int?>(p, "TelescopioId") == obj.Id ||
                Microsoft.EntityFrameworkCore.EF.Property<int?>(p, "MonturaId") == obj.Id ||
                Microsoft.EntityFrameworkCore.EF.Property<int?>(p, "CamaraId") == obj.Id ||
                Microsoft.EntityFrameworkCore.EF.Property<int?>(p, "OcularId") == obj.Id
            );*/
            var hasPrestamo = _context.Prestamos.Any(p =>
                (p.Telescopio != null && p.Telescopio.Id == obj.Id) ||
                (p.Montura != null && p.Montura.Id == obj.Id) ||
                (p.Camara != null && p.Camara.Id == obj.Id) ||
                (p.Ocular != null && p.Ocular.Id == obj.Id)
            );

            if (hasPrestamo)
                throw new LogicaNegocioException("No se puede eliminar el equipo porque existen préstamos históricos que lo referencian.");

            _context.Equipos.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _context.Equipos.ToList();
        }

        public Equipo GetById(int id)
        {
            return _context.Equipos.FirstOrDefault(e => e.Id == id);
        }

        public void Update(int id, Equipo obj)
        {
            Equipo equipo = GetById(id);
            if (equipo == null)
            {
                throw new EquipoInvalidExeption("no");
            }
            equipo.Update(obj);
            _context.Equipos.Update(equipo);
            _context.SaveChanges();
        }
    }
}
