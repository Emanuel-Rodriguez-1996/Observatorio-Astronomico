using Obligatorio.LogicaAplicacion.Dtos;
using Obligatorio.WebApi.ModelIA;
using Obligatorio.WebApi.ModelIA.DTO;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

public class GeminiService : IGeminiService
{
    private readonly HttpClient _client;
    private readonly string? _apiKey;

    public GeminiService(HttpClient client, IConfiguration configuration)
    {
        _client = client;

        // La API key NUNCA va escrita en el código ni en el repositorio.
        // Se lee de User Secrets (desarrollo) o de la variable de entorno Gemini__ApiKey (ver README).
        _apiKey = configuration["Gemini:ApiKey"];
    }

    public async Task<ResultadoIADTO> EvaluarAsync(AnalizarObservacion dto)
    {
        if (string.IsNullOrWhiteSpace(_apiKey))
            throw new InvalidOperationException(
                "Falta configurar la API key de Gemini (Gemini:ApiKey). Ver el README para configurarla.");

        var requestBody = RequestIA.CrearEvaluacion(dto);

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent"
        );

        // La clave viaja en un header (no en la URL) para que no quede en logs ni en mensajes de error.
        request.Headers.Add("x-goog-api-key", _apiKey);

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var stopwatch = Stopwatch.StartNew();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        HttpResponseMessage response;

        try
        {
            response = await _client.SendAsync(request, cts.Token);
        }
        catch (TaskCanceledException)
        {
            throw new Exception("Timeout llamando a Gemini");
        }

        var json = await response.Content.ReadAsStringAsync();

        stopwatch.Stop();

        Console.WriteLine($"Gemini time: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine(json);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Gemini error: {json}");

        if (string.IsNullOrWhiteSpace(json))
            throw new Exception("Respuesta vacía de Gemini");

        return ResponseIA.Parsear<ResultadoIADTO>(json);
    }
}