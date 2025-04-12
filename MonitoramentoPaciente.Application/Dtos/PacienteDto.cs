using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Application.Dtos;

public class PacienteDto : PessoaDto
{
    public Guid? Id { get; set; }
    public ApplicationUser Usuario { get; set; }
    
    public string Genero { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string HistoricoSaude { get; set; } = string.Empty;
    public string Metas { get; set; } = string.Empty;
    
    public ICollection<Consulta>? Consultas { get; set; }
    public ICollection<DadoVital>? DadosVitais { get; set; }
    public ICollection<Dieta>? Dietas { get; set; }
    public ICollection<Exercicio>? Exercicios { get; set; }
    public ICollection<Notificacao>? Notificacoes { get; set; }
}