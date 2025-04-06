using MonitoramentoPaciente.Domain.Entitys;
using Microsoft.AspNetCore.Identity;

namespace MonitoramentoPaciente.Domain.Entitys;
public class ApplicationUser : IdentityUser
{
    public virtual Paciente? Paciente { get; set; }
    public virtual ProfissionalSaude? ProfissionalDeSaude { get; set; }
}
