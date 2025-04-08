using Microsoft.EntityFrameworkCore;
using MonitoramentoPaciente.Domain.Core.Interfaces.Repositorys;

namespace MonitoramentoPaciente.Infrastructure.Data.Repositorys;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context)
    {
        this._context = context;
    }
    
    public void Add(TEntity entity)
    {
        try
        {
           _context.Set<TEntity>().Add(entity);
           _context.SaveChanges();
        }
        catch (Exception e)
        {
           
            throw e;
        }
    }

    public void Update(TEntity entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity GetById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }
}