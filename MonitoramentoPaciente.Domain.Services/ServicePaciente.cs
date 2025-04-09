using MonitoramentoPaciente.Domain.Core.Interfaces.Repositorys;
using MonitoramentoPaciente.Domain.Core.Interfaces.Services;
using MonitoramentoPaciente.Domain.Entitys;

namespace MonitoramentoPaciente.Domain.Services;

public class ServicePaciente : ServiceBase<Paciente>, IServicePaciente
{
    private readonly IRepositoryPaciente _repositoryPaciente;

    public ServicePaciente(IRepositoryPaciente repositoryPaciente) : base(repositoryPaciente)
    {
        this._repositoryPaciente = repositoryPaciente;
    }
}