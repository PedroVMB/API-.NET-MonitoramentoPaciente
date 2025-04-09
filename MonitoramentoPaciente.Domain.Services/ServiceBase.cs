using MonitoramentoPaciente.Domain.Core.Interfaces.Repositorys;
using MonitoramentoPaciente.Domain.Core.Interfaces.Services;

namespace MonitoramentoPaciente.Domain.Services;

public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
{
    private readonly IRepositoryBase<TEntity> repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        this.repository = repository;
    }
    
    public void Add(TEntity entity)
    {
        repository.Add(entity);
    }

    public void Update(TEntity entity)
    {
        repository.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        repository.Delete(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return repository.GetAll();
    }

    public TEntity GetById(Guid id)
    {
        return repository.GetById(id);
    }
}