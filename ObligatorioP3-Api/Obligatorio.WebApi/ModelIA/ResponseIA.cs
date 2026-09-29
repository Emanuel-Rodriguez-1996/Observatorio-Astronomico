using System.Text.Json;

namespace Obligatorio.WebApi.ModelIA
{
    public class ResponseIA
    {
        public static T Parsear<T>(string json)
        {
            using var doc = JsonDocument.Parse(json);

            if (!doc.RootElement.TryGetProperty("candidates", out var candidates))
                throw new Exception("Gemini no devolvió candidates: " + json);

            var text = candidates[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Gemini devolvió texto vacío");

            text = text.Replace("```json", "")
                       .Replace("```", "")
                       .Trim();

            return JsonSerializer.Deserialize<T>(
                text,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }
    }
}
