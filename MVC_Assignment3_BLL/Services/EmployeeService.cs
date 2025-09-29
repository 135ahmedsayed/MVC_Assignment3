global using AutoMapper;
global using Microsoft.EntityFrameworkCore.Metadata;
global using MVC_Assignment3_BLL.DataTransferObjects.Departments;
global using MVC_Assignment3_BLL.DataTransferObjects.Employees;
global using MVC_Assignment3_DAL.Entities;
global using MVC_Assignment3_DAL.Repositories;

namespace MVC_Assignment3_BLL.Services;

public class EmployeeService(IUnitOfWork unitofwork , IMapper mapper 
    , IDocumentService documentService) : IEmployeeService
{
    #region Dependency Injection
    //Repo
    //private IDepartmentRepository _departmentRepository = departmentRepository;

    public async Task<int> AddAsync(EmployeeRequest request)
    {
        //mapping t==> Auto Mapper 
        //mapper.Map<Source,Destination>();
        var employee = mapper.Map<EmployeeRequest,Employee>(request);
        //Upload File
        if (request.ImageFile != null && request.ImageFile.Length > 0)
        {
            var fileName = await documentService.UploadAsync(request.ImageFile, "Images");
            employee.Image = fileName;
        }
        //
        unitofwork.Employees.Add(employee);
        return await unitofwork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await unitofwork.Employees.GetByIdAsync(id);
        if (employee == null)
            return false;
        unitofwork.Employees.Delete(employee);
        
        //delete image
        var result = await unitofwork.SaveChangesAsync();
        if (result > 0 && employee.Image != null)
        {
            documentService.Delete(employee.Image, "Images");
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<EmployeeResponse>?> GetAllAsync()
    {
        var employee = await unitofwork.Employees.GetAllAsync(x => new EmployeeResponse
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

    public async Task<IEnumerable<EmployeeResponse>?> GetAllAsync(string SearchValue)
    {
        var employee = (await unitofwork.Employees.GetAllAsync(x => new EmployeeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Salary = x.Salary,
            IsActive = x.IsActive,
            DepartmentName = x.department.Name != null ? x.department.Name : "No Department",
        })).Where(e => e.Name.Contains(SearchValue) || e.DepartmentName.Contains(SearchValue)); //Search by Name And Department Name
        //return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employee);
        return employee;
    }

    public async Task<EmployeeDetailsResponse?> GetByIdAsync(int id)
    {
        var employee = await unitofwork.Employees.GetByIdAsync(id);
        return mapper.Map<Employee, EmployeeDetailsResponse>(employee);
    }

    public async Task<int> UpdateAsync(EmployeeUpdateRequest request)
    {
        var employee = mapper.Map<EmployeeUpdateRequest, Employee>(request);
        unitofwork.Employees.Update(employee);
        return await unitofwork.SaveChangesAsync();

    }
    #endregion
}
