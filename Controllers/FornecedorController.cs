using backend_sistema_controle_estoque.Dtos.Fornecedores;
using backend_sistema_controle_estoque.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_sistema_controle_estoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly IFornecedorService _fornecedorService;

    public FornecedorController(IFornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> MostrarFornecedorId(int id)
    {
        var fornecedor = await _fornecedorService.ObterFornecedorPorIdAsync(id);
        if (fornecedor == null)
        {
            return NotFound();
        }
        return Ok(fornecedor);
    }

    [HttpGet]
    public async Task<IActionResult> MostrarTodosFornecedores()
    {
        var fornecedores = await _fornecedorService.ListarFornecedoresAsync();
        return Ok(fornecedores);
    }

    [HttpPost]
    public async Task<IActionResult> CriarFornecedor([FromBody] CriarFornecedorDto fornecedor)
    {
        if (fornecedor == null)
        {
            return BadRequest();
        }

        var novoFornecedor = await _fornecedorService.CriarFornecedorAsync(fornecedor);
        return CreatedAtAction(nameof(MostrarFornecedorId), new { cnpj = novoFornecedor.Cnpj }, novoFornecedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarFornecedor(int id, [FromBody] AtualizarFornecedorDto fornecedor)
    {
        if (fornecedor == null || id != fornecedor.id)
        {
            return BadRequest();
        }

        var fornecedorAtualizado = await _fornecedorService.AtualizarFornecedorAsync(fornecedor);
        return Ok(fornecedorAtualizado);

    }

    [HttpPatch("{id}/desativar")]
    public async Task<IActionResult> DesativarFornecedor(int id)
    {
        var fornecedorDesativado = await _fornecedorService.DesativarFornecedorAsync(id);
        if (fornecedorDesativado == null)
        {
            return NotFound();
        }
        return Ok(fornecedorDesativado);
    }
}