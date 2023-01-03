namespace TestNinja.UnitTests.Fundamentals;

public class ErrorLoggerTests
{
    [Test]
    public void Log_GivenString_UpdateLastError()
    {
        // arrange
        var errorLogger = new ErrorLogger();
        var errorMessage = "test error";

        // act
        errorLogger.Log(errorMessage);

        // assert
        Assert.That(errorLogger.LastError, Is.EqualTo(errorMessage));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Log_InvalidError_ThrowArgumentNullException(string? error)
    {
        // arrange
        var errorLogger = new ErrorLogger();

        // act & assert
        Assert.That(() => errorLogger.Log(error), Throws.ArgumentNullException);
    }

    [Test]
    public void Log_WhenCalled_InvokeErrorLoggedEvent()
    {
        // arrange
        var errorLogger = new ErrorLogger();
        var id = Guid.Empty;
        errorLogger.ErrorLogged += (sender, args) => id = args;

        // act
        errorLogger.Log("a");

        // assert
        Assert.That(id, Is.Not.EqualTo(Guid.Empty));
    }
}