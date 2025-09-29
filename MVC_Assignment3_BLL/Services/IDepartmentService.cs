using MVC_Assignment3_BLL.DataTransferObjects.Departments;

namespace MVC_Assignment3_BLL.Services;
public interface IDepartmentService
{
    Task<DepartmentDetailsResponse?> GetByIdAsync(int id); //get by id
    Task<IEnumerable<DepartmentResponse>?> GetAllAsync(); //GetALL
    Task<int> UpdateAsync(DepartmentUpdateRequest request);
    Task<bool> DeleteAsync(int id);
    Task<int> AddAsync(DepartmentRequest request); //Add()
}
