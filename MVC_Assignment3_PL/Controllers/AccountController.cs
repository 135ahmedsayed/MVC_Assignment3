using Microsoft.AspNetCore.Identity;
using MVC_Assignment3_DAL.Entities;
using MVC_Assignment3_PL.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Assignment3_PL.Controllers;

public class AccountController(UserManager<ApplicationUser> UserManager ,
    SignInManager<ApplicationUser> manager)
    : Controller
{
    #region Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        //server side validation
        if (!ModelState.IsValid)
            return View(registerViewModel);
        var user = new ApplicationUser
        {
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            UserName = registerViewModel.UserName,
            Email = registerViewModel.Email
        };
        // compare password and confirm password
        var result = await UserManager.CreateAsync(user , registerViewModel.Password);
        if (result.Succeeded)
            return RedirectToAction("Login");
        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(registerViewModel);
    }
    #endregion

    #region Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        //server side validation
        if (!ModelState.IsValid)
            return View(loginViewModel);
        //Compare email and password
        var user = await UserManager.FindByEmailAsync(loginViewModel.Email);
        if (user != null)
        {
            var isCorrect = await UserManager.CheckPasswordAsync(user, loginViewModel.Password);
            if (isCorrect)
            {
                var result = await manager.PasswordSignInAsync(user, loginViewModel.Password, 
                    loginViewModel.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError(string.Empty, "Invalid Email And Password");
        return View(loginViewModel);
    }
    #endregion
}
