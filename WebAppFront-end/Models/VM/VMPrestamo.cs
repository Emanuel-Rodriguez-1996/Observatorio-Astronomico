using System.ComponentModel.DataAnnotations;
using WebAppFront_end.Models.Dtos.Equipo;
using WebAppFront_end.Models.Dtos.Usuario;

namespace WebAppFront_end.Models.VM
{
    public record VMPrestamo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un socio.")]
        public int? Socio { get; set; }
        [Required(ErrorMessage = "Seleccione un telescopio")]
        public int? Telescopio { get; set; }
        [Required(ErrorMessage = "Seleccione una montura")]
        public int? Montura { get; set; }
        public int? Camara { get; set; }
        public int? Ocular { get; set; }
        [Required(ErrorMessage = "Seleccione una fecha válida")]
        public DateTime? FchInicio { get; set; }
        [Required(ErrorMessage = "Seleccione una fecha de entrega")]
        public DateTime? FchFin { get; set; }
        // public string Estado { get; set; }

        // LISTAS PARA LOS SELECTS
        public IEnumerable<AltaUsuarioDTO>? listUsuarios { get; set; } = new List<AltaUsuarioDTO>();
        public IEnumerable<AltaTelescopioDTO>? listTelescopios { get; set; } = new List<AltaTelescopioDTO>();
        public IEnumerable<AltaMonturaDTO>? listMonturas { get; set; } = new List<AltaMonturaDTO>();
        public IEnumerable<AltaCamaraDTO>? listCamaras { get; set; } = new List<AltaCamaraDTO>();
        public IEnumerable<AltaOcularDTO>? listOculares { get; set; } = new List<AltaOcularDTO>();

    }
}
