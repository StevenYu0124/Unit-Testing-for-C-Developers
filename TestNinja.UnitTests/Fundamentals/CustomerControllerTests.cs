namespace TestNinja.UnitTests.Fundamentals;

public class CustomerControllerTests
{
    [Test]
    public void GetCustomer_GivenIdNot0_ReturnOk()
    {
        // arrange
        var controller = new CustomerController();

        // act
        var actual = controller.GetCustomer(5);

        // assert
        Assert.That(actual, Is.TypeOf<Ok>());
    }

    [Test]
    public void GetCustomer_GivenId0_ReturnNotFound()
    {
        // arrange
        var controller = new CustomerController();

        // act
        var actual = controller.GetCustomer(0);

        // assert
        Assert.That(actual, Is.TypeOf<NotFound>());
    }
}