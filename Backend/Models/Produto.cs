using Microsoft.AspNetCore.Http.HttpResults;

namespace backend_sistema_controle_estoque.Models;

public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Sku { get; private set; }
    public decimal Preco { get; private set; }
    public int QuantidadeEmEstoque { get; private set; } = 0;
    public bool Ativo { get; private set; } = true;
    public ICollection<MovimentacaoEstoque> Movimentacoes { get; private set; } = new List<MovimentacaoEstoque>();

    public int FornecedorId {  get; private set; }
    public Fornecedor Fornecedor { get; private set; } = null!;

    private Produto() {

    }

    public Produto(string nome, string sku, decimal preco, int fornecedorId)
    {
        ValidarProduto(nome, sku, preco, fornecedorId);

        Nome = nome.Trim();
        Sku = sku.Trim();
        Preco = preco;
        FornecedorId = fornecedorId;
    }

    private void ValidarProduto(string nome, string sku, decimal preco, int fornecedorId)
    {

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("O codigo sku não pode ser vazio.");
            if (preco <= 0)
                throw new ArgumentException("O preço não pode ser 0");
            if (fornecedorId <= 0)
                throw new ArgumentException("O Fornecedor deve ser declarado");

    }

    public void Atualizar(string novoNome, decimal novoPreco, int novoFornecedor)
    {

        ValidarProduto(novoNome, Sku, novoPreco, novoFornecedor);

        Nome = novoNome.Trim();
        Preco= novoPreco;
        FornecedorId= novoFornecedor;

    }

    public void Desativar()
    {
        if (!Ativo)
            throw new ArgumentException("O produto já foi desativado");

        Ativo = false;
    }

    public void EntradaEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        QuantidadeEmEstoque += quantidade;
    }

    public void SaidaEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        if (QuantidadeEmEstoque < quantidade)
            throw new InvalidOperationException("Estoque insuficiente.");

        QuantidadeEmEstoque -= quantidade;
    }

}
