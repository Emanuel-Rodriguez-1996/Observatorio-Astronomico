using Obligatorio.LogicaNegocio.VO.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo.Ocular;

namespace Obligatorio.LogicaNegocio.Entidades.Equipo
{
    public class Ocular : Equipo
    {
        public VOAngulo Angulo { get; private set; }
        public VODiametro Diametro { get; private set; }
        public Ocular() { }
        public Ocular(VOMarca marca, VOModelo modelo, VOCantDisp cantidad, VOAngulo angulo, VODiametro diametro) :
            base(marca, modelo, cantidad)
        {
            Angulo = angulo;
            Diametro = diametro;
        }


        public void Update(Ocular obj)
        {
            base.Update(obj);
            this.Angulo = obj.Angulo;
            this.Diametro = obj.Diametro;
        }
    }
}
