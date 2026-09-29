namespace Obligatorio.LogicaAplicacion.Dtos.Prestamo
{
    public record AltaPrestamoDTO
    (
         int Id,
         int SocioId,
         int TelescopioId,
         int MonturaId,
         int? CamaraId,
         int? OcularId,
         DateTime FchInicio,
         DateTime FchFin,
         string Estado,
         int Coord
    );
}