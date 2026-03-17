using AiTextAnalyzer.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AiTextAnalyzer.Services
{
    public class HuggingFaceService : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public HuggingFaceService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<TextResponse> AnalyzeTextAsync(string texto)
        {
            var apiKey = _config["HuggingFace:ApiKey"];

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var prompt = Prompts.AnalyzeText(texto);

            var body = new
            {
                model = "openai/gpt-oss-120b:fastest",
                messages = new[]
            {
                new
                {
                    role = "user",
                    content = prompt
                }
            },
                stream = false
            };

            var content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://router.huggingface.co/v1/chat/completions",
                content
            );

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(result);

            var json = JsonDocument.Parse(result);

            var message = json.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            message = message
                .Replace("```json", "")
                .Replace("```", "")
                .Trim();

            var parsed = JsonSerializer.Deserialize<TextResponse>(message);

            return parsed ?? new TextResponse
            {
                Resumo = "Erro ao usar IA",
                PalavrasChave = new List<string>()
            };
        }
    }
}
