namespace MVC_Assignment3_BLL.DataTransferObjects;
public class DepartmentRequest // Add()
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CraetedAt { get; set; } //user Input
}
