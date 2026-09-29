using System.Text.Json;
using Obligatorio.LogicaAplicacion.Dtos;

namespace Obligatorio.WebApi.ModelIA
{
    public class RequestIA
    {
        public static object CrearEvaluacion(AnalizarObservacion dto)
        {
            var datos = new
            {
                telescopio = new
                {
                    apertura_mm = dto.Telescopio.Apertura,
                    focal_mm = dto.Telescopio.DistanciaFocal,
                    relacion_focal = dto.Telescopio.RelacionFocal
                },

                objeto_celeste = new
                {
                    nombre = dto.Objeto.Nombre,
                    tipo = dto.Objeto.Tipo
                },

                camara = dto.Camara != null ? new
                {
                    sensor = dto.Camara.TipoSensor,
                    resolucion_px = dto.Camara.Resolucion,
                    pixel_size_um = dto.Camara.Pixel
                } : null,

                ocular = dto.Ocular != null ? new
                {
                    ocular_focal_mm = dto.Ocular.OcularFocalMm,
                    campo_aparente_grados = dto.Ocular.CampoAparenteGrados
                } : null
            };

            var jsonCompacto = JsonSerializer.Serialize(
                datos,
                new JsonSerializerOptions
                {
                    WriteIndented = false
                }
            );

            var prompt = $@"
                Responde SOLO JSON:
                {{
                  ""IndicadorIA"": ""IDEAL|ADECUADO|NO RECOMENDABLE"",
                  ""DetalleIA"": ""max 300 caracteres""
                }}
                Datos:
                {jsonCompacto}
                ";
            return new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };
        }
    }
}