namespace Obligatorio.LogicaAplicacion.Dtos.Prestamo
{
    public record AuditoriaPrestamoDTO(
        int Id,
        int PrestamoId,
        DateTime FechaPrestamo,
        int CoordinadorId,
        string CoordinadorNombre,
        string Accion
    );
}
