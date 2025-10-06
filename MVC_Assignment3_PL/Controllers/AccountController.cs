using Microsoft.AspNetCore.Identity;
using MVC_Assignment3_DAL.Entities;

namespace MVC_Assignment3_PL.Controllers;

public class AccountController(UserManager<ApplicationUser> UserManager)
    : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
}
