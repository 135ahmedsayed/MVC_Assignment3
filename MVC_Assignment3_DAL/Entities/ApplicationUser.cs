using Microsoft.AspNetCore.Identity;

namespace MVC_Assignment3_DAL.Entities;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }=default!;
    public string LastName { get; set; } = default!;

}
