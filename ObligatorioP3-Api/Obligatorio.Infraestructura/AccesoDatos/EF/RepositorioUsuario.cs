using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.Exepciones.User;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ObservatorioContext _context;
        public RepositorioUsuario(ObservatorioContext context)
        {
            _context = context;
        }
        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                //ToDo cambiar tipo Exceptions
                throw new UsuarioInvalidException("El usuario no puede ser nulo");
            }
            if (_context.Usuarios.Any(u => u.UserName.Value == obj.UserName.Value))
            {
                throw new UsuarioInvalidException("El UserName del usuario ya existe");
            }
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            var lista = _context.Usuarios.ToList();
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            Usuario usu = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usu == null)
            {
                throw new UsuarioInvalidException("El Usuario no existe");
            }
            return usu;
        }
    }
}
