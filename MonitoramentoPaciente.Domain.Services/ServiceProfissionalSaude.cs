using MonitoramentoPaciente.Domain.Core.Interfaces.Repositorys;
using MonitoramentoPaciente.Domain.Core.Interfaces.Services;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Domain.Services;

public class ServiceProfissionalSaude : ServiceBase<ProfissionalSaude>, IServiceProfissionalSaude
{
    private readonly IRepositoryProfissionalSaude _repositoryProfissionalSaude;

    public ServiceProfissionalSaude(IRepositoryProfissionalSaude repositoryProfissionalSaude) : base(repositoryProfissionalSaude)
    {
        this._repositoryProfissionalSaude = repositoryProfissionalSaude;
    }
}