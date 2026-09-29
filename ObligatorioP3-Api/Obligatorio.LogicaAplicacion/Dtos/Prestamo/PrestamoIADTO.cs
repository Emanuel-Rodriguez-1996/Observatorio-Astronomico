namespace Obligatorio.LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoIADTO(
    decimal AperturaMm,
    decimal DistanciaFocalMm,
    decimal RelacionFocal,

    string? Sensor,
    decimal? ResolucionPx,
    decimal? PixelSizeUm,

    decimal? CampoAparenteGrados,
    decimal? OcularFocalMm
);
}
