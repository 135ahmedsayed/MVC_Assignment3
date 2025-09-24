global using AutoMapper;
global using Microsoft.EntityFrameworkCore.Metadata;
global using MVC_Assignment3_BLL.DataTransferObjects.Departments;
global using MVC_Assignment3_BLL.DataTransferObjects.Employees;
global using MVC_Assignment3_DAL.Entities;
global using MVC_Assignment3_DAL.Repositories;

namespace MVC_Assignment3_BLL.Services;

public class EmployeeService(IUnitOfWork unitofwork , IMapper mapper) : IEmployeeService
{
    #region Dependency Injection
    //Repo
    //private IDepartmentRepository _departmentRepository = departmentRepository;

    public int Add(EmployeeRequest request)
    {
        //mapping t==> Auto Mapper 
        //mapper.Map<Source,Destination>();
        var employee = mapper.Map<EmployeeRequest,Employee>(request);
        unitofwork.Employees.Add(employee);
        return unitofwork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var employee = unitofwork.Employees.GetById(id);
        if (employee == null)
            return false;
        unitofwork.Employees.Delete(employee);
        return unitofwork.SaveChanges() > 0;

    }

    public IEnumerable<EmployeeResponse>? GetAll()
    {
        var employee = unitofwork.Employees.GetAll(x => new EmployeeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Salary = x.Salary,
            IsActive = x.IsActive,
            DepartmentName = x.department.Name != null ? x.department.Name : "No Department",
        });
        //return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employee);
        return employee;
    }

    public IEnumerable<EmployeeResponse>? GetAll(string SearchValue)
    {
        var employee = unitofwork.Employees.GetAll(x => new EmployeeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Salary = x.Salary,
            IsActive = x.IsActive,
            DepartmentName = x.department.Name != null ? x.department.Name : "No Department",
        }).Where(e => e.Name.Contains(SearchValue) || e.DepartmentName.Contains(SearchValue)); //Search by Name And Department Name
        //return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employee);
        return employee;
    }

    public EmployeeDetailsResponse? GetById(int id)
    {
        var employee = unitofwork.Employees.GetById(id);
        return mapper.Map<Employee, EmployeeDetailsResponse>(employee);
    }

    public int Update(EmployeeUpdateRequest request)
    {
        var employee = mapper.Map<EmployeeUpdateRequest, Employee>(request);
        unitofwork.Employees.Update(employee);
        return unitofwork.SaveChanges();

    }
    #endregion
}
