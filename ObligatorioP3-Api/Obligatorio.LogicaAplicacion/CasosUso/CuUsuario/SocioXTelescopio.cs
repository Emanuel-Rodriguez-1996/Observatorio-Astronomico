using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.CuUsuario
{
    public class SocioXTelescopio : ICUGetTById<SocioListadoDTO>
    {
        private IRepositorioPrestamo _repoPrestamo;

        public SocioXTelescopio(IRepositorioPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public IEnumerable<SocioListadoDTO> Ejecutar(int telescopioId)
        {
            var prestamos = _repoPrestamo.GetAll();
            var socios = prestamos
                .Where(p => p.Telescopio.Id == telescopioId)
                .Select(p => p.Socio)
                .GroupBy(s => s.Id)
                .Select(g => g.First())
                .OrderByDescending(s => s.Nombre.Value)
                .Select(s => new SocioListadoDTO(
                    s.Nombre.Value,
                    s.Email.Value,
                    s.Telefono.Value
                ))
                .ToList();

            return socios;
        }
    }
}
