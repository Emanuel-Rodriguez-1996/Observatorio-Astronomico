using System.ComponentModel.DataAnnotations;

namespace WebAppFront_end.Models.VM
{
    public class VMObservacion
    {
        public int Id { get; set; }

        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Seleccione un Objeto Celeste.")]
        public int? ObjCelesteId { get; set; }

        [Required(ErrorMessage = "Seleccione una fecha valida.")]
        public DateTime? FechaObservacion { get; set; }
    }
}
