using System.ComponentModel.DataAnnotations;

namespace WebAppFront_end.Models.VM.Equipo
{
    public record VMOcular
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La Marca es obligatoria.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El Modelo es obligatorio.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "La Cantidad es obligatoria.")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "El Ángulo es obligatorio.")]
        public decimal? Angulo { get; set; }
        [Required(ErrorMessage = "El Diámetro es obligatorio.")]
        public decimal? Diametro { get; set; }
    }
}
