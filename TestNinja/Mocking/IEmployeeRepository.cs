namespace TestNinja.Mocking;

public interface IEmployeeRepository
{
    Employee? RemoveById(int id);
    void SaveChanges();
}