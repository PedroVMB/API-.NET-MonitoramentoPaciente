using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.Dtos;

public class PacienteDto
{
    public Guid? Id { get; set; }
    public ApplicationUser Usuario { get; set; }
    
    public ICollection<Consulta>? Consultas { get; set; }
    public ICollection<DadoVital>? DadosVitais { get; set; }
    public ICollection<Dieta>? Dietas { get; set; }
    public ICollection<Exercicio>? Exercicios { get; set; }
    public ICollection<Notificacao>? Notificacoes { get; set; }
}