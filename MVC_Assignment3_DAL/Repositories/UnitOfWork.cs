using MVC_Assignment3_DAL.Context;

namespace MVC_Assignment3_DAL.Repositories;
public class UnitOfWork(CompanyDBContext dBContext ,
    IDepartmentRepository departmentRepository,
    IEmployeeRepository employeeRepository) 
    : IUnitOfWork
{
    public IEmployeeRepository Employees => employeeRepository;

    public IDepartmentRepository Departments => departmentRepository;

    public int SaveChanges() => dBContext.SaveChanges();
}
