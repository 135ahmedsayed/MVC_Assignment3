using MVC_Assignment3_BLL.DataTransferObjects;

namespace MVC_Assignment3_BLL.Services;
public interface IDepartmentService
{
    DepartmentDetailsResponse? GetById(int id); //get by id
    IEnumerable<DepartmentResponse>? GetAll(); //GetALL
    int Update(DepartmentUpdateRequest request);
    int Delete(int id);
    int Add(DepartmentRequest request); //Add()
}
