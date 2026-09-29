using Obligatorio.LogicaNegocio.Exepciones.Observacion;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO.VOObservacion;
using Obligatorio.LogicaNegocio.VO.VOPrestamo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Observacion : IEntity
    {
        public int Id { get; set; }
        public Prestamo Prestamo { get; private set; }
        public ObjCeleste ObjCeleste { get; private set; }
        public VOFechaObs Fecha { get; private set; }
        protected Observacion() { }

        public Observacion(
            int id,
            Prestamo prestamo,
            ObjCeleste objCeleste,
            VOFechaObs fecha)
        {
            Id = id;
            Prestamo = prestamo;
            ObjCeleste = objCeleste;
            Fecha = fecha;

            Validar();
        }

        public void Validar()
        {
            if (Prestamo == null)
                throw new ObsInvalidException(
                    "Debe seleccionar un préstamo.");

            if (ObjCeleste == null)
                throw new ObsInvalidException(
                    "Debe seleccionar un objeto celeste.");

            if (Fecha == null)
                throw new ObsInvalidException(
                    "Debe ingresar una fecha.");

            // El préstamo debe estar vigente para la fecha elegida
            if (Fecha.Value < Prestamo.FchInicio.Value ||
                Fecha.Value > Prestamo.FchFin.Value)
            {
                throw new ObsInvalidException(
                    "El préstamo no está vigente para la fecha Seleccionada.");
            }
            // Debe estar en estado EN_PRÉSTAMO
            if (Prestamo.Estado.Value !=
                VOEstadoPrestamo.VOEstadoPrestamoEnum.En_Prestamo.ToString())
            {
                throw new ObsInvalidException(
                    "El préstamo debe encontrarse en estado EN PRÉSTAMO.");
            }
        }

        public void Update(
            Prestamo prestamo,
            ObjCeleste objCeleste,
            VOFechaObs fecha)
        {
            Prestamo = prestamo;
            ObjCeleste = objCeleste;
            Fecha = fecha;

            Validar();
        }
    }
}