using MonitoramentoPaciente.Application.Dtos;

namespace MonitoramentoPaciente.Application;

public interface IApplicationServicePaciente
{
    void Add(PacienteDto pacienteDto);
    void Update(PacienteDto pacienteDto);
    void Delete(PacienteDto pacienteDto);
    IEnumerable<PacienteDto> GetAll();
    PacienteDto? GetById(Guid id);
}