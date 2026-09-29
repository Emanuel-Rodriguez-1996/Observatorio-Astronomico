using Obligatorio.LogicaNegocio.Exepciones.ObjCeleste;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO.ObjCeleste;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class ObjCeleste : IEntity
    {
        public VONombreObjCeleste Nombre { get; private set; }
        public VOTipoObjCeleste Tipo { get; private set; }
        public VOMagnitud Magnitud { get; private set; }
        public int Id { get; set; }

        public ObjCeleste() { }
        public ObjCeleste(VONombreObjCeleste nombre, VOTipoObjCeleste tipo, VOMagnitud magnitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            Magnitud = magnitud;
            Validar();
        }
        private void Validar()
        {
            if (Nombre == null)
                throw new ObjCelesteInvalidException("El nombre es obligatorio.");
            if (Tipo == null)
                throw new ObjCelesteInvalidException("El tipo es obligatorio.");
            if (Magnitud == null)
                throw new ObjCelesteInvalidException("La magnitud es obligatoria.");
        }

        public void Update(VONombreObjCeleste nombre, VOTipoObjCeleste tipo, VOMagnitud magnitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            Magnitud = magnitud;
            Validar();
        }
    }
}
