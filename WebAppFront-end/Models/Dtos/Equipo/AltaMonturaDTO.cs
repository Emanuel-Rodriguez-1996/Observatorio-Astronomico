namespace WebAppFront_end.Models.Dtos.Equipo
{
    public record AltaMonturaDTO(
         int Id,
         string Marca,
         string Modelo,
         int Cantidad,
         string TipoMontura,
         decimal CargaSoportada,
         bool EsComputarizado
    );

}
