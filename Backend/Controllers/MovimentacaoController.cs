using backend_sistema_controle_estoque.Dtos.Movimentacao;
using backend_sistema_controle_estoque.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_sistema_controle_estoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentacaoController : ControllerBase
{
   private readonly IMovimentacaoService _movimentacaoService;

    public MovimentacaoController(IMovimentacaoService movimentacao)
    {
        _movimentacaoService = movimentacao;
    }

    [HttpGet]
    public async Task<IActionResult> MostrarMovimentacao()
    {

        var movimentacao = await _movimentacaoService.ObterTodasMovimentacoesAsync();

        return Ok(movimentacao);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> MostrarMovimentacaoId(int id)
    {
        var movimentacao = await _movimentacaoService.ObterMovimentacaoPorIdAsync(id);

        return Ok(movimentacao);
    }

    [HttpPost]
    public async Task<IActionResult> CriarMovimentacao([FromBody] CriarMovimentacaoDto movimentacao)
    {

        var novaMovimentacao = await _movimentacaoService.AdicionarMovimentacaoAsync(movimentacao);
        return CreatedAtAction(nameof(MostrarMovimentacaoId), new { id = novaMovimentacao.Id }, novaMovimentacao);
    }

}
