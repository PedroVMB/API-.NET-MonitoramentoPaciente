namespace MonitoramentoPaciente.Domain.Entitys;

public class Consulta : Base
{
    public DateTime DataConsulta { get; set; }
    public string Observacoes { get; set; } = string.Empty;

    public Guid PacienteId { get; set; }
    public Paciente Paciente { get; set; } = null!;
}
