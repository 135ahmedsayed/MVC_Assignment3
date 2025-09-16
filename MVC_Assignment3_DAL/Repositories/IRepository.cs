namespace MVC_Assignment3_DAL.Repositories;
public interface IRepository<TEntity> 
    where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAll(bool trackChanges = false);
    TEntity? GetById(int id);
    //TEntity? GetByName(string name);
    int Add(TEntity Entity);
    int Update(TEntity Entity);
    int Delete(TEntity Entity);
}
