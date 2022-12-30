namespace TestNinja.UnitTests;

public class FizzBuzzTests
{
    [TestCase(15)]
    [TestCase(30)]
    [TestCase(45)]
    public void GetOutput_GivenMultipleOf3And5_ReturnFizzBuzz(int number)
    {
        // act
        var actual = FizzBuzz.GetOutput(number);

        // assert
        Assert.That(actual, Is.EqualTo("FizzBuzz"));
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    public void GetOutput_GivenMultipleOf3_ReturnFizz(int number)
    {
        // act
        var actual = FizzBuzz.GetOutput(number);

        // assert
        Assert.That(actual, Is.EqualTo("Fizz"));
    }

    [TestCase(5)]
    [TestCase(10)]
    [TestCase(20)]
    public void GetOutput_GivenMultipleOf5_ReturnBuzz(int number)
    {
        // act
        var actual = FizzBuzz.GetOutput(number);

        // assert
        Assert.That(actual, Is.EqualTo("Buzz"));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(4)]
    public void GetOutput_GivenNotMultipleOf3And5_ReturnSameNumber(int number)
    {
        // act
        var actual = FizzBuzz.GetOutput(number);

        // assert
        Assert.That(actual, Is.EqualTo(number.ToString()));
    }
}