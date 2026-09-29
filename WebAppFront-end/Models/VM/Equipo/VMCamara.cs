using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppFront_end.Models.VM.Equipo
{
    public record VMCamara
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La Marca es obligatoria.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El Modelo es obligatorio.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "La Cantidad es obligatoria.")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "El Pixel es obligatorio.")]
        public decimal? Pixel { get; set; }
        [Required(ErrorMessage = "La Resolucion es obligatoria.")]
        public decimal? Resolucion { get; set; }
        [DisplayName("Seleccione el tipo de sensor")]
        public string TipoSensor { get; set; }

    }
}
