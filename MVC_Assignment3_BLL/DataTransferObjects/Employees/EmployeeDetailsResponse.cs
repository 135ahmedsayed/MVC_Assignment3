using MVC_Assignment3_DAL.Entities.Enums;

namespace MVC_Assignment3_BLL.DataTransferObjects.Employees;
public class EmployeeDetailsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly HiringDate { get; set; }
    public Gender gender { get; set; }
    public EmployeeType employeeType { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}
