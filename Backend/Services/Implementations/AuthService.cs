using backend_sistema_controle_estoque.Dtos.Usuarios;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace backend_sistema_controle_estoque.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthService( UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> LoginUsuarioAsync(LoginDto dto)
    {
        var usuario = await _userManager.FindByEmailAsync(dto.Email);

        if (usuario is null)
            throw new Exception("email ou senha inválidos.");

        var resultadoLogin = await _signInManager.CheckPasswordSignInAsync(usuario, dto.Password, false);

        if (!resultadoLogin.Succeeded)
            throw new Exception("email ou senha inválidos.");

        var token = _tokenService.GerarToken(usuario);

        return new LoginResponseDto(
            usuario.Id,
            usuario.UserName!,
            usuario.Email!,
            token,
            "Login realizado com sucesso."
            );

    }

    public async Task<UsuarioDto> RegistrarUsuarioAsync(RegistrarUsuarioDto dto)
    {
        var usuarioExistente = await _userManager.FindByNameAsync(dto.UserName);

        if (usuarioExistente is not null)
        {
            throw new InvalidOperationException("Nome de usuário já está em uso.");
        }

        var userEmailExistente = await _userManager.FindByEmailAsync(dto.Email);
        if (userEmailExistente is not null)
            throw new InvalidOperationException("Email já está em uso.");

        var usuario = new Usuario
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(usuario, dto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);  

            throw new Exception($"Falha ao registrar usuário: {string.Join(", ", errors)}");

        }

        return new UsuarioDto(
            usuario.Id,
            usuario.UserName!,
            usuario.Email!
         );

    }
}
