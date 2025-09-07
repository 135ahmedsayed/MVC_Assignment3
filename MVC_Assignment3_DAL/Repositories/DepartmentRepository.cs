using MVC_Assignment3_DAL.Context;

namespace MVC_Assignment3_DAL.Repositories;
public class DepartmentRepository : IDepartmentRepository
{

    #region Dependency Injection
    //Context Encapsulation
    private CompanyDBContext _dBContext;
    //Generate CTOR
    public DepartmentRepository(CompanyDBContext dBContext)
    {
        _dBContext = dBContext;
    }
    #endregion

    // Get 
    // Get ALL
    // Add
    // Delete
    // Update
}
