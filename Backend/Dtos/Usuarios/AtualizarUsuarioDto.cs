using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Usuarios;

public record AtualizarUsuarioDto
(
    string Id,
    [Required(ErrorMessage = "O campo 'UserName' é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo 'UserName' deve ter no máximo 50 caracteres.")]
    string UserName,
    [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um endereço de email válido.")]
    string Email
);

