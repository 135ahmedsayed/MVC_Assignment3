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

    public virtual void Add(TEntity entity)
    {
        _dBContext.Add(entity);
        //return dBContext.SaveChanges();
        //try
        //{
        //    return dBContext.SaveChanges();
        //}
        //catch (Exception ex)
        //{
        //    // هنا هنطبع الرسالة الأساسية
        //    Console.WriteLine(ex.Message);
        //}
        //return dBContext.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        _dBContext.Remove(entity);
        //return dBContext.SaveChanges();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
    {
        return trackChanges ? await _dBContext.ToListAsync()
            : await _dBContext.AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dBContext.FindAsync(id);
    }

    //public TEntity? GetByName(string name)
    //{
    //    return _dBContext.FirstOrDefault(n => n.Name == name);
    //}

    public virtual void Update(TEntity entity)
    {
        _dBContext.Update(entity);
        //return dBContext.SaveChanges();
    }
    #endregion
}
