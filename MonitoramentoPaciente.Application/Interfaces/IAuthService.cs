using MonitoramentoPaciente.Application.Dtos;

namespace MonitoramentoPaciente.Application.Interfaces;

public interface IAuthService
{
    Task<ResponseDto> RegisterProfissionalSaudeAsync(RegisterDto model);
    Task<ResponseDto> RegisterPacienteAsync(RegisterDto model);
    Task<ResponseDto> RegisterAdminAsync(RegisterDto model);
    Task<string?> LoginAsync(LoginDTO dto);
}