namespace MonitoramentoPaciente.Domain.Entitys;

public class Exercicio : Base
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }

    public Guid PacienteId { get; set; }
    public Paciente Paciente { get; set; } = null!;
}