using Microsoft.AspNetCore.Mvc;
using MonitoramentoPaciente.Application.Dtos;
using MonitoramentoPaciente.Application.Interfaces;

namespace MonitoramentoPaciente.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto model)
    {
        var response = await _authService.RegisterAdminAsync(model);
        if (response.Status == "Success")
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPost("register-profissional")]
    public async Task<IActionResult> RegisterProfissional([FromBody] RegisterDto model)
    {
        var response = await _authService.RegisterProfissionalSaudeAsync(model);
        if (response.Status == "Success")
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPost("register-paciente")]
    public async Task<IActionResult> RegisterPaciente([FromBody] RegisterDto model)
    {
        var response = await _authService.RegisterPacienteAsync(model);
        if (response.Status == "Success")
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var token = await _authService.LoginAsync(model);
        if (token == null)
            return Unauthorized(new { message = "Usuário ou senha inválidos" });

        return Ok(new
        {
            token,
            message = "Login realizado com sucesso"
        });
    }
}