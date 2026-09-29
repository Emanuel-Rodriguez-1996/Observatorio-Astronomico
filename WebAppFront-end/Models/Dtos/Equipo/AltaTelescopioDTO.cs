namespace WebAppFront_end.Models.Dtos.Equipo
{
    public record AltaTelescopioDTO(
    int Id,
    string Marca,
    string Modelo,
    int Cantidad,
    decimal Apertura,
    decimal RelacionFocal,
    decimal DistanciaFocal,
    decimal Peso
);
}
