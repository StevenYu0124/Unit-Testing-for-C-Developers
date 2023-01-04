namespace TestNinja.UnitTests.Mocking;

public class EmployeeControllerTests
{
    [Test]
    public void DeleteEmployee_GivenId_DeleteFromDb()
    {
        // arrange
        var employeeRepository = new Mock<IEmployeeRepository>();
        var employeeController = new EmployeeController(
            employeeRepository.Object
        );

        // act
        employeeController.DeleteEmployee(1);

        // assert
        employeeRepository.Verify(x => x.RemoveById(1));
        employeeRepository.Verify(x => x.SaveChanges());
    }

    [Test]
    public void DeleteEmployee_GivenId_ReturnRedirectResult()
    {
        // arrange
        var employeeRepository = new Mock<IEmployeeRepository>();
        var employeeController = new EmployeeController(
            employeeRepository.Object
        );

        // act
        var actual = employeeController.DeleteEmployee(1);

        // assert
        Assert.That(actual, Is.TypeOf<RedirectResult>());
    }
}