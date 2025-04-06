namespace MonitoramentoPaciente.Domain.Entitys;

public class Paciente : Base
{
    public string Genero { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string HistoricoSaude { get; set; } = string.Empty;
    public string Metas { get; set; } = string.Empty;

    // Chave para o ApplicationUser (FK)
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; } = null!;

    public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    public ICollection<DadoVital> DadosVitais { get; set; } = new List<DadoVital>();
    public ICollection<Dieta> Dietas { get; set; } = new List<Dieta>();
    public ICollection<Exercicio> Exercicios { get; set; } = new List<Exercicio>();
    public ICollection<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
}
