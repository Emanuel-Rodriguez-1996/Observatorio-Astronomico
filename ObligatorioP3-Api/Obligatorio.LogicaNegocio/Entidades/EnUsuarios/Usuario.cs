using Obligatorio.LogicaNegocio.Exepciones.User;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaNegocio.Entidades.EnUsuarios
{
    public abstract class Usuario : IEntity
    {
        public int Id { get; set; }
        public VOName Nombre { get; private set; }
        public VOAddress Direccion { get; private set; }
        public VOPhone Telefono { get; private set; }
        public VOEmail Email { get; private set; }
        public VOUserName UserName { get; private set; }
        public VOPassword Password { get; private set; }
        public VORol Rol { get; private set; }

        protected Usuario() { }
        protected Usuario(VOName nombre, VOAddress direccion, VOPhone telefono, VOEmail email, VOUserName userName, VOPassword password, VORol rol)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            UserName = userName;
            Password = password;
            Rol = rol;
            Validar();
        }

        private void Validar()
        {
            if (Nombre == null)
            {
                throw new UsuarioInvalidException("El nombre es obligatorio");
            }
            if (Direccion == null)
            {
                throw new UsuarioInvalidException("La dirección es obligatoria");
            }
            if (Telefono == null)
            {
                throw new UsuarioInvalidException("El teléfono es obligatorio");
            }
            if (Email == null)
            {
                throw new UsuarioInvalidException("El email es obligatorio");
            }
            if (UserName == null)
            {
                throw new UsuarioInvalidException("El nombre de usuario es obligatorio");
            }

            if (Password == null)
            {
                throw new UsuarioInvalidException("La contraseña es obligatoria");
            }

            if (Rol == null)
            {
                throw new UsuarioInvalidException("El rol es obligatorio");
            }
        }
    }
}
