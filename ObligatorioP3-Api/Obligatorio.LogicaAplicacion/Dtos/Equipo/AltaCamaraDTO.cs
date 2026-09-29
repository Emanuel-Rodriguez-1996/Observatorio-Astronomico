namespace Obligatorio.LogicaAplicacion.Dtos.Equipo
{
    public record AltaCamaraDTO(
                                int Id,
                                string Marca,
                                string Modelo,
                                int Cantidad,
                                decimal Pixel,
                                decimal Resolucion,
                                string TipoSensor
    );

}
