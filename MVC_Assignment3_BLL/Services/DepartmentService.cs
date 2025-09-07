using MVC_Assignment3_DAL.Repositories;

namespace MVC_Assignment3_BLL.Services;
public class DepartmentService : IDepartmentService
{
    #region Dependency Injection
    //Repo
    private IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    #endregion
}
