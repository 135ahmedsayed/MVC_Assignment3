using Azure.Core;
using MVC_Assignment3_BLL.DataTransferObjects.Departments;
using MVC_Assignment3_DAL.Entities;
using MVC_Assignment3_DAL.Repositories;

namespace MVC_Assignment3_BLL.Services;
public class DepartmentService(IUnitOfWork unitofwork) : IDepartmentService
{
    #region Dependency Injection
    //Repo
    //private IDepartmentRepository _unitofwork.Departments = unitofwork.Departments;

    public async Task<int> AddAsync(DepartmentRequest request)
    {
        //mapping 
        var department = request.ToDepartmentRequest();
        unitofwork.Departments.Add(department);
        return await unitofwork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await unitofwork.Departments.GetByIdAsync(id);
        if (department == null)
            return false;
        unitofwork.Departments.Delete(department);
        return await unitofwork.SaveChangesAsync() > 0;   

    }

    public async Task<IEnumerable<DepartmentResponse>?> GetAllAsync()
    {
        return (await unitofwork.Departments.GetAllAsync())
            .Select(d => d.ToDepartmentResponse());
    }

    public async Task<DepartmentDetailsResponse?> GetByIdAsync(int id)
    {
        return (await unitofwork.Departments.GetByIdAsync(id))?
            .ToDepartmentDetailsResponse();
    }

    public async Task<int> UpdateAsync(DepartmentUpdateRequest request)
    {
        unitofwork.Departments.Update(request.ToDepartmentRequest());
        return await unitofwork.SaveChangesAsync();

    }
    #endregion
}
