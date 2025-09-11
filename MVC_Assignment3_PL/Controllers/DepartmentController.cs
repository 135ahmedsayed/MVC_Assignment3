using Microsoft.AspNetCore.Mvc;
using MVC_Assignment3_BLL.Services;

namespace MVC_Assignment3_PL.Controllers;
public class DepartmentController(IDepartmentService departmentService) : Controller
{
    #region Dependency Injection
    // Service
    
    #endregion

    public IActionResult Index()
    {
        // Get All Department
        var departments = departmentService.GetAll();
        return View(departments);
    }
}
