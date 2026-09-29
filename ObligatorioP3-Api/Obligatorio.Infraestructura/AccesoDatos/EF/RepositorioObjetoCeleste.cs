using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;


namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioObjCeleste : IRepositorioObjCeleste
    {
        private ObservatorioContext _context;

        public RepositorioObjCeleste(ObservatorioContext context)
        {
            _context = context;
        }

        public void Add(ObjCeleste obj)
        {
            _context.ObjCelestes.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<ObjCeleste> GetAll()
        {
            return _context.ObjCelestes.ToList();
        }

        public ObjCeleste GetById(int id)
        {
            return _context.ObjCelestes.Find(id);
        }
    }
}