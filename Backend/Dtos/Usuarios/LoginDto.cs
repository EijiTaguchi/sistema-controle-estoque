using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Usuarios;

public record LoginDto
(
 [Required(ErrorMessage = "O e-mail é obrigatório.")]
[EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
string Email,

 [Required(ErrorMessage = "A senha é obrigatória.")]
string Password
);
