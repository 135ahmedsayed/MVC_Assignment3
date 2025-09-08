using MVC_Assignment3_DAL.Entities;

namespace MVC_Assignment3_BLL.DataTransferObjects;
internal static class DepartmentFactory
{
    public static Department ToDepartmentRequest(this DepartmentRequest department)
    {
        return new ()
        {
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CraetedAt = department.CraetedAt,
        };
    }

    public static DepartmentResponse ToDepartmentResponse(this Department department)
    {
        return new()
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CraetedAt = DateOnly.FromDateTime(department.CreateOn),
        };
    }
    public static DepartmentDetailsResponse ToDepartmentDetailsResponse(this Department department)
    {
        return new()
        {
            Id = department.Id,
            IsDeleted = department.IsDeleted,
            CreateBy = department.CreateBy,
            CreateOn = department.CreateOn,
            LastModifiedBy = department.LastModifiedBy,
            LastModifiedOn = department.LastModifiedOn,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CraetedAt = department.CraetedAt,
        };
    }
    public static Department UpdateDepartment(this DepartmentUpdateRequest request)
    {
        return new()
        {
            Id = request.Id,
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            CraetedAt = request.CraetedAt,
        };
    }
}
