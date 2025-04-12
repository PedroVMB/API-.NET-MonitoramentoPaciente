namespace MonitoramentoPaciente.Domain.Entitys;

public class ProfissionalSaude : Pessoa
{
    public string Nome { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;

    // Chave para o ApplicationUser (FK)
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; } = null!;
}