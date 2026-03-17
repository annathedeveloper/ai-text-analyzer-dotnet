namespace AiTextAnalyzer.Models
{
    public static class Prompts
    {
        public static string AnalyzeText(string texto) =>
                """
                Analise o texto abaixo e crie um resumo e palavras-chave.

                Retorne SOMENTE um JSON no formato:

                {
                  "resumo": "string",
                  "palavrasChave": ["string","string","string"]
                }

                Texto:
                """ + texto;
    }
}
