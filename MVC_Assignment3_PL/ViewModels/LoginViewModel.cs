using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment3_PL.ViewModels;

public class LoginViewModel
{
#nullable disable
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
