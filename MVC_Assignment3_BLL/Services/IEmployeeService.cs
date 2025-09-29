using MVC_Assignment3_BLL.DataTransferObjects.Departments;
using MVC_Assignment3_BLL.DataTransferObjects.Employees;

namespace MVC_Assignment3_BLL.Services;
public interface IEmployeeService
{
    // Get , All , Update , Delete , Add
    Task<EmployeeDetailsResponse?> GetByIdAsync(int id); //get by id
    Task<IEnumerable<EmployeeResponse>?> GetAllAsync(); //GetALL
    Task<IEnumerable<EmployeeResponse>?> GetAllAsync(string SearchValue); //GetALL(SearchValue)
    Task<int> UpdateAsync(EmployeeUpdateRequest request);
    Task<bool> DeleteAsync(int id);
    Task<int> AddAsync(EmployeeRequest request); //Add()
}
