namespace MVC_Assignment3_DAL.Entities;
public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CraetedAt { get; set; } //user Input
    //Relation
    public ICollection<Employee> Employees { get; set; } = [];
}
