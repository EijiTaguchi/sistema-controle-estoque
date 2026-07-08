

namespace backend_sistema_controle_estoque.Models;

public enum TipoMovimentacao
{
    Entrada = 1,
    Saida = 2,
}

public class MovimentacaoEstoque
{
    public int Id { get; private set; }
    public int ProdutoId { get; private set; }
    public string UsuarioId { get; private set; }
    public TipoMovimentacao TipoMovimentacao { get; private set; }
    public int Quantidade { get; private set; }
    public DateTime DataHora { get; private set; } = DateTime.UtcNow;

    public Produto Produto { get; private set; }
    public Usuario Usuario { get; private set; }


    private MovimentacaoEstoque()
    {

    }

    public MovimentacaoEstoque(TipoMovimentacao tipo, int quantidade, int produtoId, string usuarioId)
    {

        if (produtoId <= 0)
            throw new ArgumentException("O produto deve conter um id");

        if (string.IsNullOrWhiteSpace(usuarioId))
            throw new ArgumentException("O usuario deve conter um id");

        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException("quantidade não pode ser menor ou zero");

        Quantidade = quantidade;
        ProdutoId = produtoId;
        UsuarioId = usuarioId;
        TipoMovimentacao = tipo;
    }


}
