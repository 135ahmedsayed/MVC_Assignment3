namespace MVC_Assignment3_DAL.Repositories;
public interface IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    IDepartmentRepository Departments { get; }
    int SaveChanges();

}
