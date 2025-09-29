using System.Linq.Expressions;

namespace MVC_Assignment3_DAL.Repositories;
public interface IEmployeeRepository : IRepository<Employee>
{
    IEnumerable<Employee> GetAll(string name);

    //to retreve to services IEnumerable
    Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<Employee, TResult>> Selector
        , Expression<Func<Employee, bool>>? predicate = null);
}
