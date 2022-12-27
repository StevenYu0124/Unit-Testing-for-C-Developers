#nullable disable
namespace TestNinja.UnitTests;

public class MathTests
{
    private Math _math;

    [SetUp]
    public void SetUp()
    {
        _math = new Math();
    }

    [Test]
    public void Add_WhenCalled_ReturnTheSumofArguments()
    {
        // arrange
        var expected = 5;

        // act
        var actual = _math.Add(2, 3);

        // assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(3, 2, 3)]
    [TestCase(1, 7, 7)]
    [TestCase(5, 5, 5)]
    public void Max_WhenCalled_ReturnGreaterArgument(
        int x,
        int y,
        int expected
    )
    {
        // act
        var actual = _math.Max(x, y);

        // assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}