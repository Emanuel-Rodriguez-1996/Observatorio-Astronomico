using System.ComponentModel.DataAnnotations;

namespace WebAppFront_end.Models.VM.Equipo
{
    public record VMTelescopio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La Marca es obligatoria.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El Modelo es obligatorio.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "La Cantidad es obligatoria.")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "La Apertura es obligatoria.")]
        public decimal? Apertura { get; set; }
        [Required(ErrorMessage = "La Relacion Focal es obligatoria.")]
        public decimal? RelacionFocal { get; set; }
        [Required(ErrorMessage = "La Distancia Focal es obligatoria.")]
        public decimal? DistanciaFocal { get; set; }
        [Required(ErrorMessage = "El Peso es obligatorio.")]
        public decimal? Peso { get; set; }
    }
}
