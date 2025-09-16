namespace MVC_Assignment3_DAL.Repositories;
public interface IEmployeeRepository : IRepository<Employee>
{
    IEnumerable<Employee> GetAll(string name);
}
