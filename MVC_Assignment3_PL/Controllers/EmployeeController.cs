using System.Reflection.Emit;
using AutoMapper;
using MVC_Assignment3_BLL.DataTransferObjects.Employees;
using MVC_Assignment3_BLL.Services;
using MVC_Assignment3_DAL.Entities;

namespace MVC_Assignment3_PL.Controllers;

public class EmployeeController(IEmployeeService employeeService,
    ILogger < EmployeeController > logger, IWebHostEnvironment env, IMapper mapper)
    : Controller
{
    #region Dependency Injection
    // Service

    #endregion
    [HttpGet]
public IActionResult Index()
{
    // Get All Employee
    var employees = employeeService.GetAll();
    return View(employees);
}

#region Create
[HttpGet]
public IActionResult Create()
{
    return View();
}
[HttpPost]
public IActionResult Create(EmployeeRequest request)
{
    //Validation
    if (!ModelState.IsValid)
        return View(request);
    try
    {
        var result = employeeService.Add(request);
        if (result > 0)
            return RedirectToAction("Index");
        ModelState.AddModelError(string.Empty, "Unable to Create employee");
    }
    catch (Exception ex)
    {
        if (env.IsDevelopment())
            ModelState.AddModelError(string.Empty, ex.Message);
        else
            logger.LogError("Something is Wrong", ex.Message);
    }
    return View(request);
}
#endregion

#region Details
[HttpGet]
public IActionResult Details(int? id)
{
    EmployeeDetailsResponse? employee ;
        (bool flowControl, IActionResult value) = ValidationEmployeeIdAndFetch(id, out employee);
        if (!flowControl)
            return value;
        return View(employee);
        //if (!id.HasValue)
        //    return BadRequest();
        //var employee = employeeService.GetById(id.Value);
        //if (employee == null)
        //    return NotFound();
        //return View(employee);
    }
#endregion

#region Edit
[HttpGet]
public IActionResult Edit(int? id)
{
        EmployeeDetailsResponse? employee;
        (bool flowControl, IActionResult value) = ValidationEmployeeIdAndFetch(id, out employee);
        if (!flowControl)
            return value;
        return View(mapper.Map<EmployeeUpdateRequest>(employee));
        //if (!id.HasValue)
        //    return BadRequest();
        //var employee = employeeService.GetById(id.Value);
        //if (employee == null)
        //    return NotFound();
        //return View(employee);
    }
[HttpPost]
public IActionResult Edit([FromRoute] int? id, EmployeeUpdateRequest request)
{
    //Validation
    if (!id.HasValue)
        return BadRequest();
    if (id.Value != request.Id)
        return BadRequest();
    if (!ModelState.IsValid)
        return View(request);
    try
    {
        var result = employeeService.Update(request);
        if (result > 0)
            return RedirectToAction("Index");
        ModelState.AddModelError(string.Empty, "Unable to Create employee");
    }
    catch (Exception ex)
    {
        if (env.IsDevelopment())
            ModelState.AddModelError(string.Empty, ex.Message);
        else
            logger.LogError("Something is Wrong", ex.Message);
    }
    return View(request);
}
#endregion

#region Delete
[HttpGet]
public IActionResult Delete(int? id)
{
        EmployeeDetailsResponse? employee;
        (bool flowControl, IActionResult value) = ValidationEmployeeIdAndFetch(id, out employee);
        if (!flowControl)
            return value;
        return View(employee);
        //if (!id.HasValue)
        //    return BadRequest();
        //var employee = employeeService.GetById(id.Value);
        //if (employee == null)
        //    return NotFound();
        //return View(employee);
    }
[HttpPost, ActionName("Delete")]
public IActionResult ConfirmDelete(int? id)
{
    if (!id.HasValue)
        return BadRequest();
    var employee = employeeService.GetById(id.Value);
    try
    {
        var IsDeleted = employeeService.Delete(id.Value);
        if (IsDeleted)
            return RedirectToAction(nameof(Index));
        ModelState.AddModelError(string.Empty, "Unable to Create employee");
    }
    catch (Exception ex)
    {
        if (env.IsDevelopment())
            ModelState.AddModelError(string.Empty, ex.Message);
        else
            logger.LogError("Something is Wrong", ex.Message);
    }
    return View(employee);
}
    #endregion

//helper
    private (bool flowControl, IActionResult value) ValidationEmployeeIdAndFetch(int? id, out EmployeeDetailsResponse? employee)
    {

        if (!id.HasValue)
        {
            employee = default;
            return (FlowControl: false, value: BadRequest());
        }
        employee = employeeService.GetById(id.Value);
        if (employee == null)
            return (false, NotFound());
        return (true, null);
    }
}

