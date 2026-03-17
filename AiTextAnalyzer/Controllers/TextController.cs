using AiTextAnalyzer.Models;
using AiTextAnalyzer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiTextAnalyzer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TextController : ControllerBase
{
    private readonly IAIService _service;

    public TextController(IAIService service)
    {
        _service = service;
    }
    [HttpPost("analisar")]
    public async Task<IActionResult> Analisar(TextRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Texto))
            return BadRequest("O texto não pode ser vazio.");

        var resultado = await _service.AnalyzeTextAsync(request.Texto);
        return Ok(resultado);
    }
}
