namespace WebAppFront_end.Models.Dtos.Prestamo
{
    public record PrestamoListadoDTO(

         int Id,
         int SocioId,
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
