# ObligatorioP3

API (.NET 10) + WebApp front-end del Observatorio.

## Configuración de la API key de Gemini

La evaluación con IA (`POST api/IA/evaluar`) usa la API de Google Gemini.
**La clave no está en el repositorio**: cada persona que corra el proyecto debe configurar la suya.

1. Generar una clave en [Google AI Studio](https://aistudio.google.com/apikey).
2. Guardarla en *User Secrets* (queda fuera del repo, en tu usuario de Windows):

```bash
cd ObligatorioP3-Api/Obligatorio.WebApi
dotnet user-secrets set "Gemini:ApiKey" "TU_CLAVE_AQUI"
```

   En Visual Studio también sirve: clic derecho sobre el proyecto `Obligatorio.WebApi` → **Manage User Secrets** y pegar:

```json
{
  "Gemini": { "ApiKey": "TU_CLAVE_AQUI" }
}
```

3. Alternativa (servidores / CI): variable de entorno `Gemini__ApiKey` (con doble guion bajo).

Si falta la clave, la API arranca igual pero muestra una advertencia en consola y
el endpoint de IA responde con un error indicando que falta configurarla.
