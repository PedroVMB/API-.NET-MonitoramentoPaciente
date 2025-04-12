using MonitoramentoPaciente.Application.Dtos;

namespace MonitoramentoPaciente.Application.Interfaces;

public interface IApplicationServiceProfissionalSaude
{
    void Add(ProfissionalSaudeDto profissionalSaudeDto);
    void Update(ProfissionalSaudeDto profissionalSaudeDto);
    void Delete(ProfissionalSaudeDto profissionalSaudeDto);
    IEnumerable<ProfissionalSaudeDto> GetAll();
    ProfissionalSaudeDto? GetById(Guid id);
}