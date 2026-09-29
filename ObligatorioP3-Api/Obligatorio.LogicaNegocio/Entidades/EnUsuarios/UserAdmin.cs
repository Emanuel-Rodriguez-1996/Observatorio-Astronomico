using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaNegocio.Entidades.EnUsuarios
{
    public class UserAdmin : Usuario
    {
        private UserAdmin() { }
        public UserAdmin(VOName nombre, VOAddress direccion, VOPhone telefono, VOEmail email, VOUserName userName, VOPassword password, VORol rol) :
            base(nombre, direccion, telefono, email, userName, password, rol)
        {
        }

    }
}
