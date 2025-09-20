using MVC_Assignment3_BLL.DataTransferObjects.Employees;
using MVC_Assignment3_DAL.Entities;

namespace MVC_Assignment3_BLL.MappingProfiles;
public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();


        CreateMap<Employee, EmployeeResponse>();
        CreateMap<Employee, EmployeeDetailsResponse>();
        CreateMap<EmployeeDetailsResponse,EmployeeUpdateRequest>();
    }
}
