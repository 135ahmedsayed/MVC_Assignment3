using MVC_Assignment3_DAL.Context;
using MVC_Assignment3_DAL.Entities;

namespace MVC_Assignment3_DAL.Repositories;
public class DepartmentRepository(CompanyDBContext dBContext) 
    : BaseRepository<Department>(dBContext),IDepartmentRepository
{

    //#region Dependency Injection
    ////Context Encapsulation
    //private CompanyDBContext _dBContext = dBContext;
    ////Generate CTOR
    ////public DepartmentRepository(CompanyDBContext dBContext)
    ////{
    ////    _dBContext = dBContext;
    ////}

    //public int Add(Department department)
    //{
    //    _dBContext.Departments.Add(department);
    //    return _dBContext.SaveChanges();
    //}

    //public int Delete(Department department)
    //{
    //    _dBContext.Departments.Remove(department);
    //    return _dBContext.SaveChanges();
    //}

    //public IEnumerable<Department> GetAll(bool trackChanges = false)
    //{
    //    return trackChanges? _dBContext.Departments.ToList()
    //        : _dBContext.Departments.AsNoTracking().ToList();
    //}

    //public Department? GetById(int id)
    //{
    //    return _dBContext.Departments.Find(id);
    //}

    //public Department? GetByName(string name)
    //{
    //    return _dBContext.Departments.FirstOrDefault(n => n.Name == name);
    //}

    //public int Update(Department department)
    //{
    //    _dBContext.Departments.Update(department);
    //    return _dBContext.SaveChanges();
    //}
    //#endregion

}
