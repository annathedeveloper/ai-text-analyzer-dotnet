using AiTextAnalyzer.Models;
using OpenAI.Chat;
using System.Text.Json;

namespace AiTextAnalyzer.Services;

public class OpenAIService : IAIService
{
    private readonly ChatClient _chat;

    public OpenAIService(IConfiguration config)
    {
        var apiKey = config["OpenAI:ApiKey"];
        _chat = new ChatClient("gpt-4.1-mini", apiKey);
    }
    public async Task<TextResponse> AnalyzeTextAsync(string texto)
    {
        var prompt = Prompts.AnalyzeText(texto);

        var response = await _chat.CompleteChatAsync(prompt);
        var text = response.Value.Content[0].Text;
        var jsonText = text
               .Replace("```json", "")
               .Replace("```", "")
               .Trim();
        var parsed = JsonSerializer.Deserialize<TextResponse>(text);
        return parsed ?? new TextResponse 
        {
            Resumo = "Erro ao interpretar resposta",
            PalavrasChave = new List<string>()
        };
    }
}
