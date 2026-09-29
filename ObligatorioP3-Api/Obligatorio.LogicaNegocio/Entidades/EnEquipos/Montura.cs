using Obligatorio.LogicaNegocio.VO.Equipo;
using Obligatorio.LogicaNegocio.VO.Equipo.Montura;

namespace Obligatorio.LogicaNegocio.Entidades.Equipo
{
    public class Montura : Equipo
    {
        public VOTipoMontura TipoMontura { get; private set; }
        public VOCargaMontura CargaSoportada { get; private set; }
        public VOComputarizado EsComputarizado { get; private set; }
        public Montura() { }
        public Montura(VOMarca marca, VOModelo modelo, VOCantDisp cantidad, VOTipoMontura tipoMontura, VOCargaMontura cargaSoportada, VOComputarizado esComputarizado) :
            base(marca, modelo, cantidad)
        {
            TipoMontura = tipoMontura;
            CargaSoportada = cargaSoportada;
            EsComputarizado = esComputarizado;
        }

        public void Update(Montura obj)
        {
            base.Update(obj);
            this.TipoMontura = obj.TipoMontura;
            this.CargaSoportada = obj.CargaSoportada;
            this.EsComputarizado = obj.EsComputarizado;
        }
    }
}
