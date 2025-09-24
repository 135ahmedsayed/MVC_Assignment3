using System.ComponentModel.DataAnnotations;
using MVC_Assignment3_DAL.Entities.Enums;

namespace MVC_Assignment3_BLL.DataTransferObjects.Employees;
public class EmployeeResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? Age { get; set; }
    [DataType(DataType.Currency)]  //10,000$
    public decimal Salary { get; set; }
    [Display(Name = "is Active")]
    public bool IsActive { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string gender { get; set; }
    [Display(Name = "Employee Type")]
    public string employeeType { get; set; }
    [Display(Name = "Department")]
    public string? DepartmentName { get; set; }

}
