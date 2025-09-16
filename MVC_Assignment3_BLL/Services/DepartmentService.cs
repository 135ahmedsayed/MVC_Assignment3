using Azure.Core;
using MVC_Assignment3_BLL.DataTransferObjects;
using MVC_Assignment3_DAL.Entities;
using MVC_Assignment3_DAL.Repositories;

namespace MVC_Assignment3_BLL.Services;
public class DepartmentService(IRepository<Department> departmentRepository) : IDepartmentService
{
    #region Dependency Injection
    //Repo
    //private IDepartmentRepository _departmentRepository = departmentRepository;

    public int Add(DepartmentRequest request)
    {
        //mapping 
        var department = request.ToDepartmentRequest();
        return departmentRepository.Add(department);
    }

    public bool Delete(int id)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
            return false;
        var result = departmentRepository.Delete(department);
        return result > 0;   

    }

    public IEnumerable<DepartmentResponse>? GetAll()
    {
        return departmentRepository.GetAll()
            .Select(d => d.ToDepartmentResponse());
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        return departmentRepository.GetById(id)?
            .ToDepartmentDetailsResponse();
    }

    public int Update(DepartmentUpdateRequest request)
    {
        return departmentRepository.Update(request.ToDepartmentRequest());
           
    }
    #endregion
}
