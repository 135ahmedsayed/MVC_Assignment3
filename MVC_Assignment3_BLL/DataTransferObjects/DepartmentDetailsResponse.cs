namespace MVC_Assignment3_BLL.DataTransferObjects;
public class DepartmentDetailsResponse //get by id
{
    public int Id { get; set; } //PK
    public bool IsDeleted { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateOn { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CraetedAt { get; set; } //user Input
}
