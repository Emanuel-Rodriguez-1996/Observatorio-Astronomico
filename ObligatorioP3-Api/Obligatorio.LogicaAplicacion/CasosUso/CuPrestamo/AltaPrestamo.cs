using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.Exepciones.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.LogicaNegocio.VO.Prestamo;
using Obligatorio.LogicaNegocio.VO.VOPrestamo;
using Obligatorio.LogicaNegocio.VO.VOPrestamo.VOAuditoria;
using Obligatorio.LogicaNegocio.VO.VOUsuarios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuPrestamo
{
    public class AltaPrestamo : ICUAlta<AltaPrestamoDTO>
    {
        private IRepositorioPrestamo _repoPrestamo;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioEquipo _repoEquipo;

        public AltaPrestamo(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario,
            IRepositorioEquipo repoEquipo)
        {
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
            _repoEquipo = repoEquipo;
        }

        public void Ejecutar(AltaPrestamoDTO dto)
        {
            var socio = _repoUsuario.GetById(dto.SocioId);
            if (socio == null)
                throw new PrestamoInvalidException("Socio no encontrado");

            var coord = _repoUsuario.GetById(dto.Coord);
            if (coord == null)
                throw new PrestamoInvalidException("Coordinador no encontrado");

            var telescopio = _repoEquipo.GetById(dto.TelescopioId) as Telescopio;
            if (telescopio == null)
                throw new PrestamoInvalidException("Telescopio no encontrado o id inválido");

            var montura = _repoEquipo.GetById(dto.MonturaId) as Montura;
            if (montura == null)
                throw new PrestamoInvalidException("Montura no encontrada o id inválido");

            Camara camara = null;
            if (dto.CamaraId != null)
            {
                camara = _repoEquipo.GetById(dto.CamaraId.Value) as Camara;
                if (camara == null)
                    throw new PrestamoInvalidException("Cámara no encontrada o id inválido");
            }

            Ocular ocular = null;
            if (dto.OcularId != null)
            {
                ocular = _repoEquipo.GetById(dto.OcularId.Value) as Ocular;
                if (ocular == null)
                    throw new PrestamoInvalidException("Ocular no encontrado o id inválido");
            }

            VOFchInicio fchInicio =
                new VOFchInicio(dto.FchInicio);

            VOFchFin fchFin =
                new VOFchFin(dto.FchFin);

            Prestamo prestamo = new Prestamo(
                dto.Id,
                socio,
                telescopio,
                montura,
                camara,
                ocular,
                fchInicio,
                fchFin,
                coord
            );

            telescopio.RestarCantidad();
            montura.RestarCantidad();
            camara?.RestarCantidad();
            ocular?.RestarCantidad();

            _repoPrestamo.Add(prestamo);

            AuditoriaPrestamo auditoria = new AuditoriaPrestamo(
                new VOId(prestamo.Id),
                new VOFchAuditoriaP(DateTime.Now),
                new VOId(coord.Id),
                new VOName(coord.Nombre.Value),
                new VOEstadoPrestamo(prestamo.Estado.Value)
            );

            _repoPrestamo.Add(auditoria);
        }
    }
}