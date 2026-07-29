namespace backend_sistema_controle_estoque.Dtos.Usuarios;

public record LoginResponseDto
(
    string Id,
    string UserName,
    string Email,
    string Token,
    string Message
);
