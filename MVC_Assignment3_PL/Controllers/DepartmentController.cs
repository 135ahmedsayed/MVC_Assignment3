using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignment3_BLL.DataTransferObjects;
using MVC_Assignment3_BLL.Services;

namespace MVC_Assignment3_PL.Controllers;
public class DepartmentController(IDepartmentService departmentService,
    ILogger<DepartmentController> logger , IWebHostEnvironment env) 
    : Controller
{
    #region Dependency Injection
    // Service

    #endregion
    [HttpGet]
    public IActionResult Index()
    {
        // Get All Department
        var departments = departmentService.GetAll();
        return View(departments);
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(DepartmentRequest request)
    {
        //Validation
        if(!ModelState.IsValid)
            return View(request);
        try
        {
            var result = departmentService.Add(request);
            if (result > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, "Unable to Create department");
        }
        catch (Exception ex)
        {
            if(env.IsDevelopment())
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
        if(!id.HasValue)
            return BadRequest();
        var department = departmentService.GetById(id.Value);
        if (department == null)
            return NotFound();
        return View(department);
    }
    #endregion

    #region Edit
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = departmentService.GetById(id.Value);
        if (department == null)
            return NotFound();
        return View(department.UpdateDepartment());
    }
    [HttpPost]
    public IActionResult Edit([FromRoute]int? id , DepartmentUpdateRequest request)
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
            var result = departmentService.Update(request);
            if (result > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, "Unable to Create department");
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
        if (!id.HasValue)
            return BadRequest();
        var department = departmentService.GetById(id.Value);
        if (department == null)
            return NotFound();
        return View(department);
    }
    [HttpPost ,ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = departmentService.GetById(id.Value);
        try
        {
            var IsDeleted = departmentService.Delete(id.Value);
            if (IsDeleted)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "Unable to Create department");
        }
        catch (Exception ex)
        {
            if (env.IsDevelopment())
                ModelState.AddModelError(string.Empty, ex.Message);
            else
                logger.LogError("Something is Wrong", ex.Message);
        }
        return View(department);
    }
    #endregion
}
