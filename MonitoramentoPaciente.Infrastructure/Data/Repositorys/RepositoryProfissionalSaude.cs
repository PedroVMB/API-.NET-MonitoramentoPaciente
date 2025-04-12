using MonitoramentoPaciente.Domain.Core.Interfaces.Repositorys;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Infrastructure.Data.Repositorys;

public class RepositoryProfissionalSaude : RepositoryBase<ProfissionalSaude>, IRepositoryProfissionalSaude
{
    private readonly ApplicationDbContext _context;
    
    public RepositoryProfissionalSaude(ApplicationDbContext context) : base(context)
    {
        this._context = context;
    }
}