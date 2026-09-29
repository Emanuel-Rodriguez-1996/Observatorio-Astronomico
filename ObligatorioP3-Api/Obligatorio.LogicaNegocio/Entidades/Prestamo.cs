using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.Entidades.Equipo;
using Obligatorio.LogicaNegocio.Exepciones.Prestamo;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO.Equipo.Montura;
using Obligatorio.LogicaNegocio.VO.Prestamo;
using Obligatorio.LogicaNegocio.VO.VOPrestamo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Prestamo : IEntity
    {
        public int Id { get; set; }
        public Usuario Socio { get; private set; }
        public Usuario? Coord { get; private set; }
        public Telescopio Telescopio { get; private set; }
        public Montura Montura { get; private set; }
        public Camara? Camara { get; private set; }
        public Ocular? Ocular { get; private set; }
        public VOFchInicio FchInicio { get; private set; }
        public VOFchFin FchFin { get; private set; }
        public VOEstadoPrestamo Estado { get; private set; }

        private Prestamo() { }

        public Prestamo(
             int id,
             Usuario socio,
             Telescopio telescopio,
             Montura montura,
             Camara camara,
             Ocular ocular,
             VOFchInicio fchInicio,
             VOFchFin fchFin,
             Usuario coord)
        {
            Id = id;
            Socio = socio;
            Telescopio = telescopio;
            Montura = montura;
            Camara = camara;
            Ocular = ocular;
            FchInicio = fchInicio;
            FchFin = fchFin;
            Estado = new VOEstadoPrestamo(VOEstadoPrestamo.VOEstadoPrestamoEnum.En_Prestamo.ToString());
            Coord = coord;
            Validar();
        }

        public void Validar()
        {
            if (FchInicio == null)
                throw new PrestamoInvalidException("Debe ingresar fecha de inicio.");

            if (FchFin == null)
                throw new PrestamoInvalidException("Debe ingresar fecha de fin.");

            if (FchFin.Value < FchInicio.Value)
                throw new PrestamoInvalidException("La fecha de fin no puede ser anterior a la fecha de inicio.");

            var hoy = DateTime.Today;

            if (FchFin.Value < hoy)
                Estado = new VOEstadoPrestamo(VOEstadoPrestamo.VOEstadoPrestamoEnum.Atrasado.ToString());

            if (FchInicio.Value < hoy)
                throw new PrestamoInvalidException("La fecha de inicio no puede ser anterior a la fecha actual.");

            if (Socio == null)
                throw new PrestamoInvalidException("Debe seleccionar un socio.");

            if (Telescopio == null)
                throw new PrestamoInvalidException("Debe seleccionar un telescopio.");

            if (Montura == null)
                throw new PrestamoInvalidException("Debe seleccionar una montura.");

            if (Camara == null && Ocular == null)
                throw new PrestamoInvalidException("Debe seleccionar una cámara o un ocular.");
            // STOCK
            if (Telescopio.Cantidad.Value <= 0)
                throw new PrestamoInvalidException("No hay telescopios disponibles.");

            if (Montura.Cantidad.Value <= 0)
                throw new PrestamoInvalidException("No hay monturas disponibles.");

            if (Camara != null && Camara.Cantidad.Value <= 0)
                throw new PrestamoInvalidException("No hay cámaras disponibles para el préstamo.");

            if (Ocular != null && Ocular.Cantidad.Value <= 0)
                throw new PrestamoInvalidException("No hay oculares disponibles para el préstamo.");
            // VALIDACIONES DE NEGOCIO
            if (Montura.CargaSoportada.Value < Telescopio.Peso.Value)
            {
                throw new PrestamoInvalidException("La montura no soporta el peso del telescopio.");
            }

            if (Camara != null)
            {
                if (Montura.TipoMontura.Value != VOTipoMontura.VOTipoMonturaEnum.Ecuatorial.ToString() &&
                    Montura.TipoMontura.Value != VOTipoMontura.VOTipoMonturaEnum.Hibrida.ToString())
                {
                    throw new PrestamoInvalidException(
                        "La cámara solo puede ser utilizada con una montura ecuatorial o híbrida.");
                }
            }
        }

        public void Devolver()
        {
            Estado = new VOEstadoPrestamo(VOEstadoPrestamo.VOEstadoPrestamoEnum.Devuelto.ToString());

            if (Telescopio == null || Montura == null)
                throw new PrestamoInvalidException("No se pueden devolver elementos porque faltan datos del equipo.");

            Telescopio.SumarCantidad();
            Montura.SumarCantidad();
            if (Camara != null)
                Camara.SumarCantidad();
            if (Ocular != null)
                Ocular.SumarCantidad();
        }

        public void Update(
            Usuario socio,
            Telescopio telescopio,
            Montura montura,
            Camara camara,
            Ocular ocular,
            VOFchInicio fchInicio,
            VOFchFin fchFin,
            VOEstadoPrestamo estado)
        {
            Socio = socio;
            Telescopio = telescopio;
            Montura = montura;
            Camara = camara;
            Ocular = ocular;
            FchInicio = fchInicio;
            FchFin = fchFin;
            Estado = estado;
            Validar();
        }
    }
}