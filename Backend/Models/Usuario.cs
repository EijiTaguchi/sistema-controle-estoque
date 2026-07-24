using Microsoft.AspNetCore.Identity;

namespace backend_sistema_controle_estoque.Models;

public class Usuario : IdentityUser
{

    public ICollection<MovimentacaoEstoque> Movimentacoes { get; private set; } = new List<MovimentacaoEstoque>();

    public Usuario()
    {
        
    }

}
