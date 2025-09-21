global using AutoMapper;
global using Microsoft.EntityFrameworkCore.Metadata;
global using MVC_Assignment3_BLL.DataTransferObjects.Departments;
global using MVC_Assignment3_BLL.DataTransferObjects.Employees;
global using MVC_Assignment3_DAL.Entities;
global using MVC_Assignment3_DAL.Repositories;

namespace MVC_Assignment3_BLL.Services;

public class EmployeeService(IEmployeeRepository employeeRepository , IMapper mapper) : IEmployeeService
{
    #region Dependency Injection
    //Repo
    //private IDepartmentRepository _departmentRepository = departmentRepository;

    public int Add(EmployeeRequest request)
    {
        //mapping t==> Auto Mapper 
        //mapper.Map<Source,Destination>();
        var employee = mapper.Map<EmployeeRequest,Employee>(request);
        return employeeRepository.Add(employee);
    }

    public bool Delete(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
            return false;
        var result = employeeRepository.Delete(employee);
        return result > 0;

    }

    public IEnumerable<EmployeeResponse>? GetAll()
    {
        var employee = employeeRepository.GetAll(x => new EmployeeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Salary = x.Salary,
            IsActive = x.IsActive,
        });
        //return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employee);
        return employee;
    }

    public EmployeeDetailsResponse? GetById(int id)
    {
        var employee = employeeRepository.GetById(id);
        return mapper.Map<Employee, EmployeeDetailsResponse>(employee);
    }

    public int Update(EmployeeUpdateRequest request)
    {
        var employee = mapper.Map<EmployeeUpdateRequest, Employee>(request);
        return employeeRepository.Update(employee);

    }
    #endregion
}
