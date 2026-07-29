using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Usuarios;

public record RegistrarUsuarioDto
(
    [Required(ErrorMessage = "O campo 'UserName' é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo 'UserName' deve ter no máximo 50 caracteres.")]
    string UserName,

    [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um endereço de email válido.")]
    string Email,

    [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
    ErrorMessage = "O campo 'Password' deve conter pelo menos 8 caracteres além de uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    string Password
);