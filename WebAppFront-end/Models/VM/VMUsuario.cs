using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppFront_end.Models.VM
{
    public record VMUsuario
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La direccion es obligatorio.")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio.")]
        public int? Telefono { get; set; }
        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Nombre de usuario es obligatorio.")]
        [DisplayName("Nombre de usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "La contraseña debe tener minimo 8 caracteres, mayúscula, minúscula, número y símbolo.")]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}