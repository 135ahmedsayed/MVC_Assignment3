global using MVC_Assignment3_DAL.Entities.Enums;

namespace MVC_Assignment3_DAL.Entities;
public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public int? Age { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly HiringDate { get; set; }
    public string? Position { get; set; }
    public Gender gender { get; set; }
    public EmployeeType employeeType { get; set; }
    //Relation
    public Department department { get; set; } 
    public int? DepartmentId { get; set; } //FK
}
