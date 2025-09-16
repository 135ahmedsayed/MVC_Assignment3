using Microsoft.EntityFrameworkCore;
using MVC_Assignment3_DAL.Context;

namespace MVC_Assignment3_DAL.Repositories;

public class BaseRepository<TEntity>(CompanyDBContext dBContext) 
    : IRepository<TEntity>
    where TEntity : BaseEntity
{
    #region Dependency Injection
    //Context Encapsulation
    protected DbSet<TEntity> _dBContext = dBContext.Set<TEntity>();
    //Generate CTOR
    //public DepartmentRepository(CompanyDBContext dBContext)
    //{
    //    _dBContext = dBContext;
    //}

    public virtual int Add(TEntity entity)
    {
        _dBContext.Add(entity);
        return dBContext.SaveChanges();
    }

    public virtual int Delete(TEntity entity)
    {
        _dBContext.Remove(entity);
        return dBContext.SaveChanges();
    }

    public virtual IEnumerable<TEntity> GetAll(bool trackChanges = false)
    {
        return trackChanges ? _dBContext.ToList()
            : _dBContext.AsNoTracking().ToList();
    }

    public virtual TEntity? GetById(int id)
    {
        return _dBContext.Find(id);
    }

    //public TEntity? GetByName(string name)
    //{
    //    return _dBContext.FirstOrDefault(n => n.Name == name);
    //}

    public virtual int Update(TEntity entity)
    {
        _dBContext.Update(entity);
        return dBContext.SaveChanges();
    }
    #endregion
}
