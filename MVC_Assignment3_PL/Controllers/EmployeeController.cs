using System.Reflection.Emit;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Assignment3_BLL.DataTransferObjects.Employees;
using MVC_Assignment3_BLL.Services;
using MVC_Assignment3_DAL.Entities;

namespace MVC_Assignment3_PL.Controllers;

[Authorize]
public class EmployeeController(IEmployeeService employeeService,
    ILogger < EmployeeController > logger, IWebHostEnvironment env, IMapper mapper,
    IDepartmentService departmentService)
    : Controller
{
        //transfer Data
        //1. Action ==> View
        //2. View   ==> Layout
        //3. View   ==> Partial

        [HttpGet]
    public async Task<IActionResult> Index(string? SearchValue)
    {
        //Addsearch
        if(string.IsNullOrWhiteSpace(SearchValue))
            return View(await employeeService.GetAllAsync());
       
        return View(await employeeService.GetAllAsync(SearchValue));
        // Get All Employee
        //var employees = employeeService.GetAll();
        //ViewData["Hi"] = "Welcome to Employee Page";
        //ViewBag.Hi = "Welcome to Employee Page";
        //return View(employees);
    }

    #region Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var departments = await departmentService.GetAllAsync();
        var select = new SelectList(departments,"Id" , "Name");
        ViewBag.Departments = select;
        return View();
    }
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeRequest request)
    {
        //Validation
        if (!ModelState.IsValid)
            return View(request);
        try
        {
            var result = await employeeService.AddAsync(request);
                if (result > 0)
                    TempData["message"] = $"Employee {request.Name} is Created .";
                else
                    TempData["message"] = $"Employee {request.Name} is not Created .";    

            return RedirectToAction("Index");
        
            //ModelState.AddModelError(string.Empty, "Unable to Create employee");
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
    public async Task<IActionResult> Details(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var employee = await employeeService.GetByIdAsync(id.Value);
        if (employee == null)
            return NotFound();
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
    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var employee =await employeeService.GetByIdAsync(id.Value);
        if (employee == null)
            return NotFound();

        var departments = await departmentService.GetAllAsync();
        //SelectList (IEnumerable items, string dataValueField, string dataTextField, object? selectedValue);
        var select = new SelectList(departments, "Id", "Name" , employee.DepartmentId);
        ViewBag.Departments = select;
        
        return View(mapper.Map<EmployeeUpdateRequest>(employee));
        //if (!id.HasValue)
        //    return BadRequest();
        //var employee = employeeService.GetById(id.Value);
        //if (employee == null)
        //    return NotFound();
        //return View(employee);
        }
    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeUpdateRequest request)
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
            var result = await employeeService.UpdateAsync(request);
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
    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var employee = await employeeService.GetByIdAsync(id.Value);
        if(employee == null)
            return NotFound();
        
        return View(employee);
        //if (!id.HasValue)
        //    return BadRequest();
        //var employee = employeeService.GetById(id.Value);
        //if (employee == null)
        //    return NotFound();
        //return View(employee);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var employee = await employeeService.GetByIdAsync(id.Value);
        try
        {
            var IsDeleted = await employeeService.DeleteAsync(id.Value);
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
        //private (bool flowControl, IActionResult value) ValidationEmployeeIdAndFetch(int? id, out EmployeeDetailsResponse? employee)
        //{

        //    if (!id.HasValue)
        //    {
        //        employee = default;
        //        return (FlowControl: false, value: BadRequest());
        //    }
        //    employee = employeeService.GetByIdAsync(id.Value);
        //    if (employee == null)
        //        return (false, NotFound());
        //    return (true, null);
        //}
}

