namespace MonitoramentoPaciente.Domain.Entitys;

public class Notificacao : Base
{
    public string Mensagem { get; set; } = string.Empty;
    public DateTime DataEnvio { get; set; }
    public bool Lida { get; set; }

    public Guid PacienteId { get; set; }
    public Paciente Paciente { get; set; } = null!;
}