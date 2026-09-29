using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO.VOPrestamo;
using Obligatorio.LogicaNegocio.VO.VOPrestamo.VOAuditoria;
using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class AuditoriaPrestamo : IEntity
    {
        public int Id { get; set; }
        public VOId PrestamoId { get; private set; }
        public VOFchAuditoriaP Fecha { get; private set; }
        public VOId CoordinadorId { get; private set; }
        public VOName CoordinadorNombre { get; private set; }
        public VOEstadoPrestamo Accion { get; private set; }

        private AuditoriaPrestamo() { }

        public AuditoriaPrestamo(
            VOId prestamoId,
            VOFchAuditoriaP fecha,
            VOId coordinadorId,
            VOName coordinadorNombre,
            VOEstadoPrestamo accion)
        {
            PrestamoId = prestamoId;
            Fecha = fecha;
            CoordinadorId = coordinadorId;
            CoordinadorNombre = coordinadorNombre;
            Accion = accion;
        }

    }
}
