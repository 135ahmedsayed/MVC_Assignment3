using System.ComponentModel.DataAnnotations;
using MVC_Assignment3_DAL.Entities.Enums;

namespace MVC_Assignment3_BLL.DataTransferObjects.Employees;
public class EmployeeUpdateRequest
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
    [MinLength(5, ErrorMessage = "Min length should be 5 character")]
    public string Name { get; set; } = null!;
    [Range(22, 30)]
    public int? Age { get; set; }
    //[RegularExpression("^[1 - 9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
    //    ErrorMessage ="Address must be like 123-street-City-Country")]
    public string? Address { get; set; }
    [DataType(DataType.Currency)]  //10,000$
    public decimal Salary { get; set; }
    [Display(Name = "is Active")]
    public bool IsActive { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Phone]
    public string? Phone { get; set; }
    [Display(Name = "Hiring Date")]
    public DateOnly HiringDate { get; set; }
    public Gender gender { get; set; }
    public EmployeeType employeeType { get; set; }
}
