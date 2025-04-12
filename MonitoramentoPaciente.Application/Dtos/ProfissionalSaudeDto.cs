using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.Dtos;

public class ProfissionalSaudeDto : PessoaDto
{
    public Guid? Id { get; set; }
    
    public ApplicationUser Usuario { get; set; }
    
    public string Especialidade { get; set; }
}