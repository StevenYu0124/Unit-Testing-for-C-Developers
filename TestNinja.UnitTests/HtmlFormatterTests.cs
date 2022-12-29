namespace TestNinja.UnitTests;

public class HtmlFormatterTests
{
    [Test]
    public void FormatAsBold_WhenGivenString_ReturnWrappedWithBoldTagString()
    {
        var htmlFormatter = new HtmlFormatter();

        // act
        var actual = htmlFormatter.FormatAsBold("test");

        // assert
        Assert.That(actual, Is.EqualTo("<strong>test</strong>"));
    }
}