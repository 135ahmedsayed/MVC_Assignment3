using MVC_Assignment3_BLL.DataTransferObjects.Departments;
using MVC_Assignment3_BLL.DataTransferObjects.Employees;

namespace MVC_Assignment3_BLL.Services;
public interface IEmployeeService
{
    // Get , All , Update , Delete , Add
    EmployeeDetailsResponse? GetById(int id); //get by id
    IEnumerable<EmployeeResponse>? GetAll(); //GetALL
    IEnumerable<EmployeeResponse>? GetAll(string SearchValue); //GetALL(SearchValue)
    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);
    int Add(EmployeeRequest request); //Add()
}
