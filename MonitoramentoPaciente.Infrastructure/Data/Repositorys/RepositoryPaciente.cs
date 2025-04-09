using MonitoramentoPaciente.Domain.Core.Interfaces.Repositorys;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Infrastructure.Data.Repositorys;

public class RepositoryPaciente : RepositoryBase<Paciente>, IRepositoryPaciente
{
    private readonly ApplicationDbContext _context;

    public RepositoryPaciente(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}