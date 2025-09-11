using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment3_BLL.DataTransferObjects;
public class DepartmentRequest // Add()
{
    public string Name { get; set; } = null!;
    [Required(ErrorMessage ="Code is required")]
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } //user Input
}
