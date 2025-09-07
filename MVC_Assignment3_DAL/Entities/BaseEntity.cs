namespace MVC_Assignment3_DAL.Entities;

public class BaseEntity
{
    public int Id { get; set; } //PK
    public bool IsDeleted { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateOn { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}
