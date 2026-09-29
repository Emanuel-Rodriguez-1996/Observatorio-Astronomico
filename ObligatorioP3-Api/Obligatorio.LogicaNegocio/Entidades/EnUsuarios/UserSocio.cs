using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaNegocio.Entidades.EnUsuarios
{
    public class UserSocio : Usuario
    {
        private UserSocio() { }
        public UserSocio(VOName nombre, VOAddress direccion, VOPhone telefono, VOEmail email, VOUserName userName, VOPassword password, VORol rol) :
            base(nombre, direccion, telefono, email, userName, password, new VORol("Socio"))
        {

        }

    }
}
