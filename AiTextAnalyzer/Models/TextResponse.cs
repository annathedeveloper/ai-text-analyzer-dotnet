using System.Text.Json.Serialization;

namespace AiTextAnalyzer.Models;

public class TextResponse
{
    [JsonPropertyName("resumo")]
    public string Resumo { get; set; }
    [JsonPropertyName("palavrasChave")]
    public List<string> PalavrasChave { get; set; }
}
