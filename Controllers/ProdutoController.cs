using backend_sistema_controle_estoque.Dtos.Produtos;
using backend_sistema_controle_estoque.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_sistema_controle_estoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
   private readonly IProdutoService _produtoService;

   public ProdutoController(IProdutoService produtoService)
   {
       _produtoService = produtoService;
   }

    [HttpGet]
    public async Task<IActionResult> ListarProdutos()
    {
        var produtos = await _produtoService.ListarProdutoAsync();

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterProdutoPorId(int id)
    {
        var produto = await _produtoService.ObterProdutoPorIdAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoDto produto)
    {
        if (produto == null)
        {
            return BadRequest();
        }
        var novoProduto = await _produtoService.CriarProdutoAsync(produto);
        return CreatedAtAction(nameof(ListarProdutos), new { Id = novoProduto.Id }, novoProduto);


    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] AtualizarProdutoDto produto)
    {
        if (produto == null || id != produto.id)
        {
            return BadRequest();
        }

        var produtoAtualizado = await _produtoService.AtualizarProdutoAsync(produto);
        return Ok(produtoAtualizado);
    }

    [HttpPatch("{id}/desativar")]
    public async Task<IActionResult> DesativarProduto(int id)
    {
        var produtoDesativado = await _produtoService.DesativarProdutoAsync(id);
        if (produtoDesativado == null)
        {
            return NotFound();
        }

        return Ok(produtoDesativado);
    }

}