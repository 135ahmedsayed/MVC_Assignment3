using Microsoft.AspNetCore.Mvc;
using MVC_Assignment3_BLL.Services;

namespace MVC_Assignment3_PL.Controllers;
public class DepartmentController : Controller
{
    #region Dependency Injection
    // Service
    private IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    #endregion

    public IActionResult Index()
    {
        // Get All Department
        return View();
    }
}
