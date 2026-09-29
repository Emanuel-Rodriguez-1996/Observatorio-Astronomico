using WebAppFront_end.Models.Dtos.Equipo;
using WebAppFront_end.Models.Dtos.Observacion;
using WebAppFront_end.Models.Dtos.Prestamo;
using WebAppFront_end.Models.Dtos.Usuario;

namespace WebAppFront_end.Models.VM
{
    public record VMIndex
    {
        public IEnumerable<AltaUsuarioDTO>? Usuarios { get; set; } = new List<AltaUsuarioDTO>();
        public IEnumerable<AltaTelescopioDTO>? Telescopios { get; set; } = new List<AltaTelescopioDTO>();
        public IEnumerable<AltaCamaraDTO>? Camaras { get; set; } = new List<AltaCamaraDTO>();
        public IEnumerable<AltaOcularDTO>? Oculares { get; set; } = new List<AltaOcularDTO>();
        public IEnumerable<AltaMonturaDTO>? Monturas { get; set; } = new List<AltaMonturaDTO>();
        public IEnumerable<PrestamoListadoDTO>? Prestamos { get; set; } = new List<PrestamoListadoDTO>();
        public IEnumerable<RankinObjCelesteDTO>? RankingObjCelestes { get; set; } = new List<RankinObjCelesteDTO>();

    }
}
