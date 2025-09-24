using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVC_Assignment3_DAL.Context;

namespace MVC_Assignment3_DAL.Repositories;
public class EmployeeRepository(CompanyDBContext dbContext)
    : BaseRepository<Employee>(dbContext),IEmployeeRepository
{
    //#region Dependency Injection
    ////Context Encapsulation
    //private CompanyDBContext _dBContext = dbContext;
    ////Generate CTOR
    ////public DepartmentRepository(CompanyDBContext dBContext)
    ////{
    ////    _dBContext = dBContext;
    ////}

    //public int Add(Employee employee)
    //{
    //    _dBContext.Employees.Add(employee);
    //    return _dBContext.SaveChanges();
    //}

    //public int Delete(Employee employee)
    //{
    //    _dBContext.Employees.Remove(employee);
    //    return _dBContext.SaveChanges();
    //}

    //public IEnumerable<Employee> GetAll(bool trackChanges = false)
    //{
    //    return trackChanges ? _dBContext.Employees.ToList()
    //        : _dBContext.Employees.AsNoTracking().ToList();
    //}


    //public Employee? GetById(int id)
    //{
    //    return _dBContext.Employees.Find(id);
    //}

    //public Employee? GetByName(string name)
    //{
    //    return _dBContext.Employees.FirstOrDefault(n => n.Name == name);
    //}

    //public int Update(Employee employee)
    //{
    //    _dBContext.Employees.Update(employee);
    //    return _dBContext.SaveChanges();
    //}
    //#endregion
    public IEnumerable<Employee> GetAll(string name)
    {
       return _dBContext.Where(e => e.Name.Contains(name)).ToList();
    }

    public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> Selector)
    {
        return _dBContext.Where(e => !e.IsDeleted).Select(Selector).ToList();
    }

    public override Employee? GetById(int id)
    {
        return _dBContext.Include(e => e.department)
            .FirstOrDefault(e => e.Id == id);
    }
}
