namespace MVC_Assignment3_DAL.Repositories;
public interface IRepository<TEntity> 
    where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
    Task<TEntity?> GetByIdAsync(int id);
    //TEntity? GetByName(string name);
    void Add(TEntity Entity);
    void Update(TEntity Entity);
    void Delete(TEntity Entity);
}
