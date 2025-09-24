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

        // map item from another table (department) to EmployeeDetailsResponse
        CreateMap<Employee, EmployeeDetailsResponse>()
            .ForMember(d => d.DepartmentName,
            o => o.MapFrom(s => s.department.Name));

        CreateMap<EmployeeDetailsResponse,EmployeeUpdateRequest>();
        CreateMap<EmployeeUpdateRequest, EmployeeRequest>();
    }
}
