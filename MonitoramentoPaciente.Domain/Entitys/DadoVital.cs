namespace MonitoramentoPaciente.Domain.Entitys;

public class DadoVital : Base
{
    public float Peso { get; set; }
    public float IMC { get; set; }
    public int NivelAtividade { get; set; } // Pode ser um enum depois

    public Guid PacienteId { get; set; }
    public Paciente Paciente { get; set; } = null!;
}
