using Obligatorio.LogicaNegocio.VO.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo.Camara;

namespace Obligatorio.LogicaNegocio.Entidades.Equipo
{
    public class Camara : Equipo
    {
        public VOPixel Pixel { get; private set; }
        public VOResolucion Resolucion { get; private set; }
        public VOTipoSensor TipoSensor { get; private set; }

        public Camara() { }
        public Camara(VOMarca marca, VOModelo modelo, VOCantDisp cantidad, VOPixel pixel, VOResolucion resolucion, VOTipoSensor tipoSensor) :
            base(marca, modelo, cantidad)
        {
            Pixel = pixel;
            Resolucion = resolucion;
            TipoSensor = tipoSensor;
        }


        public void Update(Camara obj)
        {
            base.Update(obj);
            this.Pixel = obj.Pixel;
            this.Resolucion = obj.Resolucion;
            this.TipoSensor = obj.TipoSensor;
        }
    }
}
