using Microsoft.AspNetCore.Identity;

namespace backend_sistema_controle_estoque.Models;

public class Usuario : IdentityUser
{
    public string Nome { get; private set; }

    public Usuario()
    {
        
    }

}
