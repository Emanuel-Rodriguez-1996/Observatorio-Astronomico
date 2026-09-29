namespace Obligatorio.LogicaAplicacion.Dtos.Observacion
{
    public record AltaObservacionDTO(
     int Id,
     int PrestamoId,
     int ObjCelesteId,
     DateTime FechaObservacion
    );

}