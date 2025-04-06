namespace MonitoramentoPaciente.Domain.Entitys;

public class Dieta : Base
{
    public string Descricao { get; set; } = string.Empty;
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }

    public Guid PacienteId { get; set; }
    public Paciente Paciente { get; set; } = null!;
}
