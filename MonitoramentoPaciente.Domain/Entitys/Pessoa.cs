namespace MonitoramentoPaciente.Domain.Entitys;

public abstract class Pessoa : Base
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public int? Idade { get; set; } 
    public double? Altura { get; set; }
}