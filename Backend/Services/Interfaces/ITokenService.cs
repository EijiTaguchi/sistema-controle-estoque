using backend_sistema_controle_estoque.Models;

namespace backend_sistema_controle_estoque.Services.Interfaces;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}
