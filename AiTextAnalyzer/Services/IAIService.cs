using AiTextAnalyzer.Models;

namespace AiTextAnalyzer.Services;

public interface IAIService
{
    Task<TextResponse> AnalyzeTextAsync(string texto);
}
