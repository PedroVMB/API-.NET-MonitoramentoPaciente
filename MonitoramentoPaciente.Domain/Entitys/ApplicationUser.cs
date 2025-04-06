using Microsoft.AspNetCore.Identity;

namespace MonitoramentoPaciente.Domain.Entitys;

public class ApplicationUser : IdentityUser
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;

    // Relacionamento opcional com paciente
    public Paciente? Paciente { get; set; }
}
