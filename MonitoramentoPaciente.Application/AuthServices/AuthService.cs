using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MonitoramentoPaciente.Application.Auth;
using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Application.Interfaces;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.AuthServices;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;
    private TokenService _tokenService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config,
        TokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
        _tokenService = tokenService;
    }

    public async Task<ResponseDto> RegisterAdminAsync(RegisterDto model)
    {
        return await RegisterUserAsync(model, UserRoles.Admin);
    }

    public async Task<ResponseDto> RegisterProfissionalSaudeAsync(RegisterDto model)
    {
        return await RegisterUserAsync(model, UserRoles.Profissional);
    }

    public async Task<ResponseDto> RegisterPacienteAsync(RegisterDto model)
    {
        return await RegisterUserAsync(model, UserRoles.Paciente);
    }

    private async Task<ResponseDto> RegisterUserAsync(RegisterDto model, string role)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username!);
        if (userExists != null)
            return new ResponseDto(false, "Usuário já existe!");

        var user = new ApplicationUser
        {
            UserName = model.Username,
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, model.Password!);
        if (!result.Succeeded)
            return new ResponseDto(false, $"Erro ao criar usuário: {string.Join(", ", result.Errors.Select(e => e.Description))}");

        // Cria o papel se não existir
        if (!await _roleManager.RoleExistsAsync(role))
            await _roleManager.CreateAsync(new IdentityRole(role));

        // Atribui o papel
        await _userManager.AddToRoleAsync(user, role);

        return new ResponseDto(true, $"Usuário {role} criado com sucesso!");
    }

    public async Task<string?> LoginAsync(LoginDTO dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            return null;

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var token = _tokenService.GetToken(authClaims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
