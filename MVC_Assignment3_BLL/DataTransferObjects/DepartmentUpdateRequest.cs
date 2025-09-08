namespace MVC_Assignment3_BLL.DataTransferObjects;
public class DepartmentUpdateRequest
{
    public int Id { get; set; } //PK
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CraetedAt { get; set; } //user Input
}
