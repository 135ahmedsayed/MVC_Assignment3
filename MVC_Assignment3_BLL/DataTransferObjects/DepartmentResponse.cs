namespace MVC_Assignment3_BLL.DataTransferObjects;
public class DepartmentResponse // GetAll
{
    public int Id { get; set; } //PK
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly CraetedAt { get; set; } //user Input
}
