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

    public int Add(DepartmentRequest request)
    {
        //mapping 
        var department = request.ToDepartmentRequest();
        unitofwork.Departments.Add(department);
        return unitofwork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var department = unitofwork.Departments.GetById(id);
        if (department == null)
            return false;
        unitofwork.Departments.Delete(department);
        return unitofwork.SaveChanges() > 0;   

    }

    public IEnumerable<DepartmentResponse>? GetAll()
    {
        return unitofwork.Departments.GetAll()
            .Select(d => d.ToDepartmentResponse());
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        return unitofwork.Departments.GetById(id)?
            .ToDepartmentDetailsResponse();
    }

    public int Update(DepartmentUpdateRequest request)
    {
        unitofwork.Departments.Update(request.ToDepartmentRequest());
        return unitofwork.SaveChanges();

    }
    #endregion
}
