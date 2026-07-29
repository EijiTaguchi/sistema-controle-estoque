using backend_sistema_controle_estoque.Dtos.Usuarios;

namespace backend_sistema_controle_estoque.Services.Interfaces;

public interface IAuthService
{
    Task<UsuarioDto> RegistrarUsuarioAsync(RegistrarUsuarioDto dto);

    Task<LoginResponseDto> LoginUsuarioAsync(LoginDto dto);
}