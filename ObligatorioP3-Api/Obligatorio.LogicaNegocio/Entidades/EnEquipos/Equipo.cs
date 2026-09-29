using Obligatorio.LogicaNegocio.Exepciones.Equipo;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO.Equipo;


namespace Obligatorio.LogicaNegocio.Entidades.Equipo
{
    public abstract class Equipo : IEntity
    {
        public VOMarca Marca { get; private set; }
        public VOModelo Modelo { get; private set; }
        public VOCantDisp Cantidad { get; private set; }

        public int Id { get; set; }

        public Equipo() { }
        public Equipo(VOMarca marca, VOModelo modelo, VOCantDisp cantidad)
        {
            Marca = marca;
            Modelo = modelo;
            Cantidad = cantidad;
            Validar();
        }

        private void Validar()
        {
            if (Marca == null) { throw new EquipoInvalidExeption("La marca no puede ser nula"); }
            if (Modelo == null) { throw new EquipoInvalidExeption("El modelo no puede ser nulo"); }

        }

        public void RestarCantidad()
        {
            Cantidad = new VOCantDisp(Cantidad.Value - 1);
        }

        public void SumarCantidad()
        {
            Cantidad = new VOCantDisp(Cantidad.Value + 1);
        }

        public virtual void Update(Equipo e)
        {
            if (Marca != null)
                Marca = e.Marca;
            if (Modelo != null)
                Modelo = e.Modelo;
            if (Cantidad != null)
                Cantidad = e.Cantidad;
            Validar();
        }
    }
}
