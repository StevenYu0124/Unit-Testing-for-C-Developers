namespace TestNinja.UnitTests.Fundamentals;

public class DemeritPointsCalculatorTests
{
    [TestCase(-1)]
    [TestCase(301)]
    public void CalculateDemeritPoints_GivenInvalidSpeed_ThrowsArgumentOutOfRangeException(int speed)
    {
        // arrange
        var demeritPointsCalculator = new DemeritPointsCalculator();

        // act & assert
        Assert.That(
            () => demeritPointsCalculator.CalculateDemeritPoints(speed),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(0)]
    [TestCase(65)]
    public void CalculateDemeritPoints_GivenSpeedUnderSpeedLimit_Return0(
        int speed
    )
    {
        // arrange
        var demeritPointsCalculator = new DemeritPointsCalculator();

        // act
        var actual = demeritPointsCalculator.CalculateDemeritPoints(speed);

        // assert
        Assert.That(actual, Is.Zero);
    }

    [TestCase(66, 0)]
    [TestCase(69, 0)]
    [TestCase(70, 1)]
    [TestCase(73, 1)]
    [TestCase(75, 2)]
    [TestCase(300, 47)]
    public void CalculateDemeritPoints_GivenSpeedAboveSpeedLimit_ReturnDemeritPoint(
        int speed,
        int expectedPoint
    )
    {
        // arrange
        var demeritPointsCalculator = new DemeritPointsCalculator();

        // act
        var actual = demeritPointsCalculator.CalculateDemeritPoints(speed);

        // assert
        Assert.That(actual, Is.EqualTo(expectedPoint));
    }
}