using Obligatorio.LogicaNegocio.VO.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo.Telescopio;

namespace Obligatorio.LogicaNegocio.Entidades.Equipo
{
    public class Telescopio : Equipo
    {
        public VOApertura Apertura { get; private set; }
        public VORelacionFocal RelacionFocal { get; private set; }
        public VODistanciaFocal DistanciaFocal { get; private set; }
        public VOPeso Peso { get; private set; }
        public Telescopio() { }
        public Telescopio(VOMarca marca, VOModelo modelo, VOCantDisp cantidad, VOApertura apertura,
            VORelacionFocal relacionFocal, VODistanciaFocal distanciaFocal, VOPeso peso) : base(marca, modelo, cantidad)
        {
            Apertura = apertura;
            RelacionFocal = relacionFocal;
            DistanciaFocal = distanciaFocal;
            Peso = peso;
        }

        public void Update(Telescopio obj)
        {
            base.Update(obj);
            this.Apertura = obj.Apertura;
            this.RelacionFocal = obj.RelacionFocal;
            this.DistanciaFocal = obj.DistanciaFocal;
            this.Peso = obj.Peso;
        }

    }
}
