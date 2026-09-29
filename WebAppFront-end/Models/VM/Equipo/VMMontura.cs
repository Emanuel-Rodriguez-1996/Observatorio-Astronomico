using System.ComponentModel.DataAnnotations;

namespace WebAppFront_end.Models.VM.Equipo
{
    public record VMMontura
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "La Marca es obligatoria.")]
        public string Marca { get; init; }
        [Required(ErrorMessage = "El Modelo es obligatorio.")]
        public string Modelo { get; init; }
        [Required(ErrorMessage = "La Cantidad es obligatoria.")]
        public int? Cantidad { get; init; }
        public string TipoMontura { get; init; }
        [Required(ErrorMessage = "La Carga es obligatoria.")]
        public decimal? CargaSoportada { get; init; }
        [Required(ErrorMessage = "Marcar si es Computarizado.")]
        public bool EsComputarizado { get; init; }
    }
}
