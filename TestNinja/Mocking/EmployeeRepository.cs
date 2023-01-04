namespace TestNinja.Mocking;

public class EmployeeRepository : IEmployeeRepository
{
    private EmployeeContext _db;

    public EmployeeRepository()
    {
        _db = new EmployeeContext();
    }
    public Employee? RemoveById(int id)
    {
        var employee = _db.Employees.Find(id);
        if (employee != null)
        {
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
        return employee;
    }

    public void SaveChanges()
    {
        _db.SaveChanges();
    }
}