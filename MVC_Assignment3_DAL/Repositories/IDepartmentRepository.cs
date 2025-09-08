namespace MVC_Assignment3_DAL.Repositories;
public interface IDepartmentRepository
{
    IEnumerable<Department> GetAll(bool trackChanges = false);
    Department? GetById(int id);
    Department? GetByName(string name);
    int Add(Department department);
    int Update(Department department);
    int Delete(Department department);

}
