namespace Obligatorio.LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoListadoDTO(
         int Id,
         int socioId,
         string SocioNombre,
         string TelescopioMarca,
         string MonturaMarca,
         string CamaraMarca,
         string OcularMarca,
         DateTime FchInicio,
         DateTime FchFin,
         string Estado,
         bool PuedeDevolver,
         int CoordId,
         string CoordNombre
        );

}
